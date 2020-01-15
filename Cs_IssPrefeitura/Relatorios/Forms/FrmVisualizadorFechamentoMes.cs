using Cs_IssPrefeitura.Dominio.Entities;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs_IssPrefeitura.Relatorios.Forms
{
    public partial class FrmVisualizadorFechamentoMes : Form
    {

        Config _config;
        Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss _apuracao;
        string _tipoRelatorio;
        List<ReportParameter> _reportParameter;


        List<AtoIss> _atosSelecionados;

        public FrmVisualizadorFechamentoMes(Config config, Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss apuracao)
        {
            _config = config;
            _apuracao = apuracao;
            _tipoRelatorio = "fechamento";
            InitializeComponent();
        }

        public FrmVisualizadorFechamentoMes(List<ReportParameter> reportParameter, string tipoRelatorio)
        {
            _tipoRelatorio = tipoRelatorio;
            _reportParameter = reportParameter;
            InitializeComponent();
        }

        public FrmVisualizadorFechamentoMes(List<ReportParameter> reportParameter, string tipoRelatorio, List<AtoIss> atosSelecionados)
        {
            _tipoRelatorio = tipoRelatorio;
            _reportParameter = reportParameter;
            _atosSelecionados = atosSelecionados;
            InitializeComponent();
        }
      

        private void FrmVisualizadorFechamentoMes_Load(object sender, EventArgs e)
        {
            // PARAMETROS DO RELATORIO
            List<ReportParameter> reportParameter = new List<ReportParameter>();




            if (_tipoRelatorio == "fechamento")
            {
                
                reportViewer1.LocalReport.ReportEmbeddedResource = "Cs_IssPrefeitura.Relatorios.ReportViewer.FechametoMes.rdlc";

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                // ADICIONANDO OS PARAMETROS PRIMEIRA DA PÁGINA
                reportParameter.Add(new ReportParameter("RazaoSocial", _config.RazaoSocial));
                reportParameter.Add(new ReportParameter("Cnpj", _config.Cnpj));
                reportParameter.Add(new ReportParameter("Livro", string.Format("{0:000}", _apuracao.Livro)));
                reportParameter.Add(new ReportParameter("Folha", string.Format("{0:000}", _apuracao.Folha)));
                reportParameter.Add(new ReportParameter("Periodo", _apuracao.Periodo));
                reportParameter.Add(new ReportParameter("Mes", _apuracao.NomeMes));
                reportParameter.Add(new ReportParameter("Ano", _apuracao.Ano.ToString()));
                reportParameter.Add(new ReportParameter("Recibo", _apuracao.Recibo));
                reportParameter.Add(new ReportParameter("Serie", string.Format("{0:00}", _apuracao.Serie)));
                reportParameter.Add(new ReportParameter("Numero", string.Format("{0:00000}", _apuracao.Numero)));
                reportParameter.Add(new ReportParameter("Faturamento", string.Format("{0:n2}", _apuracao.Faturamento)));
                reportParameter.Add(new ReportParameter("FundosEspeciais", string.Format("{0:n2}", _apuracao.FundosEspeciais)));
                reportParameter.Add(new ReportParameter("BaseCalculo", string.Format("{0:n2}", _apuracao.BaseCalculo)));
                reportParameter.Add(new ReportParameter("Aliquota", string.Format("{0:n2}", _apuracao.Aliquota)));
                reportParameter.Add(new ReportParameter("ValorIssRecolhido", string.Format("{0:n2}", _apuracao.ValorIssRecolhido)));
                reportParameter.Add(new ReportParameter("CMC", _config.Cmc));
                reportParameter.Add(new ReportParameter("CpfTitular", _config.CpfTitular));

                // TODO: This line of code loads data into the 'cs_issprefeituraDataSet.atoiss' table. You can move, or remove it, as needed.
                this.atoissTableAdapter.FillByIdApuracaoIss(this.cs_issprefeituraDataSet.atoiss, _apuracao.ApuracaoIssId);


                reportViewer1.LocalReport.SetParameters(reportParameter);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

                this.reportViewer1.RefreshReport();

            }

            if (_tipoRelatorio == "Consulta" || _tipoRelatorio == "FechamentoPrefeitura")
            {
                if (_tipoRelatorio == "Consulta")
                {
                    this.Text = "Consulta dos Atos Selecionados";

                    reportViewer1.LocalReport.ReportEmbeddedResource = "Cs_IssPrefeitura.Relatorios.ReportViewer.ConsultaAtos.rdlc";
                }
                else
                {
                    this.Text = "Livro de Apuração do ISSQN Notários";                

                    reportViewer1.LocalReport.ReportEmbeddedResource = "Cs_IssPrefeitura.Relatorios.ReportViewer.FechamentoPrefeitura.rdlc";
                }
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                               
                reportViewer1.LocalReport.SetParameters(_reportParameter);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

                this.reportViewer1.RefreshReport();
            }



        }
    }
}
