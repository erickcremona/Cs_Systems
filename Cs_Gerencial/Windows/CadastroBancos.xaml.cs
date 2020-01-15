using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CadastroBancos.xaml
    /// </summary>
    public partial class CadastroBancos : Window
    {
        private readonly IAppServicoBancos _AppServicoBancos = BootStrap.Container.GetInstance<IAppServicoBancos>();
        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        Usuario _usuario;

        Bancos banco;

        LogSistema logSistema;

        List<Bancos> listaBancos = new List<Bancos>();

        string acao = "pronto";

        public CadastroBancos(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregamentoInicial();
        }

        private void CarregamentoInicial()
        {
            SetarBotoesEmEstadoInicial();

            listaBancos = _AppServicoBancos.GetAll().ToList();

            AbilitaDesabilitaMenuDataGrid();

            CarregaDataGrid();

            if (dataGridBancos.Items.Count > 0)
                dataGridBancos.SelectedIndex = 0;
        }

        private void AbilitaDesabilitaMenuDataGrid()
        {
            if (listaBancos.Count <= 0)
            {
                menu.Visibility = Visibility.Hidden;
            }
            else
            {
                menu.Visibility = Visibility.Visible;
            }

        }
        private void CarregaDataGrid()
        {
            dataGridBancos.ItemsSource = listaBancos;

            dataGridBancos.Items.Refresh();


            if (dataGridBancos.Items.Count > 0)
                dataGridBancos.SelectedItem = banco;
            else
                LimparCamposParaAdicionar();

            if (acao == "excluir")
                dataGridBancos.SelectedIndex = 0;
        }

        private void ClickAdicionar()
        {
            AbilitarCamposParaAdicionarEAlterar();
        }

        private void ClickAlterar()
        {
            AbilitarCamposParaAdicionarEAlterar();
        }

        private void ClickExcluir()
        {
            if (MessageBox.Show("Deseja realmente excluir o registro?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _AppServicoBancos.Remove(banco);

                listaBancos.Remove(banco);

                SalvarLogSistema("Excluiu o registro id = " + banco.BancosId);

                CarregaDataGrid();
            }
        }

        private void ClickCancelar()
        {
            CarregarCamposDoDataGrid();
            SetarBotoesEmEstadoInicial();
            acao = "pronto";
        }


        private void AbilitarCamposParaAdicionarEAlterar()
        {
            btnAdicionar.IsEnabled = false;
            btnSalvar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            dataGridBancos.IsEnabled = false;
            gridBanco.IsEnabled = true;
        }

        private void SetarBotoesEmEstadoInicial()
        {
            
            btnSalvar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnAdicionar.IsEnabled = true;
            dataGridBancos.IsEnabled = true;
            gridBanco.IsEnabled = false;
        }

        private void ClickSalvar()
        {
            try
            {
                if (acao == "alterar")
                    banco = _AppServicoBancos.GetById(banco.BancosId);
                else
                    banco = new Bancos();


                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("Informe o Código do Banco.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    txtCodigo.Focus();
                    return;
                }
                if (txtNomeBanco.Text == "")
                {
                    MessageBox.Show("Informe o Nome do Banco.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    txtNomeBanco.Focus();
                    return;
                }

                banco.Codigo = txtCodigo.Text = txtCodigo.Text.Trim();
                banco.Agencia = txtAgencia.Text = txtAgencia.Text.Trim();
                banco.Conta = txtConta.Text = txtConta.Text.Trim();
                banco.Nome = txtNomeBanco.Text = txtNomeBanco.Text.Trim();

                if (acao == "alterar")
                {
                    _AppServicoBancos.Update(banco);

                    SalvarLogSistema("Alterou o registro id = " + banco.BancosId);
                }
                else
                {
                    _AppServicoBancos.Add(banco);

                    SalvarLogSistema("Adicionou o registro id = " + banco.BancosId);

                    listaBancos.Add(banco);
                }

                CarregaDataGrid();

                AbilitaDesabilitaMenuDataGrid();
                SetarBotoesEmEstadoInicial();

                MessageBox.Show("Registro salvo com sucesso.", "Salvo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
                SetarBotoesEmEstadoInicial();
            }
            
        }

        private void MenuItemAlterar_Click(object sender, RoutedEventArgs e)
        {
            acao = "alterar";
            ClickAlterar();
            txtCodigo.Focus();
        }

        private void MenuItemExcluir_Click(object sender, RoutedEventArgs e)
        {
            acao = "excluir";
            ClickExcluir();
            AbilitaDesabilitaMenuDataGrid();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            acao = "adicionar";
            ClickAdicionar();
            LimparCamposParaAdicionar();
            txtCodigo.Focus();            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            acao = "pronto";
            ClickCancelar();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ClickSalvar();
            acao = "pronto";
        }

        private void dataGridFornecedor_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (dataGridBancos.SelectedItem != null)
                {
                    banco = (Bancos)dataGridBancos.SelectedItem;
                    CarregarCamposDoDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
            }

        }

        private void CarregarCamposDoDataGrid()
        {
            if (banco != null)
            {
                txtCodigo.Text = banco.Codigo.ToString();
                txtAgencia.Text = banco.Agencia;
                txtConta.Text = banco.Conta;
                txtNomeBanco.Text = banco.Nome;
            }
            else
            {
                LimparCamposParaAdicionar();
            }
        }

        private void LimparCamposParaAdicionar()
        {
            txtCodigo.Text = "";
            txtAgencia.Text = "";
            txtConta.Text = "";
            txtNomeBanco.Text = "";
        }

        private void gridBanco_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void PassarDeUmCoponenteParaOutro(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Cadastro de Plano de Contas";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }

    }
}
