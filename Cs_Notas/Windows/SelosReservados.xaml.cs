using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows.Escritura;
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

namespace Cs_Notas.Windows
{
    /// <summary>
    /// Interaction logic for SelosReservados.xaml
    /// </summary>
    public partial class SelosReservados : Window
    {
        Cs_Notas.Dominio.Entities.Usuario _usuario;
        string _tipoAto;
        List<Selos> selosReservados = new List<Selos>();
        Principal _principal;

        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        public SelosReservados(Cs_Notas.Dominio.Entities.Usuario usuario, string tipoAto, Principal principal)
        {
            _usuario = usuario;
            _tipoAto = tipoAto;
            _principal = principal;
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTexto.Content = "SELOS RESERVADOS DE " + _tipoAto;
            CarregarDataGridSelosReservados();

        }

        private void dataGridSelosReservados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridSelosReservados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            List<Selos> selos = selosReservados.Where(p => p.idReferencia == ((Selos)dataGridSelosReservados.SelectedItem).idReferencia).OrderBy(p => p.Numero).ToList();

            switch (_tipoAto)
            {
                case "ESCRITURA":
                    var digitarEscritura = new IniciarPrimeiraDigitacaoEscritura(selos, _usuario, _principal);
                    this.Close();
                    digitarEscritura.Owner = _principal;
                    digitarEscritura.ShowDialog();
                    break;

                case "PROCURAÇÃO":
                    var digitarProcuracao = new IniciarPrimeiraDigitacaoProcuracao(selos, _usuario, _principal);
                    this.Close();
                    digitarProcuracao.Owner = _principal;
                    digitarProcuracao.ShowDialog();
                    break;

                case "TESTAMENTO":
                    Selos selo = (Selos)dataGridSelosReservados.SelectedItem;
                    var digitarTestamento = new DigitarTestamento(selo, _usuario, _principal);
                    this.Close();
                    digitarTestamento.Owner = _principal;
                    digitarTestamento.ShowDialog();
                    break;
            }
        }

        private void CarregarDataGridSelosReservados()
        {

            selosReservados = _AppServicoSelos.ConsultarPorSelosReservados(_tipoAto).OrderBy(p => p.DataReservado).OrderBy(p => p.UsuarioReservado).ToList();

            dataGridSelosReservados.ItemsSource = selosReservados;
        }

        private void cmbUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CarregarDataGridSelosReservados();
        }
    }
}
