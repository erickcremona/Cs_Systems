using CrossCutting;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.WindowsAguarde;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cs_Gerencial.Windows
{
    /// <summary>
    /// Interaction logic for CadastroIndisponibilidade.xaml
    /// </summary>
    public partial class CadastroIndisponibilidade : Window
    {
        public Usuario _usuario;

        private readonly IAppServicoIndisponibilidades _AppServicoIndisponibilidades = BootStrap.Container.GetInstance<IAppServicoIndisponibilidades>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();

        List<string> tiposConsulta = new List<string>();

        LogSistema logSistema;

        public IEnumerable<Indisponibilidades> _indisponibilidades;

        public CadastroIndisponibilidade(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tiposConsulta.Add("NOME");
            tiposConsulta.Add("CPF/CNPJ");
            tiposConsulta.Add("PROTOCOLO");
            tiposConsulta.Add("Nº PROCESSO");

            cmbTipoConsulta.ItemsSource = tiposConsulta;
            cmbTipoConsulta.SelectedIndex = 0;

            _indisponibilidades = _AppServicoIndisponibilidades.GetAll();

            lblQtdRegistros.Content = CarregarGrid();

            if (dataGrid1.Items.Count > 0)
                dataGrid1.SelectedIndex = 0;


        }

        private void btnImportar_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

            openFileDialog1.Filter = "Arquivos xml (*.xml)|*.xml";

            openFileDialog1.InitialDirectory = _AppServicoParametros.GetAll().FirstOrDefault().PathSelosCenib;
            List<Indisponibilidades> existentes;

            try
            {
                if (openFileDialog1.ShowDialog() == true)
                {

                    FileInfo fi = new FileInfo(openFileDialog1.FileName);


                    string ordem = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Xsd\ordem.xsd";

                    ValidadorSchemaXml.Validar(fi.FullName, ordem);


                    IEnumerable<Indisponibilidades> indisp = _AppServicoIndisponibilidades.LerArquivoXml(openFileDialog1.FileName);
                    existentes = _AppServicoIndisponibilidades.ObterArquivosImportados(string.Format("{0}_{1}", fi.Name, fi.LastWriteTime)).ToList();
                    if (existentes.Count() == 0)
                    {
                        AguardeIndisponibilidade aguardeIndisp = new AguardeIndisponibilidade(indisp.ToList(), openFileDialog1.FileName, existentes, _usuario);
                        aguardeIndisp.Owner = this;
                        aguardeIndisp.ShowDialog();
                        
                    }
                    else
                    {
                        if (MessageBox.Show("Você está tentando importar um arquivo já importado anteriormente, deseja importar novamente?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            AguardeIndisponibilidade aguardeIndisp = new AguardeIndisponibilidade(indisp.ToList(), openFileDialog1.FileName, existentes, _usuario);
                            aguardeIndisp.Owner = this;
                            aguardeIndisp.ShowDialog();

                        }
                    }
                }

                _indisponibilidades = _AppServicoIndisponibilidades.GetAll();

                lblQtdRegistros.Content = CarregarGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void txtConsulta_TextChanged(object sender, TextChangedEventArgs e)
        {

            switch (cmbTipoConsulta.Text)
            {
                case "NOME":
                    _indisponibilidades = _AppServicoIndisponibilidades.ObterIndisponibilidadesPorNome(txtConsulta.Text);
                    break;
                case "CPF/CNPJ":
                    _indisponibilidades = _AppServicoIndisponibilidades.ObterIndisponibilidadesCpfCnpj(txtConsulta.Text);
                    break;
                case "PROTOCOLO":
                    _indisponibilidades = _AppServicoIndisponibilidades.ObterIndisponibilidadesProtocolo(txtConsulta.Text);
                    break;
                case "Nº PROCESSO":
                    _indisponibilidades = _AppServicoIndisponibilidades.ObterIndisponibilidadesNumeroProcesso(txtConsulta.Text);
                    break;
            }


            lblQtdRegistros.Content = CarregarGrid();



        }

        private string CarregarGrid()
        {
            dataGrid1.ItemsSource = _indisponibilidades;
            dataGrid1.Items.Refresh();

            return string.Format("Quantidade de registros encontrados: {0}", _indisponibilidades.Count());
        }

        private void txtConsulta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key;

            switch (cmbTipoConsulta.Text)
            {
                case "CPF/CNPJ":
                    key = (int)e.Key;
                    e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 144 || key == 148 || key == 143 || key == 87 || key == 147 || key == 89 || key == 23 || key == 25 || key == 32);
                    break;               
                case "Nº PROCESSO":
                    key = (int)e.Key;
                    e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 144 || key == 148 || key == 23 || key == 25 || key == 32);
                    break;
                default:
                    break;
            }
        }

        private void cmbTipoConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtConsulta.Text = "";
            txtConsulta.Focus();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid1.SelectedIndex > 0)
            {
                try
                {
                    Indisponibilidades indispExcluir = (Indisponibilidades)dataGrid1.SelectedItem;
                    if (MessageBox.Show("Deseja realmente excluir " + indispExcluir.NomeIndividuo + "?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        _AppServicoIndisponibilidades.Remove(indispExcluir);
                        List<Indisponibilidades> listaAux = _indisponibilidades.ToList();
                        listaAux.Remove(indispExcluir);
                        _indisponibilidades = listaAux;
                        lblQtdRegistros.Content = CarregarGrid();
                        SalvarLogSistema("Excluiu o registro " + indispExcluir.NomeIndividuo);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecione um registro.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Indisponibilidade";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            AdicionarAlterarIndisponibolidade novoRegistro = new AdicionarAlterarIndisponibolidade(this);
            novoRegistro.Owner = this;
            novoRegistro.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            novoRegistro.WindowState = WindowState.Normal;
            novoRegistro.WindowStyle = WindowStyle.SingleBorderWindow;
            novoRegistro.ResizeMode = ResizeMode.NoResize;
            novoRegistro.ShowInTaskbar = false;
            novoRegistro.Title = "Adicionar Indisponibilidade";
            novoRegistro.ShowDialog();
            CarregarGrid();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            ProcedimentoAlterar();
        }
       
        private void ProcedimentoAlterar()
        {
            if (dataGrid1.Items.Count > 0)
            {
                if (dataGrid1.SelectedIndex > -1)
                {
                    AdicionarAlterarIndisponibolidade alterarRegistro = new AdicionarAlterarIndisponibolidade(this);
                    alterarRegistro.Owner = this;
                    alterarRegistro.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    alterarRegistro.WindowState = WindowState.Normal;
                    alterarRegistro.WindowStyle = WindowStyle.SingleBorderWindow;
                    alterarRegistro.ResizeMode = ResizeMode.NoResize;
                    alterarRegistro.ShowInTaskbar = false;
                    alterarRegistro.Title = "Alterar Indisponibilidade";
                    alterarRegistro.ShowDialog();

                    CarregarGrid();
                }
                else
                {
                    MessageBox.Show("Por favor selecione um registro.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcedimentoAlterar();
        }

        
    }
}
