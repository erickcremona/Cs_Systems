using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for AguardeIntegracaoIssMas.xaml
    /// </summary>
    public partial class AguardeIntegracaoIssMas : Window
    {
        List<AtoIss> _listaAtosImportados;
        string _caminhoArquivo;
        BackgroundWorker worker;
        string acao;
        List<AtoIss> listaExistentes = new List<AtoIss>();
        FileInfo arquivo;
        bool erro = false;
        private readonly IAppServicoAtoIss _appServicoAtoIss = BootStrap.Container.GetInstance<IAppServicoAtoIss>();

        public AguardeIntegracaoIssMas(List<AtoIss> listaAtosImportados, string caminhoArquivo)
        {
            _listaAtosImportados = listaAtosImportados;
            _caminhoArquivo = caminhoArquivo;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lblContagem.Content = string.Format("{0} / {1}", 0, _listaAtosImportados.Count);

            

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
            {
                progressBar1.Maximum = _listaAtosImportados.Count();
                lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, _listaAtosImportados.Count);
            }
            else
            {
                progressBar1.Maximum = listaExistentes.Count();
                lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, listaExistentes.Count);
            }


        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            arquivo = new FileInfo(_caminhoArquivo);
            try
            {
                if (erro == false)
                    if (arquivo.Exists)
                        arquivo.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
            this.Close();

        }

        private void Processo()
        {
            try
            {
                acao = "Removendo registro ";

                


                DateTime data = Convert.ToDateTime(_listaAtosImportados[0].Data);

                listaExistentes = _appServicoAtoIss.VerificarRegistrosExistentesPorData(data);

                if (listaExistentes.Count > 0)
                {


                    for (int i = 0; i < listaExistentes.Count(); i++)
                    {
                        _appServicoAtoIss.Remove(listaExistentes[i]);
                        Thread.Sleep(1);
                        worker.ReportProgress(i + 1);
                    }


                }



                for (int i = 0; i < _listaAtosImportados.Count(); i++)
                {
                    acao = "Adicionando registro ";


                    if(i == 307)
                        acao = "Adicionando registro ";

                    AtoIss AtoSalvar = _listaAtosImportados[i];


                    AtoSalvar = _appServicoAtoIss.CalcularValoresAtoIss(AtoSalvar);


                    _appServicoAtoIss.Add(AtoSalvar);

                    Thread.Sleep(1);
                    worker.ReportProgress(i + 1);

                }


            }
            catch (Exception ex)
            {
                erro = true;
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
