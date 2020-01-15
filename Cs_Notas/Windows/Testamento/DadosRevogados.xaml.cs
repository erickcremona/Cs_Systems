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

namespace Cs_Notas.Windows.Testamento
{
    /// <summary>
    /// Lógica interna para DadosRevogados.xaml
    /// </summary>
    public partial class DadosRevogados : Window
    {
        DigitarTestamento _digitarTestamento;
        string estado = string.Empty;

        Revogados revogado = new Revogados();
        public DadosRevogados(DigitarTestamento digitarTestamento)
        {

            _digitarTestamento = digitarTestamento;

            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FecharCampos();

            btnCancelar.IsEnabled = false;
            btnSalvar.IsEnabled = false;

            dataGridRevogados.ItemsSource = _digitarTestamento.listaRevogados;
            dataGridRevogados.SelectedIndex = 0;

            if (dataGridRevogados.Items.Count > 0)
                dataGridRevogados.IsEnabled = true;
            else
                dataGridRevogados.IsEnabled = false;

            btnAdicionarParte.Focus();
        }

        private void AbrirCampos()
        {
            dtDataAto.IsEnabled = true;
            txtLivro.IsEnabled = true;
            txtAto.IsEnabled = true;
            txtSelo.IsEnabled = true;
            txtAleatorio.IsEnabled = true;
            gbEletronico.IsEnabled = true;
            gbLavrado.IsEnabled = true;
            txtServentia.IsEnabled = true;
        }

        private void FecharCampos()
        {
            dtDataAto.IsEnabled = false;
            txtLivro.IsEnabled = false;
            txtAto.IsEnabled = false;
            txtSelo.IsEnabled = false;
            txtAleatorio.IsEnabled = false;
            gbEletronico.IsEnabled = false;
            gbLavrado.IsEnabled = false;
            txtServentia.IsEnabled = false;
        }

        
      

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (btnAdicionarParte.IsEnabled == true)
                this.Close();
            else
                MessageBox.Show("Para fechar é necessário salvar ou cancelar o cadastro atual.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnAdicionarParte_Click(object sender, RoutedEventArgs e)
        {
            estado = "novo";
            AbrirCampos();
            LimparCampos();
            btnCancelar.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            dataGridRevogados.IsEnabled = false;
            btnAdicionarParte.IsEnabled = false;
            dtDataAto.Focus();
        }


        private void LimparCampos()
        {
            dtDataAto.Text = "";
            txtLivro.Text = "";
            txtAto.Text = "";
            txtSelo.Text = "";
            txtAleatorio.Text = "";
            rbSimEletronico.IsChecked = true;
            rbSimLavrado.IsChecked = true;
            txtServentia.Text = "";
                       
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            FecharCampos();
            dataGridRevogados.IsEnabled = true;
            btnAdicionarParte.IsEnabled = true;
            btnCancelar.IsEnabled = false;
            btnSalvar.IsEnabled = false;

            if (dataGridRevogados.SelectedItem != null)
                CarregarCampos();
            else
                LimparCampos();
            
            estado = "pronto";
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                List<string> listaPreencher = ConferirPreenchimentoDosCampos();

                if (listaPreencher.Count > 0)
                {
                    string msgReservado = "Campo(s) de Preenchimento obrigatório encontrado(s): \n \n";

                    foreach (var item in listaPreencher)
                    {
                        msgReservado += string.Format("{0}\n", item);

                    }

                    var pergunta = "\nDeseja salvar mesmo assim?";

                    if (MessageBox.Show(msgReservado + pergunta, "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }


                SalvarRevogado();
                FecharCampos();
                dataGridRevogados.IsEnabled = true;
                btnAdicionarParte.IsEnabled = true;
                btnCancelar.IsEnabled = false;
                btnSalvar.IsEnabled = false;

                estado = "pronto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<string> ConferirPreenchimentoDosCampos()
        {
            var naoPreenchido = new List<string>();

            if (dtDataAto.SelectedDate == null)
                naoPreenchido.Add("Data não informada;");


            if (rbSimLavrado.IsChecked == true)
            {
                if (txtSelo.Text.Length != 9 || txtAleatorio.Text.Length != 3)
                {
                    naoPreenchido.Add("Selo não informado ou inválido;");
                }
            }

            if (txtLivro.Text == "")
                naoPreenchido.Add("Livro não informado;");

            if (txtAto.Text == "")
                naoPreenchido.Add("Ato não informado;");

            return naoPreenchido;
        }

        private void SalvarRevogado()
        {
            if (estado == "novo")
            {
                revogado = new Revogados();
                if (_digitarTestamento.listaRevogados.Count > 0)
                    revogado.RevogadosId = _digitarTestamento.listaRevogados.Max(p => p.RevogadosId) + 1;
                else
                    revogado.RevogadosId = 1;
            }
            else
                revogado = _digitarTestamento.listaRevogados.Where(p => p.RevogadosId == ((Revogados)dataGridRevogados.SelectedItem).RevogadosId).FirstOrDefault();

            
            revogado.Aleatorio = txtAleatorio.Text;

            if(txtAto.Text != "")
            revogado.Ato = Convert.ToInt32(txtAto.Text);

            if (dtDataAto.SelectedDate != null)
            revogado.Data = dtDataAto.SelectedDate.Value;

            if (rbSimEletronico.IsChecked == true)
                revogado.Eletronico = "S";

            if (rbNaoEletronico.IsChecked == true)
                revogado.Eletronico = "N";

            if (rbSimLavrado.IsChecked == true)
                revogado.LavradoRio = "S";

            if (rbNaoLavrado.IsChecked == true)
                revogado.LavradoRio = "N";

            revogado.Livro = txtLivro.Text;

            revogado.Selo = txtSelo.Text;

            revogado.Serventia = txtServentia.Text;

            

            if (estado == "novo")
            {               

                _digitarTestamento.listaRevogados.Add(revogado);
            }
            else
            {
                var revogadoAlterar = _digitarTestamento.listaRevogados.Where(p => p.RevogadosId == revogado.RevogadosId).FirstOrDefault();

                revogadoAlterar = revogado;

            }



            dataGridRevogados.Items.Refresh();

            dataGridRevogados.SelectedItem = revogado;
            dataGridRevogados.ScrollIntoView(revogado);
        }


        private void MenuItemExcluir_Click(object sender, RoutedEventArgs e)
        {
            _digitarTestamento.listaRevogados.Remove(revogado);

            dataGridRevogados.Items.Refresh();


            if (dataGridRevogados.Items.Count > 0)
            {
                dataGridRevogados.IsEnabled = true;
                dataGridRevogados.SelectedIndex = 0;
            }
            else
                dataGridRevogados.IsEnabled = false;

        }

        private void MenuItemAlterar_Click(object sender, RoutedEventArgs e)
        {
            AlterarTestemunha();
        }

        private void AlterarTestemunha()
        {
            estado = "alterar";

            AbrirCampos();

            btnCancelar.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            dataGridRevogados.IsEnabled = false;
            btnAdicionarParte.IsEnabled = false;

            dtDataAto.Focus();

        }

       

        private void dataGridRevogados_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridRevogados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarCampos();

            if (dataGridRevogados.Items.Count > 0)
                menu.IsEnabled = true;
            else
                menu.IsEnabled = false;

        }

        private void CarregarCampos()
        {

            if (dataGridRevogados.SelectedItem != null)
            {
                revogado = (Revogados)dataGridRevogados.SelectedItem;


                dtDataAto.SelectedDate = revogado.Data;
                txtLivro.Text = revogado.Livro;
                txtAto.Text = string.Format("{0}", revogado.Ato);
                txtSelo.Text = revogado.Selo;
                txtAleatorio.Text = revogado.Aleatorio;

                if (revogado.LavradoRio == "S")
                    rbSimLavrado.IsChecked = true;

                if(revogado.LavradoRio == "N")
                    rbNaoLavrado.IsChecked = true;

                if (revogado.Eletronico == "S")
                    rbSimEletronico.IsChecked = true;

                if (revogado.Eletronico == "N")
                    rbNaoEletronico.IsChecked = true;

                txtServentia.Text = revogado.Serventia;

            }
            else
            {
                LimparCampos();

            }

        }

        private void dataGridRevogados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AlterarTestemunha();
        }

        private void txtSelo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            txtSelo.MaxLength = 9;
            if (txtSelo.Text.Length <= 3)
            {
                int key = (int)e.Key;

                e.Handled = !(key >= 44 && key <= 69 || key == 2 || key == 3);
            }

            if (txtSelo.Text.Length >= 4 && txtSelo.Text.Length <= 8)
            {
                int key = (int)e.Key;

                e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3);
            }

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtAleatorio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 44 && key <= 69 || key == 2 || key == 3);

            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtAto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3);

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

        private void dtDataAto_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtLivro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void gbEletronico_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void gbLavrado_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtServentia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }
    }
}
