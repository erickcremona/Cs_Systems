using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Windows.Procuracao;
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
    /// Interaction logic for ConsultaServentias.xaml
    /// </summary>
    public partial class ConsultaServentias : Window
    {
        DigitarAtoConjunto _digitarAtoConjunto;
        ImovelEscritura _imovelEscritura;
        OrigemEscritura _origemEscritura;
        AtosConjuntosProcuracao _atosConjuntosProcuracao;
        DigitarProcuracao _digitarProcuracao;

        public ConsultaServentias(DigitarAtoConjunto digitarAtoConjunto)
        {
            _digitarAtoConjunto = digitarAtoConjunto;
            InitializeComponent();
        }

        public ConsultaServentias(ImovelEscritura imovelEscritura)
        {
            _imovelEscritura = imovelEscritura;
            InitializeComponent();
        }

        public ConsultaServentias(OrigemEscritura origemEscritura)
        {
            _origemEscritura = origemEscritura;
            InitializeComponent();
        }

        public ConsultaServentias(AtosConjuntosProcuracao atosConjuntosProcuracao)
        {
            _atosConjuntosProcuracao = atosConjuntosProcuracao;
            InitializeComponent();
        }

        public ConsultaServentias(DigitarProcuracao digitarProcuracao)
        {
            _digitarProcuracao = digitarProcuracao;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_digitarAtoConjunto != null)
            {
                dataGridServentias.ItemsSource = _digitarAtoConjunto.serventiasOutras;

                if (_digitarAtoConjunto.serventiasOutrasSelecionada != null)
                {
                    dataGridServentias.SelectedItem = _digitarAtoConjunto.serventiasOutrasSelecionada;
                    dataGridServentias.ScrollIntoView(_digitarAtoConjunto.serventiasOutrasSelecionada);
                }
                else
                {
                    dataGridServentias.SelectedIndex = 0;
                }
            }

            if (_imovelEscritura != null)
            {
                dataGridServentias.ItemsSource = _imovelEscritura.serventiasOutras;

                if (_imovelEscritura.serventiasOutrasSelecionada != null)
                {
                    dataGridServentias.SelectedItem = _imovelEscritura.serventiasOutrasSelecionada;
                    dataGridServentias.ScrollIntoView(_imovelEscritura.serventiasOutrasSelecionada);
                }
                else
                {
                    dataGridServentias.SelectedIndex = 0;
                }
            }

            if (_origemEscritura != null)
            {
                dataGridServentias.ItemsSource = _origemEscritura.serventias;

                if (_origemEscritura.serventiasOutrasSelecionada != null)
                {
                    dataGridServentias.SelectedItem = _origemEscritura.serventiasOutrasSelecionada;
                    dataGridServentias.ScrollIntoView(_origemEscritura.serventiasOutrasSelecionada);
                }
                else
                {
                    dataGridServentias.SelectedIndex = 0;
                }
            }

            if (_atosConjuntosProcuracao != null)
            {
                dataGridServentias.ItemsSource = _atosConjuntosProcuracao.serventiasOutras;

                if (_atosConjuntosProcuracao.serventiasOutrasSelecionada != null)
                {
                    dataGridServentias.SelectedItem = _atosConjuntosProcuracao.serventiasOutrasSelecionada;
                    dataGridServentias.ScrollIntoView(_atosConjuntosProcuracao.serventiasOutrasSelecionada);
                }
                else
                {
                    dataGridServentias.SelectedIndex = 0;
                }
            }

            if (_digitarProcuracao != null)
            {
                dataGridServentias.ItemsSource = _digitarProcuracao.serventiasOutras;

                if (_digitarProcuracao.serventiasOutrasSelecionada != null)
                {
                    dataGridServentias.SelectedItem = _digitarProcuracao.serventiasOutrasSelecionada;
                    dataGridServentias.ScrollIntoView(_digitarProcuracao.serventiasOutrasSelecionada);
                }
                else
                {
                    dataGridServentias.SelectedIndex = 0;
                }
            }
        }

        private void dataGridServentias_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_digitarAtoConjunto != null)
            {
                _digitarAtoConjunto.serventiasOutrasSelecionada = (ServentiasOutras)dataGridServentias.SelectedItem;
            }

            if (_imovelEscritura != null)
            {
                _imovelEscritura.serventiasOutrasSelecionada = (ServentiasOutras)dataGridServentias.SelectedItem;
            }

            if (_origemEscritura != null)
            {
                _origemEscritura.serventiasOutrasSelecionada = (ServentiasOutras)dataGridServentias.SelectedItem;
            }

            if (_atosConjuntosProcuracao != null)
            {
                _atosConjuntosProcuracao.serventiasOutrasSelecionada = (ServentiasOutras)dataGridServentias.SelectedItem;
            }

            if (_digitarProcuracao != null)
            {
                _digitarProcuracao.serventiasOutrasSelecionada = (ServentiasOutras)dataGridServentias.SelectedItem;
            }

            this.Close();

        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtConsultaServentia_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
            if (_digitarAtoConjunto != null)
            {
                var serventias = _digitarAtoConjunto.serventiasOutras.Where(p => p.Descricao.Contains(txtConsultaServentia.Text)).ToList();

                dataGridServentias.ItemsSource = serventias;
                dataGridServentias.Items.Refresh();

            }

            if (_imovelEscritura != null)
            {
                var serventias = _imovelEscritura.serventiasOutras.Where(p => p.Descricao.Contains(txtConsultaServentia.Text)).ToList();

                dataGridServentias.ItemsSource = serventias;
                dataGridServentias.Items.Refresh();
            }

            if (_origemEscritura != null)
            {
                var serventias = _origemEscritura.serventias.Where(p => p.Descricao.Contains(txtConsultaServentia.Text)).ToList();

                dataGridServentias.ItemsSource = serventias;
                dataGridServentias.Items.Refresh();
            }

            if (_atosConjuntosProcuracao != null)
            {
                var serventias = _atosConjuntosProcuracao.serventiasOutras.Where(p => p.Descricao.Contains(txtConsultaServentia.Text)).ToList();

                dataGridServentias.ItemsSource = serventias;
                dataGridServentias.Items.Refresh();
            }

            if (_digitarProcuracao != null)
            {
                var serventias = _digitarProcuracao.serventiasOutras.Where(p => p.Descricao.Contains(txtConsultaServentia.Text)).ToList();

                dataGridServentias.ItemsSource = serventias;
                dataGridServentias.Items.Refresh();
            }
        }


    }
}
