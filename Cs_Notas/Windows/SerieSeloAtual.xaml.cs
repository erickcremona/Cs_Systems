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

namespace Cs_Notas.Windows
{
    /// <summary>
    /// Interaction logic for SerieSeloAtual.xaml
    /// </summary>
    public partial class SerieSeloAtual : Window
    {

        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoLogSistema>();

        Series serieAtual;

        List<Series> listSeriesDisponiveis = new List<Series>();

        List<Series> listSeriesIndisponiveis = new List<Series>();

        List<Selos> listSelos = new List<Selos>();

        List<Series> listSeries = new List<Series>();

        Cs_Notas.Dominio.Entities.Usuario _usuario;

        List<Selos> listSelosDisponiveisSerieSelecionada = new List<Selos>();

        int serieAtualId;

        Cs_Notas.Dominio.Entities.LogSistema logSistema;



        public SerieSeloAtual(Cs_Notas.Dominio.Entities.Usuario usuario )
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                serieAtualId = _AppServicoConfiguracoes.GetById(1).SerieAtual;
                CarregaDataGridSeriesDisponiveis();

                serieAtual = listSeriesDisponiveis.Where(p => p.SerieId == serieAtualId).FirstOrDefault();

                dataGridSeriesDisponiveis.SelectedItem = serieAtual;
                dataGridSeriesDisponiveis.ScrollIntoView(serieAtual);

                SalvarLogSistema("Entrou na Tela de Alterar Série do Selo");

            }
            catch (Exception) { }
        }

        private void CarregaDataGridSeriesDisponiveis()
        {

            listSelos = _AppServicoSelos.ConsultarPorStatusLivre().ToList();

            listSeries = _AppServicoSeries.GetAll().ToList();

            List<int> listIdsSeriesDisponiveis = listSelos.Select(p => p.IdSerie).Distinct().ToList();



            Series serie;

            for (int i = 0; i < listIdsSeriesDisponiveis.Count; i++)
            {
                serie = listSeries.Where(p => p.SerieId == listIdsSeriesDisponiveis[i]).FirstOrDefault();

                listSeriesDisponiveis.Add(serie);
            }

            serie = null;

            dataGridSeriesDisponiveis.ItemsSource = listSeriesDisponiveis;
            dataGridSeriesDisponiveis.SelectedValuePath = "SerieId";
            dataGridSeriesDisponiveis.Items.Refresh();

        }


        

        private void dataGridSeriesDisponiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                serieAtual = (Series)dataGridSeriesDisponiveis.SelectedItem;

                if (serieAtual != null)
                {
                    listSelosDisponiveisSerieSelecionada = _AppServicoSelos.ConsultarPorIdSerie(serieAtual.SerieId).ToList();
                    CarregarSerieDisponivelSelecionadaTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuracoes config = _AppServicoConfiguracoes.GetById(1);

                config.SerieAtual = ((Series)dataGridSeriesDisponiveis.SelectedItem).SerieId;

                _AppServicoConfiguracoes.Update(config);

                AlterarLogSistema(logSistema, "Alterou Série do Selo para " + config.SerieAtual);
            }
            catch (Exception) { }
            finally {this.Close(); }           

        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new Cs_Notas.Dominio.Entities.LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Série Selo Atual";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.Nome;

            logSistema.Maquina = Environment.MachineName.ToString();

            logSistema.InicioTela = string.Format("Serie {0}; Selo Inicio {1}; Selo Fim {2}; Quant. {3}; Utilizados {4}; Livres {5};", txtSerieLetra.Text, txtSerieInicial.Text, txtSerieFinal.Text, txtSerieQtd.Text, txtSerieUtilizado.Text, txtSerieLivre.Text);
                        
            _AppServicoLogSistema.Add(logSistema);
        }


        private void AlterarLogSistema(Cs_Notas.Dominio.Entities.LogSistema log, string descricao)
        {
            logSistema = _AppServicoLogSistema.GetById(log.LogId);

            logSistema.Descricao = descricao;

            logSistema.HoraClose = DateTime.Now.ToLongTimeString();

            logSistema.FimTela = string.Format("Serie {0}; Selo Inicio {1}; Selo Fim {2}; Quant. {3}; Utilizados {4}; Livres {5};", txtSerieLetra.Text, txtSerieInicial.Text, txtSerieFinal.Text, txtSerieQtd.Text, txtSerieUtilizado.Text, txtSerieLivre.Text);

            _AppServicoLogSistema.Update(logSistema);
        }
      
        private void CarregarSerieDisponivelSelecionadaTextBox()
        {

            txtSerieLetra.Text = serieAtual.Letra;
            txtSerieInicial.Text = string.Format("{0:00000}", serieAtual.Inicial);
            txtSerieFinal.Text = string.Format("{0:00000}", serieAtual.Final);
            txtSerieQtd.Text = serieAtual.Quantidade.ToString();
            txtSerieUtilizado.Text = listSelosDisponiveisSerieSelecionada.Where(p => p.IdSerie == serieAtual.SerieId && p.Status != "LIVRE").Count().ToString();
            txtSerieLivre.Text = listSelosDisponiveisSerieSelecionada.Where(p => p.IdSerie == serieAtual.SerieId && p.Status == "LIVRE").Count().ToString();

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
