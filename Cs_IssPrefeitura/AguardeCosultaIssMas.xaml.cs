using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
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

namespace Cs_IssPrefeitura
{
    /// <summary>
    /// Interaction logic for AguardeCosultaIssMas.xaml
    /// </summary>
    public partial class AguardeCosultaIssMas : Window
    {
       BackgroundWorker worker;
        ConsultaAtosIss _importarMas;

        private readonly IAppServicoAtoIss _appServicoAtoIss = BootStrap.Container.GetInstance<IAppServicoAtoIss>();

        public AguardeCosultaIssMas(ConsultaAtosIss importarMas)
        {

            InitializeComponent();
            _importarMas = importarMas;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lblContagem.Content = "Processando Dados Solicitados";
            progressBar1.Maximum = 5;


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
            progressBar1.Value = e.ProgressPercentage;

            if (e.ProgressPercentage == 2)
            {
                if (_importarMas.tipoConsulta == "data")
                    _importarMas.atosConsultados = _appServicoAtoIss.ListarAtosPorPeriodo(_importarMas.dpConsultaInicio.SelectedDate.Value, _importarMas.dpConsultaFim.SelectedDate.Value);
                else
                {
                    if (_importarMas.cmbTipoConsulta.SelectedIndex <= 1)
                        _importarMas.atosConsultados = _appServicoAtoIss.ConsultaDetalhada(_importarMas.cmbTipoConsulta.Text, _importarMas.cmbDadosConsulta.Text);
                    else
                        _importarMas.atosConsultados = _appServicoAtoIss.ConsultaDetalhada(_importarMas.cmbTipoConsulta.Text, _importarMas.txtDadosConsulta.Text);
                }
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            this.Close();

        }

        private void Processo()
        {
            try
            {

                for (int i = 0; i < 5; i++)
                {

                    Thread.Sleep(1);
                    worker.ReportProgress(i + 1);
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}


