using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
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
    /// Interaction logic for OrigemEscritura.xaml
    /// </summary>
    public partial class OrigemEscritura : Window
    {
        DigitarEscritura _digitarEscritura;
        List<string> Ufs = new List<string>();
        public List<ServentiasOutras> serventias;

        public ServentiasOutras serventiasOutrasSelecionada;

        private readonly IAppServicoMunicipios _AppServicoMunicipios = BootStrap.Container.GetInstance<IAppServicoMunicipios>();
        private readonly IAppServicoServentiasOutras _AppServicoServentiasOutras = BootStrap.Container.GetInstance<IAppServicoServentiasOutras>();

        public OrigemEscritura(DigitarEscritura digitarEscritura)
        {
            _digitarEscritura = digitarEscritura;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarUF();
            CarregarServentias();
            if(_digitarEscritura._escrituras != null)
            CarregarInicio();
            txtDesconhecido.Focus();
            txtDesconhecido.SelectAll();
        }

        private void CarregarInicio()
        {
            try
            {
                txtDesconhecido.Text = _digitarEscritura._escrituras.Desconhecido;
                txtLivroReferente.Text = _digitarEscritura._escrituras.LivroReferencia;
                txtFolhaReferente.Text = _digitarEscritura._escrituras.FolhaReferencia;
                cmbUf.Text = _digitarEscritura._escrituras.UfReferencia;
                cmbCidade.SelectedValue = _digitarEscritura._escrituras.CidadeReferencia;

                txtServentia.Text = _digitarEscritura._escrituras.Serventia;
                if(_digitarEscritura._escrituras.Serventia != null && _digitarEscritura._escrituras.Serventia != "")
                txtCodigo.Text = serventias.Where(p => p.Descricao == txtServentia.Text).FirstOrDefault().Codigo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
            }
        }

        private void CarregarUF()
        {

            Ufs = _AppServicoMunicipios.ObterUfsDosMunicipios();

            cmbUf.ItemsSource = Ufs;

        }

        private void CarregarServentias()
        {
            serventias = _AppServicoServentiasOutras.GetAll().OrderBy(p => p.Descricao).ToList();


        }

        private void btnSalvarSair_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _digitarEscritura._escrituras.Desconhecido = txtDesconhecido.Text;
                _digitarEscritura._escrituras.LivroReferencia = txtLivroReferente.Text;
                _digitarEscritura._escrituras.FolhaReferencia = txtFolhaReferente.Text;
                _digitarEscritura._escrituras.UfReferencia = cmbUf.Text;
                _digitarEscritura._escrituras.CidadeReferencia = Convert.ToInt16(cmbCidade.SelectedValue);

                if (txtCodigo.Text != "")
                {
                    _digitarEscritura._escrituras.Serventia = txtServentia.Text;
                    _digitarEscritura._escrituras.CodigoServentia = Convert.ToInt32(txtCodigo.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message);
            }

            this.Close();
        }

        private void btnSairSemSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbUf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUf.SelectedIndex > -1)
            {
                cmbCidade.ItemsSource = _AppServicoMunicipios.ObterMunicipiosPorUF(Ufs[cmbUf.SelectedIndex]).OrderBy(p => p.Nome);

                cmbCidade.DisplayMemberPath = "Nome";

                cmbCidade.SelectedValuePath = "MunicipioId";

            }
        }

        private void btnConsultarServentia_Click(object sender, RoutedEventArgs e)
        {
            var consultarServentia = new ConsultaServentias(this);
            consultarServentia.Owner = this;
            consultarServentia.ShowDialog();

            if (serventiasOutrasSelecionada != null)
            {
                txtCodigo.Text = serventiasOutrasSelecionada.Codigo.ToString();
                txtServentia.Text = serventiasOutrasSelecionada.Descricao;
            }
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
                PesquisarServentia();
            else
                txtServentia.Text = "";
        }

        private void PesquisarServentia()
        {
            var codigo = Convert.ToInt32(txtCodigo.Text);

            serventiasOutrasSelecionada = serventias.Where(p => p.Codigo == codigo).FirstOrDefault();

            if (serventiasOutrasSelecionada != null)
                txtServentia.Text = serventiasOutrasSelecionada.Descricao;
            else
                txtServentia.Text = "";
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void txtServentia_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtServentia.Text.Length >= 35)
                txtServentia.FontSize = 12;
            else
                txtServentia.FontSize = 18;
        }

        private void txtDesconhecido_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDesconhecido.Text.Length > 0)
            {
                lblLivro.Foreground = Brushes.Black;
                lblFolhaRef.Foreground = Brushes.Black;
                lblUf.Foreground = Brushes.Black;
                lblCidade.Foreground = Brushes.Black;
                lblServentia.Foreground = Brushes.Black;
                lblCodigo.Foreground = Brushes.Black;
            }
            else
            {
                lblLivro.Foreground = Brushes.Red;
                lblFolhaRef.Foreground = Brushes.Red;
                lblUf.Foreground = Brushes.Red;
                lblCidade.Foreground = Brushes.Red;
                lblServentia.Foreground = Brushes.Red;
                lblCodigo.Foreground = Brushes.Red;
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

      

        private void txtDesconhecido_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtLivroReferente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtFolhaReferente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbUf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbCidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }
    }
}
