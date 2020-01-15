using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
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
    /// Lógica interna para Complemento.xaml
    /// </summary>
    public partial class Complemento : Window
    {

        Escrituras _escritura;
        CadProcuracao _procuracao;
        CadTestamento _testamento;
        Cs_Notas.Dominio.Entities.Usuario _usuario;
        Selos seloCCT = new Selos();
        bool salvarCCT = false;
        decimal alicotaIss;
        private readonly IAppServicoComplementos _IAppServicoComplementos = BootStrap.Container.GetInstance<IAppServicoComplementos>();
        private readonly IAppServicoSelos _IAppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoParametros _IAppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();



        public Complemento(CadTestamento testamento, Cs_Notas.Dominio.Entities.Usuario usuario)
        {
            _testamento = testamento;
            _usuario = usuario;
            seloCCT = _IAppServicoSelos.ReservarSelosCCT(1, "COMPLEMENTO DE EMOLUMENTOS", _usuario.UsuarioId, _usuario.Nome, DateTime.Now.Date, 2, _testamento.Livro, _testamento.FolhaInicio, _testamento.FolhaFim, _testamento.NumeroAto).FirstOrDefault();
            InitializeComponent();
        }

        public Complemento(CadProcuracao procuracao, Cs_Notas.Dominio.Entities.Usuario usuario)
        {
            _procuracao = procuracao;
            _usuario = usuario;
            seloCCT = _IAppServicoSelos.ReservarSelosCCT(1, "COMPLEMENTO DE EMOLUMENTOS", _usuario.UsuarioId, _usuario.Nome, DateTime.Now.Date, 2, _procuracao.Livro, _procuracao.FolhaInicio, _procuracao.FolhaFim, _procuracao.NumeroAto).FirstOrDefault();
            InitializeComponent();
        }

        public Complemento(Escrituras escritura, Cs_Notas.Dominio.Entities.Usuario usuario)
        {
            _escritura = escritura;
            _usuario = usuario;
            seloCCT = _IAppServicoSelos.ReservarSelosCCT(1, "COMPLEMENTO DE EMOLUMENTOS", _usuario.UsuarioId, _usuario.Nome, DateTime.Now.Date, 2, escritura.LivroEscritura, escritura.FolhasInicio, escritura.FolhasFim, escritura.NumeroAto).FirstOrDefault();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (seloCCT == null)
            {
                MessageBox.Show("Não foi possível reservar um selo CCT, favor verifique se existe selo CCT disponível.", "Selo CCT", MessageBoxButton.OK, MessageBoxImage.Stop);
                this.Close();
            }
            alicotaIss = _IAppServicoParametros.GetById(1).AlicotaIss;
            CarregarCampos();

            seloCCT.DataReservado = DateTime.Now.Date;
        }

        private void btnSalvarSair_Click(object sender, RoutedEventArgs e)
        {
            salvarCCT = true;

            var complemto = new Complementos();

            if (dtDataAto.SelectedDate != null)
                complemto.Data = dtDataAto.SelectedDate.Value;
            else
            {
                MessageBox.Show("Preencha a Data.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            complemto.Cct = txtSelo.Text;


            switch (cmbTipoCustas.SelectedIndex)
            {

                case 0:
                    complemto.TipoCobranca = "JG";
                    break;

                case 1:
                    complemto.TipoCobranca = "CC";
                    break;

                case 2:
                    complemto.TipoCobranca = "SC";
                    break;

                case 3:
                    complemto.TipoCobranca = "NH";
                    break;

                default:
                    break;
            }




            if (_escritura != null)
            {
                complemto.DataPratica = _escritura.DataAtoRegistro;

                if (txtLivro.Text != "")
                    complemto.Livro = Convert.ToInt32(_escritura.LivroEscritura);

                complemto.FolhaInicio = _escritura.FolhasInicio;

                complemto.FolhaFim = _escritura.FolhasFim;

                complemto.NumeroAto = _escritura.NumeroAto;

                complemto.Selo = _escritura.SeloEscritura;

                complemto.Aleatorio = _escritura.Aleatorio;

                complemto.IdEscritura = _escritura.EscriturasId;

                seloCCT.Livro = _escritura.LivroEscritura;

                seloCCT.FolhaInicial = _escritura.FolhasInicio;

                seloCCT.FolhaFinal = _escritura.FolhasFim;

                seloCCT.NumeroAto = _escritura.NumeroAto;

                seloCCT.IdAto = _escritura.EscriturasId;
            }


            if (_procuracao != null)
            {
                complemto.DataPratica = _procuracao.DataLavratura;

                if (txtLivro.Text != "")
                    complemto.Livro = Convert.ToInt32(_procuracao.Livro);

                complemto.FolhaInicio = _procuracao.FolhaInicio;

                complemto.FolhaFim = _procuracao.FolhaFim;

                complemto.NumeroAto = _procuracao.NumeroAto;

                complemto.Selo = _procuracao.Selo;

                complemto.Aleatorio = _procuracao.Aleatorio;

                complemto.IdProcuracao = _procuracao.ProcuracaoId;

                seloCCT.Livro = _procuracao.Livro;

                seloCCT.FolhaInicial = _procuracao.FolhaInicio;

                seloCCT.FolhaFinal = _procuracao.FolhaFim;

                seloCCT.NumeroAto = _procuracao.NumeroAto;

                seloCCT.IdAto = _procuracao.ProcuracaoId;
            }



            complemto.Emolumentos = Convert.ToDecimal(txtEmolumentos.Text);

            complemto.Fetj = Convert.ToDecimal(txtFetj.Text);

            complemto.Fundperj = Convert.ToDecimal(txtFundperj.Text);

            complemto.Funprj = Convert.ToDecimal(txtFunperj.Text);

            complemto.Funarpen = Convert.ToDecimal(txtFunarpen.Text);

            complemto.Pmcmv = Convert.ToDecimal(txtPmcmv.Text);

            complemto.Iss = Convert.ToDecimal(txtIss.Text);

            complemto.Total = Convert.ToDecimal(txtTotal.Text);

            complemto.NomeEscrevente = _usuario.Nome;

            complemto.CpfEscrevente = _usuario.Cpf;

            complemto.Enviado = "N";


            _IAppServicoComplementos.Add(complemto);





            seloCCT.Sistema = "NOTAS";

            seloCCT.Reservado = "N";

            seloCCT.Status = "UTILIZADO";

            seloCCT.IdUsuarioReservado = _usuario.UsuarioId;

            seloCCT.UsuarioReservado = _usuario.Nome;

            seloCCT.FormReservado = "COMPLEMENTO";

            seloCCT.FormUtilizado = "COMPLEMENTO";

            seloCCT.Atribuicao = 2;

            seloCCT.DataPratica = DateTime.Now.Date;


            seloCCT.Codigo = 2037;

            seloCCT.Conjunto = "N";

            seloCCT.Natureza = "COMPLEMENTO DE EMOLUMENTOS";

            seloCCT.Escrevente = _usuario.Nome;

            seloCCT.Convenio = "N";

            switch (cmbTipoCustas.SelectedIndex)
            {

                case 0:
                    seloCCT.TipoCobranca = "JG";
                    break;

                case 1:
                    seloCCT.TipoCobranca = "CC";
                    break;

                case 2:
                    seloCCT.TipoCobranca = "SC";
                    break;

                case 3:
                    seloCCT.TipoCobranca = "NH";
                    break;

                default:
                    break;
            }

            seloCCT.Emolumentos = Convert.ToDecimal(txtEmolumentos.Text);
            seloCCT.Fetj = Convert.ToDecimal(txtFetj.Text);
            seloCCT.Fundperj = Convert.ToDecimal(txtFundperj.Text);
            seloCCT.Funperj = Convert.ToDecimal(txtFunperj.Text);
            seloCCT.Funarpen = Convert.ToDecimal(txtFunarpen.Text);
            seloCCT.Pmcmv = Convert.ToDecimal(txtPmcmv.Text);
            seloCCT.Iss = Convert.ToDecimal(txtIss.Text);
            seloCCT.Iss = Convert.ToDecimal(txtIss.Text);
            seloCCT.Total = Convert.ToDecimal(txtTotal.Text);


            this.Close();
        }

        private void CarregarCampos()
        {
            if (_escritura != null)
            {
                dtDataAto.SelectedDate = DateTime.Now.Date;
                txtLivro.Text = _escritura.LivroEscritura;
                txtFlsIni.Text = string.Format("{0:000}", _escritura.FolhasInicio);
                txtFlsFim.Text = string.Format("{0:000}", _escritura.FolhasFim);
                txtAto.Text = string.Format("{0:000}", _escritura.NumeroAto);
                txtSelo.Text = string.Format("{0}{1}", seloCCT.Letra, seloCCT.Numero);
            }

            if (_procuracao != null)
            {
                dtDataAto.SelectedDate = DateTime.Now.Date;
                txtLivro.Text = _procuracao.Livro;
                txtFlsIni.Text = string.Format("{0:000}", _procuracao.FolhaInicio);
                txtFlsFim.Text = string.Format("{0:000}", _procuracao.FolhaFim);
                txtAto.Text = string.Format("{0:000}", _procuracao.NumeroAto);
                txtSelo.Text = string.Format("{0}{1}", seloCCT.Letra, seloCCT.Numero);
            }

            if (_testamento != null)
            {
                dtDataAto.SelectedDate = DateTime.Now.Date;
                txtLivro.Text = _testamento.Livro;
                txtFlsIni.Text = string.Format("{0:000}", _testamento.FolhaInicio);
                txtFlsFim.Text = string.Format("{0:000}", _testamento.FolhaFim);
                txtAto.Text = string.Format("{0:000}", _testamento.NumeroAto);
                txtSelo.Text = string.Format("{0}{1}", seloCCT.Letra, seloCCT.Numero);
            }

        }


        private void cmbTipoCustas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularEmolumentos();
        }


        public void CalcularEmolumentos()
        {
            decimal emol = 0;
            decimal fetj_20 = 0;
            decimal fundperj_5 = 0;
            decimal funperj_5 = 0;
            decimal funarpen_4 = 0;
            decimal pmcmv_2 = 0;
            decimal iss = 0;

            string Semol = "0,00";
            string Sfetj_20 = "0,00";
            string Sfundperj_5 = "0,00";
            string Sfunperj_5 = "0,00";
            string Sfunarpen_4 = "0,00";
            string Spmcmv_2 = "0,00";
            string Siss = "0,00";
            int index;

            try
            {

                emol = Convert.ToDecimal(txtEmolumentos.Text);

                fetj_20 = emol * 20 / 100;
                fundperj_5 = emol * 5 / 100;
                funperj_5 = emol * 5 / 100;
                funarpen_4 = emol * 4 / 100;

                iss = (100 - alicotaIss) / 100;
                iss = emol / iss - emol;

                pmcmv_2 = Convert.ToDecimal(emol * 2) / 100;

                if (cmbTipoCustas.SelectedIndex == 1 || cmbTipoCustas.SelectedIndex == 4)
                {
                    Semol = Convert.ToString(emol);
                }

                Sfetj_20 = Convert.ToString(fetj_20);
                Sfundperj_5 = Convert.ToString(fundperj_5);
                Sfunperj_5 = Convert.ToString(funperj_5);
                Sfunarpen_4 = Convert.ToString(funarpen_4);
                Siss = Convert.ToString(iss);
                Spmcmv_2 = Convert.ToString(pmcmv_2);



                if (cmbTipoCustas.SelectedIndex == 0 || cmbTipoCustas.SelectedIndex == 2)
                {
                    emol = 0;
                    fetj_20 = 0;
                    fundperj_5 = 0;
                    funperj_5 = 0;
                    funarpen_4 = 0;
                    iss = 0;
                    pmcmv_2 = 0;

                    Semol = "0,00";
                    Sfetj_20 = "0,00";
                    Sfundperj_5 = "0,00";
                    Sfunperj_5 = "0,00";
                    Sfunarpen_4 = "0,00";
                    Spmcmv_2 = "0,00";
                    Siss = "0,00";
                }

                if (cmbTipoCustas.SelectedIndex == 4)
                {
                    fetj_20 = 0;
                    fundperj_5 = 0;
                    funperj_5 = 0;
                    funarpen_4 = 0;
                    Sfetj_20 = "0,00";
                    Sfundperj_5 = "0,00";
                    Sfunperj_5 = "0,00";
                    Sfunarpen_4 = "0,00";
                }

                index = Semol.IndexOf(',');
                Semol = Semol.Substring(0, index + 3);

                index = Sfetj_20.IndexOf(',');
                Sfetj_20 = Sfetj_20.Substring(0, index + 3);

                index = Sfundperj_5.IndexOf(',');
                Sfundperj_5 = Sfundperj_5.Substring(0, index + 3);

                index = Sfunperj_5.IndexOf(',');
                Sfunperj_5 = Sfunperj_5.Substring(0, index + 3);

                index = Sfunarpen_4.IndexOf(',');
                Sfunarpen_4 = Sfunarpen_4.Substring(0, index + 3);

                index = Siss.IndexOf(',');
                Siss = Siss.Substring(0, index + 3);

                index = Spmcmv_2.IndexOf(',');
                Spmcmv_2 = Spmcmv_2.Substring(0, index + 3);

                txtEmolumentos.Text = Semol;
                txtFetj.Text = Sfetj_20;
                txtFundperj.Text = Sfundperj_5;
                txtFunperj.Text = Sfunperj_5;
                txtFunarpen.Text = Sfunarpen_4;
                txtIss.Text = Siss;
                txtPmcmv.Text = Spmcmv_2;


                txtTotal.Text = string.Format("{0:n2}", Convert.ToDecimal(Semol) + Convert.ToDecimal(Sfetj_20) + Convert.ToDecimal(Sfundperj_5) + Convert.ToDecimal(Sfundperj_5) +
                    Convert.ToDecimal(Sfunarpen_4) + Convert.ToDecimal(Siss) + Convert.ToDecimal(Spmcmv_2));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public void CalcularBotaoTotal()
        {

            if (txtEmolumentos.Text == "")
                txtEmolumentos.Text = "0,00";

            if (txtFetj.Text == "")
                txtFetj.Text = "0,00";

            if (txtFundperj.Text == "")
                txtFundperj.Text = "0,00";

            if (txtFunperj.Text == "")
                txtFunperj.Text = "0,00";

            if (txtFunarpen.Text == "")
                txtFunarpen.Text = "0,00";

            if (txtIss.Text == "")
                txtIss.Text = "0,00";

            if (txtPmcmv.Text == "")
                txtPmcmv.Text = "0,00";




            txtTotal.Text = string.Format("{0:n2}", Convert.ToDecimal(txtEmolumentos.Text) + Convert.ToDecimal(txtFetj.Text) + Convert.ToDecimal(txtFundperj.Text) + Convert.ToDecimal(txtFunperj.Text) +
                    Convert.ToDecimal(txtFunarpen.Text) + Convert.ToDecimal(txtIss.Text) + Convert.ToDecimal(txtPmcmv.Text));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (salvarCCT == true)
            {
                _IAppServicoSelos.SalvarSeloModificado(seloCCT);
            }
            else
            {
                _IAppServicoSelos.LiberarSelos(seloCCT);
                _IAppServicoSelos.SalvarSeloModificado(seloCCT);
            }
        }






        //---------------------Digitar em reais no textBox-------------------------

        private void GotFocusText(object sender, RoutedEventArgs e, TextBox textBox)
        {
            if (textBox.Text == "0,00")
                textBox.Text = "";
            else
                textBox.SelectAll();
        }

        private void LostFocusText(object sender, RoutedEventArgs e, TextBox textBox)
        {
            if (textBox.Text == "")
                textBox.Text = "0,00";
            else
                textBox.Text = string.Format("{0:n2}", Convert.ToDecimal(textBox.Text));

        }


        private void DigitarEmReais(object sender, KeyEventArgs e, TextBox textBox)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!textBox.Text.Contains(",") || textBox.SelectionLength == textBox.Text.Length)
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = textBox.Text.IndexOf(",");

                if (indexVirgula + 3 == textBox.Text.Length)
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

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        //---------------------Digitar em reais no textBox------------------------------------------------


        //--------------------Controles TextBox Custas---------------------------------------------------

        private void txtEmolumentos_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtEmolumentos);
        }

        private void txtEmolumentos_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtEmolumentos);

            CalcularEmolumentos();
        }


        private void txtEmolumentos_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtEmolumentos);

        }

        private void txtFetj_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtFetj);
        }

        private void txtFetj_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtFetj);
            CalcularBotaoTotal();
        }

        private void txtFetj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtFetj);
        }

        private void txtFundperj_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtFundperj);
        }

        private void txtFundperj_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtFundperj);
            CalcularBotaoTotal();
        }

        private void txtFundperj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtFundperj);
        }

        private void txtFunperj_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtFunperj);
        }

        private void txtFunperj_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtFunperj);
            CalcularBotaoTotal();
        }

        private void txtFunperj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtFunperj);
        }

        private void txtFunarpen_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtFunarpen);
        }

        private void txtFunarpen_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtFunarpen);
            CalcularBotaoTotal();
        }

        private void txtFunarpen_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtFunarpen);
        }

        private void txtPmcmv_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtPmcmv);
        }

        private void txtPmcmv_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtPmcmv);
            CalcularBotaoTotal();
        }

        private void txtPmcmv_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtPmcmv);
        }

        private void txtIss_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtIss);
        }

        private void txtIss_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtIss);
            CalcularBotaoTotal();
        }

        private void txtIss_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtIss);
        }

        private void txtTotal_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtTotal);
        }

        private void txtTotal_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtTotal);
        }

        private void txtTotal_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtTotal);
        }



        //--------------------Controles TextBox Custas---------------------------------------------------
































    }
}
