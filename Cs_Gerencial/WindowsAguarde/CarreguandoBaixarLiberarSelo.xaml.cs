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
    /// Interaction logic for CarreguandoBaixarLiberarSelo.xaml
    /// </summary>
    public partial class CarreguandoBaixarLiberarSelo : Window
    {


        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        BackgroundWorker worker;

        LogSistema logSistema;

        List<Selos> _selosLiberarBaixar;

        Selos selo;

        Usuario _usuario;

        string _acao;

        EstoqueSelos _estoqueSelos;

        public CarreguandoBaixarLiberarSelo(List<Selos> selosLiberarBaixar, Usuario usuario, string acao, EstoqueSelos estoqueSelos)
        {
            _selosLiberarBaixar = selosLiberarBaixar;
            _usuario = usuario;
            _acao = acao;
            _estoqueSelos = estoqueSelos;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            progressBar1.Maximum = _selosLiberarBaixar.Count;

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
            progressBar1.Value = e.ProgressPercentage;

            if (_acao == "liberar")
            {
                lblContagem.Content = string.Format("Liberando selo {0} {1} {2}", selo.Letra, selo.Numero, selo.Aleatorio);

                _estoqueSelos.dataGridSelosDisponiveis.Items.Refresh();

                _estoqueSelos.dataGridSelosIndisponiveis.Items.Refresh();

                _estoqueSelos.dataGridSelosDisponiveis.SelectedItem = selo;
                _estoqueSelos.dataGridSelosDisponiveis.ScrollIntoView(selo);

                _estoqueSelos.dataGridSelosIndisponiveis.SelectedItem = selo;
                _estoqueSelos.dataGridSelosIndisponiveis.ScrollIntoView(selo);

            }
            else
            {
                lblContagem.Content = string.Format("Baixando selo {0} {1} {2}", selo.Letra, selo.Numero, selo.Aleatorio);

                _estoqueSelos.dataGridSelosDisponiveis.Items.Refresh();

                _estoqueSelos.dataGridSelosIndisponiveis.Items.Refresh();

                _estoqueSelos.dataGridSelosDisponiveis.SelectedItem = selo;
                _estoqueSelos.dataGridSelosDisponiveis.ScrollIntoView(selo);

                _estoqueSelos.dataGridSelosIndisponiveis.SelectedItem = selo;
                _estoqueSelos.dataGridSelosIndisponiveis.ScrollIntoView(selo);
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Close();
        }

        private void Processo()
        {
            if (_acao == "liberar")
            {

                for (int i = 0; i < _selosLiberarBaixar.Count; i++)
                {
                    selo = _AppServicoSelos.LiberarSelos(_selosLiberarBaixar[i]);

                    Thread.Sleep(1);
                    worker.ReportProgress(i + 1);

                    _AppServicoSelos.SalvarSeloModificado(selo);

                    SalvarLogSistema(string.Format("Liberou o selo {0} {1} {2}", selo.Letra, selo.Numero, selo.Aleatorio));
                }

            }
            else
            {

                for (int i = 0; i < _selosLiberarBaixar.Count; i++)
                {
                    selo = _AppServicoSelos.BaixarSelosManualmente(_selosLiberarBaixar[i], _usuario);

                    Thread.Sleep(1);
                    worker.ReportProgress(i + 1);

                    _AppServicoSelos.SalvarSeloModificado(selo);

                    SalvarLogSistema(string.Format("Baixou o selo {0} {1} {2}", selo.Letra, selo.Numero, selo.Aleatorio));


                }
            }
        }



        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Estoque de Selos";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }
    }
}
