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
            usuarios = _AppServicoUsuario.GetAll().OrderBy(p => p.NomeUsuario).ToList();
            cmbUsuario.ItemsSource = usuarios;
            cmbUsuario.SelectedItem = _usuario;
            cmbUsuario.DisplayMemberPath = "NomeUsuario";
            groupUsuarioSenha.IsEnabled = false;

            if (salvarLog == "nao" || cmbUsuario.SelectedIndex == -1)
            {
                btnAlterar.IsEnabled = false;
                btnExcluir.IsEnabled = false;
            }
        }

        private void cmbUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUsuario.SelectedIndex > -1)
            {
                Usuario usu = (Usuario)cmbUsuario.SelectedItem;
                txtNomeUsuario.Text = usu.NomeUsuario;
                passSenha.Password = usu.Senha;
                btnExcluir.IsEnabled = true;
                btnAlterar.IsEnabled = true;
            }
            else
            {
                btnExcluir.IsEnabled = false;
                btnAlterar.IsEnabled = false;
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
            txtNomeUsuario.Focus();
            txtNomeUsuario.SelectAll();
            cmbUsuario.IsEnabled = false;
            toolBarPanel.IsEnabled = false;
        }

        private void FecharCampos()
        {
            groupUsuarioSenha.IsEnabled = false;
            cmbUsuario.IsEnabled = true;
            toolBarPanel.IsEnabled = true;
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

            try
            {
                if (acao == "alterar")
                {
                    salvarUsuario = (Usuario)cmbUsuario.SelectedItem;
                    string usuarioAnterior = salvarUsuario.NomeUsuario;
                    salvarUsuario.NomeUsuario = txtNomeUsuario.Text.Trim();
                    salvarUsuario.Senha = _AppServicoUsuario.CriptogravarSenha(passSenha.Password);

                    _AppServicoUsuario.Update(salvarUsuario);

                    string descricao = "Alterou o usuário " + usuarioAnterior + " para " + salvarUsuario.NomeUsuario;
                    if (salvarLog == "sim")
                    {
                        if (verificarSeAlterou != string.Format("{0}{1}", txtNomeUsuario.Text, passSenha.Password))
                        {
                            SalvarLogSistema(descricao);
                        }
                    }
                    cmbUsuario.Items.Refresh();

                    cmbUsuario.SelectedIndex = -1;

                    cmbUsuario.Text = salvarUsuario.NomeUsuario;
                    txtNomeUsuario.Text = salvarUsuario.NomeUsuario;
                    passSenha.Password = salvarUsuario.Senha;
                    
                }
                else
                {
                    salvarUsuario = new Usuario();

                    salvarUsuario.NomeUsuario = txtNomeUsuario.Text.Trim();
                    salvarUsuario.Senha = _AppServicoUsuario.CriptogravarSenha(passSenha.Password);
                    _AppServicoUsuario.Add(salvarUsuario);

                    

                    if (salvarLog == "sim")
                        SalvarLogSistema("Adicionou o usuário " + salvarUsuario.NomeUsuario);

                    usuarios.Add(salvarUsuario);
                    cmbUsuario.ItemsSource = usuarios;
                    cmbUsuario.Items.Refresh();
                    cmbUsuario.Text = salvarUsuario.NomeUsuario;
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

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            AbrirCampos();
            txtNomeUsuario.Text = "";
            passSenha.Password = "";
            acao = "adicionar";
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

            string usuarioAnterior = usuarioExcluir.NomeUsuario;
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

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Cadastro de Usuário";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }


    }
}
