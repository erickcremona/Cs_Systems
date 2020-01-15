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
    /// Interaction logic for TipoBemEscritura.xaml
    /// </summary>
    public partial class TipoBemEscritura : Window
    {
        DigitarEscritura _digitarEscritura;

        public TipoBemEscritura(DigitarEscritura digitarEscritura)
        {
            _digitarEscritura = digitarEscritura;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnImovel_Click(object sender, RoutedEventArgs e)
        {
            var imovelEscritura = new ImovelEscritura(_digitarEscritura, "I");
            imovelEscritura.Owner = _digitarEscritura;
            this.Close();
            imovelEscritura.ShowDialog();
            
        }

        private void btnMovel_Click(object sender, RoutedEventArgs e)
        {
            var movelOutros = new MovelOutrosEscritura(_digitarEscritura, "M");
            movelOutros.Owner = _digitarEscritura;
            this.Close();
            movelOutros.ShowDialog();
        }

        private void btnOutrosBens_Click(object sender, RoutedEventArgs e)
        {
            var movelOutros = new MovelOutrosEscritura(_digitarEscritura, "O");
            movelOutros.Owner = _digitarEscritura;
            this.Close();
            movelOutros.ShowDialog();
        }
    }
}
