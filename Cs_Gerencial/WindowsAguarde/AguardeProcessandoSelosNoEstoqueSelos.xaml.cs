using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cs_Gerencial.WindowsAguarde
{
    /// <summary>
    /// Interaction logic for AguardeProcessandoSelosNoEstoqueSelos.xaml
    /// </summary>
    public partial class AguardeProcessandoSelosNoEstoqueSelos : Window
    {
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        BackgroundWorker worker;

        EstoqueSelos _estoqueSelos;

        Series serie;

        List<Selos> _listSelos;

        List<Series> listSeries = new List<Series>();

        string metodo = string.Empty;

        public AguardeProcessandoSelosNoEstoqueSelos(EstoqueSelos estoqueSelos)
        {
            _estoqueSelos = estoqueSelos;
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
            try
            {
                Processo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _listSelos = null;
            this.Close();
        }

        private void Processo()
        {
            CarregaDataGridSeriesDisponiveis();

            CarregaDataGridSeriesIndisponiveis();
        }

        private void CarregaDataGridSeriesDisponiveis()
        {
            metodo = "CarregaDataGridSeriesDisponiveis";

            _listSelos = new List<Selos>();

            _listSelos = _AppServicoSelos.ConsultarPorStatusLivre().ToList();

            listSeries = _AppServicoSeries.GetAll().ToList();

            List<int> listIdsSeriesDisponiveis = _listSelos.Select(p => p.IdSerie).Distinct().ToList();

            _estoqueSelos._listSeriesDisponiveis = new List<Series>();

            for (int i = 0; i < listIdsSeriesDisponiveis.Count; i++)
            {
                serie = listSeries.Where(p => p.SerieId == listIdsSeriesDisponiveis[i]).FirstOrDefault();

                _estoqueSelos._listSeriesDisponiveis.Add(serie);

            }
            
        }

        private void CarregaDataGridSeriesIndisponiveis()
        {
            metodo = "CarregaDataGridSeriesIndisponiveis";


            for (int p = 0; p < _estoqueSelos._listSeriesDisponiveis.Count; p++)
            {
                listSeries.Remove(_estoqueSelos._listSeriesDisponiveis[p]);
            }

            _estoqueSelos._listSeriesIndisponiveis = listSeries;

        }

    }
}
