using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows.Procuracao;
using Cs_Notas.Windows.Testamento;
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

namespace Cs_Notas.Windows.Escritura
{
    /// <summary>
    /// Interaction logic for AlterarItemCustasEscritura.xaml
    /// </summary>
    public partial class AlterarItemCustasEscritura : Window
    {

        DigitarEscritura _escritura;
        ItensCustas item;
        AdicionarItensCustas _adicionar;
        DigitarProcuracao _procuracao;
        DigitarTestamento _testamento;
        string tipoConstrutor = string.Empty;

        public AlterarItemCustasEscritura(DigitarEscritura escritura)
        {
            _escritura = escritura;
            tipoConstrutor = "es";
            InitializeComponent();
        }

        public AlterarItemCustasEscritura(AdicionarItensCustas adicionar)
        {
            _adicionar = adicionar;
            tipoConstrutor = "ad";
            InitializeComponent();
        }

        public AlterarItemCustasEscritura(DigitarProcuracao procuracao)
        {
            _procuracao = procuracao;
            tipoConstrutor = "pr";
            InitializeComponent();
        }

        public AlterarItemCustasEscritura(DigitarTestamento testamento)
        {
            _testamento = testamento;
            tipoConstrutor = "te";
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {


            item.Quantidade = txtQtd.Text;

            item.Valor = Convert.ToDecimal(txtValor.Text);

            item.Total = item.Valor * Convert.ToInt16(item.Quantidade);

            ItensCustas itemAlterar;
            if (tipoConstrutor == "ad")
            {
                if (_escritura != null)
                    itemAlterar = _adicionar._escritura.listaItensCustas.Where(p => p.Tabela == item.Tabela && p.Item == item.Item && p.SubItem == item.SubItem).FirstOrDefault();

                if (_procuracao != null)
                    itemAlterar = _adicionar._procuracao.listaItensCustas.Where(p => p.Tabela == item.Tabela && p.Item == item.Item && p.SubItem == item.SubItem).FirstOrDefault();

                if (_testamento != null)
                    itemAlterar = _adicionar._testamento.listaItensCustas.Where(p => p.Tabela == item.Tabela && p.Item == item.Item && p.SubItem == item.SubItem).FirstOrDefault();
            }
            else
            {
                if (tipoConstrutor == "es")
                    itemAlterar = _escritura.listaItensCustas.Where(p => p.Tabela == item.Tabela && p.Item == item.Item && p.SubItem == item.SubItem).FirstOrDefault();
                if (tipoConstrutor == "pr")
                    itemAlterar = _procuracao.listaItensCustas.Where(p => p.Tabela == item.Tabela && p.Item == item.Item && p.SubItem == item.SubItem).FirstOrDefault();
                if (tipoConstrutor == "te")
                    itemAlterar = _testamento.listaItensCustas.Where(p => p.Tabela == item.Tabela && p.Item == item.Item && p.SubItem == item.SubItem).FirstOrDefault();
            }

            itemAlterar = item;



            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (tipoConstrutor == "es")
                item = (ItensCustas)_escritura.dataGridCustas.SelectedItem;

            if (tipoConstrutor == "ad")
                item = (ItensCustas)_adicionar.dataGridCustas.SelectedItem;

            if (tipoConstrutor == "pr")
                item = (ItensCustas)_procuracao.dataGridCustas.SelectedItem;

            if (tipoConstrutor == "te")
                item = (ItensCustas)_testamento.dataGridCustas.SelectedItem;

            lblDescricao.Content = item.Descricao;
            txtQtd.Text = item.Quantidade;
            txtValor.Text = string.Format("{0:n2}", item.Valor);
            txtQtd.Focus();

        }

        private void txtQtd_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtValor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtValor.Text.Contains(",") || txtValor.SelectionLength == txtValor.Text.Length)
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValor.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValor.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void PassarDeUmCoponenteParaOutro(object sender, KeyEventArgs e)
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



        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void DigitarSemNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }


        private void DigitarSomenteNumerosEmReaisComVirgual(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
        }

        private void txtQtd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtQtd.Text == "" || txtQtd.Text == "0")
            {
                txtQtd.Text = "1";
            }
        }

        private void txtValor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValor.Text == "")
                txtValor.Text = "0,00";
            else
                txtValor.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValor.Text));

        }

        private void txtQtd_GotFocus(object sender, RoutedEventArgs e)
        {
            txtQtd.SelectAll();
        }

        private void txtValor_GotFocus(object sender, RoutedEventArgs e)
        {
            txtValor.SelectAll();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
    }
}
