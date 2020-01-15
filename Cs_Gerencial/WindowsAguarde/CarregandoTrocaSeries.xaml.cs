using Cs_Gerencial.Aplicacao.Interfaces;
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
    /// Interaction logic for CarregandoTrocaSeries.xaml
    /// </summary>
    public partial class CarregandoTrocaSeries : Window
    {
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        BackgroundWorker worker;

        EstoqueSelos _estoqueSelos;

        public CarregandoTrocaSeries(EstoqueSelos estoqueSelos)
        {
            _estoqueSelos = estoqueSelos;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


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
            if (e.ProgressPercentage == _estoqueSelos.listSelosDisponiveisSerieSelecionada.Count - 1)
           {
               _estoqueSelos.dataGridSelosDisponiveis.ItemsSource = _estoqueSelos.listSelosDisponiveisSerieSelecionada;

               _estoqueSelos.dataGridSelosDisponiveis.Items.Refresh();
           }

        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void Processo()
        {
            _estoqueSelos.listSelosDisponiveisSerieSelecionada = _AppServicoSelos.ConsultarPorIdSerie(_estoqueSelos.serieDisponiveisSelecionada.SerieId).ToList();

            for (int i = 0; i < _estoqueSelos.listSelosDisponiveisSerieSelecionada.Count; i++)
            {
               _estoqueSelos.listSelosDisponiveisSerieSelecionada[i].Check = false;

                Thread.Sleep(1);
                worker.ReportProgress(i);
            }

           
        }
    }
}
