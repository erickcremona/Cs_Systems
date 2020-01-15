
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.ValuesObject;
using Cs_Notas.Windows.Escritura;
using Cs_Notas.WindowsAgurde;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Cs_Notas.Windows
{
    /// <summary>
    /// Interaction logic for DigitarEscritura.xaml
    /// </summary>
    public partial class DigitarEscritura : Window
    {
        public List<Selos> _selos;
        public Escrituras _escrituras;
        public Cs_Notas.Dominio.Entities.Usuario _usuario;
        public List<Naturezas> naturezas = new List<Naturezas>();
        List<Censec> naturezaCensec = new List<Censec>();
        List<TabelaCustas> tabelaCustas = new List<TabelaCustas>();
        public List<Participante> participantes = new List<Participante>();
        public List<Pessoas> listaPessoas = new List<Pessoas>();
        public List<Nomes> listaNomes = new List<Nomes>();
        public string estado = string.Empty;
        public List<AtoConjuntos> listaAtoConjuntos = new List<AtoConjuntos>();
        public List<Imovel> listaImoveis = new List<Imovel>();
        public List<BensAtosConjuntos> listaBensAtosConjuntos = new List<BensAtosConjuntos>();
        public List<AtoConjuntos> listaAtos = new List<AtoConjuntos>();
        public List<ParteConjuntos> listaParteConjuntos = new List<ParteConjuntos>();
        public Participante parte = new Participante();
        List<Cs_Notas.Dominio.Entities.Usuario> escreventes = new List<Cs_Notas.Dominio.Entities.Usuario>();
        public List<ProcuracaoEscritura> listaProcuracao = new List<ProcuracaoEscritura>();
        ProcuracaoEscritura procuracao;
        public List<TabelaCustas> listaTabelaCustas = new List<TabelaCustas>();
        public List<ItensCustas> listaItensCustas = new List<ItensCustas>();
        public Configuracoes configuracoes = new Configuracoes();
        decimal alicotaIss;
        List<ItensCustas> emolumentos = new List<ItensCustas>();
        string Observacao;
        bool _chamadaInicial;
        bool _recalcular = false;
        public int Ano;
        public List<int> anosCustasExistentes = new List<int>();
        List<FileInfo> listaArquivos = new List<FileInfo>();


        private readonly IAppServicoNaturezas _AppServicoNaturezas = BootStrap.Container.GetInstance<IAppServicoNaturezas>();
        private readonly IAppServicoCensec _AppServicoCensec = BootStrap.Container.GetInstance<IAppServicoCensec>();
        private readonly IAppServicoAdicional _AppServicoAdicional = BootStrap.Container.GetInstance<IAppServicoAdicional>();
        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();
        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoParteConjuntos _AppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();
        private readonly IAppServicoProcuracaoEscritura _AppServicoProcuracaoEscritura = BootStrap.Container.GetInstance<IAppServicoProcuracaoEscritura>();
        private readonly IAppServicoTabelaCustas _AppServicoTabelaCustas = BootStrap.Container.GetInstance<IAppServicoTabelaCustas>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();
        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();
        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();
        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();
        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();

        public DigitarEscritura(Escrituras escrituras, Cs_Notas.Dominio.Entities.Usuario usuario, bool chamadaInicial)
        {
            _escrituras = escrituras;
            _usuario = usuario;
            _chamadaInicial = chamadaInicial;

            InitializeComponent();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Ano = _escrituras.DataAtoRegistro.Date.Year;

            listaTabelaCustas = _AppServicoTabelaCustas.GetAll().ToList();
            anosCustasExistentes = listaTabelaCustas.Select(p => p.Ano).Distinct().ToList();


            configuracoes = _AppServicoConfiguracoes.GetById(1);
            alicotaIss = _AppServicoParametros.GetById(1).AlicotaIss;
            CarregarEscreventes();
            CarregarProcuracao();
            CarregarParticipantes();
            CarregarParteConjuntos();
            CarrergarImoveis();
            CarregarBensAtoConjuntos();
            CarregarComboBoxTabelaAtos();

            CarregarDadosEscritura();

            CarregarDadosSelo();

            if (_chamadaInicial == true)
            {
                imgSair.Visibility = Visibility.Hidden;
                btnMinuta.IsEnabled = false;
            }

        }

        private void CarregarBensAtoConjuntos()
        {
            listaBensAtosConjuntos = _AppServicoBensAtosConjuntos.ObterBensAtoConjuntosPorIdAto(_escrituras.EscriturasId);
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
                        atoConjunto.IdEscritura = _escrituras.EscriturasId;
                        atoConjunto.ConjuntoId = 0;
                        atoConjunto.Selo = string.Format("{0}", _escrituras.SeloEscritura);
                        atoConjunto.Aleatorio = _escrituras.Aleatorio;
                        atoConjunto.Ordem = 1;
                        atoConjunto.Data = _escrituras.DataAtoRegistro;
                        atoConjunto.Livro = _escrituras.LivroEscritura;
                        atoConjunto.Folhas = string.Format("{0}-{1}", _escrituras.FolhasInicio, _escrituras.FolhasFim);
                        atoConjunto.Ato = string.Format("{0}", _escrituras.NumeroAto);
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


        private void CarregarProcuracao()
        {
            if (_escrituras != null)
            {
                listaProcuracao = _AppServicoProcuracaoEscritura.ObterProcuracoesPorIdAto(_escrituras.EscriturasId);
                dataGridProcuracao.ItemsSource = listaProcuracao;
                if (dataGridProcuracao.Items.Count > 0)
                    dataGridProcuracao.SelectedIndex = 0;
            }
        }



        private void CarrergarImoveis()
        {

            listaImoveis = _AppServicoImovel.ObterImoveisPorIdAto(_escrituras.EscriturasId);

            dataGridImovel.ItemsSource = listaImoveis;

            if (dataGridImovel.Items.Count > 0)
                dataGridImovel.SelectedIndex = 0;
        }

        private void CarregarComboBoxRespFilhosMenores()
        {
            var respFilhosMenores = new ResponsavelFilhosMenores();
            cmbResponsavelFilhosMenores.ItemsSource = respFilhosMenores.ListarResponsavelFilhosMenores();
            cmbResponsavelFilhosMenores.SelectedValuePath = "Codigo";
            cmbResponsavelFilhosMenores.DisplayMemberPath = "Descricao";
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

        private void CarregarParteConjuntos()
        {
            try
            {
                if (_escrituras != null)
                {
                    listaParteConjuntos = _AppServicoParteConjuntos.ListarPorIdAto(_escrituras.EscriturasId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações dos Participantes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarParticipantes()
        {
            try
            {
                if (_escrituras != null)
                {
                    listaNomes = _AppServicoNomes.ObterNomesPorIdAto(_escrituras.EscriturasId);
                }

                Participante participante;

                foreach (var item in listaNomes)
                {
                    var pessoa = _AppServicoPessoas.GetById(item.IdPessoa);

                    listaPessoas.Add(pessoa);
                    participante = new Participante();
                    participante.IdAto = _escrituras.EscriturasId;
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


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações de Escreventes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarDadosEscritura()
        {
            try
            {

                cmbTabelaAtos.SelectedItem = _AppServicoTabelaCustas.GetById(_escrituras.IdCodigoTabelaCustas);

                cmbNaturezas.SelectedItem = naturezas.Where(p => p.Codigo.ToString() == _escrituras.Natureza).FirstOrDefault();

                if (_escrituras.Natureza == "999")
                {
                    txtOutros.Text = _escrituras.Descricao;
                }

                cmbNaturezaCensec.SelectedItem = naturezaCensec.Where(p => p.Codigo == _escrituras.NaturezaCensec).FirstOrDefault();

                cmbEscreventes.SelectedItem = escreventes.Where(p => p.Cpf == _escrituras.CpfEscrevente).FirstOrDefault();

                dtDataAto.SelectedDate = _escrituras.DataAtoRegistro;
                txtLivro.Text = _escrituras.LivroEscritura;
                txtFlsIni.Text = string.Format("{0:000}", _escrituras.FolhasInicio);
                txtFlsFim.Text = string.Format("{0:000}", _escrituras.FolhasFim);
                txtAto.Text = string.Format("{0:000}", _escrituras.NumeroAto);
                txtRecibo.Text = _escrituras.Recibo;
                txtSelo.Text = string.Format("{0}", _escrituras.SeloEscritura);
                txtAleatorio.Text = _escrituras.Aleatorio;
                txtObservacao.Text = _escrituras.Observacao;

                txtBaseCalculo.Text = string.Format("{0:n2}", _escrituras.ValorEscritua);
                if (_escrituras.QtdFilhosMenores != 0)
                    txtQtdFilhosMenores.Text = Convert.ToString(_escrituras.QtdFilhosMenores);

                cmbResponsavelFilhosMenores.SelectedIndex = _escrituras.ResponsavelFilhosMenores;


                if (_escrituras.IndAlvara == "S")
                    ckbAlvaraJudicial.IsChecked = true;
                else
                    ckbAlvaraJudicial.IsChecked = false;

                switch (_escrituras.TipoCobranca)
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
                    txtEmolumentos.Text = string.Format("{0:n2}", _escrituras.Emolumentos);
                    txtFetj.Text = string.Format("{0:n2}", _escrituras.Fetj);
                    txtFunperj.Text = string.Format("{0:n2}", _escrituras.Funprj);
                    txtFundperj.Text = string.Format("{0:n2}", _escrituras.Fundperj);
                    txtFunarpen.Text = string.Format("{0:n2}", _escrituras.Funarpen);
                    txtPmcmv.Text = string.Format("{0:n2}", _escrituras.Pmcmv);
                    txtIss.Text = string.Format("{0:n2}", _escrituras.Iss);
                    txtDistribuicao.Text = string.Format("{0:n2}", _escrituras.Distribuicao);
                    txtMutua.Text = string.Format("{0:n2}", _escrituras.Mutua);
                    txtAcoterj.Text = string.Format("{0:n2}", _escrituras.Acoterj);
                    txtTotal.Text = string.Format("{0:n2}", _escrituras.Total);
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
            listaAtoConjuntos = _AppServicoAtoConjuntos.ObterAtosConjuntosPorIdAto(_escrituras.EscriturasId);

            dataGridAtoConjuntos.ItemsSource = listaAtoConjuntos.OrderBy(p => p.Ordem);
            if (dataGridAtoConjuntos.Items.Count > 0)
                dataGridAtoConjuntos.SelectedIndex = 0;
        }

        private void CarregarListaItensCustas()
        {
            listaItensCustas = _AppServicoItensCustas.ObterItensCustasPorIdAto(_escrituras.EscriturasId);

            dataGridCustas.ItemsSource = listaItensCustas;

            if (dataGridCustas.Items.Count > 0)
                dataGridCustas.SelectedIndex = 0;
        }

        private void CarregarComboBoxTabelaAtos()
        {
            try
            {
                tabelaCustas = listaTabelaCustas.Where(p => (p.Ano == Ano) && ((p.Tabela == "22" && p.Item == "1") || (p.Tabela == "22" && p.Item == "1.1") || (p.Tabela == "22" && p.Item == "1.2")
                  || (p.Tabela == "22" && p.Item == "1.3") || (p.Tabela == "22" && p.Item == "1.4" && p.SubItem == "*") || (p.Tabela == "22" && p.Item == "7") ||
                  (p.Tabela == "22" && p.Item == "6" && p.SubItem == "*"))).OrderBy(p => p.Ordem).ToList();
                cmbTabelaAtos.ItemsSource = tabelaCustas;
                cmbTabelaAtos.DisplayMemberPath = "Descricao";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar TABELA DE ATOS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void CarregarComboBoxNaturezaCensec()
        {
            try
            {
                naturezaCensec = _AppServicoCensec.GetAll().ToList();
                cmbNaturezaCensec.ItemsSource = naturezaCensec;
                cmbNaturezaCensec.DisplayMemberPath = "Descricao";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar NATUREZAS CENSEC. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarregarComboBoxNaturezas()
        {
            try
            {
                naturezas = _AppServicoNaturezas.GetAll().Where(p => p.Codigo >= 1).ToList();
                cmbNaturezas.ItemsSource = naturezas;
                cmbNaturezas.DisplayMemberPath = "Descricao";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar NATUREZAS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string mensagem;

                bool sim = false;
                bool nao = false;



                DateTime data;

                if (dpDataProcuracao.SelectedDate != null)
                    data = dpDataProcuracao.SelectedDate.Value;
                else
                    data = new DateTime();

                if (rbSimProcuracao.IsChecked == true)
                    sim = true;


                if (rbNaoProcuracao.IsChecked == true)
                    nao = true;


                procuracao = _AppServicoProcuracaoEscritura.ObterUmObjetoProcuracao(data, txtServentiaProcuracao.Text, txtLivroProcuracao.Text, txtFolhasProcuracao.Text, txtAtoProcuracao.Text,
                   txtOutorgantesProcuracao.Text, txtOutorgadosProcuracao.Text, txtSeloProcuracao.Text, txtAleatorioProcuracao.Text, sim, nao, out mensagem);



                if (mensagem != "ok")
                {
                    MessageBox.Show(mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {

                    if (estado == "adicionar procuracao")
                    {
                        procuracao.IdEscritura = _escrituras.EscriturasId;
                        _AppServicoProcuracaoEscritura.Add(procuracao);
                        listaProcuracao.Add(procuracao);
                    }
                    else
                    {
                        var alterarBanco = _AppServicoProcuracaoEscritura.GetById(((ProcuracaoEscritura)dataGridProcuracao.SelectedItem).ProcuracaoEscrituraId);

                        alterarBanco.Aleatorio = procuracao.Aleatorio;
                        alterarBanco.Ato = procuracao.Ato;
                        alterarBanco.CodigoServentia = procuracao.CodigoServentia;
                        alterarBanco.Data = procuracao.Data;
                        alterarBanco.Folhas = procuracao.Folhas;
                        alterarBanco.IdEscritura = _escrituras.EscriturasId;
                        alterarBanco.Lavrado = procuracao.Lavrado;
                        alterarBanco.Livro = procuracao.Livro;
                        alterarBanco.Outorgados = procuracao.Outorgados;
                        alterarBanco.Outorgantes = procuracao.Outorgantes;
                        alterarBanco.Selo = procuracao.Selo;
                        alterarBanco.Serventia = procuracao.Serventia;
                        alterarBanco.UfOrigem = procuracao.UfOrigem;


                        _AppServicoProcuracaoEscritura.Update(alterarBanco);

                        procuracao = alterarBanco;
                    }


                    listaProcuracao = _AppServicoProcuracaoEscritura.ObterProcuracoesPorIdAto(_escrituras.EscriturasId);
                    dataGridProcuracao.ItemsSource = listaProcuracao;

                    dataGridProcuracao.SelectedItem = procuracao;
                    dataGridProcuracao.ScrollIntoView(procuracao);
                }


                FecharDigitacaoProcuracao();

                estado = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void cmbNaturezas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var natureza = naturezas[cmbNaturezas.SelectedIndex];

                if (natureza.Censec == "S")
                    ckbCensec.IsChecked = true;
                else
                    ckbCensec.IsChecked = false;

                if (natureza.Doi == "S")
                    ckbDoi.IsChecked = true;
                else
                    ckbDoi.IsChecked = false;

                if (natureza.Codigo == 999)
                {
                    txtOutros.IsEnabled = true;
                    txtOutros.Focus();
                }
                else
                {
                    txtOutros.Text = "";
                    txtOutros.IsEnabled = false;
                }
                if (natureza.Tipo == "E")
                {
                    cmbNaturezaCensec.IsEnabled = true;
                    CarregarComboBoxNaturezaCensec();

                }
                else
                {
                    cmbNaturezaCensec.ItemsSource = null;
                    cmbNaturezaCensec.IsEnabled = false;

                }

                if (natureza.Tipo == "D")
                {
                    cmbResponsavelFilhosMenores.IsEnabled = true;
                    txtQtdFilhosMenores.IsEnabled = true;
                    CarregarComboBoxRespFilhosMenores();
                }
                else
                {
                    cmbResponsavelFilhosMenores.IsEnabled = false;
                    txtQtdFilhosMenores.IsEnabled = false;
                    cmbResponsavelFilhosMenores.ItemsSource = null;
                    txtQtdFilhosMenores.Text = "";
                }

                if (natureza.Codigo >= 125 && natureza.Codigo <= 128 || natureza.Codigo == 130)
                    btnOrigem.IsEnabled = true;
                else
                    btnOrigem.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar NATUREZAS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ckbDoi_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbDoi.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Doi = "S";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void ckbCensec_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbCensec.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Censec = "S";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void ckbDoi_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbDoi.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Doi = "N";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void ckbCensec_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbCensec.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Censec = "N";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void cmbTabelaAtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (_chamadaInicial == true || _recalcular == true)
                    CarregarCustas();

                CarregarComboBoxNaturezas();

                btnCalcular.IsEnabled = true;

                btnCustas.IsEnabled = true;

                lblCustas.IsEnabled = true;

            }
            catch (Exception) { }
        }


        private void CarregarCustas()
        {

            var item = (TabelaCustas)cmbTabelaAtos.SelectedItem;

            txtBaseCalculo.IsEnabled = true;

            tabelaCustas = _AppServicoTabelaCustas.CalcularItensCustas(item.Descricao, Ano);

            txtBaseCalculo.IsEnabled = false;

            if (cmbTabelaAtos.SelectedIndex == 8 || cmbTabelaAtos.SelectedIndex == 13 || cmbTabelaAtos.SelectedIndex == 11)
                CalcularItensCustas(tabelaCustas, "3");

            if (cmbTabelaAtos.SelectedIndex == 9 || cmbTabelaAtos.SelectedIndex == 10 || cmbTabelaAtos.SelectedIndex == 14)
                CalcularItensCustas(tabelaCustas, "2");

            if (cmbTabelaAtos.SelectedIndex < 8 || cmbTabelaAtos.SelectedIndex > 14 || cmbTabelaAtos.SelectedIndex == 12)
                CalcularItensCustas(tabelaCustas, "4");

            CalcularEmolumentos();
            CalcularDistribuicao();
            CalcularMutuaAcoterj();
            CalcularBotaoTotal();

            dataGridCustas.ItemsSource = listaItensCustas;

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



        private void btnAdicionarParte_Click(object sender, RoutedEventArgs e)
        {
            estado = "adicionando participante";

            if (cmbNaturezas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Natureza antes de adicionar o participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            CarregarDataGridParticipantes();
        }

        private void CarregarDataGridParticipantes()
        {
            try
            {
                var qtdNaListaParticipantes = participantes.Count;

                var digitarParte = new DigitarDadosParticipante(this);
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

        private void dataGridParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarComponentes();

        }

        private void btnAlterarParte_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridParticipantes.Items.Count < 1)
            {
                return;
            }

            if (cmbNaturezas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Natureza antes de alterar o participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void dataGridParticipantes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnAlterarParte_Click(sender, e);
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

        private void dataGridParticipantes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                btnExcluirParte_Click(sender, e);
        }

        private void txtQtdFilhosMenores_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void dataGridAtoConjuntos_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridAtoConjuntos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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


        private void dataGridAtoConjuntos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnAlterarAtoConjunto_Click(sender, e);
        }


        private void btnAdicionarAtoConjunto_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Natureza antes de adicionar o participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var atoConjunto = new AtoConjuntos();

            atoConjunto.IdEscritura = _escrituras.EscriturasId;
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

            var digitarAtoConjunto = new DigitarAtoConjunto(this, "adicionando", atoConjunto);
            digitarAtoConjunto.Owner = this;
            digitarAtoConjunto.ShowDialog();
            CarregarAtoConjunto();
        }

        private void btnAlterarAtoConjunto_Click(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Natureza antes de adicionar o participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dataGridAtoConjuntos.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um Ato Conjunto.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var digitarAtoConjunto = new DigitarAtoConjunto(this, "alterando", (AtoConjuntos)dataGridAtoConjuntos.SelectedItem);
            digitarAtoConjunto.Owner = this;
            digitarAtoConjunto.ShowDialog();
            CarregarAtoConjunto();
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

        private void btnAdicionarImovel_Click(object sender, RoutedEventArgs e)
        {

            estado = "adicionando imovel";

            var tipoBem = new TipoBemEscritura(this);
            tipoBem.Owner = this;
            tipoBem.ShowDialog();



            estado = string.Empty;

        }

        private void dataGridImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridImovel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarImovel();
        }

        private void CarregarImovel()
        {

            var imovelSelecionado = (Imovel)dataGridImovel.SelectedItem;


            if (imovelSelecionado != null)
            {

                if (imovelSelecionado.TipoBem == "I")
                {
                    gridImovel.Visibility = Visibility.Visible;
                    gridMovelOutros.Visibility = Visibility.Hidden;

                    if (imovelSelecionado.TipoImovel == "U")
                        txtZonaImovel.Text = "URBANO";

                    if (imovelSelecionado.TipoImovel == "R")
                        txtZonaImovel.Text = "RURAL";


                    if (imovelSelecionado.SubTipo == "1")
                        txtTipoImovel.Text = "TERRENO";

                    if (imovelSelecionado.SubTipo == "2")
                        txtTipoImovel.Text = "EDIFICAÇÃO";

                    switch (imovelSelecionado.TipoRecolhimento)
                    {
                        case "N":
                            txtRecolhimentoImovel.Text = "NORMAL";
                            break;

                        case "I":
                            txtRecolhimentoImovel.Text = "ISENTO";
                            break;

                        case "F":
                            txtRecolhimentoImovel.Text = "FUTURO";
                            break;

                        default:
                            txtRecolhimentoImovel.Text = "";
                            break;
                    }

                    txtTipoImpostoImovel.Text = imovelSelecionado.TipoImposto;

                    txtNumeroGuiaImovel.Text = imovelSelecionado.Guia;

                    txtValorGuiaImovel.Text = string.Format("{0:n2}", imovelSelecionado.ValorGuia);

                    txtValorBemImovel.Text = string.Format("{0:n2}", imovelSelecionado.Valor);

                    txtValorAlienadoImovel.Text = string.Format("{0:n2}", imovelSelecionado.ValorAlienacao);

                    txtMatriculaImovel.Text = imovelSelecionado.Matricula;

                    txtInscricaoImobiliariaImovel.Text = imovelSelecionado.InscricaoImobiliaria;
                }

                if (imovelSelecionado.TipoBem == "M" || imovelSelecionado.TipoBem == "O")
                {
                    gridImovel.Visibility = Visibility.Hidden;
                    gridMovelOutros.Visibility = Visibility.Visible;

                    if (imovelSelecionado.TipoBem == "M")
                    {
                        imgAutomovel.Visibility = Visibility.Visible;
                        imgOutros.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        imgAutomovel.Visibility = Visibility.Hidden;
                        imgOutros.Visibility = Visibility.Visible;
                    }
                    txtValorAlienadoMovelOutros.Text = string.Format("{0:n2}", imovelSelecionado.Valor);

                    txtObjetoMovelOutros.Text = imovelSelecionado.Objeto;
                }

            }
            else
            {

                gridImovel.Visibility = Visibility.Visible;
                gridMovelOutros.Visibility = Visibility.Hidden;

                txtZonaImovel.Text = "";

                txtZonaImovel.Text = "";

                txtTipoImovel.Text = "";

                txtTipoImovel.Text = "";

                txtRecolhimentoImovel.Text = "";

                txtTipoImpostoImovel.Text = "";

                txtNumeroGuiaImovel.Text = "";

                txtValorGuiaImovel.Text = "";

                txtValorBemImovel.Text = "";

                txtValorAlienadoImovel.Text = "";

                txtMatriculaImovel.Text = "";

                txtInscricaoImobiliariaImovel.Text = "";

                txtObjetoMovelOutros.Text = "";
            }
        }

        private void AlterarImovel()
        {
            if (dataGridImovel.Items.Count < 1)
                return;

            if (dataGridImovel.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um imóvel.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            estado = "alterando imovel";

            var imovel = (Imovel)dataGridImovel.SelectedItem;

            if (imovel.TipoBem == "I")
            {
                var imovelEscritura = new ImovelEscritura(this, imovel.TipoBem);
                imovelEscritura.Owner = this;
                imovelEscritura.ShowDialog();
            }

            if (imovel.TipoBem == "M" || imovel.TipoBem == "O")
            {
                var movelOutros = new MovelOutrosEscritura(this, imovel.TipoBem);
                movelOutros.Owner = this;
                movelOutros.ShowDialog();
            }

            estado = string.Empty;
        }

        private void btnAlterarImovel_Click(object sender, RoutedEventArgs e)
        {
            AlterarImovel();

            dataGridImovel.Items.Refresh();

            CarregarImovel();
        }

        private void dataGridImovel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AlterarImovel();
        }

        private void btnExcluirImovel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridImovel.Items.Count < 1)
                    return;

                if (MessageBox.Show("Confirma a exclusão do Imóvel selecionado?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var excluirImovel = (Imovel)dataGridImovel.SelectedItem;

                    var listaExcluir = listaBensAtosConjuntos.Where(p => p.IdImovel == excluirImovel.ImovelId).ToList();

                    for (int i = 0; i < listaExcluir.Count(); i++)
                    {
                        if (listaExcluir[i].IdAtoConjunto > 0)
                        {
                            var excluirBanco = _AppServicoBensAtosConjuntos.GetById(listaExcluir[i].BensAtosConjuntosID);
                            _AppServicoBensAtosConjuntos.Remove(excluirBanco);
                        }
                        listaBensAtosConjuntos.Remove(listaExcluir[i]);
                    }

                    listaImoveis.Remove(excluirImovel);
                    var excluirImovelBanco = _AppServicoImovel.GetById(excluirImovel.ImovelId);
                    _AppServicoImovel.Remove(excluirImovelBanco);


                    dataGridImovel.ItemsSource = null;
                    dataGridImovel.ItemsSource = listaImoveis;
                    dataGridImovel.Items.Refresh();

                    if (dataGridImovel.Items.Count > 0)
                        dataGridImovel.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdicionarProcuracao_Click(object sender, RoutedEventArgs e)
        {
            estado = "adicionar procuracao";

            LiberarDigitacaoProcuracao();
            LimparCamposProcuracao();

            dpDataProcuracao.Focus();
        }

        private void LiberarDigitacaoProcuracao()
        {
            botoesProcuracao.Fill = Brushes.Transparent;

            gridProcuracao.IsEnabled = true;
            btnAdicionarProcuracao.IsEnabled = false;
            btnAlterarProcuracaao.IsEnabled = false;
            btnExcluirProcuracao.IsEnabled = false;
            dataGridProcuracao.IsEnabled = false;

            tabItemParticipantes.IsEnabled = false;
            tabItemAtosConjuntos.IsEnabled = false;
            tabItemImovelMovel.IsEnabled = false;
            tabItemCustas.IsEnabled = false;
            tabItemObservacao.IsEnabled = false;

        }

        private void FecharDigitacaoProcuracao()
        {
            gridProcuracao.IsEnabled = false;
            btnAdicionarProcuracao.IsEnabled = true;
            btnAlterarProcuracaao.IsEnabled = true;
            btnExcluirProcuracao.IsEnabled = true;
            dataGridProcuracao.IsEnabled = true;

            botoesProcuracao.Fill = Brushes.White;

            tabItemParticipantes.IsEnabled = true;
            tabItemAtosConjuntos.IsEnabled = true;
            tabItemImovelMovel.IsEnabled = true;
            tabItemCustas.IsEnabled = true;
            tabItemObservacao.IsEnabled = true;
        }

        private void btnCancelarProcuracao_Click(object sender, RoutedEventArgs e)
        {
            PreencherCamposSelecao();

            FecharDigitacaoProcuracao();

            estado = string.Empty;

            botoesProcuracao.Fill = Brushes.White;
        }

        private void LimparCamposProcuracao()
        {


            dpDataProcuracao.SelectedDate = null;
            txtServentiaProcuracao.Text = "";
            txtLivroProcuracao.Text = "";
            txtFolhasProcuracao.Text = "";
            txtAtoProcuracao.Text = "";
            txtOutorgantesProcuracao.Text = "";
            txtOutorgadosProcuracao.Text = "";
            rbSimProcuracao.IsChecked = true;
            txtSeloProcuracao.Text = "";
            txtAleatorioProcuracao.Text = "";
        }

        private void PreencherCamposSelecao()
        {
            try
            {

                if (dataGridProcuracao.SelectedItem != null)
                {
                    procuracao = (ProcuracaoEscritura)dataGridProcuracao.SelectedItem;

                    gridProcuracao.IsEnabled = true;
                    dpDataProcuracao.SelectedDate = procuracao.Data;
                    txtServentiaProcuracao.Text = procuracao.Serventia;
                    txtLivroProcuracao.Text = procuracao.Livro;
                    txtFolhasProcuracao.Text = procuracao.Folhas;
                    txtAtoProcuracao.Text = procuracao.Ato;
                    txtOutorgantesProcuracao.Text = procuracao.Outorgantes;
                    txtOutorgadosProcuracao.Text = procuracao.Outorgados;

                    if (procuracao.Lavrado == "S")
                        rbSimProcuracao.IsChecked = true;
                    if (procuracao.Lavrado == "N")
                        rbNaoProcuracao.IsChecked = true;

                    txtSeloProcuracao.Text = procuracao.Selo;
                    txtAleatorioProcuracao.Text = procuracao.Aleatorio;

                    gridProcuracao.IsEnabled = false;
                }
                else
                    LimparCamposProcuracao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridProcuracao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PreencherCamposSelecao();
        }

        private void btnAlterarProcuracaao_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProcuracao.SelectedItem != null)
            {
                estado = "alterar procuracao";

                LiberarDigitacaoProcuracao();
            }
        }

        private void btnExcluirProcuracao_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProcuracao.Items.Count > 0)
                if (MessageBox.Show("Deseja excluir esta Procuração?", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var procuracaoExcluir = (ProcuracaoEscritura)dataGridProcuracao.SelectedItem;

                    listaProcuracao.Remove(procuracao);

                    dataGridProcuracao.ItemsSource = null;

                    dataGridProcuracao.ItemsSource = listaProcuracao;
                    dataGridProcuracao.Items.Refresh();
                    if (dataGridProcuracao.Items.Count > 0)
                        dataGridProcuracao.SelectedIndex = 0;
                }

        }

        private void dpDataProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
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


        private void txtServentiaProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtLivroProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFolhasProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtAtoProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void txtOutorgantesProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbSimProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbNaoProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtSeloProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (txtSeloProcuracao.Text.Length < 4)
                DigitarSomenteLetras(sender, e);
            else
                DigitarSomenteNumeros(sender, e);
        }

        private void txtAleatorioProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteLetras(sender, e);
        }

        private void txtOutorgadosProcuracao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dataGridProcuracao_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridProcuracao.SelectedItem != null)
            {
                estado = "alterar procuracao";

                LiberarDigitacaoProcuracao();
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



        private void txtDistribuicao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtDistribuicao.Text.Contains(",") || txtDistribuicao.SelectionLength == txtDistribuicao.Text.Length)
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtDistribuicao.Text.IndexOf(",");

                if (indexVirgula + 3 == txtDistribuicao.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtDistribuicao_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDistribuicao.Text == "")
                    txtDistribuicao.Text = "0,00";
                else
                    txtDistribuicao.Text = string.Format("{0:n2}", Convert.ToDecimal(txtDistribuicao.Text));
            }
            catch (Exception)
            {
                txtDistribuicao.Text = "0,00";
            }
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {

            CalcularBotaoTotal();
        }

        private void txtMutua_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtMutua.Text.Contains(",") || txtMutua.SelectionLength == txtMutua.Text.Length)
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtMutua.Text.IndexOf(",");

                if (indexVirgula + 3 == txtMutua.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtMutua_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMutua.Text == "")
                    txtMutua.Text = "0,00";
                else
                    txtMutua.Text = string.Format("{0:n2}", Convert.ToDecimal(txtMutua.Text));
            }
            catch (Exception)
            {
                txtMutua.Text = "0,00";
            }
        }

        private void txtAcoterj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtAcoterj.Text.Contains(",") || txtAcoterj.SelectionLength == txtAcoterj.Text.Length)
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtAcoterj.Text.IndexOf(",");

                if (indexVirgula + 3 == txtAcoterj.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtAcoterj_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAcoterj.Text == "")
                    txtAcoterj.Text = "0,00";
                else
                    txtAcoterj.Text = string.Format("{0:n2}", Convert.ToDecimal(txtAcoterj.Text));
            }
            catch (Exception)
            {
                txtAcoterj.Text = "0,00";
            }

        }


        private void txtObservacao_LostFocus(object sender, RoutedEventArgs e)
        {
            txtObservacao.Text = txtObservacao.Text.Trim();


            Observacao = txtObservacao.Text;
        }

        private void btnSairSemSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair sem salvar?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
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


            _escrituras.CertidaoId = 0;

            _escrituras.TipoAto = "RE";

            if (dtDataAto.SelectedDate != null)
                _escrituras.DataAtoRegistro = dtDataAto.SelectedDate.Value;

            if (cmbEscreventes.SelectedIndex > -1)
            {
                var escrevente = (Cs_Notas.Dominio.Entities.Usuario)cmbEscreventes.SelectedItem;

                _escrituras.EscreventeAtoRegistro = escrevente.Nome;

                _escrituras.CpfEscrevente = escrevente.Cpf;
            }

            _escrituras.SeloEscritura = txtSelo.Text;

            _escrituras.LivroEscritura = txtLivro.Text;

            if (txtFlsIni.Text != "")
                _escrituras.FolhasInicio = Convert.ToInt32(txtFlsIni.Text);

            if (txtFlsFim.Text != "")
                _escrituras.FolhasFim = Convert.ToInt32(txtFlsFim.Text);

            if (txtAto.Text != "")
                _escrituras.NumeroAto = Convert.ToInt32(txtAto.Text);

            if (txtRecibo.Text != "")
                _escrituras.Recibo = txtRecibo.Text;

            if (cmbNaturezas.SelectedIndex > -1)
            {
                var natureza = (Naturezas)cmbNaturezas.SelectedItem;

                _escrituras.Natureza = natureza.Codigo.ToString();

                _escrituras.Descricao = natureza.Descricao;

                _escrituras.Censec = natureza.Censec;

                _escrituras.TipoCensec = natureza.Tipo;

                _escrituras.TipoAtoCesdi = natureza.Cep;
            }

            if (txtBaseCalculo.Text != "")
                _escrituras.ValorEscritua = Convert.ToDecimal(txtBaseCalculo.Text);
            else
                _escrituras.ValorEscritua = 0.00M;

            switch (cmbTipoCustas.SelectedIndex)
            {
                case 0:
                    _escrituras.TipoCobranca = "JG";
                    break;

                case 1:
                    _escrituras.TipoCobranca = "CC";
                    break;

                case 2:
                    _escrituras.TipoCobranca = "SC";
                    break;

                case 3:
                    _escrituras.TipoCobranca = "NH";
                    break;

                case 4:
                    _escrituras.TipoCobranca = "PA";
                    break;

                default:
                    _escrituras.TipoCobranca = null;
                    break;
            }

            if (txtEmolumentos.Text != "")
                _escrituras.Emolumentos = Convert.ToDecimal(txtEmolumentos.Text);

            if (txtFetj.Text != "")
                _escrituras.Fetj = Convert.ToDecimal(txtFetj.Text);

            if (txtFundperj.Text != "")
                _escrituras.Fundperj = Convert.ToDecimal(txtFundperj.Text);

            if (txtFunperj.Text != "")
                _escrituras.Funprj = Convert.ToDecimal(txtFunperj.Text);

            if (txtFunarpen.Text != "")
                _escrituras.Funarpen = Convert.ToDecimal(txtFunarpen.Text);

            if (txtPmcmv.Text != "")
                _escrituras.Pmcmv = Convert.ToDecimal(txtPmcmv.Text);

            if (txtIss.Text != "")
                _escrituras.Iss = Convert.ToDecimal(txtIss.Text);

            if (txtDistribuicao.Text != "")
                _escrituras.Distribuicao = Convert.ToDecimal(txtDistribuicao.Text);

            if (txtMutua.Text != "")
                _escrituras.Mutua = Convert.ToDecimal(txtMutua.Text);

            if (txtAcoterj.Text != "")
                _escrituras.Acoterj = Convert.ToDecimal(txtAcoterj.Text);

            if (txtTotal.Text != "")
                _escrituras.Total = Convert.ToDecimal(txtTotal.Text);


            if (listaProcuracao.Count > 0)
                _escrituras.IndProcuracao = "S";
            else
                _escrituras.IndProcuracao = "N";

            if (ckbAlvaraJudicial.IsChecked == true)
                _escrituras.IndAlvara = "S";
            else
                _escrituras.IndAlvara = "N";

            _escrituras.DistribuicaoEnviada = "N";

            if (cmbNaturezaCensec.SelectedIndex > -1)
            {
                var naturezaCensec = (Censec)cmbNaturezaCensec.SelectedItem;

                _escrituras.NaturezaCensec = naturezaCensec.Codigo;
            }

            _escrituras.Cancelado = "N";
            _escrituras.Enviado = "N";

            _escrituras.Login = _usuario.Nome;

            _escrituras.DataModificacao = DateTime.Now.Date;
            _escrituras.HoraModificacao = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

            if (txtQtdFilhosMenores.Text != "")
                _escrituras.QtdFilhosMenores = Convert.ToInt16(txtQtdFilhosMenores.Text);
            else
                _escrituras.QtdFilhosMenores = 0;

            if (cmbResponsavelFilhosMenores.SelectedIndex > -1)
                _escrituras.ResponsavelFilhosMenores = cmbResponsavelFilhosMenores.SelectedIndex;
            else
                _escrituras.ResponsavelFilhosMenores = -1;

            _escrituras.Observacao = txtObservacao.Text;

            _escrituras.IdCodigoTabelaCustas = ((TabelaCustas)cmbTabelaAtos.SelectedItem).TabelaCustasId;
            
            
            estado = "salvando";
            var aguarde = new AguardeSalvandoEscritura(this);
            aguarde.Owner = this;
            aguarde.ShowDialog();
            if (estado == "salvando")
                this.Close();
        }

        private List<string> ConferirPreenchimentoDosCampos()
        {
            var naoPreenchido = new List<string>();

            if (cmbTabelaAtos.SelectedItem == null)
                naoPreenchido.Add("Tabela de Atos;");

            if (cmbNaturezas.SelectedItem == null)
                naoPreenchido.Add("Natureza;");

            if (cmbNaturezaCensec.SelectedItem == null && cmbNaturezaCensec.IsEnabled == true)
                naoPreenchido.Add("Natureza Censec;");

            if (dtDataAto.SelectedDate == null)
                naoPreenchido.Add("Data;");

            if (cmbEscreventes.SelectedItem == null)
                naoPreenchido.Add("Escrevente;");



            return naoPreenchido;
        }

        private void lblCustas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var tabelaCustas = new AdicionarItensCustas(this);
            tabelaCustas.Owner = this;
            tabelaCustas.ShowDialog();
        }

        private void btnMinuta_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnOrigem_Click(object sender, RoutedEventArgs e)
        {
            var origem = new OrigemEscritura(this);
            origem.Owner = this;
            origem.ShowDialog();
        }



        private void txtBaseCalculo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtBaseCalculo.Text.Contains(",") || txtBaseCalculo.SelectionLength == txtBaseCalculo.Text.Length)
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

        private void txtBaseCalculo_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBaseCalculo.Text == "")
                    txtBaseCalculo.Text = "0,00";
                else
                    txtBaseCalculo.Text = string.Format("{0:n2}", Convert.ToDecimal(txtBaseCalculo.Text));
            }
            catch (Exception)
            {
                txtBaseCalculo.Text = "0,00";
            }
        }

        private void txtBaseCalculo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBaseCalculo.Text == "0,00")
                txtBaseCalculo.Text = "";
        }

        private void imgSair_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
           this.Close();
            
        }



        private void dtDataAto_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (Ano != dtDataAto.SelectedDate.Value.Date.Year)
            {
                if (anosCustasExistentes.Contains(dtDataAto.SelectedDate.Value.Date.Year))
                {
                    Ano = dtDataAto.SelectedDate.Value.Date.Year;

                    CarregarComboBoxTabelaAtos();

                    btnCustas.IsEnabled = false;

                    cmbTabelaAtos.SelectedIndex = 0;

                    _recalcular = true;

                    CarregarCustas();

                }
                else
                {
                    MessageBox.Show("Ano Selecionado não encontrado na Tabela de Custas.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    dtDataAto.SelectedDate = _escrituras.DataAtoRegistro;
                }
            }
        }

        private void btnMinuta_Click_1(object sender, RoutedEventArgs e)
        {
            //listaArquivos = new List<FileInfo>();

            //// manipular de diretorios
            //DirectoryInfo dirInfo = new DirectoryInfo(@configuracoes.PathEscritura);

            //// procurar arquivos
            //BuscaArquivos(dirInfo);

            //var arquivo = listaArquivos.Where(p => (p.Name == _escrituras.EscriturasId.ToString() + ".doc") || (p.Name == _escrituras.EscriturasId.ToString() + ".docx")).FirstOrDefault();

            //if (arquivo != null)
            //{
            //    System.Diagnostics.Process.Start(arquivo.FullName);
            //}
            //else
            //{

            //    MessageBox.Show("Minuta não existe.", "Minuta", MessageBoxButton.OK, MessageBoxImage.Warning);

            //}
        }


        private void BuscaArquivos(DirectoryInfo dir)
        {
            // lista arquivos do diretorio corrente
            foreach (FileInfo file in dir.GetFiles())
            {
                // aqui no caso estou guardando o nome completo do arquivo em em controle ListBox
                // voce faz como quiser
                listaArquivos.Add(file);
            }

            // busca arquivos do proximo sub-diretorio
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                BuscaArquivos(subDir);
            }
        }


    }
}
