using CrossCutting;
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

namespace Cs_Notas.Windows.Testamento
{
    /// <summary>
    /// Lógica interna para DigitarTestamento.xaml
    /// </summary>
    public partial class DigitarTestamento : Window
    {
        public CadTestamento _testamento = new CadTestamento();
        List<TabelaCustas> tabelaCustas = new List<TabelaCustas>();
        public List<TabelaCustas> listaTabelaCustas = new List<TabelaCustas>();
        public  List<ItensCustas> listaItensCustas = new List<ItensCustas>();
        List<Cs_Notas.Dominio.Entities.Usuario> escreventes = new List<Cs_Notas.Dominio.Entities.Usuario>();
        public int Ano;
        public List<int> anosCustasExistentes = new List<int>();
        public Configuracoes configuracoes = new Configuracoes();
        public Cs_Notas.Dominio.Entities.Usuario _usuario;
        bool _chamadaInicial;
        decimal alicotaIss;
        public List<Revogados> listaRevogados = new List<Revogados>();
        public List<Participante> participantes = new List<Participante>();
        public List<Pessoas> listaPessoas = new List<Pessoas>();
        public List<Nomes> listaNomes = new List<Nomes>();
        public List<ParteConjuntos> listaParteConjuntos = new List<ParteConjuntos>();
        public List<AtoConjuntos> listaAtos = new List<AtoConjuntos>();
        public string estado = string.Empty;
        bool _recalcular = false;
        List<ItensCustas> emolumentos = new List<ItensCustas>();
        List<string> Ufs = new List<string>();
        public ServentiasOutras serventiasOutrasSelecionada;
        public List<ServentiasOutras> serventiasOutras;
        LocalProcuracao localProc = new LocalProcuracao();
        List<LocalProcuracao> localProcuracao = new List<LocalProcuracao>();
        List<EstadoCivil> estadoCivil;
        List<Regimes> regimes;
        List<JustificativaCpf> justificativasCpf = new List<JustificativaCpf>();
        JustificativaCpf justificativa = new JustificativaCpf();
        bool verificaCpf = true;

        IEnumerable<Nacionalidades> nacionalidades = new List<Nacionalidades>();
        IEnumerable<NacionalidadesOnu> nacionalidadesOnu = new List<NacionalidadesOnu>();

        private readonly IAppServicoTabelaCustas _AppServicoTabelaCustas = BootStrap.Container.GetInstance<IAppServicoTabelaCustas>();
        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();
        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();
        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoMunicipios _AppServicoMunicipios = BootStrap.Container.GetInstance<IAppServicoMunicipios>();
        private readonly IAppServicoServentiasOutras _AppServicoServentiasOutras = BootStrap.Container.GetInstance<IAppServicoServentiasOutras>();
        private readonly IAppServicoNacionalidades _AppServicoNacionalidades = BootStrap.Container.GetInstance<IAppServicoNacionalidades>();
        private readonly IAppServicoNacionalidadesOnu _AppServicoNacionalidadesOnu = BootStrap.Container.GetInstance<IAppServicoNacionalidadesOnu>();
        private readonly IAppServicoRegimes _AppServicoRegimes = BootStrap.Container.GetInstance<IAppServicoRegimes>();
        private readonly IAppServicoRevogados _AppServicoRevogados = BootStrap.Container.GetInstance<IAppServicoRevogados>();

        public Selos _selo;
        Principal _principal;

        public DigitarTestamento(Selos selo, Cs_Notas.Dominio.Entities.Usuario usuario, Principal principal)
        {
            _selo = selo;
            _usuario = usuario;
            _principal = principal;
            _chamadaInicial = true;
            InitializeComponent();
        }

        public DigitarTestamento(CadTestamento cadTestamento, Cs_Notas.Dominio.Entities.Usuario usuario, bool chamadaInicial)
        {
            _testamento = cadTestamento;
            _usuario = usuario;
            _chamadaInicial = chamadaInicial;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

             if (_chamadaInicial == true)
                 Ano = _selo.DataReservado.Date.Year;
             else
            Ano = _testamento.DataAto.Date.Year;

            listaTabelaCustas = _AppServicoTabelaCustas.GetAll().ToList();
            anosCustasExistentes = listaTabelaCustas.Select(p => p.Ano).Distinct().ToList();
            serventiasOutras = _AppServicoServentiasOutras.GetAll().ToList();
            configuracoes = _AppServicoConfiguracoes.GetById(1);
            alicotaIss = _AppServicoParametros.GetById(1).AlicotaIss;
            
            CarregarEscreventes();
            CarregarNacionalidadesOnu();
            CarregarComboBoxTabelaAtos();
            CarregarLocalTestamento();
            CarregarNacionalidades();

            cmbJustificativaTestador.ItemsSource = justificativa.ObterJustificativas();
            cmbJustificativaTestador.DisplayMemberPath = "Descricao";
            cmbJustificativaTestador.SelectedValuePath = "Codigo";
            rbMasculino.IsChecked = true;
            CarregarParticipantes();
            CarregarRevogados();


            if (_chamadaInicial == true)
            {
                imgSair.Visibility = Visibility.Hidden;
                btnMinuta.IsEnabled = false;

                CarregarDadosSelo();
            }
            else
            {
                verificaCpf = false;
                CarregarDadosTestamento();
                verificaCpf = true;
            }
        }

        private void CarregarRevogados()
        {
         listaRevogados =  _AppServicoRevogados.ObterRevogadosPorIdTestamento(_testamento.TestamentoId);

        }

        private void CarregarNacionalidadesOnu()
        {
            nacionalidadesOnu = _AppServicoNacionalidadesOnu.GetAll();

            cmbNacionalidadeOnu.ItemsSource = nacionalidadesOnu;

            cmbNacionalidadeOnu.DisplayMemberPath = "Pais";

            cmbNacionalidadeOnu.SelectedValuePath = "Codigo";
        }

        private void CarregarNacionalidades()
        {
            nacionalidades = _AppServicoNacionalidades.GetAll();

            cmbNacionalidade.ItemsSource = nacionalidades;

            cmbNacionalidade.DisplayMemberPath = "AdjetivoPatrio";
        }

        private void CarregarDadosTestamento()
        {

            switch (_testamento.Codigo)
            {
                case 2017:
                   cmbTabelaAtos.SelectedIndex = 0;
                    break;

                case 2018:
                    cmbTabelaAtos.SelectedIndex = 1;
                    break;

                case 2019:
                    cmbTabelaAtos.SelectedIndex = 2;
                    break;

                case 2020:
                    cmbTabelaAtos.SelectedIndex = 3;
                    break;

                case 2021:
                    cmbTabelaAtos.SelectedIndex = 4;
                    break;

                default:
                    cmbTabelaAtos.SelectedIndex = -1;
                    break;
            }

            switch (_testamento.Local)
            {
                case "S":
                    cmbLocalPratica.SelectedIndex = 0;
                    break;

                case "F":
                    cmbLocalPratica.SelectedIndex = 1;
                    break;

                case "O":
                    cmbLocalPratica.SelectedIndex = 2;
                    break;

                default:
                    cmbLocalPratica.SelectedIndex = -1;
                    break;
            }

            dtDataAto.SelectedDate = _testamento.DataAto;

            txtLivro.Text = string.Format("{0:000}",_testamento.Livro);
            txtFlsIni.Text = string.Format("{0:000}", _testamento.FolhaInicio);
            txtFlsFim.Text = string.Format("{0:000}", _testamento.FolhaFim);
            txtAto.Text = string.Format("{0:000}", _testamento.NumeroAto);

            txtLetra.Text = _testamento.Letra;
            txtRecibo.Text = _testamento.Recibo;

            if (_testamento.Revogatorio == "S")
                cmbRevogatorio.SelectedIndex = 0;
            else
                cmbRevogatorio.SelectedIndex = 1;

            txtSelo.Text = _testamento.Selo;
            txtAleatorio.Text = _testamento.Aleatorio;

            txtCpfCnpjTestador.Text = _testamento.Cpf;

            if (_testamento.Justificativa != null)           
                cmbJustificativaTestador.Text = _testamento.Justificativa;           
            else
                cmbJustificativaTestador.SelectedIndex = -1;

            txtNomeParte.Text = _testamento.Nome;

            if (_testamento.Sexo == "M")
                rbMasculino.IsChecked = true;
            if (_testamento.Sexo == "F")
                rbFeminino.IsChecked = true;
            if(_testamento.DataNascimento != null && _testamento.DataNascimento != Convert.ToDateTime("01/01/0001"))
            dpDataNascimento.SelectedDate = _testamento.DataNascimento;

            if(_testamento.EstadoCivil != null)
            cmbEstadoCivil.SelectedItem = estadoCivil.Where(p => p.Codigo == Convert.ToInt16(_testamento.EstadoCivil)).FirstOrDefault();

            cmbRegime.Text = _testamento.RegimeCasamento;
                        
            txtNaturalidade.Text = _testamento.Naturalidade;

            var nacion = nacionalidades.Where(p => p.Nacionalidade == _testamento.Nacionalidade).FirstOrDefault();

            cmbNacionalidade.Text = nacion.AdjetivoPatrio;

            var nacionOnu = nacionalidadesOnu.Where(p => p.Codigo == _testamento.CodigoPaisOnu).FirstOrDefault();

            cmbNacionalidadeOnu.Text = nacionOnu.Pais;

            txtEmail.Text = _testamento.Email;

            txtIdentidade.Text = _testamento.Rg;

            if(_testamento.OrgaoRg == "IFP" || _testamento.OrgaoRg == "DETRAN")                
            cmbOrgaoEmissor.Text = _testamento.OrgaoRg;
            else
            {
                cmbOrgaoEmissor.Text = "OUTRO";
                txtOutroOrgao.Text = _testamento.OrgaoRg;
            }

            if (_testamento.DataEmissaoRg != null && _testamento.DataEmissaoRg != Convert.ToDateTime("01/01/0001"))
                dpDataEmissaoIdentidade.SelectedDate = _testamento.DataEmissaoRg;

            txtNomePai.Text = _testamento.Pai;

            txtNomeMae.Text = _testamento.Mae;

            cmbEscreventes.Text = _testamento.Escrevente;


            CarregaCustasExistentes();

            txtCpfCnpjTestador.Focus();

            txtCpfCnpjTestador.Select(0, txtCpfCnpjTestador.Text.Length);
        }

        private void CarregaCustasExistentes()
        {

            listaItensCustas = _AppServicoItensCustas.ObterItensCustasPorIdTestamento(_testamento.TestamentoId);

            CalcularEmolumentos();
            CalcularDistribuicao();
            CalcularMutuaAcoterj();
            CalcularBotaoTotal();

            dataGridCustas.ItemsSource = listaItensCustas;

        }


        private void CarregarEstadoCivil()
        {
            var ec = new EstadoCivil();
            var indiceSelecao = cmbEstadoCivil.SelectedIndex;
            gbEstadoCivil.IsEnabled = true;

            if (rbMasculino.IsChecked == true)
            {
                estadoCivil = ec.ObterListaEstadoCivil(true);
            }
            if (rbFeminino.IsChecked == true)
            {
                estadoCivil = ec.ObterListaEstadoCivil(false);
            }

            cmbEstadoCivil.ItemsSource = estadoCivil;
            cmbEstadoCivil.DisplayMemberPath = "Descricao";
            cmbEstadoCivil.SelectedValuePath = "Codigo";
            cmbEstadoCivil.SelectedIndex = indiceSelecao;
        }


        private void CarregarLocalTestamento()
        {

            localProcuracao = localProc.ObterListaLocalProcuracao();

            cmbLocalPratica.ItemsSource = localProcuracao;

            cmbLocalPratica.DisplayMemberPath = "Descricao";

            cmbLocalPratica.SelectedIndex = 0;
        }


        private void CarregarDadosSelo()
        {
            try
            {
                dtDataAto.SelectedDate = _selo.DataReservado;

                txtLivro.Text = _selo.Livro;
                txtFlsIni.Text =string.Format("{0:000}", _selo.FolhaInicial);
                txtFlsFim.Text = string.Format("{0:000}", _selo.FolhaFinal);
                txtAto.Text = string.Format("{0:000}", _selo.NumeroAto);
                txtSelo.Text = string.Format("{0}{1}", _selo.Letra, _selo.Numero);
                txtAleatorio.Text = _selo.Aleatorio;
                cmbEscreventes.SelectedItem = escreventes.Where(p => p.UsuarioId == _selo.IdUsuarioReservado).FirstOrDefault();
                cmbTabelaAtos.SelectedIndex = 2;
                cmbRevogatorio.SelectedIndex = 1;
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
                if (_chamadaInicial == true)
                tabelaCustas = listaTabelaCustas.Where(p => (p.Ano == _selo.DataReservado.Date.Year) && ((p.Tabela == "22" && p.Item == "5"))).OrderBy(p => p.Ordem).ToList();
                else
                    tabelaCustas = listaTabelaCustas.Where(p => (p.Ano == _testamento.DataAto.Date.Year) && ((p.Tabela == "22" && p.Item == "5"))).OrderBy(p => p.Ordem).ToList();
                cmbTabelaAtos.ItemsSource = tabelaCustas;
                cmbTabelaAtos.DisplayMemberPath = "Descricao";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar TABELA DE ATOS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CarregarParticipantes()
        {
            try
            {
                if (_testamento != null && _testamento.TestamentoId > 0)
                {
                    listaNomes = _AppServicoNomes.ObterNomesPorIdTestamento(_testamento.TestamentoId);
                }

                Participante participante;

                foreach (var item in listaNomes)
                {
                    var pessoa = _AppServicoPessoas.GetById(item.IdPessoa);

                    listaPessoas.Add(pessoa);
                    participante = new Participante();
                    participante.IdAto = _testamento.TestamentoId;
                    participante.IdNomes = item.NomeId;
                    participante.IdPessoa = pessoa.PessoasId;
                    participante.Nome = pessoa.Nome;
                    participante.Descricao = item.Descricao;
                    participante.CpfCnpj = pessoa.CpfCgc;

                    participantes.Add(participante);
                }

                
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
                cmbEscreventes.Text = _testamento.Login;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações de Escreventes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
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

        private void cmbLocalProcuracao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void txtCpfCnpj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCpfCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                
                ValidarCpfCnpj();
            }
            catch (Exception) { };
        }

        private void ValidarCpfCnpj()
        {
            imgValidaCpfCnpj.Visibility = Visibility.Hidden;
            txtCpfCnpjTestador.Background = Brushes.Red;

            if (txtCpfCnpjTestador.Text.Length == 11)
            {
                bool cpfValido = ValidaCpfCnpj.ValidaCPF(txtCpfCnpjTestador.Text);

                if (cpfValido == true)
                {
                    imgValidaCpfCnpj.Visibility = Visibility.Visible;
                    txtCpfCnpjTestador.Background = Brushes.White;
                    rbMasculino.IsEnabled = true;
                    rbFeminino.IsEnabled = true;

                    if (verificaCpf == true)
                    {
                        txtNomeParte.Focus();
                        ProcurarNomesJaCadastrados();
                    }
                }
            }

            if (txtCpfCnpjTestador.Text != "")
            {
                cmbJustificativaTestador.SelectedIndex = -1;
                cmbJustificativaTestador.IsEnabled = false;
            }
            else
                cmbJustificativaTestador.IsEnabled = true;
        }

        private void ProcurarNomesJaCadastrados()
        {
            var nomes = new List<Pessoas>();

            nomes = _AppServicoPessoas.ObterListaPessoasPorCpfCnpj(txtCpfCnpjTestador.Text);

            if (nomes.Count > 0)
            {
                var nomesExistentes = new ConsultaNomesExistentes(nomes, this);
                nomesExistentes.Owner = this;
                nomesExistentes.ShowDialog();

            }
                        

        }






        private void txtNomeParte_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNomeParte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dpDataNascimento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dpDataNascimento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbEstadoCivil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEstadoCivil.SelectedIndex == 0 || cmbEstadoCivil.SelectedIndex == 4 || cmbEstadoCivil.SelectedIndex == 7)
            {
                cmbRegime.ItemsSource = null;
                cmbRegime.IsEnabled = false;
            }
            else
            {
                cmbRegime.IsEnabled = true;
                CarregarRegimeCasamento();
            }
        }

        private void CarregarRegimeCasamento()
        {

            regimes = _AppServicoRegimes.GetAll().ToList();

            cmbRegime.ItemsSource = regimes;

            cmbRegime.DisplayMemberPath = "Descricao";
        }

        private void cmbEstadoCivil_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbRegime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbNacionalidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbNacionalidadeOnu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbNacionalidadeOnu_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtIdentidade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtIdentidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbOrgaoEmissor_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void cmbOrgaoEmissor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbOrgaoEmissor_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtNaturalidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNaturalidade_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dpDataEmissaoIdentidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dpDataEmissaoIdentidade_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNomePai_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNomeMae_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSalvarSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SalvarTestamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalvarTestamento()
        {

            var nacionalidade = (Nacionalidades)cmbNacionalidade.SelectedItem;

            var nacionalidadeOnu = (NacionalidadesOnu)cmbNacionalidadeOnu.SelectedItem;

            var escrevente = (Cs_Notas.Dominio.Entities.Usuario)cmbEscreventes.SelectedItem;

            var estadoCivil = (EstadoCivil)cmbEstadoCivil.SelectedItem;

            var local = (LocalProcuracao)cmbLocalPratica.SelectedItem;

            var tabela = (TabelaCustas)cmbTabelaAtos.SelectedItem;

            if (txtAcoterj.Text != "")
                _testamento.Acoterj = Convert.ToDecimal(txtAcoterj.Text);
            else
                _testamento.Acoterj = 0;

            _testamento.Aleatorio = txtAleatorio.Text;

            _testamento.Cancelado = "N";
            
           
            switch (tabela.SubItem)
            {
                case "I-A":
                    _testamento.Codigo = 2017;
                    break;

                case "I-B":
                    _testamento.Codigo = 2018;
                    break;

                case "II":
                    _testamento.Codigo = 2019;
                    break;

                case "II-A":
                    _testamento.Codigo = 2020;
                    break;

                case "II-B":
                    _testamento.Codigo = 2021;
                    break;

                default:

                    break;
            }

                       
            
            if(nacionalidade != null)
            _testamento.CodigoPais = nacionalidade.Codigo;
            else
                _testamento.CodigoPais = 0;

            if(nacionalidadeOnu != null)
            _testamento.CodigoPaisOnu = nacionalidadeOnu.Codigo;
            else
                _testamento.CodigoPaisOnu = 0;

            
            _testamento.Cpf = txtCpfCnpjTestador.Text;

            if (escrevente != null)
                _testamento.CpfEscrevente = escrevente.Cpf;

            if(dtDataAto.SelectedDate != null)
            _testamento.DataAto = dtDataAto.SelectedDate.Value;

            if (dpDataEmissaoIdentidade.SelectedDate != null)
            _testamento.DataEmissaoRg = dpDataEmissaoIdentidade.SelectedDate.Value;


            _testamento.DataModificado = DateTime.Now.Date;

            if (dpDataNascimento.SelectedDate != null)
            _testamento.DataNascimento = dpDataNascimento.SelectedDate.Value;

            if(txtDistribuicao.Text != "")
            _testamento.Distribuicao = Convert.ToDecimal(txtDistribuicao.Text);

            _testamento.Email = txtEmail.Text.Trim();

            if(txtEmolumentos.Text != "")
            _testamento.Emolumentos = Convert.ToDecimal(txtEmolumentos.Text);

            _testamento.Escrevente = escrevente.Nome;

            if(estadoCivil != null)
            _testamento.EstadoCivil = estadoCivil.Codigo.ToString();

            if (txtFetj.Text != null)
            _testamento.Fetj = Convert.ToDecimal(txtFetj.Text);

            if(txtFlsFim.Text != "")
            _testamento.FolhaFim = Convert.ToInt32(txtFlsFim.Text);

            if(txtFlsIni.Text != "")
            _testamento.FolhaInicio = Convert.ToInt32(txtFlsIni.Text);

            if (txtFunarpen.Text != null)
            _testamento.Funarpen = Convert.ToDecimal(txtFunarpen.Text);

            if (txtFundperj.Text != null)
            _testamento.Fundperj = Convert.ToDecimal(txtFundperj.Text);

            if (txtFunperj.Text != null)
            _testamento.Funprj = Convert.ToDecimal(txtFunperj.Text);

            _testamento.HoraModificado = DateTime.Now.ToLongTimeString();

            if (txtIss.Text != null)
            _testamento.Iss = Convert.ToDecimal(txtIss.Text);

            if (txtCpfCnpjTestador.Text == "")
            {
                var justificativa = (JustificativaCpf)cmbJustificativaTestador.SelectedItem;

                if(justificativa != null)
                _testamento.Justificativa = justificativa.Descricao;

                _testamento.TipoJustificativa = justificativa.Codigo;
            }

            if(txtLetra.Text != "")
            _testamento.Letra = txtLetra.Text;
            else
                _testamento.Letra = null;


            _testamento.Livro = txtLivro.Text;

            if(local != null)
            _testamento.Local = local.Sigla;

            _testamento.Login = _usuario.Nome;

            _testamento.Mae = txtNomeMae.Text.Trim();

            if(txtMutua.Text != "")
            _testamento.Mutua = Convert.ToDecimal(txtMutua.Text);

            _testamento.Nacionalidade = nacionalidade.Nacionalidade;

            _testamento.Naturalidade = txtNaturalidade.Text.Trim();

            _testamento.Nome = txtNomeParte.Text.Trim();

            if(txtAto.Text != "")
            _testamento.NumeroAto = Convert.ToInt32(txtAto.Text);


            switch (cmbOrgaoEmissor.SelectedIndex)
            {
                case 0:
                    _testamento.OrgaoRg = "IFP";
                    break;

                case 1:
                    _testamento.OrgaoRg = "DETRAN";
                    break;

                case 2:
                    _testamento.OrgaoRg = txtOutroOrgao.Text.Trim();
                    break;

                default:
                    break;
            }

            _testamento.Pai = txtNomePai.Text.Trim();

            if(txtPmcmv.Text != "")
            _testamento.Pmcmv = Convert.ToDecimal(txtPmcmv.Text);

            if (txtRecibo.Text != "")
                _testamento.Recibo = txtRecibo.Text.Trim();
            else
                _testamento.Recibo = null;

            _testamento.RegimeCasamento = cmbRegime.Text;

            if (cmbRevogatorio.SelectedIndex == 0)
                _testamento.Revogatorio = "S";
            else
                _testamento.Revogatorio = "N";

            _testamento.Rg = txtIdentidade.Text.Trim();

            _testamento.Selo = txtSelo.Text;

            if(rbMasculino.IsChecked == true)
            _testamento.Sexo = "M";

            if (rbFeminino.IsChecked == true)
                _testamento.Sexo = "F";

            _testamento.TipoAto = "RT";

            switch (cmbTipoCustas.SelectedIndex)
            {
                case 0:
                    _testamento.TipoCobranca = "JG";
                    break;

                case 1:
                    _testamento.TipoCobranca = "CC";
                    break;

                case 2:
                    _testamento.TipoCobranca = "SC";
                    break;

                case 3:
                    _testamento.TipoCobranca = "NH";
                    break;

                case 4:
                    _testamento.TipoCobranca = "PA";
                    break;

                default:

                    break;
            }

            if (cmbTabelaAtos.SelectedIndex <= 1)
                _testamento.TipoTestamento = "C";
            else
                _testamento.TipoTestamento = "P";

            if(txtTotal.Text != "")
            _testamento.Total = Convert.ToDecimal(txtTotal.Text);


            estado = "salvando";
            var aguarde = new AguardeSalvandoTestamento(this);
            aguarde.Owner = this;
            aguarde.ShowDialog();

            if (estado == "salvando")
            this.Close();
        
        }

        private void rbMasculino_Checked(object sender, RoutedEventArgs e)
        {
            CarregarEstadoCivil();
        }

        private void rbMasculino_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbFeminino_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbFeminino_Checked(object sender, RoutedEventArgs e)
        {
            CarregarEstadoCivil();
        }

        private void imgSair_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if(MessageBox.Show("Deseja realmente sair sem salvar?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            this.Close();
        }

        private void cmbRegime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbOrgaoEmissor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOrgaoEmissor.SelectedIndex < 2)
            {
                txtOutroOrgao.Text = "";
                txtOutroOrgao.IsEnabled = false;
            }
            else
            {
                txtOutroOrgao.IsEnabled = true;
                if(_chamadaInicial == true)
                txtOutroOrgao.Focus();
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

        private void GroupBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gbJustificativa_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void btnMinuta_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnTestemunhas_Click(object sender, RoutedEventArgs e)
        {
            var testemunhas = new Testemunhas(this);
            testemunhas.Owner = this;
            testemunhas.ShowDialog();
        }

        private void Revogados_Click(object sender, RoutedEventArgs e)
        {
            var revogados = new DadosRevogados(this);
            revogados.Owner = this;
            revogados.ShowDialog();
        }

        private void btnRecalcular_Click(object sender, RoutedEventArgs e)
        {
            CarregarCustas();
        }
    }
}
