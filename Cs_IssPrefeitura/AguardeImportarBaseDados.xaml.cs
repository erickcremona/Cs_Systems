using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for AguardeImportarBaseDados.xaml
    /// </summary>
    public partial class AguardeImportarBaseDados : Window
    {

        BackgroundWorker worker;
        string acao;
        private readonly IAppServicoAtoIss _appServicoAtoIss = BootStrap.Container.GetInstance<IAppServicoAtoIss>();
        DataTable dtSql = new DataTable();


        public AguardeImportarBaseDados()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lblContagem.Content = "";

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
                progressBar1.Maximum = dtSql.Rows.Count;
                lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, dtSql.Rows.Count);
            }
            else
            {
                progressBar1.Maximum = dtSql.Rows.Count;
                lblContagem.Content = string.Format("{0} {1} de {2}", acao, e.ProgressPercentage, dtSql.Rows.Count);
            }


        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
                        

            this.Close();

        }

        private void Processo()
        {
            SqlConnection conSql = new SqlConnection(@"Data Source=Servidor;Initial Catalog=CS_CAIXA_DB;Persist Security Info=True;User ID=sa;Password=P@$$w0rd");
            conSql.Open();
            try
            {

                SqlCommand cmdTotal = new SqlCommand("select * from ImportarMas", conSql);
                cmdTotal.CommandType = CommandType.Text;


                SqlDataReader drSql;
                drSql = cmdTotal.ExecuteReader();

                dtSql = new DataTable();
                dtSql.Load(drSql);

                acao = "Adicionando registro ";

                var ato = new AtoIss();

                for (int i = 0; i < dtSql.Rows.Count; i++)
                {

                    Thread.Sleep(1);
                    worker.ReportProgress(i + 1);
                                       

                    ato.Data = Convert.ToDateTime(dtSql.Rows[i]["Data"]);
                    ato.Atribuicao = dtSql.Rows[i]["Atribuicao"].ToString();
                    ato.TipoAto = dtSql.Rows[i]["TipoAto"].ToString();
                    ato.Selo = dtSql.Rows[i]["Selo"].ToString();
                    ato.Aleatorio = dtSql.Rows[i]["Aleatorio"].ToString();
                    ato.TipoCobranca = dtSql.Rows[i]["TipoCobranca"].ToString();
                    ato.Emolumentos = Convert.ToDecimal(dtSql.Rows[i]["Emolumentos"]);
                    ato.Fetj = Convert.ToDecimal(dtSql.Rows[i]["Fetj"]);
                    ato.Funperj = Convert.ToDecimal(dtSql.Rows[i]["Funperj"]);
                    ato.Fundperj = Convert.ToDecimal(dtSql.Rows[i]["Fundperj"]);
                    ato.Funarpen = Convert.ToDecimal(dtSql.Rows[i]["Funarpen"]);
                    ato.Ressag = Convert.ToDecimal(dtSql.Rows[i]["Ressag"]);
                    ato.Mutua = Convert.ToDecimal(dtSql.Rows[i]["Mutua"]);
                    ato.Acoterj = Convert.ToDecimal(dtSql.Rows[i]["Acoterj"]);
                    ato.Distribuidor = Convert.ToDecimal(dtSql.Rows[i]["Distribuidor"]);
                    ato.Iss = Convert.ToDecimal(dtSql.Rows[i]["Iss"]);
                    ato.Total = Convert.ToDecimal(dtSql.Rows[i]["Total"]);

                    _appServicoAtoIss.Add(ato);
                }
                conSql.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}