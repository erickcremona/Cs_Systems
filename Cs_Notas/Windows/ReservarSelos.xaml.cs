using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
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
    /// Interaction logic for ReservarSelos.xaml
    /// </summary>
    public partial class ReservarSelos : Window
    {

        Cs_Notas.Dominio.Entities.Usuario _usuario;

        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoLogSistema>();

        public ReservarSelos(Cs_Notas.Dominio.Entities.Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int idSeloAtual = _AppServicoConfiguracoes.GetById(1).SerieAtual;

            int qtdSelosLivres = _AppServicoSelos.ConsultarPorIdSerie(idSeloAtual).Where(p => p.Status == "LIVRE").Count();
            

            if (qtdSelosLivres == 0)
            {
                MessageBox.Show("Selecione uma série de Selos Disponíveis.", "Informação", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }



            datePickerDataReserva.SelectedDate = DateTime.Now.Date;
            txtQtd.Text = "1";
            cmbNatureza.Focus();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
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
                       

        private void txtQtd_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3);
        }

        private void txtFlsInicio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtFlsFim_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }
               
        private void txtQtd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtQtd.Text == "1")
                txtQtd.Text = "";
            else
                txtQtd.SelectAll();
        }

        private void txtQtd_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt16(txtQtd.Text) == 0)
                    txtQtd.Text = "1";
            }
            catch (Exception)
            {
                txtQtd.Text = "1";
            }
        }

        private void txtLivro_GotFocus(object sender, RoutedEventArgs e)
        {
            txtLivro.SelectAll();
        }

        private void txtFlsInicio_GotFocus(object sender, RoutedEventArgs e)
        {
            txtFlsInicio.SelectAll();
        }

        private void txtFlsFim_GotFocus(object sender, RoutedEventArgs e)
        {
            txtFlsFim.SelectAll();
        }

        private void txtAto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtAto_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAto.SelectAll();
        }

        private void txtFlsInicio_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt16(txtFlsInicio.Text);                    
            }
            catch (Exception)
            {
                txtFlsInicio.Text = "";
            }
        }

        private void txtFlsFim_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt16(txtFlsInicio.Text);
            }
            catch (Exception)
            {
                txtFlsInicio.Text = "";
            }
        }

        private void txtAto_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt16(txtAto.Text);
            }
            catch (Exception)
            {
                txtAto.Text = "";
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            ProcConfirmarReserva();
        }

        private void ProcConfirmarReserva()
        {
            try
            {

                if (datePickerDataReserva.SelectedDate == null)
                {
                    MessageBox.Show("Preencha o campo Data.", "Data", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    datePickerDataReserva.Focus();
                    return;
                }

                if (txtLivro.Text == "")
                {
                    MessageBox.Show("Preencha o campo Livro.", "Livro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtLivro.Focus();
                    return;
                }

                if (txtFlsInicio.Text == "")
                {
                    MessageBox.Show("Preencha o campo Fls Início.", "Fls Início", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtFlsInicio.Focus();
                    return;
                }

                if (txtFlsFim.Text == "")
                {
                    MessageBox.Show("Preencha o campo Fls Fim.", "Fls Fim", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtFlsFim.Focus();
                    return;
                }

                if (txtAto.Text == "")
                {
                    MessageBox.Show("Preencha o campo Ato.", "Ato", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtAto.Focus();
                    return;
                }

                if (Convert.ToInt16(txtQtd.Text) > 9)
                {
                    MessageBox.Show("É permitido reservar no máximo 9 selos por vez.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    txtQtd.Focus();
                    return;
                }

                int idSeloAtual = _AppServicoConfiguracoes.GetById(1).SerieAtual;

                int qtdSelosLivres = _AppServicoSelos.ConsultarPorIdSerie(idSeloAtual).Where(p => p.Status == "LIVRE").Count();
                      
                int quantidade = Convert.ToInt16(txtQtd.Text);

                if (quantidade > qtdSelosLivres)
                {
                    MessageBox.Show("Quantidade de selo(s) livre(s) " + qtdSelosLivres + " é menor que a quantidade que foi reservado.", "Informação", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }

                string natureza = cmbNatureza.Text;

                DateTime dataReserva = datePickerDataReserva.SelectedDate.Value;

                int folhaInicio = Convert.ToInt16(txtFlsInicio.Text);

                int folhaFim = Convert.ToInt16(txtFlsFim.Text);

                int ato = Convert.ToInt16(txtAto.Text);

                List<Selos> selosReservar = _AppServicoSelos.ReservarSelos(idSeloAtual, quantidade, natureza, _usuario.UsuarioId, _usuario.Nome, dataReserva, 2, txtLivro.Text, folhaInicio, folhaFim, ato);

                string msgReservado = "Selo(s) reservado(s): \n \n";

                foreach (var item in selosReservar)
                {
                    msgReservado += string.Format("{0} {1:00000} {2}\n", item.Letra, item.Numero, item.Aleatorio);


                    Selos selo = _AppServicoSelos.GetById(item.SeloId);

                    selo.DataReservado = dataReserva;
                    selo.FormReservado = "Reservar Selos";
                    selo.Reservado = "S";
                    selo.Atribuicao = 2;
                    selo.Sistema = "NOTAS";
                    selo.Livro = txtLivro.Text;
                    selo.FolhaInicial = folhaInicio;
                    selo.FolhaFinal = folhaFim;
                    selo.NumeroAto = ato;
                    selo.Natureza = cmbNatureza.Text;
                    selo.IdUsuarioReservado = _usuario.UsuarioId;
                    selo.UsuarioReservado = _usuario.Nome;

                    _AppServicoSelos.Update(selo);
                }
                
                               


                MessageBox.Show(msgReservado, "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }
    }
}
