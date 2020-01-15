using CrossCutting;
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
    /// Interaction logic for CadastroFornecedor.xaml
    /// </summary>
    public partial class CadastroFornecedor : Window
    {
        private readonly IAppServicoFornecedores _AppServicoFornecedores = BootStrap.Container.GetInstance<IAppServicoFornecedores>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        List<Fornecedores> fornecedores;

        Fornecedores fornecedor;

        Usuario _usuario;

        LogSistema logSistema;

        string acao = "pronto";
        public CadastroFornecedor(Usuario usuario)
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
            CarregamentoDataGrid();

            EstadoIsEnableComponentes();

            List<string> carregaCombo = new List<string>();

            carregaCombo.Add("RAZÃO SOCIAL");
            carregaCombo.Add("NOME FANTASIA");
            carregaCombo.Add("DOCUMENTO");

            cmbTipoConsulta.ItemsSource = carregaCombo;
            cmbTipoConsulta.SelectedIndex = 0;
        }


        private void CarregamentoDataGrid()
        {
            fornecedores = _AppServicoFornecedores.GetAll().ToList();

            dataGridFornecedor.ItemsSource = fornecedores;

            VerificaMenu();
        }

        private void VerificaMenu()
        {
            if (fornecedores.Count > 0)
            {
                dataGridFornecedor.SelectedIndex = 0;

                MenuItemAlterar.IsEnabled = true;

                MenuItemExcluir.IsEnabled = true;
            }
            else
            {
                MenuItemAlterar.IsEnabled = false;

                MenuItemExcluir.IsEnabled = false;
            }
        }

        private void CarregamentoDataGridConsulta()
        {
            
            dataGridFornecedor.ItemsSource = fornecedores;

            if (fornecedores.Count > 0)
            {
                dataGridFornecedor.SelectedIndex = 0;

                MenuItemAlterar.IsEnabled = true;

                MenuItemExcluir.IsEnabled = true;
            }
            else
            {
                MenuItemAlterar.IsEnabled = false;

                MenuItemExcluir.IsEnabled = false;
            }
        }

        private void dataGridFornecedor_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (dataGridFornecedor.SelectedIndex > -1)
                {
                    fornecedor = (Fornecedores)dataGridFornecedor.SelectedItem;
                    CarregaCamposCadastro();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void CarregaCamposCadastro()
        {

            if (fornecedor != null)
            {

                txtRazaoSocial.Text = fornecedor.RazaoSocial;

                txtNomeFantasia.Text = fornecedor.NomeFantasia;

                switch (fornecedor.Cnpj.Length)
                {
                    case 11:
                        string cpf = FormatarCpf(fornecedor.Cnpj);

                        if (cpf != "invalido")
                            txtCpfCnpj.Text = cpf;
                        else
                            txtCpfCnpj.Text = fornecedor.Cnpj;

                        rbCpj.IsChecked = true;
                        break;
                    case 14:

                        string cnpj = FormatarCnpj(fornecedor.Cnpj);

                        if (cnpj != "invalido")
                            txtCpfCnpj.Text = cnpj;
                        else
                            txtCpfCnpj.Text = fornecedor.Cnpj;

                        rbCnpj.IsChecked = true;
                        break;
                    default:
                        rbCnpj.IsChecked = false;
                        rbCpj.IsChecked = false;
                        txtCpfCnpj.Text = fornecedor.Cnpj;
                        break;
                }
            }
            else
            {
                LimparCampos();
            }
        }

        private string FormatarCpf(string cpf)
        {
            if (cpf.Length == 11)
            {
                cpf = string.Format("{0}.{1}.{2}-{3}", cpf.Substring(0, 3), cpf.Substring(3, 3), cpf.Substring(6, 3), cpf.Substring(9, 2));
            }
            if (ValidaCpfCnpj.ValidaCPF(cpf))
                return cpf;
            else
                return "invalido";
        }

        private string FormatarCnpj(string cnpj)
        {
            if (cnpj.Length == 14)
            {
                cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", cnpj.Substring(0, 2), cnpj.Substring(2, 3), cnpj.Substring(5, 3), cnpj.Substring(8, 4), cnpj.Substring(12, 2));
            }
            if (ValidaCpfCnpj.ValidaCNPJ(cnpj))
                return cnpj;
            else
               return "invalido";
        }

        private void LimparCampos()
        {
            txtRazaoSocial.Text = "";
            txtNomeFantasia.Text = "";
            txtCpfCnpj.Text = "";
            rbCnpj.IsChecked = false;
            rbCpj.IsChecked = false;
        }

        private void txtCpfCnpj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void txtCpfCnpj_LostFocus(object sender, RoutedEventArgs e)
        {
            FormatarCpfCnpj();
        }

        private void FormatarCpfCnpj()
        {
            if (rbCpj.IsChecked == true)
            {
                var cpf = FormatarCpf(txtCpfCnpj.Text);
                if (cpf != "invalido")
                {
                    txtCpfCnpj.Text = cpf;
                    txtCpfCnpj.Background = Brushes.White;
                }
                else
                {
                    txtCpfCnpj.Background = Brushes.Red;
                }
            }

            if (rbCnpj.IsChecked == true)
            {

                var cnpj = FormatarCnpj(txtCpfCnpj.Text);
                if (cnpj != "invalido")
                {
                    txtCpfCnpj.Text = cnpj;
                    txtCpfCnpj.Background = Brushes.White;
                }
                else
                {
                    txtCpfCnpj.Background = Brushes.Red;
                }
            }
        }

        private void txtCpfCnpj_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCpfCnpj.Text = txtCpfCnpj.Text.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            acao = "adicionar";
            LimparCampos();
            ClickAdicionar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            acao = "cancelar";
            ClickCancelar();
        }

        private void MenuItemAlterar_Click(object sender, RoutedEventArgs e)
        {
            acao = "alterar";
            
            ClickAlterar();

            FormatarCpfCnpj();
        }

        private void MenuItemExcluir_Click(object sender, RoutedEventArgs e)
        {
            ClickExcluir();
        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ClickSalvar();
        }

        private void ClickAdicionar()
        {
            LimparCampos();
            EstadoIsEnableComponentes();
            txtCpfCnpj.Background = Brushes.White;
            txtCpfCnpj.IsEnabled = false;
            txtRazaoSocial.Focus();
            txtRazaoSocial.SelectAll();
        }

        private void ClickCancelar()
        {
            EstadoIsEnableComponentes();
            CarregaCamposCadastro();
        }


        private void ClickAlterar()
        {
            EstadoIsEnableComponentes();
            CarregaCamposCadastro();
            txtRazaoSocial.Focus();
            txtRazaoSocial.SelectAll();
            VerificarTipoDocumentoRadioButton();
        }

        private void ClickExcluir()
        {
            if(fornecedor != null)
            if(MessageBox.Show("Deseja realmente excluir este Registro?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _AppServicoFornecedores.Remove(fornecedor);

                fornecedores.Remove(fornecedor);

                SalvarLogSistema("Excluiu o registro Id = " + fornecedor.FornecedorId);

                dataGridFornecedor.Items.Refresh();
            }
        }

        private void ClickSalvar()
        {

            if (txtCpfCnpj.Background != Brushes.White)
            {
                if (MessageBox.Show("O documento digitado está incorreto, deseja salvar o registro com o documento errado?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
            }

            Fornecedores salvarFornecedor;
            try
            {
                if (acao == "adicionar")
                    salvarFornecedor = new Fornecedores();
                else
                    salvarFornecedor = _AppServicoFornecedores.GetById(fornecedor.FornecedorId);

                salvarFornecedor.RazaoSocial = txtRazaoSocial.Text.Trim();

                if (txtNomeFantasia.Text == "")
                {
                    salvarFornecedor.NomeFantasia = txtRazaoSocial.Text.Trim();
                }
                else
                {
                    salvarFornecedor.NomeFantasia = txtNomeFantasia.Text.Trim();
                }

                salvarFornecedor.Cnpj = txtCpfCnpj.Text.Replace(".","").Replace("/","").Replace("-","");

                if (acao == "adicionar")
                {
                    _AppServicoFornecedores.Add(salvarFornecedor);

                    fornecedores.Add(salvarFornecedor);

                    SalvarLogSistema("Adicionou o registro Id = " + salvarFornecedor.FornecedorId);
                }
                else
                {
                    _AppServicoFornecedores.Update(salvarFornecedor);

                    SalvarLogSistema("Alterou o registro Id = " + salvarFornecedor.FornecedorId);
                }

                dataGridFornecedor.Items.Refresh();

                dataGridFornecedor.SelectedItem = salvarFornecedor;
                

                MessageBox.Show("Registro salvo com sucesso.", "Salvo", MessageBoxButton.OK, MessageBoxImage.Information);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                acao = "pronto";

                EstadoIsEnableComponentes();

                VerificaMenu();
            }

        }
        private void EstadoIsEnableComponentes()
        {
            if (acao == "adicionar" || acao == "alterar")
            {
                gridCadastro.IsEnabled = true;
                gridConsulta.IsEnabled = false;

                btnAdicionar.IsEnabled = false;
                btnCancelar.IsEnabled = true;
                btnSalvar.IsEnabled = true;
                dataGridFornecedor.IsEnabled = false;
            }
            if (acao == "cancelar" || acao == "pronto")
            {
                gridCadastro.IsEnabled = false;
                gridConsulta.IsEnabled = true;

                btnAdicionar.IsEnabled = true;
                btnCancelar.IsEnabled = false;
                btnSalvar.IsEnabled = false;
                dataGridFornecedor.IsEnabled = true;
            }
            
        }

        private void rbCpj_Checked(object sender, RoutedEventArgs e)
        {
            VerificarTipoDocumentoRadioButton();
            FormatarCpfCnpj();
        }

        private void rbCnpj_Checked(object sender, RoutedEventArgs e)
        {
            VerificarTipoDocumentoRadioButton();
            FormatarCpfCnpj();
        }

        private void VerificarTipoDocumentoRadioButton()
        {
           
                if (rbCpj.IsChecked == true)
                {
                    txtCpfCnpj.IsEnabled = true;
                    if (acao != "alterar")
                    {
                        txtCpfCnpj.Focus();
                        txtCpfCnpj.SelectAll();
                    }
                    txtCpfCnpj.MaxLength = 11;
                }

                if (rbCnpj.IsChecked == true)
                {
                    txtCpfCnpj.IsEnabled = true;
                    if (acao != "alterar")
                    {
                        txtCpfCnpj.Focus();
                        txtCpfCnpj.SelectAll();
                    }
                    txtCpfCnpj.MaxLength = 14;
                }

                if (rbCpj.IsChecked == false && rbCnpj.IsChecked == false)
                {
                    txtCpfCnpj.IsEnabled = false;
                }
            
    
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

        private void gridCadastro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtConsulta_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (cmbTipoConsulta.Text == "DOCUMENTO")
            {
                DigitarSomenteNumeros(sender, e);                
            }
            
        }

        private void ConsultarFornecedor()
        {
            switch (cmbTipoConsulta.Text)
            {
                case "RAZÃO SOCIAL":
                    ConsultarPorRazaoSocial();                    
                    break;

                case "NOME FANTASIA":
                    ConsultarPorNomeFantasia();
                    break;

                case "DOCUMENTO":
                    ConsultarPorDocumento();
                    break;

                default:
                    break;
            }
        }

        private void ConsultarPorRazaoSocial()
        {
            fornecedores = _AppServicoFornecedores.ConsultarPorRazaoSocial(txtConsulta.Text).ToList();

            CarregamentoDataGridConsulta();
        }

        private void ConsultarPorNomeFantasia()
        {
            fornecedores = _AppServicoFornecedores.ConsultarPorNomeFantasia(txtConsulta.Text).ToList();

            CarregamentoDataGridConsulta();
        }

        private void ConsultarPorDocumento()
        {
            fornecedores = _AppServicoFornecedores.ConsultarPorDocumento(txtConsulta.Text).ToList();

            CarregamentoDataGridConsulta();
        }

        private void txtConsulta_TextChanged(object sender, TextChangedEventArgs e)
        {
            ConsultarFornecedor();           
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Cadastro de Fornecedor";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }

        private void cmbTipoConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtConsulta.Text = "";
            txtConsulta.Focus();
        }
    }
}
