using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.ValuesObject;
using Cs_Notas.Windows.Escritura;
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
    /// Lógica interna para DigitarProcuracao.xaml
    /// </summary>
    public partial class DigitarProcuracao : Window
    {
        public CadProcuracao _procuracao = new CadProcuracao();
        List<TabelaCustas> tabelaCustas = new List<TabelaCustas>();
        public List<TabelaCustas> listaTabelaCustas = new List<TabelaCustas>();
        public List<ItensCustas> listaItensCustas = new List<ItensCustas>();
        List<Cs_Notas.Dominio.Entities.Usuario> escreventes = new List<Cs_Notas.Dominio.Entities.Usuario>();
        public int Ano;
        public List<int> anosCustasExistentes = new List<int>();
        public Configuracoes configuracoes = new Configuracoes();
        public Cs_Notas.Dominio.Entities.Usuario _usuario;
        bool _chamadaInicial;
        decimal alicotaIss;
        public List<Participante> participantes = new List<Participante>();
        public List<Pessoas> listaPessoas = new List<Pessoas>();
        public List<Nomes> listaNomes = new List<Nomes>();
        public List<ParteConjuntos> listaParteConjuntos = new List<ParteConjuntos>();
        public List<AtoConjuntos> listaAtoConjuntos = new List<AtoConjuntos>();
        public List<AtoConjuntos> listaAtos = new List<AtoConjuntos>();
        List<Selos> _selo;
        TiposProcuracao tiposProc = new TiposProcuracao();
        List<TiposProcuracao> tiposProcuracao = new List<TiposProcuracao>();
        LocalProcuracao localProc = new LocalProcuracao();        
        List<LocalProcuracao> localProcuracao = new List<LocalProcuracao>();
        public Participante parte = new Participante();
        public string estado = string.Empty;
        bool _recalcular = false;
        List<ItensCustas> emolumentos = new List<ItensCustas>();
        List<string> Ufs = new List<string>();
        TipoLivroProcuracao tiposLivroProcuracao = new TipoLivroProcuracao();
        List<TipoLivroProcuracao> listaTiposLivroProcuracao = new List<TipoLivroProcuracao>();
        List<TipoLivroProcuracao> listaTiposLivroProcuracaoOrigem = new List<TipoLivroProcuracao>();
        public ServentiasOutras serventiasOutrasSelecionada;
        public List<ServentiasOutras> serventiasOutras;

        private readonly IAppServicoTabelaCustas _AppServicoTabelaCustas = BootStrap.Container.GetInstance<IAppServicoTabelaCustas>();
        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();
        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();
        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoParteConjuntos _AppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();
        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoMunicipios _AppServicoMunicipios = BootStrap.Container.GetInstance<IAppServicoMunicipios>();
        private readonly IAppServicoServentiasOutras _AppServicoServentiasOutras = BootStrap.Container.GetInstance<IAppServicoServentiasOutras>();

        public DigitarProcuracao(CadProcuracao procuracao, Cs_Notas.Dominio.Entities.Usuario usuario, bool chamadaInicial)
        {
            _procuracao = procuracao;
            _usuario = usuario;
            _chamadaInicial = chamadaInicial;
            InitializeComponent();
        }

        public DigitarProcuracao(List<Selos> selos, Cs_Notas.Dominio.Entities.Usuario usuario, bool chamadaInicial)
        {
            _selo = selos;
            _usuario = usuario;
            _chamadaInicial = chamadaInicial;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Ano = _procuracao.DataLavratura.Date.Year;

            listaTabelaCustas = _AppServicoTabelaCustas.GetAll().ToList();
            anosCustasExistentes = listaTabelaCustas.Select(p => p.Ano).Distinct().ToList();
            serventiasOutras = _AppServicoServentiasOutras.GetAll().ToList();
            configuracoes = _AppServicoConfiguracoes.GetById(1);
            alicotaIss = _AppServicoParametros.GetById(1).AlicotaIss;
            CarregarLocalProcuracao();
            CarregarTipoProcuracao();
            CarregarEscreventes();
            CarregarParticipantes();
            CarregarParteConjuntos();


            CarregarComboBoxTabelaAtos();

            CarregarUF();

            cmbPossuiBens.SelectedIndex = 1;

            CarregarTipoLivro();

            CarregarDadosProcuracao();

            CarregarDadosSelo();

            if (_chamadaInicial == true)
            {
                imgSair.Visibility = Visibility.Hidden;
                btnMinuta.IsEnabled = false;
            }

           



        }

        private void CarregarTipoLivro()
        {
            listaTiposLivroProcuracao = tiposLivroProcuracao.ObterTipoLivroProcuracao();

            listaTiposLivroProcuracaoOrigem = tiposLivroProcuracao.ObterTipoLivroProcuracaoOrigem();

            cmbTipoLivro.ItemsSource = listaTiposLivroProcuracao;
            cmbTipoLivro.DisplayMemberPath = "Descricao";
            cmbTipoLivro.SelectedIndex = 0;

            cmbTipoLivroOrigem.ItemsSource = listaTiposLivroProcuracaoOrigem;
            cmbTipoLivroOrigem.DisplayMemberPath = "Descricao";
            cmbTipoLivroOrigem.SelectedIndex = 0;
        }

        private void CarregarUF()
        {

            Ufs = _AppServicoMunicipios.ObterUfsDosMunicipios();

            cmbUfOrigem.ItemsSource = Ufs;

        }
        private void CarregarDadosProcuracao()
        {
            try
            {

                switch (_procuracao.Codigo)
                {
                    case 2388:
                        cmbTabelaAtos.SelectedIndex = 0;
                        break;

                    case 2389:
                        cmbTabelaAtos.SelectedIndex = 1;
                        break;

                    case 2390:
                        cmbTabelaAtos.SelectedIndex = 2;
                        break;

                    case 2391:
                        cmbTabelaAtos.SelectedIndex = 3;
                        break;

                    default:

                        break;
                }

                cmbTipoProcuracao.SelectedItem = tiposProcuracao.Where(p => p.Sigla == _procuracao.Tipo).FirstOrDefault();

                if (_procuracao.Tipo == "E")
                {
                    txtOutrosTipo.Text = _procuracao.DescricaoTipo;
                }

                if (_procuracao.Tipo == "D")
                {
                    txtSeloEscritura.Text = _procuracao.SeloEscritura;
                    txtAleatorioEscritura.Text = _procuracao.AleatorioEscritura;
                }

                cmbLocalPratica.SelectedItem = localProcuracao.Where(p => p.Sigla == _procuracao.Local).FirstOrDefault();

                if (_procuracao.Local == "O")
                    txtOutrosLocalPratica.Text = _procuracao.OutrosLocal;

                if (_procuracao.Bens == "S")
                    cmbPossuiBens.Text = "SIM";
                if (_procuracao.Bens == "N")
                    cmbPossuiBens.Text = "NÃO";


                cmbTipoLivro.SelectedItem = listaTiposLivroProcuracao.Where(p => p.Sigla == _procuracao.TipoLivro).FirstOrDefault();

                txtPoderes.Text = _procuracao.Poderes;
                txtResumo.Text = _procuracao.Resumo;

                cmbEscreventes.SelectedItem = escreventes.Where(p => p.Cpf == _procuracao.CpfEscrevente).FirstOrDefault();

                dtDataAto.SelectedDate = _procuracao.DataLavratura;

                if (_procuracao.DataVigencia.ToShortDateString() == "01/01/0001")
                    dtDataVigencia.SelectedDate = null;
                else
                    dtDataVigencia.SelectedDate = _procuracao.DataVigencia;

                txtLivro.Text = _procuracao.Livro;
                txtFlsIni.Text = string.Format("{0:000}", _procuracao.FolhaInicio);
                txtFlsFim.Text = string.Format("{0:000}", _procuracao.FolhaFim);
                txtAto.Text = string.Format("{0:000}", _procuracao.NumeroAto);
                txtRecibo.Text = _procuracao.Recibo;
                txtSelo.Text = string.Format("{0}", _procuracao.Selo);
                txtAleatorio.Text = _procuracao.Aleatorio;
                txtObservacao.Text = _procuracao.Observacao;
                txtLetra.Text = _procuracao.Letra;

                switch (_procuracao.TipoCobranca)
                {
                    case "JG":
                        cmbTipoCustas.SelectedIndex = 0;
                        break;

                    case "CC":
                        cmbTipoCustas.SelectedIndex = 1;
                        break;

                    case "SC":
                        cmbTipoCustas.SelectedIndex = 2;
                        break;

                    case "NH":
                        cmbTipoCustas.SelectedIndex = 3;
                        break;

                    case "PA":
                        cmbTipoCustas.SelectedIndex = 4;
                        break;

                    default:
                        cmbTipoCustas.SelectedIndex = 1;
                        break;
                }

                if (_chamadaInicial == false)
                {
                    txtEmolumentos.Text = string.Format("{0:n2}", _procuracao.Emolumentos);
                    txtFetj.Text = string.Format("{0:n2}", _procuracao.Fetj);
                    txtFunperj.Text = string.Format("{0:n2}", _procuracao.Funprj);
                    txtFundperj.Text = string.Format("{0:n2}", _procuracao.Fundperj);
                    txtFunarpen.Text = string.Format("{0:n2}", _procuracao.Funarpen);
                    txtPmcmv.Text = string.Format("{0:n2}", _procuracao.Pmcmv);
                    txtIss.Text = string.Format("{0:n2}", _procuracao.Iss);
                    txtDistribuicao.Text = string.Format("{0:n2}", _procuracao.Distribuicao);
                    txtMutua.Text = string.Format("{0:n2}", _procuracao.Mutua);
                    txtAcoterj.Text = string.Format("{0:n2}", _procuracao.Acoterj);
                    txtTotal.Text = string.Format("{0:n2}", _procuracao.Total);
                    CarregarListaItensCustas();
                }

                CarregarListaAtoConjuntos();


                if (listaAtoConjuntos.Count > 0)
                    dataGridAtoConjuntos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar informações do Selo. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarListaAtoConjuntos()
        {
            listaAtoConjuntos = _AppServicoAtoConjuntos.ObterAtosConjuntosPorIdProcuracao(_procuracao.ProcuracaoId);

            dataGridAtoConjuntos.ItemsSource = listaAtoConjuntos.OrderBy(p => p.Ordem);
            if (dataGridAtoConjuntos.Items.Count > 0)
                dataGridAtoConjuntos.SelectedIndex = 0;
        }


        private void CarregarListaItensCustas()
        {
            listaItensCustas = _AppServicoItensCustas.ObterItensCustasPorIdProcuracao(_procuracao.ProcuracaoId);

            dataGridCustas.ItemsSource = listaItensCustas;

            if (dataGridCustas.Items.Count > 0)
                dataGridCustas.SelectedIndex = 0;
        }


        private void CarregarDadosSelo()
        {
            try
            {

                for (int i = 0; i < listaAtoConjuntos.Count + 1; i++)
                {

                    if (i == 0)
                    {
                        var atoConjunto = new AtoConjuntos();
                        atoConjunto.IdProcuracao = _procuracao.ProcuracaoId;
                        atoConjunto.ConjuntoId = 0;
                        atoConjunto.Selo = string.Format("{0}", _procuracao.Selo);
                        atoConjunto.Aleatorio = _procuracao.Aleatorio;
                        atoConjunto.Ordem = 1;
                        atoConjunto.Data = _procuracao.DataLavratura;
                        atoConjunto.Livro = _procuracao.Livro;
                        atoConjunto.Folhas = string.Format("{0}-{1}", _procuracao.FolhaInicio, _procuracao.FolhaFim);
                        atoConjunto.Ato = string.Format("{0}", _procuracao.NumeroAto);
                        atoConjunto.TipoAto = "PRINCIPAL";
                        listaAtos.Add(atoConjunto);
                    }
                    else
                    {
                        listaAtos.Add(listaAtoConjuntos[i - 1]);
                    }
                }


                dataGridAtoConjuntos.ItemsSource = listaAtoConjuntos;
                if (dataGridAtoConjuntos.Items.Count > 0)
                    dataGridAtoConjuntos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar informações do Selo. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }


        private void CarregarParteConjuntos()
        {
            try
            {
                if (_procuracao != null)
                {
                    listaParteConjuntos = _AppServicoParteConjuntos.ObterNomesPorIdProcuracao(_procuracao.ProcuracaoId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações dos Participantes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        public void CarregarParticipantes()
        {
            try
            {
                if (_procuracao != null)
                {
                    listaNomes = _AppServicoNomes.ObterNomesPorIdProcuracao(_procuracao.ProcuracaoId);
                }

                Participante participante;

                foreach (var item in listaNomes)
                {
                    var pessoa = _AppServicoPessoas.GetById(item.IdPessoa);

                    listaPessoas.Add(pessoa);
                    participante = new Participante();
                    participante.IdAto = _procuracao.ProcuracaoId;
                    participante.IdNomes = item.NomeId;
                    participante.IdPessoa = pessoa.PessoasId;
                    participante.Nome = pessoa.Nome;
                    participante.Descricao = item.Descricao;
                    participante.CpfCnpj = pessoa.CpfCgc;

                    participantes.Add(participante);
                }

                dataGridParticipantes.ItemsSource = participantes;
                if (dataGridParticipantes.Items.Count > 0)
                    dataGridParticipantes.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações dos Participantes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }



        private void CarregarEscreventes()
        {
            try
            {
                escreventes = _AppServicoUsuario.GetAll().OrderBy(p => p.Nome).ToList();
                cmbEscreventes.ItemsSource = escreventes;
                cmbEscreventes.DisplayMemberPath = "Nome";
                cmbEscreventes.Text = _procuracao.Login;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações de Escreventes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }



        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void imgSair_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void cmbTabelaAtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (_chamadaInicial == true || _recalcular == true)
                    CarregarCustas();

                btnCalcular.IsEnabled = true;

                btnCustas.IsEnabled = true;


            }
            catch (Exception) { }
        }



        private void CarregarCustas()
        {

            var item = (TabelaCustas)cmbTabelaAtos.SelectedItem;


            tabelaCustas = _AppServicoTabelaCustas.CalcularItensCustas(item.Descricao, Ano);


            CalcularItensCustas(tabelaCustas, "2");

            CalcularEmolumentos();
            CalcularDistribuicao();
            CalcularMutuaAcoterj();
            CalcularBotaoTotal();

            dataGridCustas.ItemsSource = listaItensCustas;

        }

        public void CalcularBotaoTotal()
        {
            if (txtDistribuicao.Text == "")
                txtDistribuicao.Text = "0,00";

            if (txtMutua.Text == "")
                txtMutua.Text = "0,00";

            if (txtAcoterj.Text == "")
                txtAcoterj.Text = "0,00";

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
                    Convert.ToDecimal(txtFunarpen.Text) + Convert.ToDecimal(txtIss.Text) + Convert.ToDecimal(txtPmcmv.Text) + Convert.ToDecimal(txtDistribuicao.Text) + Convert.ToDecimal(txtMutua.Text) + Convert.ToDecimal(txtAcoterj.Text));
        }

        public void CalcularMutuaAcoterj()
        {
            var qtdAtos = listaAtos.Count;


            if (qtdAtos == 0)
                qtdAtos = 1;

            var mutua = configuracoes.Mutua * qtdAtos;
            var acoterj = configuracoes.Acoterj * qtdAtos;

            if (cmbTipoCustas.SelectedIndex == 0 || cmbTipoCustas.SelectedIndex == 2)
            {
                txtMutua.Text = "0,00";
                txtAcoterj.Text = "0,00";
            }
            else
            {

                txtMutua.Text = string.Format("{0:n2}", mutua);
                txtAcoterj.Text = string.Format("{0:n2}", acoterj);
            }
        }

        public void CalcularDistribuicao()
        {
            decimal distrib = configuracoes.Distribuicao;
            if (cmbTipoCustas.SelectedIndex == 0 || cmbTipoCustas.SelectedIndex == 2)
            {
                txtDistribuicao.Text = "0,00";
            }
            else
                txtDistribuicao.Text = string.Format("{0:n2}", distrib);
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
                emolumentos = listaItensCustas.Where(p => p.Tabela == "22").ToList();

                emol = Convert.ToDecimal(listaItensCustas.Sum(p => p.Total));

                fetj_20 = emol * 20 / 100;
                fundperj_5 = emol * 5 / 100;
                funperj_5 = emol * 5 / 100;
                funarpen_4 = emol * 4 / 100;

                iss = (100 - alicotaIss) / 100;
                iss = emol / iss - emol;

                pmcmv_2 = Convert.ToDecimal(emolumentos.Sum(p => p.Total) * 2) / 100;

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

        public void CalcularItensCustas(List<TabelaCustas> tabelaCustas, string qtdComunicacao)
        {
            listaItensCustas = new List<ItensCustas>();

            for (int i = 0; i < tabelaCustas.Count; i++)
            {
                var itemCustas = new ItensCustas();
                itemCustas.Descricao = tabelaCustas[i].Descricao;
                itemCustas.Tabela = tabelaCustas[i].Tabela;
                itemCustas.Item = tabelaCustas[i].Item;
                itemCustas.SubItem = tabelaCustas[i].SubItem;

                if (itemCustas.Tabela == "16" && itemCustas.Item == "5")
                    itemCustas.Quantidade = qtdComunicacao;
                else
                    itemCustas.Quantidade = "1";

                itemCustas.Valor = tabelaCustas[i].Valor;

                try
                {
                    itemCustas.Total = Convert.ToInt16(itemCustas.Quantidade) * itemCustas.Valor;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }


                listaItensCustas.Add(itemCustas);
            }

        }




        private void CarregarComboBoxTabelaAtos()
        {
            try
            {
                tabelaCustas = listaTabelaCustas.Where(p => (p.Ano == Ano) && ((p.Tabela == "22" && p.Item == "2"))).OrderBy(p => p.Ordem).ToList();
                cmbTabelaAtos.ItemsSource = tabelaCustas;
                cmbTabelaAtos.DisplayMemberPath = "Descricao";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar TABELA DE ATOS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridParticipantes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridParticipantes.Items.Count < 1)
            {
                return;
            }


            estado = "alterando participante";

            if (dataGridParticipantes.SelectedIndex > -1)
            {

                CarregarDataGridParticipantes();
                CarregarComponentes();
            }
            else
            {
                MessageBox.Show("Selecione um participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dataGridCustas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var alterarCustas = new AlterarItemCustasEscritura(this);
            alterarCustas.Owner = this;
            alterarCustas.ShowDialog();

            CalcularEmolumentos();

            CalcularMutuaAcoterj();
            CalcularBotaoTotal();

            dataGridCustas.Items.Refresh();
        }

        private void dataGridAtoConjuntos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridAtoConjuntos.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um Ato Conjunto.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var digitarAtoConjunto = new AtosConjuntosProcuracao(this, "alterando", (AtoConjuntos)dataGridAtoConjuntos.SelectedItem);
            digitarAtoConjunto.Owner = this;
            digitarAtoConjunto.ShowDialog();
            CarregarAtoConjunto();
        }

        private void cmbLocalProcuracao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLocalPratica.SelectedIndex == 2)
            {
                txtOutrosLocalPratica.IsEnabled = true;
                txtOutrosLocalPratica.Focus();
            }
            else
            {
                txtOutrosLocalPratica.Text = "";
                txtOutrosLocalPratica.IsEnabled = false;
            }
        }

        private void CarregarLocalProcuracao()
        {

            localProcuracao = localProc.ObterListaLocalProcuracao();

            cmbLocalPratica.ItemsSource = localProcuracao;

            cmbLocalPratica.DisplayMemberPath = "Descricao";

            cmbLocalPratica.SelectedIndex = 0;
        }

        private void CarregarTipoProcuracao()
        {
            tiposProcuracao = tiposProc.ObterListaTiposProcuracao();

            cmbTipoProcuracao.ItemsSource = tiposProcuracao;

            cmbTipoProcuracao.DisplayMemberPath = "Descricao";

            cmbTipoProcuracao.SelectedIndex = 0;
        }

        private void cmbTipoProcuracao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cmbTipoProcuracao.SelectedIndex == 2 || cmbTipoProcuracao.SelectedIndex == 3)
            {

                if (cmbTipoProcuracao.SelectedIndex == 3)
                {
                    
                    cmbOutorgadoAusenteOrigem.IsEnabled = true;
                    txtNotificacaoOrigem.IsEnabled = true;
                }
                else
                {
                    cmbOutorgadoAusenteOrigem.SelectedIndex = -1;
                    txtNotificacaoOrigem.Text = "";
                    cmbOutorgadoAusenteOrigem.IsEnabled = false;
                    txtNotificacaoOrigem.IsEnabled = false;

                }

                tabItemOrigem.Visibility = Visibility.Visible;
            }
            else
            {
                tabItemOrigem.Visibility = Visibility.Collapsed;
                if (tabItemOrigem.IsSelected == true)
                    tabItemCustas.IsSelected = true;
            }
            if (cmbTipoProcuracao.SelectedIndex == 1 || cmbTipoProcuracao.SelectedIndex == 4)
            {
                if (cmbTipoProcuracao.SelectedIndex == 1)
                {
                    lblDescricaoTipo.Content = "Descrição:";
                    lblDescricaoTipo.Visibility = Visibility.Visible;
                    txtOutrosTipo.Visibility = Visibility.Visible;
                    txtOutrosTipo.Text = "";
                    txtOutrosTipo.Focus();
                }
                else
                {
                    txtOutrosTipo.Visibility = Visibility.Hidden;
                }

                if (cmbTipoProcuracao.SelectedIndex == 4)
                {
                    lblDescricaoTipo.Content = "Selo Escritura:";
                    lblDescricaoTipo.Visibility = Visibility.Visible;
                    txtSeloEscritura.Visibility = Visibility.Visible;
                    txtSeloEscritura.Text = "";
                    txtAleatorioEscritura.Visibility = Visibility.Visible;
                    txtAleatorioEscritura.Text = "";
                    txtSeloEscritura.Focus();
                }
                else
                {
                    txtSeloEscritura.Visibility = Visibility.Hidden;
                    txtSeloEscritura.Text = "";
                    txtAleatorioEscritura.Visibility = Visibility.Hidden;
                    txtAleatorioEscritura.Text = "";
                }
            }
            else
            {
                lblDescricaoTipo.Content = "";
                lblDescricaoTipo.Visibility = Visibility.Hidden;
                txtSeloEscritura.Visibility = Visibility.Hidden;
                txtSeloEscritura.Text = "";
                txtAleatorioEscritura.Visibility = Visibility.Hidden;
                txtAleatorioEscritura.Text = "";
                lblDescricaoTipo.Visibility = Visibility.Hidden;
                txtOutrosTipo.Visibility = Visibility.Hidden;
            }
        }

        private void dataGridParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarComponentes();
        }

        private void dataGridParticipantes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                btnExcluirParte_Click(sender, e);
        }

        private void CarregarComponentes()
        {

            if ((dataGridParticipantes.Items.Count > 0) & (dataGridParticipantes.SelectedIndex > -1))
            {
                parte = (Participante)dataGridParticipantes.SelectedItem;

                var pessoa = (Pessoas)listaPessoas.Where(p => p.PessoasId == parte.IdPessoa).FirstOrDefault();


                txtCpfCnpj.Text = pessoa.CpfCgc;
                txtNomeParte.Text = pessoa.Nome;
                if (pessoa.TipoPessoa == "F")
                    rbFisica.IsChecked = true;
                if (pessoa.TipoPessoa == "J")
                    rbJuridica.IsChecked = true;

                if (pessoa.Sexo == "M")
                    rbMasculino.IsChecked = true;
                if (pessoa.Sexo == "F")
                    rbFeminino.IsChecked = true;

                txtEndereco.Text = pessoa.Endereco;
                txtBairro.Text = pessoa.Bairro;
                txtUf.Text = pessoa.Uf;
                txtMunicipio.Text = pessoa.Cidade;
                txtIdentidade.Text = pessoa.Rg;
                txtOrgaoEmissor.Text = pessoa.OrgaoRG;

                if (pessoa.DataEmissaoRG.ToShortDateString() != "01/01/0001")
                    txtDataEmissao.Text = pessoa.DataEmissaoRG.ToShortDateString();

                txtProfissao.Text = pessoa.Profissao;

                if (pessoa.EsctadoCivil > 0)
                    txtEstadoCivil.Text = EstadoCivil(pessoa.EsctadoCivil, pessoa.Sexo);
                txtRegime.Text = pessoa.RegimeBens;
                txtNomeConjuge.Text = pessoa.Conjuge;

                if (pessoa.DataNascimento.ToShortDateString() != "01/01/0001")
                    txtDataNascimento.Text = pessoa.DataNascimento.ToShortDateString();

                if (pessoa.DataCasamento.ToShortDateString() != "01/01/0001")
                    txtDataCasamento.Text = pessoa.DataCasamento.ToShortDateString();

            }
            else
            {
                txtCpfCnpj.Text = "";
                txtNomeParte.Text = "";
                rbFisica.IsChecked = false;
                rbJuridica.IsChecked = false;

                rbMasculino.IsChecked = false;
                rbFeminino.IsChecked = false;

                txtEndereco.Text = "";
                txtBairro.Text = "";
                txtUf.Text = "";
                txtMunicipio.Text = "";
                txtIdentidade.Text = "";
                txtOrgaoEmissor.Text = "";

                txtDataEmissao.Text = "";

                txtProfissao.Text = "";

                txtEstadoCivil.Text = "";
                txtRegime.Text = "";
                txtNomeConjuge.Text = "";
                txtDataNascimento.Text = "";

                txtDataCasamento.Text = "";
            }
        }

        private string EstadoCivil(int codEstadoCivil, string sexo)
        {
            EstadoCivil ec = new EstadoCivil();
            var estadoCivil = new List<EstadoCivil>();

            bool sex;
            if (sexo == "M")
                sex = true;
            else
                sex = false;

            estadoCivil = ec.ObterListaEstadoCivil(sex);

            return estadoCivil.Where(p => p.Codigo == codEstadoCivil).FirstOrDefault().Descricao;
        }

        private void btnExcluirParte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridParticipantes.Items.Count < 1)
                {
                    return;
                }
                if (dataGridParticipantes.SelectedIndex > -1)
                {

                    if (MessageBox.Show("Confirma a exclusão do participante?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        estado = "excluindo participante";


                        var parteConjuntos = listaParteConjuntos.Where(p => p.IdNome == parte.IdNomes).ToList();

                        for (int i = 0; i < parteConjuntos.Count(); i++)
                        {
                            listaParteConjuntos.Remove(parteConjuntos[i]);

                            if (parteConjuntos[i].ParteConjuntosId > 0)
                            {
                                var parteConuntosExcluirDoBanco = _AppServicoParteConjuntos.GetById(parteConjuntos[i].ParteConjuntosId);
                                _AppServicoParteConjuntos.Remove(parteConuntosExcluirDoBanco);
                            }

                        }


                        listaNomes.Remove(listaNomes.Where(p => p.NomeId == parte.IdNomes).FirstOrDefault());


                        var excluirNomeDoBanco = _AppServicoNomes.GetById(parte.IdNomes);
                        _AppServicoNomes.Remove(excluirNomeDoBanco);


                        listaPessoas.Remove(listaPessoas.Where(p => p.PessoasId == parte.IdPessoa).FirstOrDefault());
                        participantes.Remove(parte);

                        var excluirPessoaDoBanco = _AppServicoPessoas.GetById(parte.IdPessoa);
                        _AppServicoPessoas.Remove(excluirPessoaDoBanco);

                        dataGridParticipantes.ItemsSource = null;
                        dataGridParticipantes.ItemsSource = participantes;
                        dataGridParticipantes.Items.Refresh();
                        if (dataGridParticipantes.Items.Count > 0)
                            dataGridParticipantes.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um participante para excluir.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Não foi possível excluir a Parte. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdicionarParte_Click(object sender, RoutedEventArgs e)
        {
            estado = "adicionando participante";

           
            CarregarDataGridParticipantes();
        }

        private void CarregarDataGridParticipantes()
        {
            try
            {
                var qtdNaListaParticipantes = participantes.Count;

                var digitarParte = new ParticipantesProcuracao(this);
                digitarParte.Owner = this;
                digitarParte.ShowDialog();

                dataGridParticipantes.ItemsSource = null;
                dataGridParticipantes.ItemsSource = participantes;
                dataGridParticipantes.Items.Refresh();

                if (qtdNaListaParticipantes < participantes.Count)
                    parte = participantes.LastOrDefault();

                dataGridParticipantes.SelectedItem = parte;
                dataGridParticipantes.ScrollIntoView(parte);

                estado = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar informações das Partes. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAlterarParte_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridParticipantes.Items.Count < 1)
            {
                return;
            }


            estado = "alterando participante";

            if (dataGridParticipantes.SelectedIndex > -1)
            {

                CarregarDataGridParticipantes();
                CarregarComponentes();
            }
            else
            {
                MessageBox.Show("Selecione um participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnAdicionarAtoConjunto_Click(object sender, RoutedEventArgs e)
        {


            var atoConjunto = new AtoConjuntos();

            atoConjunto.IdProcuracao = _procuracao.ProcuracaoId;
            atoConjunto.Ordem = listaAtos.Max(p => p.Ordem) + 1;
            atoConjunto.Data = dtDataAto.SelectedDate.Value;
            atoConjunto.Livro = txtLivro.Text;
            atoConjunto.Folhas = txtFlsIni.Text;
            atoConjunto.Ato = txtAto.Text;
            atoConjunto.TipoAto = "ATO CONJUNTO";

            _AppServicoAtoConjuntos.Add(atoConjunto);

            listaAtoConjuntos.Add(atoConjunto);
            listaAtos.Add(atoConjunto);

            dataGridAtoConjuntos.ItemsSource = null;
            dataGridAtoConjuntos.ItemsSource = listaAtoConjuntos;

            dataGridAtoConjuntos.SelectedItem = atoConjunto;
            dataGridAtoConjuntos.ScrollIntoView(atoConjunto);
            dataGridAtoConjuntos.Items.Refresh();

            var digitarAtoConjunto = new AtosConjuntosProcuracao(this, "adicionando", atoConjunto);
            digitarAtoConjunto.Owner = this;
            digitarAtoConjunto.ShowDialog();
            CarregarAtoConjunto();
        }

        private void CarregarAtoConjunto()
        {
            var _atoConjunto = (AtoConjuntos)dataGridAtoConjuntos.SelectedItem;


            if (_atoConjunto != null)
            {
                txtSeloAtoConjunto.Text = _atoConjunto.Selo;

                txtAleatorioAtoConjunto.Text = _atoConjunto.Aleatorio;

                txtNaturezaAtoConjunto.Text = _atoConjunto.TipoAto;

                txtDataAtoConjunto.Text = _atoConjunto.Data.ToShortDateString();

                txtLivroAtoConjunto.Text = _atoConjunto.Livro;

                txtFlsAtoConjunto.Text = _atoConjunto.Folhas;

                txtAtoAtoConjunto.Text = _atoConjunto.Ato;

                txtTipoLivroAtoConjunto.Text = _atoConjunto.TipoLivro;

                if (_atoConjunto.LavradoRj == "S")
                    txtLavradoRjAtoConjunto.Text = "SIM";
                else
                    txtLavradoRjAtoConjunto.Text = "NÃO";

                txtUfAtoConjunto.Text = _atoConjunto.UfOrigem;

                if (_atoConjunto.Procuracao == "S")
                    txtPorProcAtoConjunto.Text = "SIM";
                else
                    txtPorProcAtoConjunto.Text = "NÃO";

                txtTipoLivroAtoConjunto.Text = _atoConjunto.TipoLivro;

                txtValorAtoConjunto.Text = string.Format("{0:N2}", _atoConjunto.Valor);
            }
            else
            {
                txtSeloAtoConjunto.Text = "";

                txtAleatorioAtoConjunto.Text = "";

                txtNaturezaAtoConjunto.Text = "";

                txtDataAtoConjunto.Text = "";

                txtLivroAtoConjunto.Text = "";

                txtFlsAtoConjunto.Text = "";

                txtAtoAtoConjunto.Text = "";

                txtLavradoRjAtoConjunto.Text = "";

                txtUfAtoConjunto.Text = "";

                txtPorProcAtoConjunto.Text = "";

                txtTipoLivroAtoConjunto.Text = "";

                txtValorAtoConjunto.Text = "";

                txtTipoLivroAtoConjunto.Text = "";
            }
        }


        private void btnExcluirAtoConjunto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridAtoConjuntos.Items.Count < 1)
                    return;

                var atoConjunto = (AtoConjuntos)dataGridAtoConjuntos.SelectedItem;

                if (MessageBox.Show("Confirma a exclusão do Ato Conjunto?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    var listaExcluir = listaParteConjuntos.Where(p => p.IdConjunto == atoConjunto.ConjuntoId).ToList();


                    for (int i = 0; i < listaExcluir.Count(); i++)
                    {
                        if (listaExcluir[i].IdConjunto == atoConjunto.ConjuntoId)
                        {
                            var excluirBanco = _AppServicoParteConjuntos.GetById(listaExcluir[i].ParteConjuntosId);
                            _AppServicoParteConjuntos.Remove(excluirBanco);
                            listaParteConjuntos.Remove(listaExcluir[i]);
                        }
                    }

                    _AppServicoAtoConjuntos.Remove(atoConjunto);

                    listaAtoConjuntos.Remove(atoConjunto);
                    listaAtos.Remove(atoConjunto);

                    dataGridAtoConjuntos.ItemsSource = null;
                    dataGridAtoConjuntos.ItemsSource = listaAtoConjuntos;

                    dataGridAtoConjuntos.Items.Refresh();

                    for (int i = 0; i < listaExcluir.Count; i++)
                    {
                        var item = listaParteConjuntos.Contains(listaParteConjuntos.Where(p => p.IdNome == listaExcluir[i].IdNome).FirstOrDefault());

                        if (item == false)
                        {
                            var parte = participantes.Where(p => p.IdNomes == listaExcluir[i].IdNome).FirstOrDefault();

                            listaNomes.Remove(listaNomes.Where(p => p.NomeId == parte.IdNomes).FirstOrDefault());

                            listaPessoas.Remove(listaPessoas.Where(p => p.PessoasId == parte.IdPessoa).FirstOrDefault());

                            participantes.Remove(parte);
                        }
                    }

                    dataGridParticipantes.Items.Refresh();

                    if (dataGridParticipantes.Items.Count > 0)
                        dataGridAtoConjuntos.SelectedIndex = 0;

                    if (dataGridAtoConjuntos.SelectedIndex < 0)
                        dataGridAtoConjuntos.SelectedIndex = 0;
                }

                if (MessageBox.Show("Deseja liberar o selo " + atoConjunto.Selo + "?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var serie = atoConjunto.Selo.Substring(0, 4);

                    var numero = Convert.ToInt32(atoConjunto.Selo.Substring(4, 5));

                    var seloLiberar = _AppServicoSelos.ConsultarPorSerieNumero(serie, numero);

                    _AppServicoSelos.LiberarSelos(seloLiberar);

                    _AppServicoSelos.Update(seloLiberar);
                }
                else
                {
                    var serie = atoConjunto.Selo.Substring(0, 4);

                    var numero = Convert.ToInt32(atoConjunto.Selo.Substring(4, 5));

                    var seloLiberar = _AppServicoSelos.ConsultarPorSerieNumero(serie, numero);

                    _AppServicoSelos.LiberarSelos(seloLiberar);

                    seloLiberar.Status = "BLOQUEADO";

                    _AppServicoSelos.Update(seloLiberar);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAlterarAtoConjunto_Click(object sender, RoutedEventArgs e)
        {


            if (dataGridAtoConjuntos.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um Ato Conjunto.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var digitarAtoConjunto = new AtosConjuntosProcuracao(this, "alterando", (AtoConjuntos)dataGridAtoConjuntos.SelectedItem);
            digitarAtoConjunto.Owner = this;
            digitarAtoConjunto.ShowDialog();
            CarregarAtoConjunto();
        }

        private void dataGridAtoConjuntos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarAtoConjunto();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            CalcularBotaoTotal();
        }

        private void cmbTipoCustas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoCustas.Focus() == true)
                if (cmbTabelaAtos.SelectedIndex > -1)
                {
                    CalcularEmolumentos();
                    CalcularDistribuicao();
                    CalcularMutuaAcoterj();
                    CalcularBotaoTotal();
                }
        }

        private void btnCustas_Click(object sender, RoutedEventArgs e)
        {
            var tabelaCustas = new AdicionarItensCustas(this);
            tabelaCustas.Owner = this;
            tabelaCustas.ShowDialog();
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }


        private void txtFlsIniOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        
        private void txtFlsFimOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtAtoOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtSeloOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtSeloOrigem.MaxLength = 9;
            if (txtSeloOrigem.Text.Length <= 3)
            {
                int key = (int)e.Key;

                e.Handled = !(key >= 44 && key <= 69 || key == 2 || key == 3);
            }

            if (txtSeloOrigem.Text.Length >= 4 && txtSeloOrigem.Text.Length <= 8)
            {
                int key = (int)e.Key;

                e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtAleatorioOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 44 && key <= 69 || key == 2 || key == 3);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtSeloEscritura_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtSeloEscritura.MaxLength = 9;
            if (txtSeloEscritura.Text.Length <= 3)
            {
                int key = (int)e.Key;

                e.Handled = !(key >= 44 && key <= 69 || key == 2 || key == 3);
            }

            if (txtSeloEscritura.Text.Length >= 4 && txtSeloEscritura.Text.Length <= 8)
            {
                int key = (int)e.Key;

                e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3);
            }
        }

        private void txtAleatorioEscritura_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 44 && key <= 69 || key == 2 || key == 3);
        }

        private void txtNumeroConsultaOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCodigoOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void btnConsultarServentia_Click(object sender, RoutedEventArgs e)
        {
            var consultarServentia = new ConsultaServentias(this);
            consultarServentia.Owner = this;
            consultarServentia.ShowDialog();

            if (serventiasOutrasSelecionada != null)
            {
                txtCodigoOrigem.Text = serventiasOutrasSelecionada.Codigo.ToString();
                txtServentiaOrigem.Text = serventiasOutrasSelecionada.Descricao;
            }
        }

        private void PesquisarServentia()
        {
            var codigo = Convert.ToInt32(txtCodigoOrigem.Text);

            serventiasOutrasSelecionada = serventiasOutras.Where(p => p.Codigo == codigo).FirstOrDefault();

            if (serventiasOutrasSelecionada != null)
                txtServentiaOrigem.Text = serventiasOutrasSelecionada.Descricao;
            else
                txtServentiaOrigem.Text = "";
        }

        
        private void txtCodigoOrigem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigoOrigem.Text.Length > 0)
                PesquisarServentia();
            else
                txtServentiaOrigem.Text = "";
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


        private void dtDataAtoOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtLivroOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCodigoLivroOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtServentiaOrigem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void btnSalvarSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SalvarProcuracao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalvarProcuracao()
        {
            _procuracao.Acoterj = Convert.ToDecimal(txtAcoterj.Text);
            _procuracao.Aleatorio = txtAleatorio.Text;

            var tipoProcuracao = ((TiposProcuracao)cmbTipoProcuracao.SelectedItem).Sigla;

            var escrevente = ((Cs_Notas.Dominio.Entities.Usuario)cmbEscreventes.SelectedItem);

            var local = (LocalProcuracao)cmbLocalPratica.SelectedItem;

            
            _procuracao.Tipo = tipoProcuracao;




            if (tipoProcuracao == "D")
            {
                _procuracao.SeloEscritura = txtSeloEscritura.Text;
                _procuracao.AleatorioEscritura = txtAleatorioEscritura.Text;
            }

            if (tipoProcuracao == "E")
            {
                _procuracao.DescricaoTipo = txtOutrosTipo.Text;
            }

            _procuracao.TipoAto = "RP";

            // ----------------- Origem ----------------------
            if (tipoProcuracao == "S" || tipoProcuracao == "R")
            {

                if(txtSeloOrigem.Text != "")
                _procuracao.SeloTipo = txtSeloOrigem.Text;

                if (txtAleatorioOrigem.Text != "")
                _procuracao.AleatorioTipo = txtAleatorioOrigem.Text;

                if (txtCodigoLivroOrigem.Text != "")
                _procuracao.CodigoLivro = txtCodigoLivroOrigem.Text;

                if (txtOrigem.Text != "")
                _procuracao.CodigoMunicipioOrigem = txtOrigem.Text;

                if (txtCodigoOrigem.Text != "")
                _procuracao.CodigoServentiaTipo = Convert.ToInt32(txtCodigoOrigem.Text);

                if (txtNumeroConsultaOrigem.Text != "")
                _procuracao.ConsultaTipo = txtNumeroConsultaOrigem.Text;

                if (dtDataAtoOrigem.SelectedDate != null)
                _procuracao.DataLavraturaTipo = dtDataAtoOrigem.SelectedDate.Value;
                
                if (txtFlsFimOrigem.Text != "")
                    _procuracao.FolhaFimTipo = Convert.ToInt32(txtFlsFimOrigem.Text);

                if (txtFlsIniOrigem.Text != "")
                _procuracao.FolhaInicioTipo = Convert.ToInt32(txtFlsIniOrigem.Text);

                if(cmbLavradoRioOrigem.Text == "SIM")
                _procuracao.LavradoRj = "S";

                if (cmbLavradoRioOrigem.Text == "NÃO")
                    _procuracao.LavradoRj = "N";

                if(txtLivroOrigem.Text != "")
                _procuracao.LivroTipo = txtLivroOrigem.Text;


                if (cmbTipoLivroOrigem.SelectedIndex > -1)
                    _procuracao.TipoLivroTipo = ((TipoLivroProcuracao)cmbTipoLivroOrigem.SelectedItem).Sigla;

                if (cmbTipoLivro.SelectedItem != null)
                    _procuracao.TipoLivro = ((TipoLivroProcuracao)cmbTipoLivro.SelectedItem).Sigla;
                                

                if (cmbUfOrigem.SelectedIndex > -1)
                    _procuracao.UfOrigem = cmbUfOrigem.Text;

                if (txtServentiaOrigem.Text != "")
                    _procuracao.ServentiaTipo = txtServentiaOrigem.Text;

                if (txtAtoOrigem.Text != "")
                    _procuracao.NumeroAtoTipo = Convert.ToInt32(txtAtoOrigem.Text);


                if (tipoProcuracao == "R")
                {
                    if (cmbOutorgadoAusenteOrigem.Text == "SIM")
                        _procuracao.Ausente = "S";

                    if (cmbOutorgadoAusenteOrigem.Text == "NÃO")
                        _procuracao.Ausente = "N";

                    if(txtNotificacaoOrigem.Text != "")
                    _procuracao.Notificacao = txtNotificacaoOrigem.Text;
                }

            }
            
            
            //------------------------------------------------


            if( cmbPossuiBens.Text == "SIM")
            _procuracao.Bens = "S";

            if (cmbPossuiBens.Text == "NÃO")
                _procuracao.Bens = "N";

            if(cmbTipoLivro.SelectedItem != null)
            _procuracao.TipoLivro = ((TipoLivroProcuracao)cmbTipoLivro.SelectedItem).Sigla;
            

            _procuracao.Cancelado = "N";

            

            TabelaCustas tabela = (TabelaCustas)cmbTabelaAtos.SelectedItem;
            switch (tabela.SubItem)
            {
                case "A":
                    _procuracao.Codigo = 2388;
                    break;

                case "B":
                    _procuracao.Codigo = 2389;
                    break;

                case "C":
                    _procuracao.Codigo = 2390;
                    break;

                case "D":
                    _procuracao.Codigo = 2391;
                    break;

                default:

                    break;
            }

            _procuracao.CpfEscrevente = escrevente.Cpf;

            _procuracao.DataLavratura = dtDataAto.SelectedDate.Value;

            _procuracao.DataModificado = DateTime.Now.Date;

            if (dtDataVigencia.SelectedDate != null)
            _procuracao.DataVigencia = dtDataVigencia.SelectedDate.Value;

            _procuracao.Distribuicao = Convert.ToDecimal(txtDistribuicao.Text);

            _procuracao.Emolumentos = Convert.ToDecimal(txtEmolumentos.Text);

            _procuracao.Fetj = Convert.ToDecimal(txtFetj.Text);
            
            if(txtFlsFim.Text != "")
            _procuracao.FolhaFim = Convert.ToInt32(txtFlsFim.Text);

            if (txtFlsIni.Text != "")
            _procuracao.FolhaInicio = Convert.ToInt32(txtFlsIni.Text);

            _procuracao.Funarpen = Convert.ToDecimal(txtFunarpen.Text);

            _procuracao.Fundperj = Convert.ToDecimal(txtFundperj.Text);

            _procuracao.Funprj = Convert.ToDecimal(txtFunperj.Text);

            _procuracao.HoraModificado = DateTime.Now.ToLongTimeString();

            _procuracao.Iss = Convert.ToDecimal(txtIss.Text);

            if(txtLetra.Text != "")
            _procuracao.Letra = txtLetra.Text;

            _procuracao.Livro = txtLivro.Text;


            _procuracao.Local = local.Sigla;

            if (local.Sigla == "O")
                _procuracao.OutrosLocal = txtOutrosLocalPratica.Text;

            _procuracao.Login = _usuario.Nome;

            _procuracao.Mutua = Convert.ToDecimal(txtMutua.Text);

            if(txtAto.Text != "")
            _procuracao.NumeroAto = Convert.ToInt32(txtAto.Text);

            if(txtAtoOrigem.Text != "")
            _procuracao.NumeroAtoTipo = Convert.ToInt32(txtAtoOrigem.Text);

            if(txtObservacao.Text != "")
            _procuracao.Observacao = txtObservacao.Text;

            if (txtPmcmv.Text != "")
                _procuracao.Pmcmv = Convert.ToDecimal(txtPmcmv.Text);

            if(txtPoderes.Text != "")
            _procuracao.Poderes = txtPoderes.Text;

            if(txtRecibo.Text != "")
            _procuracao.Recibo = txtRecibo.Text;

            if(txtResumo.Text != "")
            _procuracao.Resumo = txtResumo.Text;


            _procuracao.Selo = txtSelo.Text;

            

            switch (cmbTipoCustas.SelectedIndex)
            {
                case 0:
                    _procuracao.TipoCobranca = "JG";
                    break;

                case 1:
                    _procuracao.TipoCobranca = "CC";
                    break;

                case 2:
                    _procuracao.TipoCobranca = "SC";
                    break;

                case 3:
                    _procuracao.TipoCobranca = "NH";
                    break;

                case 4:
                    _procuracao.TipoCobranca = "PA";
                    break;

                default:
                    
                    break;
            }

            

            if(txtTotal.Text != "")
            _procuracao.Total = Convert.ToDecimal(txtTotal.Text);

            estado = "salvando";
            var aguarde = new AgurardeSalvandoProcuracao(this);
            aguarde.Owner = this;
            aguarde.ShowDialog();

            if(estado == "salvando")
            this.Close();
        }

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
               

        private void txtDistribuicao_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtDistribuicao);
        }

        private void txtDistribuicao_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtDistribuicao);
        }

        private void txtDistribuicao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtDistribuicao);
        }

        private void txtMutua_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtMutua);
        }

        private void txtMutua_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtMutua);
        }

        private void txtMutua_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtMutua);
        }

        private void txtAcoterj_LostFocus(object sender, RoutedEventArgs e)
        {
            LostFocusText(sender, e, txtAcoterj);
        }

        private void txtAcoterj_GotFocus(object sender, RoutedEventArgs e)
        {
            GotFocusText(sender, e, txtAcoterj);
        }

        private void txtAcoterj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarEmReais(sender, e, txtAcoterj);
        }


    }
}
