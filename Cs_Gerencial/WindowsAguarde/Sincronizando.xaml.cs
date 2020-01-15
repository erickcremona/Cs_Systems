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

namespace Cs_Gerencial.WindowsAguarde
{
    /// <summary>
    /// Interaction logic for Sincronizando.xaml
    /// </summary>
    public partial class Sincronizando : Window
    {

        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        private readonly IAppServicoContas _AppServicoContas = BootStrap.Container.GetInstance<IAppServicoContas>();

        BackgroundWorker worker;

        LogSistema logSistema;

        string acao;

        List<Selos> selos = new List<Selos>();

        List<Contas> contasExistentes = new List<Contas>();

        DateTime _dataInicio;
        DateTime _dataFim;
        Usuario _usuario;

        public Sincronizando(DateTime dataInicio, DateTime dataFim, Usuario usuario)
        {

            _dataInicio = dataInicio;
            _dataFim = dataFim;
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            selos = _AppServicoSelos.ConsultaPorPeriodo(_dataInicio, _dataFim).ToList();

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


            if (acao == "adicionar")
            {
                progressBar1.Maximum = selos.Count;
                lblContagem.Content = string.Format("Sincronizando {0} de {1}", e.ProgressPercentage, selos.Count());
            }
            else
            {
                progressBar1.Maximum = contasExistentes.Count;
                lblContagem.Content = string.Format("Removendo {0} de {1}", e.ProgressPercentage, selos.Count());
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Close();
        }

        private void Processo()
        {

            acao = "remover";

            contasExistentes = _AppServicoContas.ConsultaPorPeriodo(_dataInicio.Date, _dataFim.Date).ToList();

            for (int c = 0; c < contasExistentes.Count; c++)
            {
                Thread.Sleep(1);
                worker.ReportProgress(c + 1);

                _AppServicoContas.Remove(contasExistentes[c]);

            }




            acao = "adicionar";
            for (int i = 0; i < selos.Count; i++)
            {
                Thread.Sleep(1);
                worker.ReportProgress(i + 1);


                Salvar(selos[i]);

            }

            SalvarLogSistema(string.Format("Sincronizou o período {0} até {1}", _dataInicio.Date, _dataFim.Date));
        }


        private void Salvar(Selos selo)
        {
            Contas contas = new Contas();

            contas.IdAto = selo.IdAto;
            contas.Atribuicao = selo.Atribuicao;
            contas.Livro = selo.Livro;
            contas.FolhaInicial = selo.FolhaInicial;
            contas.FolhaFinal = selo.FolhaFinal;
            contas.Protocolo = selo.Protocolo;
            contas.Recibo = selo.Recibo;
            contas.Codigo = selo.Codigo;


            if (selo.Atribuicao == 5)
            {
                if (selo.Codigo == 2012 || selo.Codigo == 2013)
                    contas.Tipo = "RE";
                else
                    contas.Tipo = "DP";
            }
            else
            {
                contas.Tipo = "RE";
            }


            contas.DataMovimento = selo.DataPratica;
            contas.Matricula = selo.Matricula;
            contas.Descricao = selo.Natureza;
            contas.Total = selo.Emolumentos;
            contas.Letra = selo.Letra;
            contas.Numero = selo.Numero;
            contas.Aleatorio = selo.Aleatorio;

            _AppServicoContas.Add(contas);

        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Sincronizando";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }
    }
}