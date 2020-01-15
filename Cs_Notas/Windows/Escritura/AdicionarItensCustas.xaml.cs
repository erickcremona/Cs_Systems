using Cs_Gerencial.Dominio.Entities;
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
    /// Interaction logic for AdicionarItensCustas.xaml
    /// </summary>
    public partial class AdicionarItensCustas : Window
    {
        public DigitarEscritura _escritura;
        public DigitarProcuracao _procuracao;
        public DigitarTestamento _testamento;
        string construtor = "";

        public AdicionarItensCustas(DigitarEscritura escritura)
        {
            _escritura = escritura;
            construtor = "escritura";
            InitializeComponent();
        }

        public AdicionarItensCustas(DigitarProcuracao procuracao)
        {
            _procuracao = procuracao;
            construtor = "procuracao";
            InitializeComponent();
        }

        public AdicionarItensCustas(DigitarTestamento testamento)
        {
            _testamento = testamento;
            construtor = "testamento";
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (construtor == "escritura")
            {
                dataGridTabelaCustas.ItemsSource = _escritura.listaTabelaCustas.Where(p => p.Tabela == "22" || p.Tabela == "16").OrderBy(p => p.Tabela);
                dataGridCustas.ItemsSource = _escritura.listaItensCustas;

                cmbAnoCustas.Text = _escritura.Ano.ToString();
            }

            if (construtor == "procuracao")
            {
                dataGridTabelaCustas.ItemsSource = _procuracao.listaTabelaCustas.Where(p => p.Tabela == "22" || p.Tabela == "16").OrderBy(p => p.Tabela);
                dataGridCustas.ItemsSource = _procuracao.listaItensCustas;

                cmbAnoCustas.Text = _procuracao.Ano.ToString();
            }

            if (construtor == "testamento")
            {
                dataGridTabelaCustas.ItemsSource = _testamento.listaTabelaCustas.Where(p => p.Tabela == "22" || p.Tabela == "16").OrderBy(p => p.Tabela);
                dataGridCustas.ItemsSource = _testamento.listaItensCustas;

                cmbAnoCustas.Text = _testamento.Ano.ToString();
            }

            if (dataGridTabelaCustas.Items.Count > 0)
                dataGridTabelaCustas.SelectedIndex = 0;

            if (dataGridCustas.Items.Count > 0)
                dataGridCustas.SelectedIndex = 0;

            txtTabela.Focus();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void dataGridTabelaCustas_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridTabelaCustas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridTabelaCustas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AdicionarItensTabelaCustas();

        }

        private void AdicionarItensTabelaCustas()
        {
            var tabelaCustas = (TabelaCustas)dataGridTabelaCustas.SelectedItem;

            
            var itemCustas = new ItensCustas();
            itemCustas.Descricao = tabelaCustas.Descricao;
            itemCustas.Tabela = tabelaCustas.Tabela;
            itemCustas.Item = tabelaCustas.Item;
            itemCustas.SubItem = tabelaCustas.SubItem;
            itemCustas.Quantidade = "1";
            itemCustas.Valor = tabelaCustas.Valor;

            try
            {
                itemCustas.Total = Convert.ToInt16(itemCustas.Quantidade) * itemCustas.Valor;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if (construtor == "escritura")
            {
                var contem = _escritura.listaItensCustas.Where(p => p.Tabela == itemCustas.Tabela && p.Item == itemCustas.Item && p.SubItem == itemCustas.SubItem).FirstOrDefault();

                if (contem == null)
                    _escritura.listaItensCustas.Add(itemCustas);
                else
                {
                    contem.Quantidade = string.Format("{0}", Convert.ToInt16(contem.Quantidade) + 1);
                    contem.Descricao = tabelaCustas.Descricao;
                    contem.Tabela = tabelaCustas.Tabela;
                    contem.Item = tabelaCustas.Item;
                    contem.SubItem = tabelaCustas.SubItem;
                    contem.Valor = tabelaCustas.Valor;
                    contem.Total = Convert.ToInt16(contem.Quantidade) * itemCustas.Valor;
                }

                _escritura.dataGridCustas.Items.Refresh();
                dataGridCustas.Items.Refresh();


                _escritura.CalcularEmolumentos();
                _escritura.CalcularMutuaAcoterj();
                _escritura.CalcularBotaoTotal();

                dataGridCustas.Items.Refresh();
                _escritura.dataGridCustas.Items.Refresh();
            }

            if (construtor == "procuracao")
            {
                var contem = _procuracao.listaItensCustas.Where(p => p.Tabela == itemCustas.Tabela && p.Item == itemCustas.Item && p.SubItem == itemCustas.SubItem).FirstOrDefault();

                if (contem == null)
                    _procuracao.listaItensCustas.Add(itemCustas);
                else
                {
                    contem.Quantidade = string.Format("{0}", Convert.ToInt16(contem.Quantidade) + 1);
                    contem.Descricao = tabelaCustas.Descricao;
                    contem.Tabela = tabelaCustas.Tabela;
                    contem.Item = tabelaCustas.Item;
                    contem.SubItem = tabelaCustas.SubItem;
                    contem.Valor = tabelaCustas.Valor;
                    contem.Total = Convert.ToInt16(contem.Quantidade) * itemCustas.Valor;
                }

                _procuracao.dataGridCustas.Items.Refresh();
                dataGridCustas.Items.Refresh();


                _procuracao.CalcularEmolumentos();
                _procuracao.CalcularMutuaAcoterj();
                _procuracao.CalcularBotaoTotal();

                dataGridCustas.Items.Refresh();
                _procuracao.dataGridCustas.Items.Refresh();
            }

            if (construtor == "testamento")
            {
                var contem = _testamento.listaItensCustas.Where(p => p.Tabela == itemCustas.Tabela && p.Item == itemCustas.Item && p.SubItem == itemCustas.SubItem).FirstOrDefault();

                if (contem == null)
                    _testamento.listaItensCustas.Add(itemCustas);
                else
                {
                    contem.Quantidade = string.Format("{0}", Convert.ToInt16(contem.Quantidade) + 1);
                    contem.Descricao = tabelaCustas.Descricao;
                    contem.Tabela = tabelaCustas.Tabela;
                    contem.Item = tabelaCustas.Item;
                    contem.SubItem = tabelaCustas.SubItem;
                    contem.Valor = tabelaCustas.Valor;
                    contem.Total = Convert.ToInt16(contem.Quantidade) * itemCustas.Valor;
                }

                _testamento.dataGridCustas.Items.Refresh();
                dataGridCustas.Items.Refresh();


                _testamento.CalcularEmolumentos();
                _testamento.CalcularMutuaAcoterj();
                _testamento.CalcularBotaoTotal();

                dataGridCustas.Items.Refresh();
                _testamento.dataGridCustas.Items.Refresh();
            }
        }

        private void dataGridCustas_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (construtor == "escritura")
            {
                if (e.Key == Key.Delete)
                {

                    var itemExcluir = (ItensCustas)dataGridCustas.SelectedItem;

                    if (itemExcluir.Tabela == "22")
                    {
                        var emolumentos = _escritura.listaItensCustas.Where(p => p.Tabela == "22").ToList();
                        if (emolumentos.Count < 2)
                            return;
                    }



                    _escritura.listaItensCustas.Remove(itemExcluir);

                    _escritura.dataGridCustas.Items.Refresh();
                    dataGridCustas.Items.Refresh();


                    _escritura.CalcularEmolumentos();
                    _escritura.CalcularMutuaAcoterj();
                    _escritura.CalcularBotaoTotal();

                    dataGridCustas.Items.Refresh();
                    _escritura.dataGridCustas.Items.Refresh();
                }
            }

            if (construtor == "procuracao")
            {
                if (e.Key == Key.Delete)
                {

                    var itemExcluir = (ItensCustas)dataGridCustas.SelectedItem;

                    if (itemExcluir.Tabela == "22")
                    {
                        var emolumentos = _procuracao.listaItensCustas.Where(p => p.Tabela == "22").ToList();
                        if (emolumentos.Count < 2)
                            return;
                    }



                    _procuracao.listaItensCustas.Remove(itemExcluir);

                    _procuracao.dataGridCustas.Items.Refresh();
                    dataGridCustas.Items.Refresh();


                    _procuracao.CalcularEmolumentos();
                    _procuracao.CalcularMutuaAcoterj();
                    _procuracao.CalcularBotaoTotal();

                    dataGridCustas.Items.Refresh();
                    _procuracao.dataGridCustas.Items.Refresh();
                }
            }

            if (construtor == "testamento")
            {
                if (e.Key == Key.Delete)
                {

                    var itemExcluir = (ItensCustas)dataGridCustas.SelectedItem;

                    if (itemExcluir.Tabela == "22")
                    {
                        var emolumentos = _testamento.listaItensCustas.Where(p => p.Tabela == "22").ToList();
                        if (emolumentos.Count < 2)
                            return;
                    }



                    _testamento.listaItensCustas.Remove(itemExcluir);

                    _testamento.dataGridCustas.Items.Refresh();
                    dataGridCustas.Items.Refresh();


                    _testamento.CalcularEmolumentos();
                    _testamento.CalcularMutuaAcoterj();
                    _testamento.CalcularBotaoTotal();

                    dataGridCustas.Items.Refresh();
                    _testamento.dataGridCustas.Items.Refresh();
                }
            }
        }

        private void dataGridCustas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridCustas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (construtor == "escritura")
            {
                var alterarCustas = new AlterarItemCustasEscritura(this);
                alterarCustas.Owner = this;
                alterarCustas.ShowDialog();

                _escritura.CalcularEmolumentos();
                _escritura.CalcularMutuaAcoterj();
                _escritura.CalcularBotaoTotal();

                dataGridCustas.Items.Refresh();
                _escritura.dataGridCustas.Items.Refresh();
            }

            if (construtor == "procuracao")
            {
                var alterarCustas = new AlterarItemCustasEscritura(this);
                alterarCustas.Owner = this;
                alterarCustas.ShowDialog();

                _procuracao.CalcularEmolumentos();
                _procuracao.CalcularMutuaAcoterj();
                _procuracao.CalcularBotaoTotal();

                dataGridCustas.Items.Refresh();
                _procuracao.dataGridCustas.Items.Refresh();
            }

            if (construtor == "testamento")
            {
                var alterarCustas = new AlterarItemCustasEscritura(this);
                alterarCustas.Owner = this;
                alterarCustas.ShowDialog();

                _testamento.CalcularEmolumentos();
                _testamento.CalcularMutuaAcoterj();
                _testamento.CalcularBotaoTotal();

                dataGridCustas.Items.Refresh();
                _testamento.dataGridCustas.Items.Refresh();
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtTabela_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (construtor == "escritura")
            {
                txtItem.Text = "";
                txtSubitem.Text = "";

                var tabela = _escritura.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text).FirstOrDefault();

                if (tabela != null)
                {
                    dataGridTabelaCustas.SelectedItem = tabela;
                    dataGridTabelaCustas.ScrollIntoView(tabela);
                }
            }

            if (construtor == "procuracao")
            {
                txtItem.Text = "";
                txtSubitem.Text = "";

                var tabela = _procuracao.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text).FirstOrDefault();

                if (tabela != null)
                {
                    dataGridTabelaCustas.SelectedItem = tabela;
                    dataGridTabelaCustas.ScrollIntoView(tabela);
                }
            }

            if (construtor == "testamento")
            {
                txtItem.Text = "";
                txtSubitem.Text = "";

                var tabela = _testamento.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text).FirstOrDefault();

                if (tabela != null)
                {
                    dataGridTabelaCustas.SelectedItem = tabela;
                    dataGridTabelaCustas.ScrollIntoView(tabela);
                }
            }
        }


        private void txtItem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (construtor == "escritura")
            {
                txtSubitem.Text = "";

                var item = _escritura.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text && p.Item == txtItem.Text).FirstOrDefault();

                if (item != null)
                {
                    dataGridTabelaCustas.SelectedItem = item;
                    dataGridTabelaCustas.ScrollIntoView(item);
                }
            }

            if (construtor == "procuracao")
            {
                txtSubitem.Text = "";

                var item = _procuracao.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text && p.Item == txtItem.Text).FirstOrDefault();

                if (item != null)
                {
                    dataGridTabelaCustas.SelectedItem = item;
                    dataGridTabelaCustas.ScrollIntoView(item);
                }
            }

            if (construtor == "testamento")
            {
                txtSubitem.Text = "";

                var item = _testamento.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text && p.Item == txtItem.Text).FirstOrDefault();

                if (item != null)
                {
                    dataGridTabelaCustas.SelectedItem = item;
                    dataGridTabelaCustas.ScrollIntoView(item);
                }
            }

        }

        private void txtSubitem_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (construtor == "escritura")
            {
                var subitem = _escritura.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text && p.Item == txtItem.Text && p.SubItem == txtSubitem.Text).FirstOrDefault();

                if (subitem != null)
                {
                    dataGridTabelaCustas.SelectedItem = subitem;
                    dataGridTabelaCustas.ScrollIntoView(subitem);
                }
            }

            if (construtor == "procuracao")
            {
                var subitem = _procuracao.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text && p.Item == txtItem.Text && p.SubItem == txtSubitem.Text).FirstOrDefault();

                if (subitem != null)
                {
                    dataGridTabelaCustas.SelectedItem = subitem;
                    dataGridTabelaCustas.ScrollIntoView(subitem);
                }
            }

            if (construtor == "testamento")
            {
                var subitem = _testamento.listaTabelaCustas.Where(p => p.Tabela == txtTabela.Text && p.Item == txtItem.Text && p.SubItem == txtSubitem.Text).FirstOrDefault();

                if (subitem != null)
                {
                    dataGridTabelaCustas.SelectedItem = subitem;
                    dataGridTabelaCustas.ScrollIntoView(subitem);
                }
            }
        }

        private void txtTabela_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtItem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtSubitem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
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


    }
}
