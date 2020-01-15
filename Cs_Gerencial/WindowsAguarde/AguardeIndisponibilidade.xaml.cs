using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
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
using System.Windows.Threading;

namespace Cs_Gerencial.WindowsAguarde
{
    /// <summary>
    /// Interaction logic for AguardeIndisponibilidade.xaml
    /// </summary>
    public partial class AguardeIndisponibilidade : Window
    {
        List<Indisponibilidades> _indisponibilidades;
        List<Indisponibilidades> _existentes;
        string acao;
        LogSistema logSistema;
        Usuario _usuario;
        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();
        private readonly IAppServicoIndisponibilidades _AppServicoIndisponibilidades = BootStrap.Container.GetInstance<IAppServicoIndisponibilidades>();
        BackgroundWorker worker;
        string _arquivo;
        public AguardeIndisponibilidade(List<Indisponibilidades> indisponibilidades, string arquivo, List<Indisponibilidades> existentes, Usuario usuario)
        {
            _indisponibilidades = indisponibilidades;
            _arquivo = arquivo;
            _existentes = existentes;
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            lblContagem.Content = string.Format("{0} / {1}", 0, _indisponibilidades.Count);

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

            if (acao == "Adicionando registro ")
                progressBar1.Maximum = _indisponibilidades.Count();
            else
                progressBar1.Maximum = _existentes.Count();

            lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, _indisponibilidades.Count);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            MessageBox.Show("Importação finalizada com sucesso.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void Processo()
        {
            try
            {
                if (_existentes.Count() > 0)
                {
                    acao = "Removendo registro ";

                    for (int i = 0; i < _existentes.Count(); i++)
                    {
                        _AppServicoIndisponibilidades.Remove(_existentes[i]);
                        
                        Thread.Sleep(1);
                        worker.ReportProgress(i + 1);
                    }

                }



                for (int i = 0; i < _indisponibilidades.Count(); i++)
                {
                    acao = "Adicionando registro ";


                    Indisponibilidades indispSalvar = _indisponibilidades[i];

                    _AppServicoIndisponibilidades.Add(indispSalvar);

                    Thread.Sleep(1);
                    worker.ReportProgress(i + 1);

                }

                if (_existentes.Count > 0)
                {
                    SalvarLogSistema("Importou novamente o arquivo " + _arquivo);
                }
                else
                {
                    SalvarLogSistema("Importou o arquivo " + _arquivo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "AguardeIndisponibilidade";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }
    }
}
