using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
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

namespace Cs_IssPrefeitura
{
    /// <summary>
    /// Interaction logic for CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        string _tipoEntrada;
        private Usuario _usuario;
        string acao = "pronto";
        private readonly IAppServicoUsuario _IAppServicoUsuario = BootStrap.Container.GetInstance<IAppServicoUsuario>();
        List<Usuario> _usuarios = new List<Usuario>();
        string verificarSeAlterou;


        public CadastroUsuario(List<Usuario> usuarios, string tipoEntrada)
        {
            _usuarios = usuarios;
            _tipoEntrada = tipoEntrada;
            InitializeComponent();
        }

        public CadastroUsuario(Usuario usuario, string tipoEntrada)
        {
            _usuario = usuario;
            _tipoEntrada = tipoEntrada;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            if (_tipoEntrada == "Tela Login")
            {
                ckbMaster.IsChecked = true;
                ckbMaster.IsEnabled = false;

                groupBoxUsuario.IsEnabled = false;
                groupUsuarioSenha.IsEnabled = true;
                groupPermissoes.IsEnabled = false;


                btnSalvar.IsEnabled = true;

                txtNomeUsuario.Focus();
            }
            else
            {

                _usuarios = _IAppServicoUsuario.GetAll().OrderBy(p => p.Nome).ToList();

                cmbUsuario.ItemsSource = _usuarios;
                cmbUsuario.DisplayMemberPath = "Nome";

                cmbUsuario.SelectedItem = _usuario;
                cmbUsuario.DisplayMemberPath = "Nome";
                btnSalvar.IsEnabled = false;
                groupUsuarioSenha.IsEnabled = false;
                groupPermissoes.IsEnabled = false;

                if (cmbUsuario.SelectedIndex == -1)
                {
                    btnAlterar.IsEnabled = false;
                    btnExcluir.IsEnabled = false;
                }

                if (_usuario != null)
                {
                    if (_usuario.UsuarioMaster != true && _usuario.Nome != "Administrador")
                    {
                        btnExcluir.IsEnabled = false;
                        btnAdicionar.IsEnabled = false;
                        cmbUsuario.IsEnabled = false;
                    }
                }
            }
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
                if (_tipoEntrada == "Tela Login")
                {

                    salvarUsuario = new Usuario();

                    salvarUsuario.Nome = txtNomeUsuario.Text.Trim();
                    salvarUsuario.Senha = _IAppServicoUsuario.CriptogravarSenha(passSenha.Password);

                    salvarUsuario.UsuarioMaster = true;
                    salvarUsuario.ImprimirFechamentoMes = true;
                    salvarUsuario.ImportarMas = true;
                    salvarUsuario.FechamentoMes = true;
                    salvarUsuario.AlterarAtos = true;
                    salvarUsuario.AbrirFecharLivro = true;


                    _IAppServicoUsuario.Add(salvarUsuario);
                    _usuarios.Add(salvarUsuario);
                    this.Close();

                }
                else
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
                    salvarUsuario.Senha = _IAppServicoUsuario.CriptogravarSenha(passSenha.Password);

                    salvarUsuario.AbrirFecharLivro = ckbAbrirFecharLivro.IsChecked.Value;
                    salvarUsuario.AlterarAtos = ckbAlterarAtos.IsChecked.Value;
                    salvarUsuario.FechamentoMes = ckbFechamentoMes.IsChecked.Value;
                    salvarUsuario.ImportarMas = ckbImportarMas.IsChecked.Value;
                    salvarUsuario.ImprimirFechamentoMes = ckbImprimirFechamentoMes.IsChecked.Value;
                    salvarUsuario.UsuarioMaster = ckbMaster.IsChecked.Value;

                    if (acao == "alterar")
                    {
                        _IAppServicoUsuario.Update(salvarUsuario);

                        string descricao = "Alterou o usuário " + usuarioAnterior + " para " + salvarUsuario.Nome;

                        cmbUsuario.Items.Refresh();

                        cmbUsuario.SelectedIndex = -1;

                        cmbUsuario.Text = salvarUsuario.Nome;
                        txtNomeUsuario.Text = salvarUsuario.Nome;
                        passSenha.Password = salvarUsuario.Senha;
                    }
                    else
                    {

                        _IAppServicoUsuario.Add(salvarUsuario);


                        _usuarios.Add(salvarUsuario);
                        cmbUsuario.ItemsSource = _usuarios;
                        cmbUsuario.Items.Refresh();
                        cmbUsuario.Text = salvarUsuario.Nome;
                    }

                    MessageBox.Show("Usuário cadastrado com sucesso!", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Information);



                    FecharCampos();
                    acao = "pronto";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado, " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FecharCampos()
        {

            toolBarPanel.IsEnabled = true;

            if (_usuario != null)
            {
                if (_usuario.UsuarioMaster == true || _usuario.Nome == "Administrador")
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

        private void ckbMaster_Checked(object sender, RoutedEventArgs e)
        {
            ckbAbrirFecharLivro.IsChecked = true;
            ckbAlterarAtos.IsChecked = true;
            ckbFechamentoMes.IsChecked = true;
            ckbImportarMas.IsChecked = true;
            ckbImprimirFechamentoMes.IsChecked = true;


            ckbAbrirFecharLivro.IsEnabled = false;
            ckbAlterarAtos.IsEnabled = false;
            ckbFechamentoMes.IsEnabled = false;
            ckbImportarMas.IsEnabled = false;
            ckbImprimirFechamentoMes.IsEnabled = false;

        }

        private void ckbMaster_Unchecked(object sender, RoutedEventArgs e)
        {
            ckbAbrirFecharLivro.IsChecked = false;
            ckbAlterarAtos.IsChecked = false;
            ckbFechamentoMes.IsChecked = false;
            ckbImportarMas.IsChecked = false;
            ckbImprimirFechamentoMes.IsChecked = false;


            ckbAbrirFecharLivro.IsEnabled = true;
            ckbAlterarAtos.IsEnabled = true;
            ckbFechamentoMes.IsEnabled = true;
            ckbImportarMas.IsEnabled = true;
            ckbImprimirFechamentoMes.IsEnabled = true;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

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

                    ckbMaster.IsChecked = usu.UsuarioMaster;
                    ckbAbrirFecharLivro.IsChecked = usu.AbrirFecharLivro;
                    ckbAlterarAtos.IsChecked = usu.AlterarAtos;
                    ckbFechamentoMes.IsChecked = usu.FechamentoMes;
                    ckbImportarMas.IsChecked = usu.ImportarMas;
                    ckbImprimirFechamentoMes.IsChecked = usu.ImprimirFechamentoMes;


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
            acao = "adicionar";


        }

        private void AbrirCampos()
        {
            groupUsuarioSenha.IsEnabled = true;

            if (_usuario != null)
            {
                if (_usuario.UsuarioMaster == true || _usuario.Nome == "Administrador")
                {
                    groupPermissoes.IsEnabled = true;
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

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            AbrirCampos();
            passSenha.Password = _IAppServicoUsuario.DecriptogravarSenha(passSenha.Password);
            acao = "alterar";
            verificarSeAlterou = string.Format("{0}{1}", txtNomeUsuario.Text, passSenha.Password);
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
                    _IAppServicoUsuario.Remove(usuarioExcluir);


                    _usuarios.Remove(usuarioExcluir);

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
    }
}
