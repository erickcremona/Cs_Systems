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

namespace Cs_Gerencial.Windows
{
    /// <summary>
    /// Interaction logic for AdicionarAlterarIndisponibolidade.xaml
    /// </summary>
    public partial class AdicionarAlterarIndisponibolidade : Window
    {
        CadastroIndisponibilidade _cadIndisp;

        private readonly IAppServicoIndisponibilidades _AppServicoIndisponibilidades = BootStrap.Container.GetInstance<IAppServicoIndisponibilidades>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        Indisponibilidades indisponiblidade;

        LogSistema logSistema;

        int key;

        public AdicionarAlterarIndisponibolidade(CadastroIndisponibilidade cadIndisp)
        {
            _cadIndisp = cadIndisp;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Title == "Alterar Indisponibilidade")
                {
                    indisponiblidade = (Indisponibilidades)_cadIndisp.dataGrid1.SelectedItem;

                    CarregarComponentes();
                }
                else
                {
                    ckbCancelado.IsChecked = false;
                    txtCancelamento.IsEnabled = false;
                    dpDataCancelamento.IsEnabled = false;
                    txtHoraCancelamento.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CarregarComponentes()
        {


            if (indisponiblidade.Cancelado == "S")
            {
                ckbCancelado.IsChecked = true;
                txtCancelamento.IsEnabled = true;
                dpDataCancelamento.IsEnabled = true;
                txtHoraCancelamento.IsEnabled = true;
            }
            else
            {
                ckbCancelado.IsChecked = false;
                txtCancelamento.IsEnabled = false;
                dpDataCancelamento.IsEnabled = false;
                txtHoraCancelamento.IsEnabled = false;
            }



            if (indisponiblidade.Cancelamento != null && indisponiblidade.Cancelamento != "")
                txtCancelamento.Text = indisponiblidade.Cancelamento;



            if (indisponiblidade.DataCancelamento != null && indisponiblidade.DataCancelamento != "")
                dpDataCancelamento.SelectedDate = Convert.ToDateTime(indisponiblidade.DataCancelamento);



            if (indisponiblidade.HoraCancelamento != null)
                txtHoraCancelamento.Text = indisponiblidade.HoraCancelamento;



            if (indisponiblidade.DataPedido != null)
                dpDataPedido.SelectedDate = indisponiblidade.DataPedido;



            txtHoraPedido.Text = indisponiblidade.HoraPedido;

            txtProtocolo.Text = indisponiblidade.Protocolo;

            txtNumeroProcesso.Text = indisponiblidade.NumeroProcesso;

            txtTelefone.Text = indisponiblidade.Telefone;

            txtNomeInstituicao.Text = indisponiblidade.NomeInstituicao;

            txtForumVara.Text = indisponiblidade.ForumVara;

            txtUsuario.Text = indisponiblidade.Usuario;

            txtEmail.Text = indisponiblidade.Email;

            txtNome.Text = indisponiblidade.NomeIndividuo;

            txtCpfCnpj.Text = indisponiblidade.CpfCnpj;
        }

        private void TabNoEnter(object sender, KeyEventArgs e)
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

        private void txtCancelamento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Indisponibilidades salvarIndisp;
            try
            {
                if (this.Title == "Alterar Indisponibilidade")
                {
                    salvarIndisp = indisponiblidade;
                }
                else
                {
                    salvarIndisp = new Indisponibilidades();
                }

                if (ckbCancelado.IsChecked == true)
                {
                    salvarIndisp.Cancelado = "S";
                    if (txtCancelamento.Text == "")
                    {
                        MessageBox.Show("Preencha o campo 'Cancelamento de Indisponibilidade' ou desmarque a opção 'Cancelado'.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtCancelamento.Focus();
                        return;
                    }
                    if (dpDataCancelamento.Text == "")
                    {
                        MessageBox.Show("Preencha o campo 'Data Cancelamento' ou desmarque a opção 'Cancelado'.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                        dpDataCancelamento.Focus();
                        return;
                    }

                    if (txtHoraCancelamento.Text == "")
                    {
                        MessageBox.Show("Preencha o campo 'Hora Cancelamento' ou desmarque a opção 'Cancelado'.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtHoraCancelamento.Focus();
                        return;
                    }
                }


                if (ckbCancelado.IsChecked == true)
                {
                    salvarIndisp.Cancelado = "S";
                }
                else
                {
                    salvarIndisp.Cancelado = "N";
                }


                salvarIndisp.Cancelamento = txtCancelamento.Text;

                if (dpDataCancelamento.Text != "")
                    salvarIndisp.DataCancelamento = dpDataCancelamento.SelectedDate.ToString();

                salvarIndisp.HoraCancelamento = txtHoraCancelamento.Text;



                if (dpDataPedido.Text != "")
                {
                    salvarIndisp.DataPedido = dpDataPedido.SelectedDate.Value;
                }
                
                if (dpDataPedido.Text != "")
                    salvarIndisp.HoraPedido = txtHoraPedido.Text;

                if (txtProtocolo.Text != "")
                    salvarIndisp.Protocolo = txtProtocolo.Text;

                if (txtNumeroProcesso.Text != "")
                    salvarIndisp.NumeroProcesso = txtNumeroProcesso.Text;

                if (txtTelefone.Text != "")
                    salvarIndisp.Telefone = txtTelefone.Text;

                if (txtNomeInstituicao.Text != "")
                    salvarIndisp.NomeInstituicao = txtNomeInstituicao.Text;

                if (txtForumVara.Text != "")
                    salvarIndisp.ForumVara = txtForumVara.Text;

                if (txtUsuario.Text != "")
                    salvarIndisp.Usuario = txtUsuario.Text;

                if (txtEmail.Text != "")
                    salvarIndisp.Email = txtEmail.Text;

                if (txtNome.Text != "")
                    salvarIndisp.NomeIndividuo = txtNome.Text;

                if (txtCpfCnpj.Text != "")
                    salvarIndisp.CpfCnpj = txtCpfCnpj.Text;



                if (this.Title == "Alterar Indisponibilidade")
                {
                    _AppServicoIndisponibilidades.Update(salvarIndisp);
                    SalvarLogSistema("Alterou registro de " + salvarIndisp.NomeIndividuo);
                }
                else
                {
                    _AppServicoIndisponibilidades.Add(salvarIndisp);

                    SalvarLogSistema("Adicionou registro de " + salvarIndisp.NomeIndividuo);

                    var lista_cadIndisp = _cadIndisp._indisponibilidades.ToList();

                    lista_cadIndisp.Add(salvarIndisp);

                    _cadIndisp._indisponibilidades = lista_cadIndisp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado, por favor entre em contato com o programador. => " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }

            this.Close();


        }

        private void dpDataCancelamento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtHoraCancelamento_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 145);


            TabNoEnter(sender, e);
        }

        private void txtProtocolo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void dpDataPedido_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtTelefone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtNomeInstituicao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtForumVara_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtUsuario_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtNome_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtCpfCnpj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);

            TabNoEnter(sender, e);
        }

        private void txtHoraPedido_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 145);
            TabNoEnter(sender, e);
        }

        private void txtNumeroProcesso_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TabNoEnter(sender, e);
        }

        private void txtCpfCnpj_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCpfCnpj.Text = txtCpfCnpj.Text.Replace("/", "").Replace(".", "").Replace("-", "");
        }

        private void txtCpfCnpj_LostFocus(object sender, RoutedEventArgs e)
        {
            switch (txtCpfCnpj.Text.Length)
            {
                case 11:

                    if (_AppServicoIndisponibilidades.ValidarCpf(txtCpfCnpj.Text))
                    {
                        txtCpfCnpj.Background = Brushes.GreenYellow;
                        txtCpfCnpj.Text = string.Format("{0}.{1}.{2}-{3}", txtCpfCnpj.Text.Substring(0, 3), txtCpfCnpj.Text.Substring(3, 3),
                            txtCpfCnpj.Text.Substring(6, 3), txtCpfCnpj.Text.Substring(9, 2));
                    }
                    else
                    {
                        txtCpfCnpj.Background = Brushes.Red;
                    }
                    break;

                case 14:

                    if (_AppServicoIndisponibilidades.ValidarCnpj(txtCpfCnpj.Text))
                    {
                        txtCpfCnpj.Background = Brushes.GreenYellow;
                        txtCpfCnpj.Text = string.Format("{0}.{1}.{2}/{3}-{4}", txtCpfCnpj.Text.Substring(0, 2), txtCpfCnpj.Text.Substring(2, 3),
                            txtCpfCnpj.Text.Substring(5, 3), txtCpfCnpj.Text.Substring(8, 4), txtCpfCnpj.Text.Substring(12, 2));
                    }
                    else
                    {
                        txtCpfCnpj.Background = Brushes.Red;
                    }
                    break;

                case 0:
                    txtCpfCnpj.Background = Brushes.White;
                    break;

                default:
                    txtCpfCnpj.Background = Brushes.Red;
                    break;
            }
        }

        private void txtCpfCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCpfCnpj.Text.Length == 0)
                txtCpfCnpj.Background = Brushes.White;
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text != "")
            {
                if (_AppServicoIndisponibilidades.ValidarEmail(txtEmail.Text))
                    txtEmail.Background = Brushes.GreenYellow;
                else
                    txtEmail.Background = Brushes.Red;
            }
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Background = Brushes.White;
            }

        }


        private void ckbCancelado_Checked(object sender, RoutedEventArgs e)
        {

            txtCancelamento.IsEnabled = true;
            dpDataCancelamento.IsEnabled = true;
            txtHoraCancelamento.IsEnabled = true;


        }

        private void ckbCancelado_Unchecked(object sender, RoutedEventArgs e)
        {
            txtCancelamento.Text = "";
            dpDataCancelamento.Text = "";
            txtHoraCancelamento.Text = "";


            txtCancelamento.IsEnabled = false;
            dpDataCancelamento.IsEnabled = false;
            txtHoraCancelamento.IsEnabled = false;

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();
                        
            logSistema.Tela = this.Title;

            logSistema.IdUsuario = _cadIndisp._usuario.UsuarioId;

            logSistema.Usuario = _cadIndisp._usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }


    }
}
