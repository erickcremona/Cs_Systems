
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

namespace Cs_Notas.Windows
{
    /// <summary>
    /// Interaction logic for CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        string salvarLog;
        LogSistema logSistema;
        private Usuario _usuario;
        string acao = "pronto";
        private readonly IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<IAppServicoUsuario>();
        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();
        List<Usuario> usuarios;
        string verificarSeAlterou;

        public CadastroUsuario(Usuario usuario)
        {
            _usuario = usuario;
            salvarLog = "sim";
            InitializeComponent();
        }

        public CadastroUsuario()
        {
            salvarLog = "nao";
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            usuarios = _AppServicoUsuario.GetAll().OrderBy(p => p.Nome).ToList();
            cmbUsuario.ItemsSource = usuarios;
            cmbUsuario.SelectedItem = _usuario;
            cmbUsuario.DisplayMemberPath = "Nome";
            btnSalvar.IsEnabled = false;
            groupUsuarioSenha.IsEnabled = false;
            groupPermissoes.IsEnabled = false;

            if (salvarLog == "nao" || cmbUsuario.SelectedIndex == -1)
            {
                btnAlterar.IsEnabled = false;
                btnExcluir.IsEnabled = false;
            }

            if (_usuario != null)
            {
                if (_usuario.Master != "S" && _usuario.Nome != "Administrador")
                {
                    btnExcluir.IsEnabled = false;
                    btnAdicionar.IsEnabled = false;
                    cmbUsuario.IsEnabled = false;
                }
            }
          
        }

        private void cmbUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregaCampos();
        }

        private void CarregaCampos()
        {
            try
            {
                if (cmbUsuario.SelectedIndex > -1)
                {
                    Usuario usu = (Usuario)cmbUsuario.SelectedItem;
                    txtNomeUsuario.Text = usu.Nome;
                    passSenha.Password = usu.Senha;
                    txtQualificacao.Text = usu.Qualificacao;
                    txtCpf.Text = usu.Cpf;
                    txtMatrícula.Text = usu.Matricula;

                    if (usu.Master == "S")
                        ckbMaster.IsChecked = true;
                    else
                        ckbMaster.IsChecked = false;

                    if (usu.AlterarAto == "S")
                        ckbAlteraAtos.IsChecked = true;
                    else
                        ckbAlteraAtos.IsChecked = false;

                    if (usu.ExcluirAto == "S")
                        ckbExcluirAtos.IsChecked = true;
                    else
                        ckbExcluirAtos.IsChecked = false;

                    if (usu.SelarAto == "S")
                        ckbSelarAtos.IsChecked = true;
                    else
                        ckbSelarAtos.IsChecked = false;

                    if (usu.LiberarSelo == "S")
                        ckbLiberarSelo.IsChecked = true;
                    else
                        ckbLiberarSelo.IsChecked = false;

                    if (usu.ReservarSelo == "S")
                        ckbReservarSelo.IsChecked = true;
                    else
                        ckbReservarSelo.IsChecked = false;

                    if (usu.AlterarSelo == "S")
                        ckbAlterarSelo.IsChecked = true;
                    else
                        ckbAlterarSelo.IsChecked = false;

                    if (usu.AlterarEmolumentos == "S")
                        ckbAlterarEmolumentos.IsChecked = true;
                    else
                        ckbAlterarEmolumentos.IsChecked = false;

                    btnExcluir.IsEnabled = true;
                    btnAlterar.IsEnabled = true;

                }
                else
                {
                    btnExcluir.IsEnabled = false;
                    btnAlterar.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            AbrirCampos();
            txtNomeUsuario.Text = "";
            passSenha.Password = "";
            txtCpf.Text = "";
            txtQualificacao.Text = "";
            txtMatrícula.Text = "";
            acao = "adicionar";

            if (salvarLog == "sim")
            {
                ckbMaster.IsChecked = false;
                ckbAlteraAtos.IsChecked = false;
                ckbExcluirAtos.IsChecked = false;
                ckbSelarAtos.IsChecked = false;
                ckbLiberarSelo.IsChecked = false;
                ckbReservarSelo.IsChecked = false;
                ckbAlterarSelo.IsChecked = false;
                ckbAlterarEmolumentos.IsChecked = false;
            }
            else
            {
                ckbMaster.IsChecked = true;
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            AbrirCampos();
            passSenha.Password = _AppServicoUsuario.DecriptogravarSenha(passSenha.Password);
            acao = "alterar";
            verificarSeAlterou = string.Format("{0}{1}", txtNomeUsuario.Text, passSenha.Password);
        }

        private void AbrirCampos()
        {
            groupUsuarioSenha.IsEnabled = true;

            if (_usuario != null)
            {
                if (_usuario.Master == "S" || _usuario.Nome == "Administrador")
                {
                    if (salvarLog == "sim")
                        groupPermissoes.IsEnabled = true;
                    else
                        groupPermissoes.IsEnabled = false;
                }
                else
                {
                    groupPermissoes.IsEnabled = false;
                }
            }

            btnSalvar.IsEnabled = true;
            txtNomeUsuario.Focus();
            txtNomeUsuario.SelectAll();
            cmbUsuario.IsEnabled = false;
            toolBarPanel.IsEnabled = false;
        }

        private void FecharCampos()
        {

            toolBarPanel.IsEnabled = true;

            if (_usuario != null)
            {
                if (_usuario.Master == "S" || _usuario.Nome == "Administrador")
                {
                    groupUsuarioSenha.IsEnabled = false;
                    groupPermissoes.IsEnabled = false;
                    btnSalvar.IsEnabled = false;
                    cmbUsuario.IsEnabled = true;

                }
                else
                {
                    btnAdicionar.IsEnabled = false;
                    btnExcluir.IsEnabled = false;
                    btnAlterar.IsEnabled = true;
                    btnSalvar.IsEnabled = false;
                    groupUsuarioSenha.IsEnabled = false;
                    groupPermissoes.IsEnabled = false;
                }
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

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
           
            Usuario usuarioExcluir = (Usuario)cmbUsuario.SelectedItem;

            if (usuarioExcluir.UsuarioId == _usuario.UsuarioId)
            {
                MessageBox.Show("Não é possível excluir o usuário logado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            
            string usuarioAnterior = usuarioExcluir.Nome;
            if (MessageBox.Show("Deseja realmente excluir o Usuário " + usuarioAnterior + "?", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    _AppServicoUsuario.Remove(usuarioExcluir);

                    if (salvarLog == "sim")
                        SalvarLogSistema("Excluiu o usuário " + usuarioAnterior);

                    usuarios.Remove(usuarioExcluir);

                    cmbUsuario.Items.Refresh();

                    cmbUsuario.SelectedIndex = -1;

                    txtNomeUsuario.Text = "";
                    passSenha.Password = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado, " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void txtNomeUsuario_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void passSenha_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Usuario salvarUsuario;


            if (txtNomeUsuario.Text == "")
            {
                MessageBox.Show("Preencha o campo Nome.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtNomeUsuario.Focus();
                return;
            }



            if (passSenha.Password == "")
            {
                MessageBox.Show("Preencha o campo Senha.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                passSenha.Focus();
                return;
            }


            if (txtQualificacao.Text == "")
            {
                MessageBox.Show("Preencha o campo Qualificação.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtQualificacao.Focus();
                return;
            }



            try
            {


                if (acao == "alterar")
                {
                    salvarUsuario = (Usuario)cmbUsuario.SelectedItem;
                }
                else
                {
                    salvarUsuario = new Usuario();
                }


                string usuarioAnterior = salvarUsuario.Nome;
                salvarUsuario.Nome = txtNomeUsuario.Text.Trim();
                salvarUsuario.Senha = _AppServicoUsuario.CriptogravarSenha(passSenha.Password);
                salvarUsuario.Qualificacao = txtQualificacao.Text;
                salvarUsuario.Cpf = txtCpf.Text;
                salvarUsuario.Matricula = txtMatrícula.Text;

                if (ckbMaster.IsChecked == true)
                    salvarUsuario.Master = "S";
                else
                    salvarUsuario.Master = "N";

                if (ckbAlteraAtos.IsChecked == true)
                    salvarUsuario.AlterarAto = "S";
                else
                    salvarUsuario.AlterarAto = "N";

                if (ckbExcluirAtos.IsChecked == true)
                    salvarUsuario.ExcluirAto = "S";
                else
                    salvarUsuario.ExcluirAto = "N";

                if (ckbSelarAtos.IsChecked == true)
                    salvarUsuario.SelarAto = "S";
                else
                    salvarUsuario.SelarAto = "N";

                if (ckbLiberarSelo.IsChecked == true)
                    salvarUsuario.LiberarSelo = "S";
                else
                    salvarUsuario.LiberarSelo = "N";

                if (ckbReservarSelo.IsChecked == true)
                    salvarUsuario.ReservarSelo = "S";
                else
                    salvarUsuario.ReservarSelo = "N";

                if (ckbAlterarSelo.IsChecked == true)
                    salvarUsuario.AlterarSelo = "S";
                else
                    salvarUsuario.AlterarSelo = "N";

                if (ckbAlterarEmolumentos.IsChecked == true)
                    salvarUsuario.AlterarEmolumentos = "S";
                else
                    salvarUsuario.AlterarEmolumentos = "N";


                if (acao == "alterar")
                {
                    _AppServicoUsuario.Update(salvarUsuario);

                    string descricao = "Alterou o usuário " + usuarioAnterior + " para " + salvarUsuario.Nome;
                    if (salvarLog == "sim")
                    {
                        if (verificarSeAlterou != string.Format("{0}{1}", txtNomeUsuario.Text, passSenha.Password))
                        {
                            SalvarLogSistema(descricao);
                        }
                    }
                    cmbUsuario.Items.Refresh();

                    cmbUsuario.SelectedIndex = -1;

                    cmbUsuario.Text = salvarUsuario.Nome;
                    txtNomeUsuario.Text = salvarUsuario.Nome;
                    passSenha.Password = salvarUsuario.Senha;
                }
                else
                {


                    _AppServicoUsuario.Add(salvarUsuario);

                    if (salvarLog == "sim")
                        SalvarLogSistema("Adicionou o usuário " + salvarUsuario.Nome);

                    usuarios.Add(salvarUsuario);
                    cmbUsuario.ItemsSource = usuarios;
                    cmbUsuario.Items.Refresh();
                    cmbUsuario.Text = salvarUsuario.Nome;
                }

                MessageBox.Show("Usuário cadastrado com sucesso!", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado, " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (salvarLog == "nao")
            {
                this.Close();
            }

            FecharCampos();
            acao = "pronto";
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Cadastro de Usuário";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.Nome;

            logSistema.Maquina = Environment.MachineName.ToString();
            
            _AppServicoLogSistema.Add(logSistema);
        }

        private void ckbMaster_Checked(object sender, RoutedEventArgs e)
        {
            ckbAlteraAtos.IsChecked = true;
            ckbExcluirAtos.IsChecked = true;
            ckbSelarAtos.IsChecked = true;
            ckbLiberarSelo.IsChecked = true;
            ckbReservarSelo.IsChecked = true;
            ckbAlterarSelo.IsChecked = true;
            ckbAlterarEmolumentos.IsChecked = true;

            ckbAlteraAtos.IsEnabled = false;
            ckbExcluirAtos.IsEnabled = false;
            ckbSelarAtos.IsEnabled = false;
            ckbLiberarSelo.IsEnabled = false;
            ckbReservarSelo.IsEnabled = false;
            ckbAlterarSelo.IsEnabled = false;
            ckbAlterarEmolumentos.IsEnabled = false;
        }

        private void ckbMaster_Unchecked(object sender, RoutedEventArgs e)
        {
            ckbAlteraAtos.IsChecked = false;
            ckbExcluirAtos.IsChecked = false;
            ckbSelarAtos.IsChecked = false;
            ckbLiberarSelo.IsChecked = false;
            ckbReservarSelo.IsChecked = false;
            ckbAlterarSelo.IsChecked = false;
            ckbAlterarEmolumentos.IsChecked = false;

            ckbAlteraAtos.IsEnabled = true;
            ckbExcluirAtos.IsEnabled = true;
            ckbSelarAtos.IsEnabled = true;
            ckbLiberarSelo.IsEnabled = true;
            ckbReservarSelo.IsEnabled = true;
            ckbAlterarSelo.IsEnabled = true;
            ckbAlterarEmolumentos.IsEnabled = true;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (btnAdicionar.IsEnabled == true)
            {
                if (e.Key == Key.Escape)
                    this.Close();
            }
            else
            {
                if (e.Key == Key.Escape)
                {
                    FecharCampos();
                    CarregaCampos();
                }
            }
        }

        private void txtQualificacao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCpf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void txtMatrícula_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }
    }
}
