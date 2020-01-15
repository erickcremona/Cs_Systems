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
    /// Interaction logic for CadastroPlanoContas.xaml
    /// </summary>
    public partial class CadastroPlanoContas : Window
    {
        private readonly IAppServicoPlanos _AppServicoPlanos = BootStrap.Container.GetInstance<IAppServicoPlanos>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        Usuario _usuario;

        Planos planos;

        LogSistema logSistema;

        List<Planos> listaPlanos = new List<Planos>();

        string acao = "pronto";

        public CadastroPlanoContas(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregamentoInicial();
        }

        private void dataGridFornecedor_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItem != null)
                {
                    planos = (Planos)dataGrid.SelectedItem;
                    CarregarCamposDoDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
            }
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            acao = "adicionar";
            ClickAdicionar();
            LimparCamposParaAdicionar();
            txtPlano.Focus();            
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

        private void MenuItemAlterar_Click(object sender, RoutedEventArgs e)
        {
            acao = "alterar";
            ClickAlterar();
            txtPlano.Focus();
        }

        private void MenuItemExcluir_Click(object sender, RoutedEventArgs e)
        {
            acao = "excluir";
            ClickExcluir();
            AbilitaDesabilitaMenuDataGrid();
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

        private void CarregarCamposDoDataGrid()
        {
            if (planos != null)
            {
                txtPlano.Text = planos.Descricao;
            }
            else
            {
                LimparCamposParaAdicionar();
            }
        }

        private void LimparCamposParaAdicionar()
        {
            txtPlano.Text = "";
        }

        private void CarregaDataGrid()
        {
            dataGrid.ItemsSource = listaPlanos;

            dataGrid.Items.Refresh();

            if (dataGrid.Items.Count > 0)
                dataGrid.SelectedItem = planos;
            else
                LimparCamposParaAdicionar();

            if (acao == "excluir")
                dataGrid.SelectedIndex = 0;
        }

        private void AbilitaDesabilitaMenuDataGrid()
        {
            if (listaPlanos.Count <= 0)
            {
                menu.Visibility = Visibility.Hidden;
            }
            else
            {
                menu.Visibility = Visibility.Visible;
            }

        }

        private void CarregamentoInicial()
        {
            SetarBotoesEmEstadoInicial();

            listaPlanos = _AppServicoPlanos.GetAll().ToList();

            AbilitaDesabilitaMenuDataGrid();

            CarregaDataGrid();

            if (dataGrid.Items.Count > 0)
                dataGrid.SelectedIndex = 0;
        }

        private void SetarBotoesEmEstadoInicial()
        {
            btnSalvar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnAdicionar.IsEnabled = true;
            dataGrid.IsEnabled = true;
            txtPlano.IsEnabled = false;
            txtPlanoConsulta.IsEnabled = true;
        }

        private void AbilitarCamposParaAdicionarEAlterar()
        {
            btnAdicionar.IsEnabled = false;
            btnSalvar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            dataGrid.IsEnabled = false;
            txtPlano.IsEnabled = true;
            txtPlanoConsulta.IsEnabled = false;
        }

        private void ClickCancelar()
        {
            CarregarCamposDoDataGrid();
            SetarBotoesEmEstadoInicial();
            acao = "pronto";
        }

        private void ClickExcluir()
        {
            if (MessageBox.Show("Deseja realmente excluir o registro?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _AppServicoPlanos.Remove(planos);

                listaPlanos.Remove(planos);

                SalvarLogSistema("Excluiu o registro id = " + planos.PlanoId);

                CarregaDataGrid();
            }
        }

        private void ClickAdicionar()
        {
            AbilitarCamposParaAdicionarEAlterar();
        }

        private void ClickAlterar()
        {
            AbilitarCamposParaAdicionarEAlterar();
        }


        private void ClickSalvar()
        {
            try
            {
                if (acao == "alterar")
                    planos = _AppServicoPlanos.GetById(planos.PlanoId);
                else
                    planos = new Planos();


                if (txtPlano.Text == "")
                {
                    MessageBox.Show("Informe a Descrição do Plano de Contas.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    txtPlano.Focus();
                    return;
                }


                planos.Descricao = txtPlano.Text = txtPlano.Text.Trim();
                planos.Principal = "N";
               

                if (acao == "alterar")
                {
                    _AppServicoPlanos.Update(planos);

                    SalvarLogSistema("Alterou o registro id = " + planos.PlanoId);
                }
                else
                {
                    _AppServicoPlanos.Add(planos);

                    SalvarLogSistema("Adicionou o registro id = " + planos.PlanoId);

                    listaPlanos.Add(planos);
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

        private void txtPlano_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtPlanoConsulta_TextChanged(object sender, TextChangedEventArgs e)
        {
            listaPlanos = _AppServicoPlanos.ConsultarPlanosPorDescricao(txtPlanoConsulta.Text).ToList();

            dataGrid.ItemsSource = listaPlanos;

            dataGrid.Items.Refresh();
        }
    }
}
