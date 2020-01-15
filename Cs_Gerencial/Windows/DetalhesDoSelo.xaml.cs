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
    /// Interaction logic for DetalhesDoSelo.xaml
    /// </summary>
    public partial class DetalhesDoSelo : Window
    {

        private readonly IAppServicoAtribuicoes _AppServicoAtribuicoes = BootStrap.Container.GetInstance<IAppServicoAtribuicoes>();

        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        Selos _seloSelecionado;

        Usuario _usuario;

        LogSistema logSistema;

        public DetalhesDoSelo(Selos seloSelecionado, Usuario usuario)
        {
            _seloSelecionado = seloSelecionado;
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarCamposSelo();

            if (_seloSelecionado.Status == "BAIXADO")
            {
                SetarCamposParaEditaveis();
                
            }
        }

        private void CarregarCamposSelo()
        {
            lblSelo.Content = string.Format("Selo: {0} {1} {2}", _seloSelecionado.Letra, _seloSelecionado.Numero, _seloSelecionado.Aleatorio);
            lblStatus.Content = string.Format("Status: {0}", _seloSelecionado.Status);
            lblSistema.Content = string.Format("Sistema: {0}", _seloSelecionado.Sistema);
            if (_seloSelecionado.Status != "LIVRE")
                lblDataReserva.Content = _seloSelecionado.DataReservado.ToShortDateString();

            lblReservadoPor.Content = _seloSelecionado.UsuarioReservado;

            lblIdAto.Content = _seloSelecionado.IdAto;

            txtNatureza.Text = _seloSelecionado.Natureza;

            txtEscrevente.Text = _seloSelecionado.Escrevente;

            txtMatricula.Text = _seloSelecionado.Matricula;

            txtLivro.Text = _seloSelecionado.Livro;

            if (_seloSelecionado.FolhaInicial != 0)
                txtFlsInicial.Text = _seloSelecionado.FolhaInicial.ToString();

            if (_seloSelecionado.FolhaFinal != 0)
                txtFlsFinal.Text = _seloSelecionado.FolhaFinal.ToString();

            if (_seloSelecionado.NumeroAto != 0)
                txtNumeroAto.Text = _seloSelecionado.NumeroAto.ToString();

            if (_seloSelecionado.Protocolo != 0)
                txtProtocolo.Text = _seloSelecionado.Protocolo.ToString();

            if (_seloSelecionado.Recibo != 0)
                txtRecibo.Text = _seloSelecionado.Recibo.ToString();

            if (_seloSelecionado.DataPratica.ToShortDateString() != "01/01/0001")
                datePickerDataPratica.SelectedDate = _seloSelecionado.DataPratica;

            if (_seloSelecionado.Codigo != 0)
                txtCodigo.Text = _seloSelecionado.Codigo.ToString();

            cmbAtribuicao.ItemsSource = _AppServicoAtribuicoes.GetAll().OrderBy(p => p.Codigo);

            cmbAtribuicao.DisplayMemberPath = "Descricao";

            cmbAtribuicao.SelectedValuePath = "Codigo";

            cmbAtribuicao.SelectedValue = _seloSelecionado.Atribuicao;

            txtTipoCobranca.Text = _seloSelecionado.TipoCobranca;


            switch (_seloSelecionado.Convenio)
            {
                case "S":
                    cmbConvenio.SelectedIndex = 0;
                    break;
                case "N":
                    cmbConvenio.SelectedIndex = 1;
                    break;
                default:
                    cmbConvenio.SelectedIndex = -1;
                    break;
            }



            if (_seloSelecionado.Atribuicao == 4 || _seloSelecionado.Atribuicao == 5)
            {

                if (_seloSelecionado.Atribuicao == 4)
                    lblPronot_Apont.Content = "Apontamento:";

                if (_seloSelecionado.Atribuicao == 5)
                    lblPronot_Apont.Content = "Prenotação:";

                txtPrenot_Apont.Text = string.Format("{0:n2}", _seloSelecionado.Prenotacao);
            }
            else
            {
                txtPrenot_Apont.IsEnabled = false;
            }


            txtEmolumentos.Text = string.Format("{0:n2}", _seloSelecionado.Emolumentos);

            txtFetj.Text = string.Format("{0:n2}", _seloSelecionado.Fetj);

            txtFundperj.Text = string.Format("{0:n2}", _seloSelecionado.Fundperj);

            txtFunperj.Text = string.Format("{0:n2}", _seloSelecionado.Funperj);

            txtFunarpen.Text = string.Format("{0:n2}", _seloSelecionado.Funarpen);

            txtPmcmv.Text = string.Format("{0:n2}", _seloSelecionado.Pmcmv);

            txtIss.Text = string.Format("{0:n2}", _seloSelecionado.Iss);

            txtMutua.Text = string.Format("{0:n2}", _seloSelecionado.Mutua);

            txtAcoterj.Text = string.Format("{0:n2}", _seloSelecionado.Acoterj);

            txtDistribuicao.Text = string.Format("{0:n2}", _seloSelecionado.Distribuicao);

            txtIndisponibilidade.Text = string.Format("{0:n2}", _seloSelecionado.Indisponibilidade);

            txtTarifa.Text = string.Format("{0:n2}", _seloSelecionado.TarifaBancaria);

            txtTotal.Text = string.Format("{0:n2}", _seloSelecionado.Total);



        }


        private void SetarCamposParaEditaveis()
        {
            txtNatureza.IsReadOnly = false;

            txtEscrevente.IsReadOnly = false;

            txtMatricula.IsReadOnly = false;

            txtLivro.IsReadOnly = false;

            txtFlsInicial.IsReadOnly = false;

            txtFlsFinal.IsReadOnly = false;

            txtNumeroAto.IsReadOnly = false;

            txtProtocolo.IsReadOnly = false;

            txtRecibo.IsReadOnly = false;

            datePickerDataPratica.IsEnabled = true;

            txtCodigo.IsReadOnly = false;

            cmbAtribuicao.IsEnabled = true;

            txtTipoCobranca.IsEnabled = true;

            cmbConvenio.IsEnabled = true;

            txtPrenot_Apont.IsReadOnly = false;

            txtEmolumentos.IsReadOnly = false;

            txtFetj.IsReadOnly = false;

            txtFundperj.IsReadOnly = false;

            txtFunperj.IsReadOnly = false;

            txtFunarpen.IsReadOnly = false;

            txtPmcmv.IsReadOnly = false;

            txtIss.IsReadOnly = false;

            txtMutua.IsReadOnly = false;

            txtAcoterj.IsReadOnly = false;

            txtDistribuicao.IsReadOnly = false;

            txtIndisponibilidade.IsReadOnly = false;

            txtTarifa.IsReadOnly = false;

            txtTotal.IsReadOnly = false;
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

        private void DigitarSomenteNumerosEmReaisComVirgual(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
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




        private void txtNatureza_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtEscrevente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void datePickerDataPratica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtLivro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFlsInicial_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFlsFinal_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNumeroAto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtProtocolo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtRecibo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbAtribuicao_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtTipoCobranca_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbConvenio_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtPrenot_Apont_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtPrenot_Apont.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtPrenot_Apont.Text.IndexOf(",");

                if (indexVirgula + 3 == txtPrenot_Apont.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtEmolumentos_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtEmolumentos.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtEmolumentos.Text.IndexOf(",");

                if (indexVirgula + 3 == txtEmolumentos.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFetj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtFetj.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtFetj.Text.IndexOf(",");

                if (indexVirgula + 3 == txtFetj.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFundperj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtFundperj.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtFundperj.Text.IndexOf(",");

                if (indexVirgula + 3 == txtFundperj.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFunperj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtFunperj.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtFunperj.Text.IndexOf(",");

                if (indexVirgula + 3 == txtFunperj.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFunarpen_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtFunarpen.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtFunarpen.Text.IndexOf(",");

                if (indexVirgula + 3 == txtFunarpen.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtPmcmv_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtPmcmv.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtPmcmv.Text.IndexOf(",");

                if (indexVirgula + 3 == txtPmcmv.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtIss_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtIss.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtIss.Text.IndexOf(",");

                if (indexVirgula + 3 == txtIss.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtMutua_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtMutua.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtMutua.Text.IndexOf(",");

                if (indexVirgula + 3 == txtMutua.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtAcoterj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtAcoterj.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtAcoterj.Text.IndexOf(",");

                if (indexVirgula + 3 == txtAcoterj.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtDistribuicao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtDistribuicao.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtDistribuicao.Text.IndexOf(",");

                if (indexVirgula + 3 == txtDistribuicao.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtIndisponibilidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtIndisponibilidade.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtIndisponibilidade.Text.IndexOf(",");

                if (indexVirgula + 3 == txtIndisponibilidade.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtTarifa_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtTarifa.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtTarifa.Text.IndexOf(",");

                if (indexVirgula + 3 == txtTarifa.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtTotal_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtTotal.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtTotal.Text.IndexOf(",");

                if (indexVirgula + 3 == txtTotal.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtPrenot_Apont_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPrenot_Apont.Text == "0,00")
                txtPrenot_Apont.Text = "";
            else
                txtPrenot_Apont.SelectAll();
        }

        private void txtPrenot_Apont_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPrenot_Apont.Text == "" || txtPrenot_Apont.Text == ",")
                txtPrenot_Apont.Text = "0,00";
            else
                txtPrenot_Apont.Text = string.Format("{0:n2}", Convert.ToDecimal(txtPrenot_Apont.Text));
        }

        private void txtEmolumentos_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmolumentos.Text == "0,00")
                txtEmolumentos.Text = "";
            else
                txtEmolumentos.SelectAll();
        }

        private void txtEmolumentos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmolumentos.Text == "" || txtEmolumentos.Text == ",")
                txtEmolumentos.Text = "0,00";
            else
                txtEmolumentos.Text = string.Format("{0:n2}", Convert.ToDecimal(txtEmolumentos.Text));
        }

        private void txtFetj_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFetj.Text == "0,00")
                txtFetj.Text = "";
            else
                txtFetj.SelectAll();
        }

        private void txtFetj_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFetj.Text == "" || txtFetj.Text == ",")
                txtFetj.Text = "0,00";
            else
                txtFetj.Text = string.Format("{0:n2}", Convert.ToDecimal(txtFetj.Text));
        }

        private void txtFundperj_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFundperj.Text == "0,00")
                txtFundperj.Text = "";
            else
                txtFundperj.SelectAll();
        }

        private void txtFundperj_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFundperj.Text == "" || txtFundperj.Text == ",")
                txtFundperj.Text = "0,00";
            else
                txtFundperj.Text = string.Format("{0:n2}", Convert.ToDecimal(txtFundperj.Text));
        }

        private void txtFunperj_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFunperj.Text == "0,00")
                txtFunperj.Text = "";
            else
                txtFunperj.SelectAll();
        }

        private void txtFunperj_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFunperj.Text == "" || txtFunperj.Text == ",")
                txtFunperj.Text = "0,00";
            else
                txtFunperj.Text = string.Format("{0:n2}", Convert.ToDecimal(txtFunperj.Text));
        }

        private void txtFunarpen_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFunarpen.Text == "0,00")
                txtFunarpen.Text = "";
            else
                txtFunarpen.SelectAll();
        }

        private void txtFunarpen_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFunarpen.Text == "" || txtFunarpen.Text == ",")
                txtFunarpen.Text = "0,00";
            else
                txtFunarpen.Text = string.Format("{0:n2}", Convert.ToDecimal(txtFunarpen.Text));
        }

        private void txtPmcmv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPmcmv.Text == "0,00")
                txtPmcmv.Text = "";
            else
                txtPmcmv.SelectAll();
        }

        private void txtPmcmv_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPmcmv.Text == "" || txtPmcmv.Text == ",")
                txtPmcmv.Text = "0,00";
            else
                txtPmcmv.Text = string.Format("{0:n2}", Convert.ToDecimal(txtPmcmv.Text));
        }

        private void txtIss_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtIss.Text == "0,00")
                txtIss.Text = "";
            else
                txtIss.SelectAll();
        }

        private void txtIss_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtIss.Text == "" || txtIss.Text == ",")
                txtIss.Text = "0,00";
            else
                txtIss.Text = string.Format("{0:n2}", Convert.ToDecimal(txtIss.Text));
        }

        private void txtMutua_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtMutua.Text == "0,00")
                txtMutua.Text = "";
            else
                txtMutua.SelectAll();
        }

        private void txtMutua_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtMutua.Text == "" || txtMutua.Text == ",")
                txtMutua.Text = "0,00";
            else
                txtMutua.Text = string.Format("{0:n2}", Convert.ToDecimal(txtMutua.Text));
        }

        private void txtAcoterj_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAcoterj.Text == "0,00")
                txtAcoterj.Text = "";
            else
                txtAcoterj.SelectAll();
        }

        private void txtAcoterj_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtAcoterj.Text == "" || txtAcoterj.Text == ",")
                txtAcoterj.Text = "0,00";
            else
                txtAcoterj.Text = string.Format("{0:n2}", Convert.ToDecimal(txtAcoterj.Text));
        }

        private void txtDistribuicao_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDistribuicao.Text == "0,00")
                txtDistribuicao.Text = "";
            else
                txtDistribuicao.SelectAll();
        }

        private void txtDistribuicao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDistribuicao.Text == "" || txtDistribuicao.Text == ",")
                txtDistribuicao.Text = "0,00";
            else
                txtDistribuicao.Text = string.Format("{0:n2}", Convert.ToDecimal(txtDistribuicao.Text));
        }

        private void txtIndisponibilidade_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtIndisponibilidade.Text == "0,00")
                txtIndisponibilidade.Text = "";
            else
                txtIndisponibilidade.SelectAll();
        }

        private void txtIndisponibilidade_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtIndisponibilidade.Text == "" || txtIndisponibilidade.Text == ",")
                txtIndisponibilidade.Text = "0,00";
            else
                txtIndisponibilidade.Text = string.Format("{0:n2}", Convert.ToDecimal(txtIndisponibilidade.Text));
        }

        private void txtTarifa_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtTarifa.Text == "0,00")
                txtTarifa.Text = "";
            else
                txtTarifa.SelectAll();
        }

        private void txtTarifa_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTarifa.Text == "" || txtTarifa.Text == ",")
                txtTarifa.Text = "0,00";
            else
                txtTarifa.Text = string.Format("{0:n2}", Convert.ToDecimal(txtTarifa.Text));
        }

        private void txtTotal_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtTotal.Text == "0,00")
                txtTotal.Text = "";
            else
                txtTotal.SelectAll();
        }

        private void txtTotal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTotal.Text == "" || txtTotal.Text == ",")
                txtTotal.Text = "0,00";
            else
                txtTotal.Text = string.Format("{0:n2}", Convert.ToDecimal(txtTotal.Text));
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_seloSelecionado.Status == "BAIXADO")
                {
                    var selo = _AppServicoSelos.GetById(_seloSelecionado.SeloId);

                    selo.Natureza = txtNatureza.Text.Trim();

                    selo.Escrevente = txtEscrevente.Text.Trim();

                    selo.Matricula = txtMatricula.Text.Trim();

                    selo.Livro = txtLivro.Text.Trim();

                    if (txtFlsInicial.Text != "")
                       selo.FolhaInicial = Convert.ToInt32(txtFlsInicial.Text);

                    if (txtFlsFinal.Text != "")
                        selo.FolhaFinal = Convert.ToInt32(txtFlsFinal.Text);

                    if (txtNumeroAto.Text != "")
                        selo.NumeroAto = Convert.ToInt32(txtNumeroAto.Text);

                    if (txtProtocolo.Text != "")
                         selo.Protocolo = Convert.ToInt32(txtProtocolo.Text);

                    if (txtRecibo.Text != "")
                         selo.Recibo = Convert.ToInt32(txtRecibo.Text);

                    if (datePickerDataPratica.SelectedDate != null)
                        selo.DataPratica = datePickerDataPratica.SelectedDate.Value.Date;

                    if (txtCodigo.Text != "")
                         selo.Codigo = Convert.ToInt32(txtCodigo.Text);

                    if(cmbAtribuicao.SelectedIndex > -1)
                    selo.Atribuicao = ((Atribuicoes)cmbAtribuicao.SelectedItem).Codigo;


                    selo.TipoCobranca = txtTipoCobranca.Text;

                    if (cmbConvenio.SelectedIndex == 0)
                        selo.Convenio = "S";

                    if (cmbConvenio.SelectedIndex == 1)
                        selo.Convenio = "N";

                    if (txtPrenot_Apont.Text != "")
                    selo.Prenotacao = Convert.ToDecimal(txtPrenot_Apont.Text);

                    if (txtEmolumentos.Text != "")
                        selo.Emolumentos = Convert.ToDecimal(txtEmolumentos.Text);

                    if (txtFetj.Text != "")
                        selo.Fetj = Convert.ToDecimal(txtFetj.Text);


                    if (txtFundperj.Text != "")
                        selo.Fundperj = Convert.ToDecimal(txtFundperj.Text);
                    
                    if (txtFunperj.Text != "")
                        selo.Funperj = Convert.ToDecimal(txtFunperj.Text);

                  
                    if (txtFunarpen.Text != "")
                        selo.Funarpen = Convert.ToDecimal(txtFunarpen.Text);

                    if (txtPmcmv.Text != "")
                        selo.Pmcmv = Convert.ToDecimal(txtPmcmv.Text);
                    
                    if (txtIss.Text != "")
                        selo.Iss = Convert.ToDecimal(txtIss.Text);
                    
                    if (txtMutua.Text != "")
                        selo.Mutua = Convert.ToDecimal(txtMutua.Text);
                    
                    if (txtAcoterj.Text != "")
                        selo.Acoterj = Convert.ToDecimal(txtAcoterj.Text);
                    
                    if (txtDistribuicao.Text != "")
                        selo.Distribuicao = Convert.ToDecimal(txtDistribuicao.Text);
                    
                    if (txtIndisponibilidade.Text != "")
                        selo.Indisponibilidade = Convert.ToDecimal(txtIndisponibilidade.Text);

                    if (txtTarifa.Text != "")
                        selo.TarifaBancaria = Convert.ToDecimal(txtTarifa.Text);
                    
                    if (txtTotal.Text != "")
                        selo.Total = Convert.ToDecimal(txtTotal.Text);

                    _AppServicoSelos.Update(selo);

                    SalvarLogSistema(string.Format("Alterou o Selo Baixado {0} {1} {2}", selo.Letra, selo.Numero, selo.Aleatorio));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        private void cmbAtribuicao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Atribuicoes atribuicao = (Atribuicoes)cmbAtribuicao.SelectedItem;

            if (atribuicao.Descricao == "RGI" || atribuicao.Descricao == "PROTESTO")
            {
                txtPrenot_Apont.IsEnabled = true;
                if (atribuicao.Descricao == "RGI")
                    lblPronot_Apont.Content = "Prenotação:";
                else
                    lblPronot_Apont.Content = "Apontamento:";
            }
            else
            {
                txtPrenot_Apont.Text = "0,00";
                txtPrenot_Apont.IsEnabled = false;
                lblPronot_Apont.Content = "Prenot./Apont.:";
            }
        }


        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Detalhes Do Selo";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }

    }
}
