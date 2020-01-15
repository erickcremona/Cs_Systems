using CrossCutting;
using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;

namespace Cs_IssPrefeitura
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private readonly IAppServicoAtoIss _appServicoAtoIss = BootStrap.Container.GetInstance<IAppServicoAtoIss>();
        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();
        Usuario _usuario;
        Config _config;

        public Principal(Usuario usuario, Config config)
        {
            _usuario = usuario;
            _config = config;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _config = _AppServicoConfiguracoes.GetById(1);
            lblNomeCartorio.Content = _config.RazaoSocial;
            lblNomeUsuario.Content = string.Format("Usuário: {0}", _usuario.Nome);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemConsultaAtos_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemConsultaAtos.Foreground = Brushes.Black;
        }

        private void MenuItemConsultaAtos_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemConsultaAtos.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemConsultaAtos_Click(object sender, RoutedEventArgs e)
        {


            //var importarBase = new AguardeImportarBaseDados();
            //importarBase.Owner = this;
            //importarBase.ShowDialog();

        }

        private void MenuItemImportarAtos_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemImportarAtos.Foreground = Brushes.Black;
        }

        private void MenuItemImportarAtos_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemImportarAtos.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemImportarAtos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemFechamentoMes_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemFechamentoMes.Foreground = Brushes.Black;
        }

        private void MenuItemFechamentoMes_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemFechamentoMes.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemFechamentoMes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemParamentros_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemParamentros.Foreground = Brushes.Black;
        }

        private void MenuItemParamentros_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemParamentros.Foreground = Brushes.AliceBlue;
        }

       

        private void btnCadastroUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (_usuario.UsuarioMaster == true)
            {
                var cadUsuario = new CadastroUsuario(_usuario, "Tela Principal");
                cadUsuario.Owner = this;
                cadUsuario.ShowDialog();

                lblNomeUsuario.Content = _usuario.Nome;
            }
            else
            {
                MessageBox.Show("Apenas Usuario Master tem permissão para acessar o Cadastro de Usuários.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnParametros_Click(object sender, RoutedEventArgs e)
        {
            if (_usuario.UsuarioMaster == true)
            {
                var configur = new Configuracoes(_config);
                configur.Owner = this;
                configur.ShowDialog();

                _config = _AppServicoConfiguracoes.GetById(1);
                lblNomeCartorio.Content = _config.RazaoSocial;
            }
            else
            {
                MessageBox.Show("Apenas Usuario Master tem permissão para acessar Parâmetros do Sistema.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void MenuItemCadUsuarios_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemCadUsuarios.Foreground = Brushes.Black;
        }

        private void MenuItemCadUsuarios_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemCadUsuarios.Foreground = Brushes.AliceBlue;
        }


        private void btnConsultarAtos_Click(object sender, RoutedEventArgs e)
        {
            var consultaAtosIss = new ConsultaAtosIss(_usuario);
            consultaAtosIss.Owner = this;
            consultaAtosIss.ShowDialog();
        }

        private void btnImportarAtos_Click(object sender, RoutedEventArgs e)
        {
            if (_usuario.UsuarioMaster == true || _usuario.ImportarMas == true)
                Sincronizar();
            else
                MessageBox.Show("Apenas Usuario Master ou Importar Atos, tem permissão para acessar Importar Atos.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void Sincronizar()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

            openFileDialog1.Filter = "Arquivos xml (*.xml)|*.xml";

            openFileDialog1.InitialDirectory = @"\\Servidor\c\Cartorio\cgj-rj\ModuloApoioServico\Caixa de Entrada\Relatórios";

            openFileDialog1.Multiselect = true;

            openFileDialog1.Title = "Importar Arquivos";
            try
            {

                var arquivos = new List<string>();



                if (openFileDialog1.ShowDialog() == true)
                {


                    foreach (String file in openFileDialog1.FileNames)
                    {
                        arquivos.Add(file);
                    }

                    for (int i = 0; i < arquivos.Count; i++)
                    {
                        

                        FileInfo fi = new FileInfo(arquivos[i]);


                        string relatorio = @"\\Servidor\c\Cartorio\CS_Sistemas\CS_ISS\relatorio.xml.xsd";

                        ValidadorSchemaXml.Validar(fi.FullName, relatorio);

                        List<AtoIss> AtosImportar = _appServicoAtoIss.LerArquivoXml(arquivos[i]);

                        if (AtosImportar.Count == 0)
                        {
                            //MessageBox.Show("Não constam atos no arquivo: \n\n " + arquivos[i], "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                            
                        }
                        else
                        {
                            _config = _AppServicoConfiguracoes.GetById(1);

                            if (_config.NomeArquivoImportando == fi.FullName)
                            {
                                MessageBox.Show("Arquivo selecionado já foi importado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);

                            }
                            else
                            {
                                _config.NomeArquivoImportando = fi.FullName;

                                _AppServicoConfiguracoes.Update(_config);


                                var aguardeIndisp = new AguardeIntegracaoIssMas(AtosImportar, arquivos[i]);
                                aguardeIndisp.Owner = this;
                                aguardeIndisp.ShowDialog();
                            }
                        }
                        //DateTime data = Convert.ToDateTime(AtosImportar[0].Data);

                        //var consultaAtosIss = new ConsultaAtosIss(data, _usuario);
                        //consultaAtosIss.Owner = this;
                        //consultaAtosIss.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnFechamentoMes_Click(object sender, RoutedEventArgs e)
        {
            var apuracaoIss = new ApuracaoIss(_usuario);
            apuracaoIss.Owner = this;
            apuracaoIss.ShowDialog();
        }


    }
}
