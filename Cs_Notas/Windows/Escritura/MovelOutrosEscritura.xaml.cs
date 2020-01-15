using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
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
    /// Interaction logic for MovelOutrosEscritura.xaml
    /// </summary>
    public partial class MovelOutrosEscritura : Window
    {
        DigitarEscritura _digitarEscritura;
        Imovel imovel;
        string _tipoBem;
        int ordemImovel;
        public string estado;

        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();

        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();


        public MovelOutrosEscritura(DigitarEscritura digitarEscritura, string tipoBem)
        {
            _digitarEscritura = digitarEscritura;
            _tipoBem = tipoBem;
            estado = _digitarEscritura.estado;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (_digitarEscritura.estado == "adicionando imovel")
            {
                imovel = new Imovel();
                
            }
            else
            {
                ordemImovel = _digitarEscritura.listaImoveis[_digitarEscritura.dataGridImovel.SelectedIndex].Ordem;
                imovel = _digitarEscritura.listaImoveis.Where(p => p.ImovelId == ((Imovel)_digitarEscritura.dataGridImovel.SelectedItem).ImovelId).FirstOrDefault();
                 CarregarImovel();
            }

          

            if (_digitarEscritura.estado == "adicionando imovel")
            {
                this.Title = string.Format("Incluindo Novo Bem Nº {0}", ordemImovel);
            }
            else
            {
                this.Title = string.Format("Alterando Bem Nº {0}", ordemImovel);
            }

            dataGridAtoConjunto.ItemsSource = _digitarEscritura.listaAtos;
            
            CarregarBensConjuntosNaLista();

            txtValorBemImovel.Focus();
        }

        private void CarregarImovel()
        {
            txtValorBemImovel.Text = string.Format("{0:n2}", imovel.Valor);

            txtObjeto.Text = imovel.Objeto;
        }


        private void CarregarBensConjuntosNaLista()
        {
            var bensConjuntos = _digitarEscritura.listaBensAtosConjuntos.Where(p => p.IdImovel == imovel.ImovelId).ToList();


            foreach (var item in _digitarEscritura.listaAtos)
            {
                item.IsChecked = false;

                if (imovel.Principal == "S")
                    _digitarEscritura.listaAtos[0].IsChecked = true;

                if (_digitarEscritura.estado == "alterando imovel")
                    for (int i = 0; i < bensConjuntos.Count; i++)
                    {
                        if (item.ConjuntoId == bensConjuntos[i].IdAtoConjunto)
                            item.IsChecked = true;
                    }
                else
                    item.IsChecked = true;
            }
        }

        private void dataGridAtoConjunto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var quant = 0;
            foreach (var item in _digitarEscritura.listaAtos)
            {
                if (item.IsChecked == true)
                {
                    quant++;
                }
            }

            if (((AtoConjuntos)dataGridAtoConjunto.SelectedItem).IsChecked == true && quant > 1)
            {
                _digitarEscritura.listaAtos[dataGridAtoConjunto.SelectedIndex].IsChecked = false;
            }
            else
            {
                _digitarEscritura.listaAtos[dataGridAtoConjunto.SelectedIndex].IsChecked = true;
            }

            dataGridAtoConjunto.Items.Refresh();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarImovel();

            SalvarBensConjuntosNaLista();

            _digitarEscritura.dataGridImovel.Items.Refresh();

            if (imovel != null)
            {
                _digitarEscritura.dataGridImovel.ItemsSource = null;
                _digitarEscritura.dataGridImovel.ItemsSource = _digitarEscritura.listaImoveis;

                _digitarEscritura.dataGridImovel.SelectedItem = imovel;
                _digitarEscritura.dataGridImovel.ScrollIntoView(imovel);
                _digitarEscritura.dataGridImovel.Items.Refresh();
            }

            this.Close();
        }

        private void SalvarBensConjuntosNaLista()
        {
            var bensConjuntos = new BensAtosConjuntos();

            if (_digitarEscritura.estado == "alterando imovel")
            {
                var listaBensConjuntos = _digitarEscritura.listaBensAtosConjuntos.Where(p => p.IdImovel == imovel.ImovelId).ToList();

                foreach (var item in listaBensConjuntos)
                {
                    if (item.IdAtoConjunto != 0)
                    {
                        var excluirBanco = _AppServicoBensAtosConjuntos.GetById(item.BensAtosConjuntosID);
                        _AppServicoBensAtosConjuntos.Remove(excluirBanco);
                    }
                    _digitarEscritura.listaBensAtosConjuntos.Remove(item);
                }
            }


            for (int i = 0; i < _digitarEscritura.listaAtos.Count; i++)
            {

                if (_digitarEscritura.listaAtos[i].IsChecked == true)
                {
                    bensConjuntos = new BensAtosConjuntos();

                    bensConjuntos.IdEscritura = _digitarEscritura.listaAtos[i].IdEscritura;
                    bensConjuntos.IdImovel = imovel.ImovelId;
                    bensConjuntos.IdAtoConjunto = _digitarEscritura.listaAtos[i].ConjuntoId;
                    if (i > 0)
                        _AppServicoBensAtosConjuntos.Add(bensConjuntos);
                    _digitarEscritura.listaBensAtosConjuntos.Add(bensConjuntos);

                }
            }
        }



        private void SalvarImovel()
        {
            
            imovel.Ordem = ordemImovel;

            imovel.IdEscritura = _digitarEscritura._escrituras.EscriturasId;
           
            imovel.TipoRecolhimento = "N";
                                
            imovel.Endereco = txtObjeto.Text.Trim();

            imovel.Objeto = imovel.Endereco;
                        
            if (txtValorBemImovel.Text.Length > 0)
                imovel.Valor = Convert.ToDecimal(txtValorBemImovel.Text);

            imovel.TipoTransacao = "39";

            imovel.DataAlienacao = _digitarEscritura._escrituras.DataAtoRegistro;

            imovel.FormaAlienacao = "5";

            imovel.TipoImovelDoi = "89";

            imovel.Construcao = "2";

            imovel.AreaNaoConsta = "1";
            
            imovel.TipoBem = _tipoBem;

            if (_digitarEscritura.listaAtos[0].IsChecked == true)
                imovel.Principal = "S";
            else
                imovel.Principal = "N";


            if (_digitarEscritura.estado == "adicionando imovel")
            {

                _AppServicoImovel.Add(imovel);

                _digitarEscritura.listaImoveis.Add(imovel);
            }
            else
            {
                var imovelAlterar = (Imovel)_digitarEscritura.dataGridImovel.SelectedItem;
                imovelAlterar = imovel;

                _AppServicoImovel.Update(imovel);
            }
        }


        private void MenuItemDesmarcarTodos_Click(object sender, RoutedEventArgs e)
        {
            DesmarcarTodosCheckes();
        }

        private void MenuItemMarcarTodos_Click(object sender, RoutedEventArgs e)
        {
            MarcarTodosCheckes();
        }

        private void DesmarcarTodosCheckes()
        {
            try
            {
                foreach (var item in _digitarEscritura.listaAtos)
                {
                    item.IsChecked = false;

                }

                _digitarEscritura.listaAtos[0].IsChecked = true;
                dataGridAtoConjunto.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MarcarTodosCheckes()
        {
            try
            {
                foreach (var item in _digitarEscritura.listaAtos)
                {
                    item.IsChecked = true;
                    dataGridAtoConjunto.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void DigitarSomenteLetras(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key >= 44 && key <= 69);
        }

        private void txtValorBemImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (txtValorBemImovel.SelectionLength == txtValorBemImovel.Text.Length)
            {
                txtValorBemImovel.Text = "";
            }

            if (!txtValorBemImovel.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorBemImovel.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorBemImovel.Text.Length)
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

        private void txtValorBemImovel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorBemImovel.Text != "" && txtValorBemImovel.Text != ",")
                txtValorBemImovel.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorBemImovel.Text));
            else
                txtValorBemImovel.Text = "0,00";

            if (txtValorBemImovel.Text.Length > 0)
                imovel.Valor = Convert.ToDecimal(txtValorBemImovel.Text);
        }

        private void txtValorBemImovel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorBemImovel.Text == "0,00")
                txtValorBemImovel.Text = "";
        }

        private void txtObjeto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dataGridAtoConjunto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        
    }
}
