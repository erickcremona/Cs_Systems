using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Linq;
using System.Threading;
using System.IO;

namespace Cs_Gerencial.WindowsAguarde
{
    /// <summary>
    /// Interaction logic for AguardeProcessandoSelos.xaml
    /// </summary>
    public partial class AguardeProcessandoSelos : Window
    {
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        
        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        Usuario _usuario;

        BackgroundWorker worker;

        Principal _principal;

        List<Series> listSeriesDisponiveis = new List<Series>();

        List<Series> listSeriesIndisponiveis = new List<Series>();

        List<Selos> listSelos = new List<Selos>();

        List<Series> listSeries = new List<Series>();

        Selos _seloSelecionado;
        private Selos seloDisponivelSelecionado;
        private FileInfo arquivoSelecionado;
        private FileInfo arquivoSelecionadoImportados;



        public AguardeProcessandoSelos(Principal principal, Usuario usuario)
        {

            _principal = principal;
            _usuario = usuario;
            InitializeComponent();
        }

        public AguardeProcessandoSelos(Principal principal, Usuario usuario, Selos seloSelecionado)
        {

            _principal = principal;
            _usuario = usuario;
            _seloSelecionado = seloSelecionado;
            InitializeComponent();
        }

        public AguardeProcessandoSelos(Principal _principal, Usuario _usuario, Selos seloDisponivelSelecionado, FileInfo arquivoSelecionado, FileInfo arquivoSelecionadoImportados)
        {
            // TODO: Complete member initialization
            this._principal = _principal;
            this._usuario = _usuario;
            this.seloDisponivelSelecionado = seloDisponivelSelecionado;
            this.arquivoSelecionado = arquivoSelecionado;
            this.arquivoSelecionadoImportados = arquivoSelecionadoImportados;
            InitializeComponent();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BootStrap.Start();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

         void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Processo();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            

            this.Close();

            var estoqueSelos = new EstoqueSelos(listSeriesDisponiveis, listSeriesIndisponiveis, _usuario, _principal, _seloSelecionado, arquivoSelecionado, arquivoSelecionadoImportados);
            estoqueSelos.Owner = _principal;

            estoqueSelos.ShowDialog();
        }

        private void Processo()
        {
            CarregaDataGridSeriesDisponiveis();

            CarregaDataGridSeriesIndisponiveis();
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
            
        }

        private void CarregaDataGridSeriesIndisponiveis()
        {
            for (int p = 0; p < listSeriesDisponiveis.Count; p++)
            {
                listSeries.Remove(listSeriesDisponiveis[p]);
            }

            listSeriesIndisponiveis = listSeries;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            listSelos = null;

            listSeries = null;
        }
    }
}
