using CrossCutting;
using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Cs_IssPrefeitura
{
    /// <summary>
    /// Interaction logic for Configuracoes.xaml
    /// </summary>
    public partial class Configuracoes : Window
    {
        Config _config;

        Apresentacao _apresentacao;

        private readonly IAppServicoConfiguracoes _IAppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        public Configuracoes(Config config)
        {
            _config = config;
            InitializeComponent();
        }

        public Configuracoes(Apresentacao apresentacao)
        {
            _apresentacao = apresentacao;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            try
            {
                if (_config != null)
                {
                    txtCodigo.Text = string.Format("{0}", _config.Codigo);
                    txtDescricao.Text = _config.RazaoSocial;
                    txtResponsavel.Text = _config.Titular;
                    txtSubstituto.Text = _config.Substituto;
                    txtCnpj.Text = FormatarCpfCnpj(_config.Cnpj);
                    txtCmc.Text = _config.Cmc;
                    txtCpfTitular.Text = _config.CpfTitular;

                    txtEndereco.Text = _config.Endereco;
                    txtBairro.Text = _config.Bairro;
                    txtCidade.Text = _config.Cidade;
                    txtUf.Text = _config.Uf;
                    txtCep.Text = FormatarCep(_config.Cep);
                    txtTelefone1.Text = FormatarTelefone(_config.Telefone1);
                    txtTelefone2.Text = FormatarTelefone(_config.Telefone2);
                    txtEmail.Text = _config.Email;

                    txtProximoLivro.Text = _config.ProximoLivro.ToString();
                    txtProximaFolha.Text = _config.ProximaFolha.ToString();
                    cmbTipoCalculo.Text = _config.TipoCalculoIss;
                    txtValorAlicota.Text = string.Format("{0:n2}", _config.ValorAliquota);
                    txtQtdFolhas.Text = _config.TotalFolhasPorLivro.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Não foi possível carregar os dados. " + ex.Message);
            }
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("O campo Código da Serventia é obrigatório.", "Código da Serventia", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("O campo Serventia é obrigatório.", "Serventia", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtResponsavel.Text == "")
                {
                    MessageBox.Show("O campo Titular é obrigatório.", "Titular", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtSubstituto.Text == "")
                {
                    MessageBox.Show("O campo Substituto é obrigatório.", "Substituto", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtCnpj.Text == "")
                {
                    MessageBox.Show("O campo CNPJ é obrigatório.", "CNPJ", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtProximoLivro.Text == "")
                {
                    MessageBox.Show("O campo Número do Livro Atual é obrigatório.", "Número do Livro Atual", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtProximaFolha.Text == "")
                {
                    MessageBox.Show("O campo Número da Folha Atual é obrigatório.", "Número da Folha Atual", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (cmbTipoCalculo.Text == "")
                {
                    MessageBox.Show("O campo Tipo Cálculo Iss é obrigatório.", "Número da Tipo Cálculo Iss", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtValorAlicota.Text == "")
                {
                    MessageBox.Show("O campo Valor Alíquota é obrigatório.", "Valor Alíquota", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }

                if (txtQtdFolhas.Text == "")
                {
                    MessageBox.Show("O campo Número da Folha de Encerramento é obrigatório.", "Número da Folha de Encerramento", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }


                Config conf;

                if (_config != null)
                {
                    conf = _IAppServicoConfiguracoes.GetById(1);
                }
                else
                {
                    conf = new Config();
                }
                if (txtCodigo.Text != "")
                    conf.Codigo = Convert.ToInt16(txtCodigo.Text);


                conf.RazaoSocial = txtDescricao.Text;

                conf.Titular = txtResponsavel.Text;
                conf.Substituto = txtSubstituto.Text;
                conf.Cnpj = txtCnpj.Text;
                conf.CpfTitular = txtCpfTitular.Text;
                conf.Cmc = txtCmc.Text;

                conf.Endereco = txtEndereco.Text;
                conf.Bairro = txtBairro.Text;
                conf.Cidade = txtCidade.Text;
                conf.Uf = txtUf.Text;
                conf.Cep = txtCep.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                conf.Telefone1 = txtTelefone1.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                conf.Telefone2 = txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "");
                conf.Email = txtEmail.Text;

                if (txtProximoLivro.Text != "")
                    conf.ProximoLivro = Convert.ToInt16(txtProximoLivro.Text);

                if (txtProximaFolha.Text != "")
                    conf.ProximaFolha = Convert.ToInt16(txtProximaFolha.Text);

                conf.TipoCalculoIss = cmbTipoCalculo.Text;

                if (txtValorAlicota.Text != "")
                    conf.ValorAliquota = Convert.ToDouble(txtValorAlicota.Text);

                if (txtQtdFolhas.Text != "")
                    conf.TotalFolhasPorLivro = Convert.ToInt16(txtQtdFolhas.Text);

                if (_config != null)
                {
                    _IAppServicoConfiguracoes.Update(conf);
                    _config = conf;
                }
                else
                {
                    _IAppServicoConfiguracoes.Add(conf);
                    _apresentacao.config = conf;
                }

                              

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Não foi possível salvar os dados. " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro( sender,  e);
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3);
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

        private void txtCep_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCep.Text != "")
                    txtCep.Text = FormatarCep(txtCep.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string FormatarCep(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");

                if (cep.Length == 8)
                {
                    cep = string.Format("{0}-{1}", cep.Substring(0, 5), cep.Substring(5, 3));
                }
                else
                {
                    cep = string.Format("{0:00000000}", Convert.ToInt32(cep));

                    cep = string.Format("{0}-{1}", cep.Substring(0, 5), cep.Substring(5, 3));
                }


                return cep;
            }
            catch (Exception) { return null; }
        }

        private void txtCep_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCep.Text = txtCep.Text.Replace("-", "");
        }

        private void txtCep_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtTelefone1_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTelefone1.Text = txtTelefone1.Text.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private void txtTelefone1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTelefone1.Text != "")
                    txtTelefone1.Text = FormatarTelefone(txtTelefone1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string FormatarTelefone(string telefone)
        {
            try
            {
                telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "");


                if (telefone.Length == 10)
                {
                    telefone = string.Format("({0}){1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 4), telefone.Substring(6, 4));
                }
                else
                {

                    telefone = string.Format("{0:0000000000}", Convert.ToInt32(telefone));

                    telefone = string.Format("({0}){1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 4), telefone.Substring(6, 4));
                }

                return telefone;
            }
            catch (Exception) { return null; }
        }

        private void txtTelefone1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtTelefone2_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTelefone2.Text = txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private void txtTelefone2_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTelefone2.Text != "")
                    txtTelefone2.Text = FormatarTelefone(txtTelefone2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTelefone2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDescricao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtResponsavel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtSubstituto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtEndereco_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtBairro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtUf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtProximoLivro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtProximaFolha_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ComboBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtValorAlicota_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            if (!txtValorAlicota.Text.Contains(",") || txtValorAlicota.SelectionLength == txtValorAlicota.Text.Length)
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorAlicota.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorAlicota.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void DigitarSemNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void txtQtdFolhas_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void DigitarSomenteNumerosEmReaisComVirgual(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
        }

        private void txtCnpj_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCnpj.Text = txtCnpj.Text.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        private void txtCnpj_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (ValidaCpfCnpj.ValidaCNPJ(txtCnpj.Text) == false)
                txtCnpj.Background = Brushes.Red;
            else
            {
                txtCnpj.Background = Brushes.White;
                if (txtCnpj.Text.Length == 14)
                    txtCnpj.Text = FormatarCpfCnpj(txtCnpj.Text);
            }
        }

        public static string FormatarCpfCnpj(string strCpfCnpj)
        {
            if (strCpfCnpj.Length <= 11)
            {
                MaskedTextProvider mtpCpf = new MaskedTextProvider(@"000\.000\.000-00");
                mtpCpf.Set(ZerosEsquerda(strCpfCnpj, 11));
                return mtpCpf.ToString();
            }
            else
            {
                MaskedTextProvider mtpCnpj = new MaskedTextProvider(@"00\.000\.000/0000-00");
                mtpCnpj.Set(ZerosEsquerda(strCpfCnpj, 11));
                return mtpCnpj.ToString();
            }
        }

        public static string ZerosEsquerda(string strString, int intTamanho)
        {
            string strResult = "";
            for (int intCont = 1; intCont <= (intTamanho - strString.Length); intCont++)
            {
                strResult += "0";
            }
            return strResult + strString;
        }

        private void txtCnpj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void tbEndereco_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtEndereco.Focus();
            }
        }

        private void txtEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                tbConfig.IsSelected = true;
            }
        }

        private void tbConfig_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtProximoLivro.Focus();
            }
        }

        private void txtCmc_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCpfTitular_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCpfTitular.Text = txtCpfTitular.Text.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        private void txtCpfTitular_LostFocus(object sender, RoutedEventArgs e)
        {
           
            if (ValidaCpfCnpj.ValidaCPF(txtCpfTitular.Text) == false)
                txtCpfTitular.Background = Brushes.Red;
            else
            {
                txtCpfTitular.Background = Brushes.White;
                if (txtCpfTitular.Text.Length == 11)
                    txtCpfTitular.Text = FormatarCpfCnpj(txtCpfTitular.Text);
            }
        }

        private void txtCpfTitular_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);

            if (e.Key == Key.Enter)
            {
                tbEndereco.IsSelected = true;
            }
        }
    }
}
