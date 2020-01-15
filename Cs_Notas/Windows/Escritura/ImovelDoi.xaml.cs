using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
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

namespace Cs_Notas.Windows.Escritura
{
    /// <summary>
    /// Interaction logic for ImovelDoi.xaml
    /// </summary>
    public partial class ImovelDoi : Window
    {
        private readonly IAppServicoTipoImovel _IAppServicoTipoImovel = BootStrap.Container.GetInstance<IAppServicoTipoImovel>();

        private readonly IAppServicoTransacaoDoi _IAppServicoTransacaoDoi = BootStrap.Container.GetInstance<IAppServicoTransacaoDoi>();

        List<TipoImovel> listaTipoImovel = new List<TipoImovel>();

        List<TransacaoDoi> listaTransacaoDoi = new List<TransacaoDoi>();

        ImovelEscritura _imovelEscritura;

        DateTime _dataAlienacao;

        string _estado;

        public ImovelDoi(ImovelEscritura imovelEscritura, DateTime dataAlienacao, string estado)
        {
            _imovelEscritura = imovelEscritura;
            _dataAlienacao = dataAlienacao;
            _estado = estado;
            InitializeComponent();
        }

        private void cmbTipoTransacao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbTipoTransacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((TransacaoDoi)cmbTipoTransacao.SelectedItem).Codigo == 39)
            {
                txtOutros.IsEnabled = true;
            }
            else
            {
                txtOutros.Text = "";
                txtOutros.IsEnabled = false;
            }
        }

        private void txtOutros_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarComponentes();
        }

        private void CarregarComponentes()
        {
            listaTipoImovel = _IAppServicoTipoImovel.GetAll().ToList();

            listaTransacaoDoi = _IAppServicoTransacaoDoi.GetAll().ToList();

            cmbTipoImovel.ItemsSource = listaTipoImovel;
            cmbTipoImovel.DisplayMemberPath = "Descricao";
            cmbTipoImovel.SelectedValuePath = "Codigo";

            cmbTipoTransacao.ItemsSource = listaTransacaoDoi;
            cmbTipoTransacao.DisplayMemberPath = "Descricao";
            cmbTipoTransacao.SelectedValuePath = "Codigo";

            rbSituacaoNormal.Focus();

            CarregarAlterar();
        }


        private void CarregarAlterar()
        {
            cmbTipoTransacao.SelectedValue = _imovelEscritura.imovel.TipoTransacao;
                      

            if (_imovelEscritura.imovel.Retificacao == "1")
                ckbRetificacao.IsChecked = true;
            else
                ckbRetificacao.IsChecked = false;

            if (_imovelEscritura.imovel.DataAlienacao.ToShortDateString() == "01/01/0001")
                dtDataAlienacao.SelectedDate = _dataAlienacao;
            else
                dtDataAlienacao.SelectedDate = _imovelEscritura.imovel.DataAlienacao;


            switch (_imovelEscritura.imovel.FormaAlienacao)
            {
                case "5":
                    rbFormaAlienacaoAVista.IsChecked = true;
                    break;
                case "7":
                    rbFormaAlienacaoAPrazo.IsChecked = true;
                    break;
                case "9":
                    rbFormaAlienacaoNaoSeAplica.IsChecked = true;
                    break;

                default:
                    rbFormaAlienacaoAVista.IsChecked = true;
                    break;
            }


            if (_imovelEscritura.imovel.ValorNaoConsta == "1" || _imovelEscritura.imovel.ValorNaoConsta == null)
                ckbValorAlienacaoNaoSeAplica.IsChecked = true;
            else
                ckbValorAlienacaoNaoSeAplica.IsChecked = false;

            if (txtBaseCalculo.Text.Length > 1)
                txtBaseCalculo.Text = string.Format("{0:n2}", _imovelEscritura.imovel.BaseItbiItcd);


            cmbTipoImovel.SelectedValue = _imovelEscritura.imovel.TipoImovelDoi;



            switch (_imovelEscritura.imovel.Construcao)
            {
                case "0":
                    rbAndamentoConstrucaoAverbada.IsChecked = true;
                    break;
                case "1":
                    rbAndamentoEmConstrucao.IsChecked = true;
                    break;
                case "2":
                    rbAndamentoNaoSeAplica.IsChecked = true;
                    break;
                default:
                    rbAndamentoNaoSeAplica.IsChecked = true;
                    break;

            }


            if (_imovelEscritura.imovel.AreaNaoConsta == "1" || _imovelEscritura.imovel.AreaNaoConsta == null)
                ckbAreaNaoSeAplica.IsChecked = true;
            else
                ckbAreaNaoSeAplica.IsChecked = false;

            if (_imovelEscritura.imovel.ValorItbi == "1" || _imovelEscritura.imovel.ValorItbi == null)
                ckbBaseCalculoNaoSeAplica.IsChecked = true;
            else
                ckbBaseCalculoNaoSeAplica.IsChecked = false;


            switch (_imovelEscritura.imovel.Situacao)
            {
                case "0":
                    rbSituacaoNormal.IsChecked = true;
                    break;

                case "1":
                    rbSituacaoRetificadora.IsChecked = true;
                    break;

                case "2":
                    rbSituacaoCanceladora.IsChecked = true;
                    break;

                default:
                    rbSituacaoNormal.IsChecked = true;
                    break;
            }

            if (_imovelEscritura.imovel.ValorItbi == "0")
                txtBaseCalculo.Text = string.Format("{0:n2}", _imovelEscritura.imovel.Valor);

            if (_imovelEscritura.imovel.AreaNaoConsta == "0")
                txtAreaImovel.Text = _imovelEscritura.imovel.Area;

            if (_imovelEscritura.imovel.ValorNaoConsta == "0")
                txtValorAlienacao.Text = string.Format("{0:n2}", _imovelEscritura.imovel.ValorAlienacao);

            if (cmbTipoImovel.Text == "Outros")
                txtOutrosTipoImovel.Text = _imovelEscritura.imovel.DescricaoTipoImovel;

            if (cmbTipoTransacao.Text == "Outros")
                txtOutros.Text = _imovelEscritura.imovel.DescricaoTransacao;
        }


        private void txtOutrosTipoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbTipoImovel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbTipoImovel.SelectedIndex > -1)
            if (((TipoImovel)cmbTipoImovel.SelectedItem).Codigo == 89)
            {
                txtOutrosTipoImovel.IsEnabled = true;
            }
            else
            {
                txtOutrosTipoImovel.Text = "";
                txtOutrosTipoImovel.IsEnabled = false;
            }
        }

        private void cmbTipoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void DigitarSemNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }


        private void DigitarSomenteNumerosEmReaisComVirgual(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
        }

        private void DigitarSomenteLetras(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key >= 44 && key <= 69);
        }

        private void ckbValorAlienacaoNaoSeAplica_Unchecked(object sender, RoutedEventArgs e)
        {
            txtValorAlienacao.Focus();
            if(txtValorAlienacao.Text.Length > 1)
            txtValorAlienacao.SelectAll();
        }

        private void txtValorAlienacao_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtValorAlienacao.Text.Length > 0)
                ckbValorAlienacaoNaoSeAplica.IsChecked = false;
            else
                ckbValorAlienacaoNaoSeAplica.IsChecked = true;
        }

        private void ckbBaseCalculoNaoSeAplica_Unchecked(object sender, RoutedEventArgs e)
        {
            txtBaseCalculo.Focus();
            if (txtBaseCalculo.Text.Length > 1)
            txtBaseCalculo.SelectAll();
        }

        private void txtBaseCalculo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBaseCalculo.Text.Length > 0)
            {
                ckbBaseCalculoNaoSeAplica.IsChecked = false;
            }
            else
                ckbBaseCalculoNaoSeAplica.IsChecked = true;
        }

        private void ckbAreaNaoSeAplica_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAreaImovel.Focus();
            if (txtAreaImovel.Text.Length > 1)
            txtAreaImovel.SelectAll();
        }

        private void txtAreaImovel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAreaImovel.Text.Length > 0)
            {
                ckbAreaNaoSeAplica.IsChecked = false;
            }
            else
                ckbAreaNaoSeAplica.IsChecked = true;
        }

        private void ckbValorAlienacaoNaoSeAplica_Checked(object sender, RoutedEventArgs e)
        {
            txtValorAlienacao.Text = "";
        }

        private void ckbBaseCalculoNaoSeAplica_Checked(object sender, RoutedEventArgs e)
        {
            txtBaseCalculo.Text = "";
        }

        private void ckbAreaNaoSeAplica_Checked(object sender, RoutedEventArgs e)
        {
            txtAreaImovel.Text = "";
        }

        private void SalvarDoi()
        {

            if (cmbTipoTransacao.SelectedIndex > -1)
            {
                if (cmbTipoTransacao.Text == "Outros")
                    _imovelEscritura.imovel.DescricaoTransacao = txtOutros.Text.Trim();
                else
                    _imovelEscritura.imovel.DescricaoTransacao = cmbTipoTransacao.Text;

                _imovelEscritura.imovel.TipoTransacao = cmbTipoTransacao.SelectedValue.ToString();

            }

            if (ckbRetificacao.IsChecked == true)
                _imovelEscritura.imovel.Retificacao = "1";
            else
                _imovelEscritura.imovel.Retificacao = "0";

            _imovelEscritura.imovel.DataAlienacao = dtDataAlienacao.SelectedDate.Value;

            if (rbFormaAlienacaoAVista.IsChecked == true)
                _imovelEscritura.imovel.FormaAlienacao = "5";
            if (rbFormaAlienacaoAPrazo.IsChecked == true)
                _imovelEscritura.imovel.FormaAlienacao = "7";
            if (rbFormaAlienacaoNaoSeAplica.IsChecked == true)
                _imovelEscritura.imovel.FormaAlienacao = "9";

            if (ckbValorAlienacaoNaoSeAplica.IsChecked == true)
                _imovelEscritura.imovel.ValorNaoConsta = "1";
            else
                _imovelEscritura.imovel.ValorNaoConsta = "0";

            if (txtBaseCalculo.Text.Length > 1)
                _imovelEscritura.imovel.BaseItbiItcd = Convert.ToDecimal(txtBaseCalculo.Text);

            if (cmbTipoImovel.SelectedIndex > -1)
            {
                if (cmbTipoImovel.Text == "Outros")
                    _imovelEscritura.imovel.DescricaoTipoImovel = txtOutrosTipoImovel.Text;
                else
                    _imovelEscritura.imovel.DescricaoTipoImovel = cmbTipoImovel.Text;

                _imovelEscritura.imovel.TipoImovelDoi = cmbTipoImovel.SelectedValue.ToString();

            }

            if (rbAndamentoConstrucaoAverbada.IsChecked == true)
                _imovelEscritura.imovel.Construcao = "0";

            if (rbAndamentoEmConstrucao.IsChecked == true)
                _imovelEscritura.imovel.Construcao = "1";

            if (rbAndamentoNaoSeAplica.IsChecked == true)
                _imovelEscritura.imovel.Construcao = "2";

            if (ckbAreaNaoSeAplica.IsChecked == true)
                _imovelEscritura.imovel.AreaNaoConsta = "1";
            else
                _imovelEscritura.imovel.AreaNaoConsta = "0";

            if (ckbBaseCalculoNaoSeAplica.IsChecked == true)
                _imovelEscritura.imovel.ValorItbi = "1";
            else
                _imovelEscritura.imovel.ValorItbi = "0";

            if (rbSituacaoNormal.IsChecked == true)
                _imovelEscritura.imovel.Situacao = "0";

            if (rbSituacaoRetificadora.IsChecked == true)
                _imovelEscritura.imovel.Situacao = "1";

            if (rbSituacaoCanceladora.IsChecked == true)
                _imovelEscritura.imovel.Situacao = "3";

            if (txtValorAlienacao.Text.Length > 1)
                _imovelEscritura.imovel.ValorAlienacao = Convert.ToDecimal(txtValorAlienacao.Text);

            if (txtBaseCalculo.Text.Length > 1)
                _imovelEscritura.imovel.Valor = Convert.ToDecimal(txtBaseCalculo.Text);

            if (ckbAreaNaoSeAplica.IsChecked == false)
                _imovelEscritura.imovel.Area = txtAreaImovel.Text;
        }

        private void btnSalvarSemSair_Click(object sender, RoutedEventArgs e)
        {
            SalvarDoi();
            this.Close();
        }

        private void txtBaseCalculo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBaseCalculo.Text != "" && txtBaseCalculo.Text != ",")
            {
                txtBaseCalculo.Text = string.Format("{0:n2}", Convert.ToDecimal(txtBaseCalculo.Text));
                _imovelEscritura.imovel.Valor = Convert.ToDecimal(txtBaseCalculo.Text);
                _imovelEscritura.txtValorBemImovel.Text = txtBaseCalculo.Text;
            }
            else
                txtBaseCalculo.Text = "";


        }

        private void txtValorAlienacao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorAlienacao.Text != "" && txtValorAlienacao.Text != ",")
            {
                txtValorAlienacao.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorAlienacao.Text));
                _imovelEscritura.imovel.ValorAlienacao = Convert.ToDecimal(txtValorAlienacao.Text);
                _imovelEscritura.txtValorAlienadoImovel.Text = txtValorAlienacao.Text;
            }
            else
                txtValorAlienacao.Text = "";


        }

        private void txtAreaImovel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtAreaImovel.Text != "" && txtAreaImovel.Text != ",")
            {
                txtAreaImovel.Text = string.Format("{0:n2}", Convert.ToDecimal(txtAreaImovel.Text));

                _imovelEscritura.imovel.Area = txtAreaImovel.Text;

                _imovelEscritura.ckbNaoConstaAreaImovel.IsChecked = false;

                _imovelEscritura.txtAreaImovel.Text = txtAreaImovel.Text;

            }
            else
                txtAreaImovel.Text = "";


        }

        private void txtValorAlienacao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtValorAlienacao.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorAlienacao.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorAlienacao.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtBaseCalculo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtBaseCalculo.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtBaseCalculo.Text.IndexOf(",");

                if (indexVirgula + 3 == txtBaseCalculo.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtAreaImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtAreaImovel.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtAreaImovel.Text.IndexOf(",");

                if (indexVirgula + 3 == txtAreaImovel.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
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

        private void rbSituacaoNormal_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbSituacaoRetificadora_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbSituacaoCanceladora_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbFormaAlienacaoAVista_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbFormaAlienacaoAPrazo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbFormaAlienacaoNaoSeAplica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dtDataAlienacao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbRetificacao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbValorAlienacaoNaoSeAplica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbBaseCalculoNaoSeAplica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbAreaNaoSeAplica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbAndamentoConstrucaoAverbada_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbAndamentoEmConstrucao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbAndamentoNaoSeAplica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
    }
}

