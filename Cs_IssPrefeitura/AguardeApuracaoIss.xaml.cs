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
    /// Interaction logic for AguardeApuracaoIss.xaml
    /// </summary>
    public partial class AguardeApuracaoIss : Window
    {

        BackgroundWorker worker;
        bool erro = false;
        private readonly IAppServicoAtoIss _appServicoAtoIss = BootStrap.Container.GetInstance<IAppServicoAtoIss>();
        private readonly IAppServicoApuracaoIss _appServicoApuracaoIss = BootStrap.Container.GetInstance<IAppServicoApuracaoIss>();
        private readonly IAppServicoConfiguracoes _appServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();
        string acao;
        List<AtoIss> _listaAtos;
        int _mes;
        int _ano;
        DateTime _inicio;
        DateTime _fim;

        Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss apuracao = new Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss();
        Config configuracao = new Config();


        Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss _apuracaoIss;
        List<AtoIss> _atosIss;
        string construtor = string.Empty;

        public AguardeApuracaoIss(int mes, int ano, DateTime inicio, DateTime fim)
        {

            _mes = mes;
            _ano = ano;
            _inicio = inicio;
            _fim = fim;
            construtor = "vinculando";
            InitializeComponent();
        }

        public AguardeApuracaoIss(Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss apuracaoIss, List<AtoIss> atosIss)
        {
            _apuracaoIss = apuracaoIss;
            _atosIss = atosIss;
            construtor = "desvinculando";
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
            if (construtor == "vinculando")
            {
                Processo();

                if (erro == true)
                    ProcessoErro();
                else
                    SalvarConfiguracoes();
            }
            else
            {
                ProcessoCancelamentoApuracao();
            }

        }

        private void SalvarConfiguracoes()
        {
            configuracao.ProximaFolha = apuracao.Folha + 4;


            if (configuracao.ProximaFolha > configuracao.TotalFolhasPorLivro - 4)
            {
                configuracao.ProximaFolha = 1;
                configuracao.ProximoLivro = configuracao.ProximoLivro + 1;
            }

            _appServicoConfiguracoes.Update(configuracao);
        }


        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            if (acao == "Vinculando atos para Apuração. ")
            {
                progressBar1.Maximum = _listaAtos.Count();
                lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, _listaAtos.Count);
            }
            if (acao == "Desvinculando atos. ")
            {
                progressBar1.Maximum = _listaAtos.Count();
                lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, _listaAtos.Count);
            }

            if (acao == "Desvinculando. ")
            {
                progressBar1.Maximum = _atosIss.Count();
                lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, _atosIss.Count);
            }

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }


        private void ProcessoCancelamentoApuracao()
        {

            _apuracaoIss.Cancelado = "SIM";

            _appServicoApuracaoIss.Update(_apuracaoIss);



            for (int i = 0; i < _atosIss.Count(); i++)
            {
                acao = "Desvinculando. ";


                AtoIss AtoDesvincular = _atosIss[i];

                AtoDesvincular.IdApuracaoIss = 0;

                _appServicoAtoIss.Update(AtoDesvincular);


                Thread.Sleep(1);
                worker.ReportProgress(i + 1);

            }
        }

        private void ProcessoErro()
        {
            for (int i = 0; i < _listaAtos.Count(); i++)
            {
                acao = "Desvinculando atos. ";


                AtoIss AtoDesvincular = _listaAtos[i];

                AtoDesvincular.IdApuracaoIss = 0;

                _appServicoAtoIss.Update(AtoDesvincular);


                Thread.Sleep(1);
                worker.ReportProgress(i + 1);

            }


            _appServicoApuracaoIss.Remove(apuracao);
        }




        private void Processo()
        {
            try
            {

                acao = "Vinculando atos para apuração. ";
                _listaAtos = _appServicoAtoIss.ListarAtosPorPeriodo(_inicio, _fim);

                configuracao = _appServicoConfiguracoes.GetById(1);

                apuracao.Aliquota = Convert.ToSingle(configuracao.ValorAliquota);
                apuracao.Ano = _ano;
                apuracao.BaseCalculo = _listaAtos.Sum(p => p.Emolumentos);
                apuracao.Cancelado = "NÂO";
                apuracao.DataFechamento = DateTime.Now.Date;
                apuracao.Faturamento = _listaAtos.Sum(p =>p.Emolumentos + p.Fetj + p.Funarpen + p.Fundperj + p.Funperj + p.Mutua + p.Ressag + p.Acoterj);
                apuracao.Folha = configuracao.ProximaFolha;
                apuracao.FundosEspeciais = _listaAtos.Sum(p => p.Fetj + p.Funarpen + p.Fundperj + p.Funperj + p.Mutua + p.Acoterj);
                apuracao.Livro = configuracao.ProximoLivro;
                apuracao.Mes = _mes;
                
                apuracao.Numero = _appServicoApuracaoIss.ObterUltimoNumero() + 1;
                apuracao.Periodo = string.Format("{0} a {1}", _inicio.ToShortDateString(), _fim.ToShortDateString());
                apuracao.Recibo = "GERAL";

                apuracao.Serie = _appServicoApuracaoIss.ObterUltimaSerie(_ano) + 1;
                apuracao.ValorIssRecolhido = _listaAtos.Sum(p => p.Iss);
                apuracao.NomeMes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(_mes).ToUpper();


                _appServicoApuracaoIss.Add(apuracao);




                for (int i = 0; i < _listaAtos.Count(); i++)
                {
                    acao = "Vinculando atos para Apuração. ";


                    AtoIss AtoVincular = _appServicoAtoIss.GetById(_listaAtos[i].AtoIssId);

                    AtoVincular.IdApuracaoIss = apuracao.ApuracaoIssId;




                    _appServicoAtoIss.Update(AtoVincular);


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
