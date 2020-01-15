using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Relatorios.Forms;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica interna para LivroFolhaIss.xaml
    /// </summary>
    public partial class LivroFolhaIss : Window
    {
        List<ReportParameter> _reportParameter;
        ConsultaAtosIss _consultaAtos;
        

        public LivroFolhaIss(List<ReportParameter> reportParameter, ConsultaAtosIss consultaAtos)
        {
            _reportParameter = reportParameter;
            _consultaAtos = consultaAtos;

            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            
            _reportParameter.Add(new ReportParameter("Livro", txtLivro.Text));
            _reportParameter.Add(new ReportParameter("Folha", txtFolha.Text));
            this.Close();
            var relatorio = new FrmVisualizadorFechamentoMes(_reportParameter, "FechamentoPrefeitura", _consultaAtos.atosConsultados);
            relatorio.ShowDialog();
            
            relatorio.Close();
            
        }

        private void txtLivro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void txtFolha_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void txtLivro_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLivro.Text == "0")
                txtLivro.Text = "";
        }

        private void txtLivro_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLivro.Text == "")
                txtLivro.Text = "0";
        }

        private void txtFolha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFolha.Text == "0")
                txtFolha.Text = "";
        }

        private void txtFolha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFolha.Text == "")
                txtFolha.Text = "0";
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtLivro.Text = "0";
            txtFolha.Text = "0";
        }

      
    }
}
