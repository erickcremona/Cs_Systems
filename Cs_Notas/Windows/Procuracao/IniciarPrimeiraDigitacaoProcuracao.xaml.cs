using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.ValuesObject;
using Cs_Notas.WindowsAgurde;
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

namespace Cs_Notas.Windows.Procuracao
{
    /// <summary>
    /// Lógica interna para IniciarPrimeiraDigitacaoProcuracao.xaml
    /// </summary>
    public partial class IniciarPrimeiraDigitacaoProcuracao : Window
    {

        List<Selos> _selos;
        CadProcuracao _cadProcuracao = new CadProcuracao();
        Cs_Notas.Dominio.Entities.Usuario _usuario;
        List<TabelaCustas> listaTabelaCustas = new List<TabelaCustas>();
        List<Cs_Notas.Dominio.Entities.Usuario> escreventes = new List<Cs_Notas.Dominio.Entities.Usuario>();
        List<AtoConjuntos> listaAtoConjuntos = new List<AtoConjuntos>();
        List<AtoConjuntos> listaAtos = new List<AtoConjuntos>();
        List<TabelaCustas> tabelaCustas = new List<TabelaCustas>();
        TiposProcuracao tiposProcuracao = new TiposProcuracao();
        LocalProcuracao localProcuracão = new LocalProcuracao();

        int Ano;
        List<int> anosCustasExistentes = new List<int>();

        private readonly IAppServicoTabelaCustas _AppServicoTabelaCustas = BootStrap.Container.GetInstance<IAppServicoTabelaCustas>();
        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();

        Principal _principal;



        public IniciarPrimeiraDigitacaoProcuracao(List<Selos> selos, Cs_Notas.Dominio.Entities.Usuario usuario, Principal principal)
        {
            _selos = selos;
            _usuario = usuario;
            _principal = principal;
            InitializeComponent();
        }

        private void btnSalvarSair_Click(object sender, RoutedEventArgs e)
        {

            List<string> listaPreencher = ConferirPreenchimentoDosCampos();

            if (listaPreencher.Count > 0)
            {
                string msgReservado = "Campo(s) de Preenchimento obrigatório encontrado(s): \n \n";

                foreach (var item in listaPreencher)
                {
                    msgReservado += string.Format("{0}\n", item);

                }


                if (listaPreencher.Count > 0)
                {
                    MessageBox.Show(msgReservado, "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
            }

            _cadProcuracao.Tipo = ((TiposProcuracao)cmbTipoProcuracao.SelectedItem).Sigla;

            _cadProcuracao.Local = ((LocalProcuracao)cmbLocalProcuracao.SelectedItem).Sigla;

            if (_cadProcuracao.Local == "O")
                _cadProcuracao.OutrosLocal = txtOutrosLocal.Text;

            _cadProcuracao.Selo = txtSelo.Text;

            _cadProcuracao.Aleatorio = txtAleatorio.Text;

            _cadProcuracao.Livro = txtLivro.Text;

            if (txtFlsIni.Text != "")
                _cadProcuracao.FolhaInicio = Convert.ToInt32(txtFlsIni.Text);

            if (txtFlsFim.Text != "")
                _cadProcuracao.FolhaFim = Convert.ToInt32(txtFlsFim.Text);

            if (txtAto.Text != "")
                _cadProcuracao.NumeroAto = Convert.ToInt32(txtAto.Text);

            if (dtDataAto.SelectedDate != null)
                _cadProcuracao.DataLavratura = dtDataAto.SelectedDate.Value;

            _cadProcuracao.TipoAto = "RP";


            _cadProcuracao.CpfEscrevente = ((Cs_Notas.Dominio.Entities.Usuario)cmbEscreventes.SelectedItem).Cpf;

            _cadProcuracao.Login = ((Cs_Notas.Dominio.Entities.Usuario)cmbEscreventes.SelectedItem).Nome;

            _cadProcuracao.DataModificado = DateTime.Now.Date;

            _cadProcuracao.HoraModificado = DateTime.Now.ToLongTimeString();

            TabelaCustas tabela = (TabelaCustas)cmbTabelaAtos.SelectedItem;

            switch (tabela.SubItem)
            {
                case "A":
                    _cadProcuracao.Codigo = 2388;
                    break;

                case "B":
                    _cadProcuracao.Codigo = 2389;
                    break;

                case "C":
                    _cadProcuracao.Codigo = 2390;
                    break;

                case "D":
                    _cadProcuracao.Codigo = 2391;
                    break;

                default:

                    break;
            }
            
            _cadProcuracao.Cancelado = "N";

            _cadProcuracao.Enviado = "N";

            var aguarde = new AgurardeSalvandoProcuracao(_cadProcuracao, listaAtoConjuntos, _principal, _usuario, _selos);
            this.Close();
            aguarde.Owner = _principal;
            aguarde.ShowDialog();
        }


        private List<string> ConferirPreenchimentoDosCampos()
        {
            var naoPreenchido = new List<string>();

            if (cmbTabelaAtos.SelectedItem == null)
                naoPreenchido.Add("Tabela de Atos;");

            if (cmbTipoProcuracao.SelectedItem == null)
                naoPreenchido.Add("Tipo da Procuração;");

            if (cmbLocalProcuracao.SelectedItem == null)
                naoPreenchido.Add("Local;");

            if (cmbLocalProcuracao.SelectedIndex == 2 && txtOutrosLocal.Text == "")
                naoPreenchido.Add("Outros;");

            if (dtDataAto.SelectedDate == null)
                naoPreenchido.Add("Data;");


            if (cmbEscreventes.SelectedItem == null)
                naoPreenchido.Add("Escrevente;");



            return naoPreenchido;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ano = _selos.FirstOrDefault().DataReservado.Date.Year;

            listaTabelaCustas = _AppServicoTabelaCustas.GetAll().ToList();

            anosCustasExistentes = listaTabelaCustas.Select(p => p.Ano).Distinct().ToList();

            CarregarComboBoxTabelaAtos();

            CarregarEscreventes();

            CarregarDadosSelo();

            CarregarTipoProcuracao();

            CarregarLocalProcuracao();
        }


        private void CarregarLocalProcuracao()
        {
            cmbLocalProcuracao.ItemsSource = localProcuracão.ObterListaLocalProcuracao();

            cmbLocalProcuracao.DisplayMemberPath = "Descricao";

            cmbLocalProcuracao.SelectedIndex = 0;
        }

        private void CarregarTipoProcuracao()
        {

            cmbTipoProcuracao.ItemsSource = tiposProcuracao.ObterListaTiposProcuracao();

            cmbTipoProcuracao.DisplayMemberPath = "Descricao";

            cmbTipoProcuracao.SelectedIndex = 0;
        }



        private void CarregarEscreventes()
        {
            try
            {
                escreventes = _AppServicoUsuario.GetAll().OrderBy(p => p.Nome).ToList();
                cmbEscreventes.ItemsSource = escreventes;
                cmbEscreventes.DisplayMemberPath = "Nome";
                cmbEscreventes.SelectedValuePath = "UsuarioId";

                cmbEscreventes.SelectedValue = _selos.FirstOrDefault().IdUsuarioReservado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações de Escreventes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarDadosSelo()
        {
            try
            {
                dtDataAto.SelectedDate = _selos.FirstOrDefault().DataReservado;
                txtLivro.Text = _selos.FirstOrDefault().Livro;
                txtFlsIni.Text = string.Format("{0:000}", _selos.FirstOrDefault().FolhaInicial);
                txtFlsFim.Text = string.Format("{0:000}", _selos.FirstOrDefault().FolhaFinal);
                txtAto.Text = string.Format("{0:000}", _selos.FirstOrDefault().NumeroAto);
                txtSelo.Text = string.Format("{0}{1}", _selos.FirstOrDefault().Letra, _selos.FirstOrDefault().Numero);
                txtAleatorio.Text = _selos.FirstOrDefault().Aleatorio;


                for (int i = 0; i < _selos.Count; i++)
                {
                    var atoConjunto = new AtoConjuntos();
                    atoConjunto.IdEscritura = i + 1;
                    atoConjunto.ConjuntoId = i + 1;
                    atoConjunto.Selo = string.Format("{0}{1}", _selos[i].Letra, _selos[i].Numero);
                    atoConjunto.Aleatorio = _selos[i].Aleatorio;
                    atoConjunto.Ordem = i + 1;
                    atoConjunto.Data = _selos[i].DataReservado;
                    atoConjunto.Livro = _selos[i].Livro;
                    atoConjunto.Folhas = string.Format("{0}-{1}", _selos[i].FolhaInicial, _selos[i].FolhaFinal);
                    atoConjunto.Ato = string.Format("{0}", _selos[i].NumeroAto);
                    if (i == 0)
                        atoConjunto.TipoAto = "PRINCIPAL";
                    else
                    {
                        atoConjunto.TipoAto = "ATO CONJUNTO";
                        listaAtoConjuntos.Add(atoConjunto);
                    }
                    listaAtos.Add(atoConjunto);
                }


                dataGridAtoConjuntos.ItemsSource = listaAtoConjuntos;
                if (listaAtoConjuntos.Count > 0)
                    dataGridAtoConjuntos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar informações do Selo. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarComboBoxTabelaAtos()
        {
            try
            {
                tabelaCustas = listaTabelaCustas.Where(p => (p.Ano == Ano) && ((p.Tabela == "22" && p.Item == "2"))).OrderBy(p => p.Ordem).ToList();
                cmbTabelaAtos.ItemsSource = tabelaCustas;
                cmbTabelaAtos.DisplayMemberPath = "Descricao";

                cmbTabelaAtos.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar TABELA DE ATOS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbTabelaAtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridAtoConjuntos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }


        private void cmbLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbLocalProcuracao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLocalProcuracao.SelectedIndex == 2)
            {
                txtOutrosLocal.IsEnabled = true;
                txtOutrosLocal.Focus();
            }
            else
            {
                txtOutrosLocal.Text = "";
                txtOutrosLocal.IsEnabled = false;
            }
        }

    }
}
