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
using System.IO;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities_Fracas;
using Cs_Gerencial.WindowsAguarde;
using System.ComponentModel;
using System.Threading;
using System.Data;
using System.Diagnostics;

namespace Cs_Gerencial.Windows
{
    /// <summary>
    /// Interaction logic for EstoqueSelos.xaml
    /// </summary>
    public partial class EstoqueSelos : Window
    {


        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();

        private readonly IAppServicoCompraSelo _AppServicoCompraSelo = BootStrap.Container.GetInstance<IAppServicoCompraSelo>();

        public LeituraArquivoSeloComprado leituraDoArquivoXml;

        public LeituraArquivoSeloComprado leituraDoArquivoXmlImportado;

        Usuario _usuario;

        Principal _principal;

        public string autorizacao;

        public FileInfo arquivoSelecionado;

        FileInfo arquivoSelecionadoImportados;

        public List<Series> _listSeriesDisponiveis = new List<Series>();

        public List<Series> _listSeriesIndisponiveis = new List<Series>();

        IEnumerable<Selos> listSelosDisponiveis = new List<Selos>();

        IEnumerable<Selos> listSelosIndisponiveis = new List<Selos>();

        List<Selos> listSelosCheckedsDisponiveis = new List<Selos>();

        List<Selos> listSelosCheckedsIndisponiveis = new List<Selos>();

        public Series serieDisponiveisSelecionada;

        public Series serieIndisponiveisSelecionada;

        Selos seloDisponivelSelecionado;

        Selos seloIndisponivelSelecionado;

        public List<Selos> listSelosDisponiveisSerieSelecionada;

        public List<Selos> listSelosIndisponiveisSerieSelecionada;

        public Parametros parametros;

        List<FileInfo> listArquivosNaoImportados;

        List<FileInfo> listArquivosImportados;

        List<CompraSelo> listCompraSelos;


        public EstoqueSelos(List<Series> listSeriesDisponiveis, List<Series> listSeriesIndisponiveis, Usuario usuario, Principal principal, Selos selecionado)
        {
            _usuario = usuario;
            _listSeriesDisponiveis = listSeriesDisponiveis;
            _listSeriesIndisponiveis = listSeriesIndisponiveis;
            seloDisponivelSelecionado = selecionado;
            _principal = principal;
            InitializeComponent();
        }

        public EstoqueSelos(List<Series> listSeriesDisponiveis, List<Series> listSeriesIndisponiveis, Usuario usuario, Principal principal, Selos seloSelecionado, FileInfo arquivoSelecionado, FileInfo arquivoSelecionadoImportados)
        {
            // TODO: Complete member initialization
            _usuario = usuario;
            _listSeriesDisponiveis = listSeriesDisponiveis;
            _listSeriesIndisponiveis = listSeriesIndisponiveis;
            seloDisponivelSelecionado = seloSelecionado;
            _principal = principal;
            this.arquivoSelecionado = arquivoSelecionado;
            this.arquivoSelecionadoImportados = arquivoSelecionadoImportados;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            parametros = _AppServicoParametros.GetAll().FirstOrDefault();
            CarregarTodosOsMetodosDeCarregamento();
        }


        public void CarregarTodosOsMetodosDeCarregamento()
        {
            CarregarHistorio();

            CarregarSelosNaoImpotados();

            CarregarSelosImportados();

            CarregarDataGridSeriesDisponiveis();

            CarregaDataGridSeriesIndisponiveis();
        }

        private void CarregarHistorio()
        {
            listCompraSelos = new List<CompraSelo>();

            listCompraSelos = _AppServicoCompraSelo.GetAll().OrderBy(p => p.DataPedido).ToList();


            dataGridHistorico.ItemsSource = listCompraSelos;

            if (listCompraSelos.Count > 0)
            {
                dataGridHistorico.SelectedIndex = 0;
            }
        }

        private void CarregarSelosNaoImpotados()
        {
            try
            {
                
                var diretorio = parametros.PathSelosNaoImportados;

                DirectoryInfo diretorioAtual = new DirectoryInfo(diretorio);


                if (diretorioAtual.Exists)
                {
                    listView.ItemsSource = null;
                    listView.Items.Clear();


                    List<FileInfo> arquivos = diretorioAtual.GetFiles().Where(p => p.Extension == ".xml" || p.Extension == ".XML" && p.Name.Contains("ArquivoSelos")).ToList();

                    listArquivosNaoImportados = arquivos;
                  

                    listView.ItemsSource = listArquivosNaoImportados;


                    if (listArquivosNaoImportados.Count() > 0)
                    {
                        if (arquivoSelecionado != null)
                        {
                            arquivoSelecionado = listArquivosNaoImportados.Where(p => p.Name == arquivoSelecionado.Name).FirstOrDefault();

                            tabItemNaoImportarSelos.IsSelected = true;
                            listView.SelectedItem = arquivoSelecionado;
                            listView.ScrollIntoView(arquivoSelecionado);
                            listView.SelectedItem = arquivoSelecionado;
                        }
                        else
                            listView.SelectedIndex = 0;
                        btnImportar.IsEnabled = true;
                        MenuMoverImportados.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        btnImportar.IsEnabled = false;
                        MenuMoverImportados.Visibility = Visibility.Hidden;
                    }
                }

            }
            catch (Exception)
            {
               
            }
        }

        private void CarregarSelosImportados()
        {
            try
            {

                var diretorio = parametros.PathSelosImportados;

                DirectoryInfo diretorioAtual = new DirectoryInfo(diretorio);

                if (diretorioAtual.Exists)
                {
                    listViewImportados.ItemsSource = null;
                    listViewImportados.Items.Clear();


                    List<FileInfo> arquivos = diretorioAtual.GetFiles().Where(p => p.Extension == ".xml" || p.Extension == ".XML" && p.Name.Contains("ArquivoSelos")).ToList();

                    listArquivosImportados = arquivos;
                    

                    listViewImportados.ItemsSource = listArquivosImportados;

                    MenuMoverNaoImportados.Visibility = Visibility.Hidden;

                    if (listArquivosImportados.Count() > 0)
                    {
                        if (arquivoSelecionadoImportados != null)
                        {
                            arquivoSelecionadoImportados = listArquivosImportados.Where(p => p.Name == arquivoSelecionadoImportados.Name).FirstOrDefault();
                            tabItemImportarSelos.IsSelected = true;
                            listView.SelectedItem = arquivoSelecionadoImportados;
                            listView.ScrollIntoView(arquivoSelecionadoImportados);
                            listViewImportados.SelectedItem = arquivoSelecionadoImportados;

                        }
                        else
                            listViewImportados.SelectedIndex = 0;

                        MenuMoverNaoImportados.Visibility = Visibility.Visible;
                    }

                }
                

            }
            catch (Exception)
            {
                
            }
        }

        private void DigitarSomenteLetras(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key >= 44 && key <= 69);
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }


        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listView.Items.Count > 0)
                {
                    try
                    {
                        {
                            arquivoSelecionado = (FileInfo)listView.SelectedItem;

                            CarregaInformacoesDoArquivo();
                        }
                    }
                    catch (Exception)
                    {
                        CarregarTodosProcessos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
            }
        }

        private void CarregaInformacoesDoArquivo()
        {
            leituraDoArquivoXml = _AppServicoSelos.LerArquivoCompraSelo(arquivoSelecionado.FullName);

            lblNomeSolicitanteValor.Content = leituraDoArquivoXml.SolicitanteNome;

            lblCpfSolicitanteValor.Content = leituraDoArquivoXml.SolicitanteCpf;

            lblDataPedidoValor.Content = String.Format("{0:dd/MM/yyyy HH:mm:ss}", leituraDoArquivoXml.DataPedido);

            lblDataGeracaoValor.Content = String.Format("{0:dd/MM/yyyy HH:mm:ss}", leituraDoArquivoXml.DataGeracao);

            lblCodigoServicoValor.Content = leituraDoArquivoXml.CodigoServico;

            lblIdValor.Content = leituraDoArquivoXml.Id;

            lblSerieValor.Content = leituraDoArquivoXml.Serie;

            lblQuantidadeValor.Content = leituraDoArquivoXml.Quantidade;

            lblSeloInicialValor.Content = leituraDoArquivoXml.SequenciaInicio;

            lblSeloFinalValor.Content = leituraDoArquivoXml.SequenciaFim;

            lblGrerjValor.Content = leituraDoArquivoXml.Grerj;

        }


        private void CarregaInformacoesDoArquivoImportado()
        {
            leituraDoArquivoXmlImportado = _AppServicoSelos.LerArquivoCompraSelo(arquivoSelecionadoImportados.FullName);

            lblNomeSolicitanteValor1.Content = leituraDoArquivoXmlImportado.SolicitanteNome;

            lblCpfSolicitanteValor1.Content = leituraDoArquivoXmlImportado.SolicitanteCpf;

            lblDataPedidoValor1.Content = String.Format("{0:dd/MM/yyyy HH:mm:ss}", leituraDoArquivoXmlImportado.DataPedido);

            lblDataGeracaoValor1.Content = String.Format("{0:dd/MM/yyyy HH:mm:ss}", leituraDoArquivoXmlImportado.DataGeracao);

            lblCodigoServicoValor1.Content = leituraDoArquivoXmlImportado.CodigoServico;

            lblIdValor1.Content = leituraDoArquivoXmlImportado.Id;

            lblSerieValor1.Content = leituraDoArquivoXmlImportado.Serie;

            lblQuantidadeValor1.Content = leituraDoArquivoXmlImportado.Quantidade;

            lblSeloInicialValor1.Content = leituraDoArquivoXmlImportado.SequenciaInicio;

            lblSeloFinalValor1.Content = leituraDoArquivoXmlImportado.SequenciaFim;

            lblGrerjValor1.Content = leituraDoArquivoXmlImportado.Grerj;


        }

        private void btnImportar_Click(object sender, RoutedEventArgs e)
        {


            if (MessageBox.Show("Deseja realmente importar o arquivo selecionado? " + "\n" + "\n" + "Este processo pode demorar alguns minutos.", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {


                var aguardeImportarSelos = new AguardeImportarSelos(_usuario, this);
                aguardeImportarSelos.Owner = this;
                aguardeImportarSelos.ShowDialog();

                this.Close();

                seloDisponivelSelecionado = _AppServicoSelos.ConsultarPorIdSerie(serieDisponiveisSelecionada.SerieId).FirstOrDefault();

                AguardeProcessandoSelos aguarde = new AguardeProcessandoSelos(_principal, _usuario, seloDisponivelSelecionado);
                aguarde.Owner = _principal;
                aguarde.ShowDialog();
            }
        }


        private void CarregarTodosProcessos()
        {

            CarregarSelosNaoImpotados();

            CarregarSelosImportados();

            var aguardeProcessando = new AguardeProcessandoSelosNoEstoqueSelos(this);
            aguardeProcessando.Owner = this;
            aguardeProcessando.ShowDialog();

            CarregarDataGridSeriesDisponiveis();
            CarregaDataGridSeriesIndisponiveis();


        }







        //---------------------------------------- INÍCIO SÉRIES DISPONÍVEIS --------------------------------------------------------------

        private void CarregarDataGridSeriesDisponiveis()
        {
            dataGridSeriesDisponiveis.ItemsSource = _listSeriesDisponiveis;
            dataGridSeriesDisponiveis.SelectedValuePath = "SerieId";
            dataGridSeriesDisponiveis.Items.Refresh();

            if (seloDisponivelSelecionado != null)
                serieDisponiveisSelecionada = _listSeriesDisponiveis.Where(p => p.SerieId == seloDisponivelSelecionado.IdSerie).FirstOrDefault();

            if (serieDisponiveisSelecionada == null)
            {
                if (_listSeriesDisponiveis.Count > 0)
                {
                    dataGridSeriesDisponiveis.SelectedIndex = 0;
                }
            }
            else
            {
                dataGridSeriesDisponiveis.SelectedItem = serieDisponiveisSelecionada;
                dataGridSeriesDisponiveis.ScrollIntoView(serieDisponiveisSelecionada);

                dataGridSelosDisponiveis.ScrollIntoView(serieDisponiveisSelecionada);
            }
        }

        private void CarregarSerieDisponivelSelecionadaTextBox()
        {

            txtSerieLetra.Text = serieDisponiveisSelecionada.Letra;
            txtSerieInicial.Text = string.Format("{0:00000}", serieDisponiveisSelecionada.Inicial);
            txtSerieFinal.Text = string.Format("{0:00000}", serieDisponiveisSelecionada.Final);
            txtSerieQtd.Text = serieDisponiveisSelecionada.Quantidade.ToString();
            txtSerieUtilizado.Text = listSelosDisponiveisSerieSelecionada.Where(p => p.IdSerie == serieDisponiveisSelecionada.SerieId && p.Status != "LIVRE").Count().ToString();
            txtSerieLivre.Text = listSelosDisponiveisSerieSelecionada.Where(p => p.IdSerie == serieDisponiveisSelecionada.SerieId && p.Status == "LIVRE").Count().ToString();

        }


        private void checkedUmDisponivel_Unchecked(object sender, RoutedEventArgs e)
        {

            VerificarQtdMarcadosDisponiveis();
        }

        private void checkedUmDisponivel_Checked(object sender, RoutedEventArgs e)
        {
            VerificarQtdMarcadosDisponiveis();
        }


        private void VerificarQtdMarcadosDisponiveis()
        {

            int qtd = listSelosDisponiveisSerieSelecionada.Where(p => p.Check == true).Count();

            lblQtdMarcados.Content = string.Format("Qtd Selos Marcados: {0}", qtd);
        }

        private void dataGridSeriesDisponiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                serieDisponiveisSelecionada = (Series)dataGridSeriesDisponiveis.SelectedItem;

                if (serieDisponiveisSelecionada != null)
                {
                    CarregarDataGridSelosDaSerieDisponivel();
                    CarregarSerieDisponivelSelecionadaTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DesmarcarTodosCheckesDisponiveis();
                checkTodosDisponiveis.IsChecked = false;
                dataGridSelosDisponiveis.ScrollIntoView(seloDisponivelSelecionado);
            }
        }

        public void CarregarDataGridSelosDaSerieDisponivel()
        {


            listSelosDisponiveisSerieSelecionada = _AppServicoSelos.ConsultarPorIdSerie(serieDisponiveisSelecionada.SerieId).ToList();

            dataGridSelosDisponiveis.ItemsSource = listSelosDisponiveisSerieSelecionada;

            if (seloDisponivelSelecionado != null)
                seloDisponivelSelecionado = listSelosDisponiveisSerieSelecionada.Where(p => p.SeloId == seloDisponivelSelecionado.SeloId).FirstOrDefault();



            if (listSelosDisponiveisSerieSelecionada.Count > 0)
            {
                if (seloDisponivelSelecionado != null)
                {
                    dataGridSelosDisponiveis.SelectedItem = seloDisponivelSelecionado;
                }
                else
                {
                    dataGridSelosDisponiveis.SelectedIndex = 0;
                }

            }
        }



        private void checkTodosDisponiveis_Checked(object sender, RoutedEventArgs e)
        {
            MarcarTodosCheckesDisponiveis();
        }

        private void checkTodosDisponiveis_Unchecked(object sender, RoutedEventArgs e)
        {
            DesmarcarTodosCheckesDisponiveis();
        }


        private void DesmarcarTodosCheckesDisponiveis()
        {
            if (listSelosDisponiveisSerieSelecionada == null)
                return;

            foreach (var item in listSelosDisponiveisSerieSelecionada)
            {
                item.Check = false;
                dataGridSelosDisponiveis.Items.Refresh();
                listSelosCheckedsDisponiveis.Remove(item);
            }
            VerificarQtdMarcadosDisponiveis();
        }

        private void MarcarTodosCheckesDisponiveis()
        {
            if (listSelosDisponiveisSerieSelecionada == null)
                return;

            foreach (var item in listSelosDisponiveisSerieSelecionada)
            {
                item.Check = true;
                dataGridSelosDisponiveis.Items.Refresh();
                listSelosCheckedsDisponiveis.Add(item);
            }

            VerificarQtdMarcadosDisponiveis();
        }

        private void txtConsultaSerieDisponivel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtConsultaSerieDisponivel.Text.Length == 4)
            {
                ConsultarSerieDisponivel();

            }
            else
            {
                txtConsultaNumeroDisponivel.Text = "";
                txtConsultaNumeroDisponivel.IsEnabled = false;
            }
        }

        private void ConsultarSerieDisponivel()
        {
            try
            {
                Series serie = _listSeriesDisponiveis.Where(p => p.Letra.Contains(txtConsultaSerieDisponivel.Text)).FirstOrDefault();

                if (serie != null)
                {
                    dataGridSeriesDisponiveis.SelectedItem = serie;

                    dataGridSeriesDisponiveis.ScrollIntoView(serie);

                    txtConsultaNumeroDisponivel.IsEnabled = true;

                    txtConsultaNumeroDisponivel.Focus();


                }
                else
                {
                    MessageBox.Show("Série não encontrada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtConsultaSerieDisponivel.Text = "";
                    txtConsultaSerieDisponivel.Focus();
                    txtConsultaNumeroDisponivel.Text = "";
                    txtConsultaNumeroDisponivel.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtConsultaNumeroDisponivel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtConsultaNumeroDisponivel.Text.Length == 5)
                ConsultarSerieDisponivel_E_Numero();
        }

        private void ConsultarSerieDisponivel_E_Numero()
        {
            Series serie = null;
            try
            {
                Selos selo = _AppServicoSelos.ConsultarPorSerieNumero(txtConsultaSerieDisponivel.Text, Convert.ToInt32(txtConsultaNumeroDisponivel.Text));

                if (selo != null)
                    serie = _listSeriesDisponiveis.Where(p => p.SerieId == selo.IdSerie).FirstOrDefault();

                if (serie != null)
                {
                    dataGridSeriesDisponiveis.SelectedItem = serie;
                    dataGridSeriesDisponiveis.ScrollIntoView(serie);

                    if (selo != null)
                    {
                        dataGridSelosDisponiveis.SelectedItem = selo;
                        dataGridSelosDisponiveis.ScrollIntoView(selo);
                    }

                }
                else
                {
                    MessageBox.Show("Selo informado não foi encontrado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtConsultaSerieDisponivel.Text = "";
                    txtConsultaSerieDisponivel.Focus();
                    txtConsultaNumeroDisponivel.Text = "";
                    txtConsultaNumeroDisponivel.IsEnabled = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            AguardeProcessandoSelos aguarde = new AguardeProcessandoSelos(_principal, _usuario, seloDisponivelSelecionado);
            aguarde.Owner = _principal;
            aguarde.ShowDialog();
        }

        private void dataGridSelosDisponiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                seloDisponivelSelecionado = (Selos)dataGridSelosDisponiveis.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnLiberarSeloDisponiveis_Click(object sender, RoutedEventArgs e)
        {

            if ( listSelosDisponiveisSerieSelecionada == null)
                return;

            List<Selos> selosLiberar = new List<Selos>();


            selosLiberar = listSelosDisponiveisSerieSelecionada.Where(p => p.Check == true && p.Status != "LIVRE").ToList();


            if (selosLiberar.Count > 0)
            {


                if (_usuario.NomeUsuario != "Administrador")
                {

                    autorizacao = string.Empty;

                    var verificarSenha = new InformarSenhaMaster(this);
                    verificarSenha.Owner = this;
                    verificarSenha.ShowDialog();

                    if (autorizacao != "autorizado")
                    {

                        return;
                    }
                }


                lblQtdMarcados.Visibility = Visibility.Hidden;
                var liberarBaixarSelos = new CarreguandoBaixarLiberarSelo(selosLiberar, _usuario, "liberar", this);
                liberarBaixarSelos.Owner = this;
                liberarBaixarSelos.ShowDialog();
                lblQtdMarcados.Visibility = Visibility.Visible;

                this.Close();

                AguardeProcessandoSelos aguarde = new AguardeProcessandoSelos(_principal, _usuario, seloDisponivelSelecionado);
                aguarde.Owner = _principal;
                aguarde.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum selo com Status diferente de LIVRE foi selecionado", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnBaixarManualDisponiveis_Click(object sender, RoutedEventArgs e)
        {

            if (listSelosDisponiveisSerieSelecionada == null)
                return;

            List<Selos> selosBaixar = new List<Selos>();


            selosBaixar = listSelosDisponiveisSerieSelecionada.Where(p => p.Check == true && p.Status == "LIVRE").ToList();


            if (selosBaixar.Count > 0)
            {

                if (_usuario.NomeUsuario != "Administrador")
                {

                    autorizacao = string.Empty;

                    var verificarSenha = new InformarSenhaMaster(this);
                    verificarSenha.Owner = this;
                    verificarSenha.ShowDialog();

                    if (autorizacao != "autorizado")
                    {

                        return;
                    }
                }

                lblQtdMarcados.Visibility = Visibility.Hidden;

                var liberarBaixarSelos = new CarreguandoBaixarLiberarSelo(selosBaixar, _usuario, "baixar", this);
                liberarBaixarSelos.Owner = this;
                liberarBaixarSelos.ShowDialog();

                lblQtdMarcados.Visibility = Visibility.Visible;

                this.Close();

                AguardeProcessandoSelos aguarde = new AguardeProcessandoSelos(_principal, _usuario, seloDisponivelSelecionado);
                aguarde.Owner = _principal;
                aguarde.ShowDialog();

            }
            else
            {
                MessageBox.Show("Nenhum selo LIVRE foi selecionado", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void dataGridSelosDisponiveis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var detalhesSelo = new DetalhesDoSelo(seloDisponivelSelecionado, _usuario);
            detalhesSelo.Owner = this;
            detalhesSelo.ShowDialog();


            listSelosDisponiveisSerieSelecionada[dataGridSelosDisponiveis.SelectedIndex] = _AppServicoSelos.GetById(seloDisponivelSelecionado.SeloId);

            dataGridSelosDisponiveis.Items.Refresh();
        }




        //---------------------------------------- FIM SÉRIES DISPONÍVEIS --------------------------------------------------------------





        //---------------------------------------- INÍCIO SÉRIES INDISPONÍVEIS --------------------------------------------------------------



        private void CarregaDataGridSeriesIndisponiveis()
        {
            dataGridSeriesIndisponiveis.ItemsSource = _listSeriesIndisponiveis;

            dataGridSeriesIndisponiveis.SelectedValuePath = "SerieId";

            dataGridSeriesIndisponiveis.Items.Refresh();


            if (serieIndisponiveisSelecionada == null)
            {
                if (_listSeriesIndisponiveis.Count > 0)
                {
                    dataGridSeriesIndisponiveis.SelectedIndex = 0;
                }
            }
            else
            {
                dataGridSeriesIndisponiveis.SelectedItem = serieIndisponiveisSelecionada;
            }
        }
        private void CarregarSerieIndisponiveisSelecionadaTextBox()
        {

            txtSerieLetraIndisponiveis.Text = serieIndisponiveisSelecionada.Letra;
            txtSerieInicialIndisponiveis.Text = string.Format("{0:00000}", serieIndisponiveisSelecionada.Inicial);
            txtSerieFinalIndisponiveis.Text = string.Format("{0:00000}", serieIndisponiveisSelecionada.Final);
            txtSerieQtdIndisponiveis.Text = serieIndisponiveisSelecionada.Quantidade.ToString();
            txtSerieUtilizadoIndisponiveis.Text = listSelosIndisponiveisSerieSelecionada.Where(p => p.IdSerie == serieIndisponiveisSelecionada.SerieId && p.Status != "LIVRE").Count().ToString();
            txtSerieLivreIndisponiveis.Text = listSelosIndisponiveisSerieSelecionada.Where(p => p.IdSerie == serieIndisponiveisSelecionada.SerieId && p.Status == "LIVRE").Count().ToString();

        }


        private void checkedUmIndisponiveis_Unchecked(object sender, RoutedEventArgs e)
        {

            VerificarQtdMarcadosIndisponiveis();
        }

        private void checkedUmIndisponiveis_Checked(object sender, RoutedEventArgs e)
        {
            VerificarQtdMarcadosIndisponiveis();
        }


        private void VerificarQtdMarcadosIndisponiveis()
        {

            int qtd = listSelosIndisponiveisSerieSelecionada.Where(p => p.Check == true).Count();

            lblQtdMarcadosIndisponiveis.Content = string.Format("Qtd Selos Marcados: {0}", qtd);
        }

        private void dataGridSeriesIndisponiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                serieIndisponiveisSelecionada = (Series)dataGridSeriesIndisponiveis.SelectedItem;

                if (serieIndisponiveisSelecionada != null)
                {

                    CarregarDataGridSelosDaSerieIndisponiveis();
                    CarregarSerieIndisponiveisSelecionadaTextBox();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (serieDisponiveisSelecionada != null)
                {
                    DesmarcarTodosCheckesIndisponiveis();
                    checkTodosIndisponiveis.IsChecked = false;

                    if (seloIndisponivelSelecionado != null)
                    dataGridSelosIndisponiveis.ScrollIntoView(seloIndisponivelSelecionado);
                }
            }
        }

        public void CarregarDataGridSelosDaSerieIndisponiveis()
        {

            dataGridSelosIndisponiveis.ItemsSource = null;

            listSelosIndisponiveisSerieSelecionada = _AppServicoSelos.ConsultarPorIdSerie(serieIndisponiveisSelecionada.SerieId).ToList();

            dataGridSelosIndisponiveis.ItemsSource = listSelosIndisponiveisSerieSelecionada;


            if (seloIndisponivelSelecionado != null)
                seloIndisponivelSelecionado = listSelosIndisponiveisSerieSelecionada.Where(p => p.SeloId == seloIndisponivelSelecionado.SeloId).FirstOrDefault();



            if (listSelosIndisponiveisSerieSelecionada.Count > 0)
            {
                if (seloIndisponivelSelecionado != null)
                {
                    dataGridSelosIndisponiveis.SelectedItem = seloIndisponivelSelecionado;
                }
                else
                {
                    dataGridSelosIndisponiveis.SelectedIndex = 0;
                }

            }
        }



        private void checkTodosIndisponiveis_Checked(object sender, RoutedEventArgs e)
        {
            MarcarTodosCheckesIndisponiveis();
        }

        private void checkTodosIndisponiveis_Unchecked(object sender, RoutedEventArgs e)
        {
            DesmarcarTodosCheckesIndisponiveis();
        }


        private void DesmarcarTodosCheckesIndisponiveis()
        {
            if (listSelosIndisponiveisSerieSelecionada == null)
                return;

            foreach (var item in listSelosIndisponiveisSerieSelecionada)
            {
                item.Check = false;
                dataGridSelosIndisponiveis.Items.Refresh();
                listSelosCheckedsIndisponiveis.Remove(item);
            }
            VerificarQtdMarcadosIndisponiveis();
        }

        private void MarcarTodosCheckesIndisponiveis()
        {
            if (listSelosIndisponiveisSerieSelecionada == null)
                return;

            foreach (var item in listSelosIndisponiveisSerieSelecionada)
            {
                item.Check = true;
                dataGridSelosIndisponiveis.Items.Refresh();
                listSelosCheckedsIndisponiveis.Add(item);
            }

            VerificarQtdMarcadosIndisponiveis();
        }

        private void txtConsultaSerieIndisponiveis_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtConsultaSerieIndisponiveis.Text.Length == 4)
            {
                ConsultarSerieIndisponiveis();

            }
            else
            {
                txtConsultaNumeroIndisponiveis.Text = "";
                txtConsultaNumeroIndisponiveis.IsEnabled = false;
            }
        }

        private void ConsultarSerieIndisponiveis()
        {
            try
            {
                Series serie = _listSeriesIndisponiveis.Where(p => p.Letra.Contains(txtConsultaSerieIndisponiveis.Text)).FirstOrDefault();

                if (serie != null)
                {
                    dataGridSeriesIndisponiveis.SelectedItem = serie;

                    dataGridSeriesIndisponiveis.ScrollIntoView(serie);

                    txtConsultaNumeroIndisponiveis.IsEnabled = true;

                    txtConsultaNumeroIndisponiveis.Focus();


                }
                else
                {
                    MessageBox.Show("Série não encontrada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtConsultaSerieIndisponiveis.Text = "";
                    txtConsultaSerieIndisponiveis.Focus();
                    txtConsultaNumeroIndisponiveis.Text = "";
                    txtConsultaNumeroIndisponiveis.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtConsultaNumeroIndisponiveis_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtConsultaNumeroIndisponiveis.Text.Length == 5)
                ConsultarSerieIndisponiveis_E_Numero();
        }

        private void ConsultarSerieIndisponiveis_E_Numero()
        {
            Series serie = null;
            try
            {
                Selos selo = _AppServicoSelos.ConsultarPorSerieNumero(txtConsultaSerieIndisponiveis.Text, Convert.ToInt32(txtConsultaNumeroIndisponiveis.Text));

                if (selo != null)
                    serie = _listSeriesIndisponiveis.Where(p => p.SerieId == selo.IdSerie).FirstOrDefault();

                if (serie != null)
                {
                    dataGridSeriesIndisponiveis.SelectedItem = serie;
                    dataGridSeriesIndisponiveis.ScrollIntoView(serie);

                    if (selo != null)
                    {
                        dataGridSelosIndisponiveis.SelectedItem = selo;
                        dataGridSelosIndisponiveis.ScrollIntoView(selo);
                    }

                }
                else
                {
                    MessageBox.Show("Selo informado não foi encontrado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtConsultaSerieIndisponiveis.Text = "";
                    txtConsultaSerieIndisponiveis.Focus();
                    txtConsultaNumeroIndisponiveis.Text = "";
                    txtConsultaNumeroIndisponiveis.IsEnabled = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridSelosIndisponiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                seloIndisponivelSelecionado = (Selos)dataGridSelosIndisponiveis.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnLiberarSeloIndisponiveis_Click(object sender, RoutedEventArgs e)
        {
            if (listSelosIndisponiveisSerieSelecionada == null)
                return;


            List<Selos> selosLiberar = new List<Selos>();


            selosLiberar = listSelosIndisponiveisSerieSelecionada.Where(p => p.Check == true && p.Status != "LIVRE").ToList();


            if (selosLiberar.Count > 0)
            {
                if (_usuario.NomeUsuario != "Administrador")
                {

                    autorizacao = string.Empty;

                    var verificarSenha = new InformarSenhaMaster(this);
                    verificarSenha.Owner = this;
                    verificarSenha.ShowDialog();

                    if (autorizacao != "autorizado")
                    {

                        return;
                    }
                }

                lblQtdMarcadosIndisponiveis.Visibility = Visibility.Hidden;
                var liberarBaixarSelos = new CarreguandoBaixarLiberarSelo(selosLiberar, _usuario, "liberar", this);
                liberarBaixarSelos.Owner = this;
                liberarBaixarSelos.ShowDialog();
                lblQtdMarcadosIndisponiveis.Visibility = Visibility.Visible;

                this.Close();

                AguardeProcessandoSelos aguarde = new AguardeProcessandoSelos(_principal, _usuario, seloIndisponivelSelecionado);
                aguarde.Owner = _principal;
                aguarde.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum selo com Status diferente de LIVRE foi selecionado", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnBaixarManualIndisponiveis_Click(object sender, RoutedEventArgs e)
        {

            if (listSelosIndisponiveisSerieSelecionada == null)
                return;

            List<Selos> selosBaixar = new List<Selos>();


            selosBaixar = listSelosIndisponiveisSerieSelecionada.Where(p => p.Check == true && p.Status == "LIVRE").ToList();


            if (selosBaixar.Count > 0)
            {
                if (_usuario.NomeUsuario != "Administrador")
                {

                    autorizacao = string.Empty;

                    var verificarSenha = new InformarSenhaMaster(this);
                    verificarSenha.Owner = this;
                    verificarSenha.ShowDialog();

                    if (autorizacao != "autorizado")
                    {
                        return;
                    }
                }


                lblQtdMarcadosIndisponiveis.Visibility = Visibility.Hidden;
                var liberarBaixarSelos = new CarreguandoBaixarLiberarSelo(selosBaixar, _usuario, "baixar", this);
                liberarBaixarSelos.Owner = this;
                liberarBaixarSelos.ShowDialog();
                lblQtdMarcadosIndisponiveis.Visibility = Visibility.Visible;

                this.Close();

                AguardeProcessandoSelos aguarde = new AguardeProcessandoSelos(_principal, _usuario, seloIndisponivelSelecionado);
                aguarde.Owner = _principal;
                aguarde.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nenhum selo LIVRE foi selecionado", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


        private void moverNaoImportados_Click(object sender, RoutedEventArgs e)
        {
            string pathImportados = parametros.PathSelosImportados + @"\" + arquivoSelecionadoImportados.Name;
            string pathNaoImportados = parametros.PathSelosNaoImportados + @"\" + arquivoSelecionadoImportados.Name;
            try
            {
                
                if (File.Exists(pathNaoImportados))
                    File.Delete(pathNaoImportados);


                arquivoSelecionadoImportados = new FileInfo(pathImportados);

                if (arquivoSelecionadoImportados.Exists)
                    arquivoSelecionadoImportados.MoveTo(pathNaoImportados);

                string arquivoMovido = arquivoSelecionadoImportados.Name;

                CarregarSelosImportados();

                CarregarSelosNaoImpotados();
                

                tabItemNaoImportarSelos.IsSelected = true;

                arquivoSelecionado = listArquivosNaoImportados.Where(p => p.Name == arquivoMovido).FirstOrDefault();

                listView.SelectedItem = arquivoSelecionado;

                listView.ScrollIntoView(arquivoSelecionado);


            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível mover o arquivo. Por favor aguarde alguns segundo e tente novamente.", "Aguarde", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void listViewImportados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listViewImportados.Items.Count > 0)
                {

                    arquivoSelecionadoImportados = (FileInfo)listViewImportados.SelectedItem;

                    CarregaInformacoesDoArquivoImportado();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
                CarregarTodosProcessos();
            }


            try
            {
                if (listView.Items.Count > 0)
                {
                    try
                    {
                        {
                            arquivoSelecionado = (FileInfo)listView.SelectedItem;

                            CarregaInformacoesDoArquivo();

                        }
                    }
                    catch (Exception)
                    {
                        CarregarTodosProcessos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
                CarregarTodosProcessos();
            }

        }

        private void moverImportados_Click(object sender, RoutedEventArgs e)
        {

            string pathImportados = parametros.PathSelosImportados + @"\" + arquivoSelecionado.Name;
            string pathNaoImportados = parametros.PathSelosNaoImportados + @"\" + arquivoSelecionado.Name;

            try
            {

                if (File.Exists(pathImportados))
                    File.Delete(pathImportados);


                arquivoSelecionado = new FileInfo(pathNaoImportados);

                if (arquivoSelecionado.Exists)
                    arquivoSelecionado.MoveTo(pathImportados);

                string arquivoMovido = arquivoSelecionado.Name;

                CarregarSelosImportados();

                CarregarSelosNaoImpotados();


                tabItemImportarSelos.IsSelected = true;

                arquivoSelecionadoImportados = listArquivosImportados.Where(p => p.Name == arquivoMovido).FirstOrDefault();

                listViewImportados.SelectedItem = arquivoSelecionadoImportados;

                listViewImportados.ScrollIntoView(arquivoSelecionadoImportados);


            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível mover o arquivo. Por favor aguarde alguns segundo e tente novamente.", "Aguarde", MessageBoxButton.OK, MessageBoxImage.Information);                
            }
        }

        private void dataGridHistorico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CompraSelo compraSelo = (CompraSelo)dataGridHistorico.SelectedItem;

                Series serie = _AppServicoSeries.ConsultarPorIdCompraSelo(compraSelo.CompraSeloId).FirstOrDefault();

                List<Series> series = new List<Series>();

                series.Add(serie);

                listViewSeries.ItemsSource = null;

                listViewSeries.Items.Clear();

                listViewSeries.ItemsSource = series;

                if (listViewSeries.Items.Count > 0)
                    listViewSeries.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dataGridSelosIndisponiveis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var detalhesSelo = new DetalhesDoSelo(seloIndisponivelSelecionado, _usuario);
            detalhesSelo.Owner = this;
            detalhesSelo.ShowDialog();

            listSelosIndisponiveisSerieSelecionada[dataGridSelosIndisponiveis.SelectedIndex] = _AppServicoSelos.GetById(seloIndisponivelSelecionado.SeloId);

            dataGridSelosIndisponiveis.Items.Refresh();

        }





    }
}
