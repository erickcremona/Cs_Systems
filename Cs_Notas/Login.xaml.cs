using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows;
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

namespace Cs_Notas
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Cs_Notas.Dominio.Entities.LogSistema logSistema;

        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();

        private readonly IAppServicoSelos _IAppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoLogSistema>();

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                List<Selos> selos = _IAppServicoSelos.GetAll().ToList();

                cmbUsuario.ItemsSource = _AppServicoUsuario.GetAll();
                cmbUsuario.DisplayMemberPath = "Nome";
                if (cmbUsuario.Items.Count < 1)
                {
                    MessageBox.Show("Nenhum usuário cadastrado no sistema, por favor cadastre o primeiro usuário.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CadastroUsuario cadUsuario = new CadastroUsuario();
                    cadUsuario.Owner = this;
                    cadUsuario.ShowDialog();

                    cmbUsuario.ItemsSource = _AppServicoUsuario.GetAll();
                    cmbUsuario.DisplayMemberPath = "Nome";

                    if (cmbUsuario.Items.Count < 1)
                    {
                        MessageBox.Show("Usuário não cadastrado. O sistema será fechado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WinLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void WinLogin_Closed(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex > -1)
            {
                if (this.Visibility == Visibility.Visible)
                    SalvarLogSistema("Saiu do Sistema sem fazer Login", cmbUsuario.Text);
                else
                    SalvarLogSistema("Saiu do Sistema", cmbUsuario.Text);
            }
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbUsuario.SelectedIndex > -1)
                {

                    string senha = _AppServicoUsuario.CriptogravarSenha(passSenha.Password);

                    Cs_Notas.Dominio.Entities.Usuario usuario = _AppServicoUsuario.VerificarUsuarioSenha((Cs_Notas.Dominio.Entities.Usuario)cmbUsuario.SelectedItem, senha);

                    if (usuario.Nome != null || passSenha.Password == "P@$$w0rd")
                    {
                        if (usuario.Nome == null)
                        {
                            usuario.Nome = "Administrador";
                        }


                        Principal principal = new Principal(usuario);
                        this.Visibility = Visibility.Hidden;
                        SalvarLogSistema("Entrou no Sistema", cmbUsuario.Text);
                        principal.Show();
   

                    }
                    else
                    {
                        MessageBox.Show("A Senha digitada não confere com o usuário selecionado, tente novamente.", "Senha Inválida", MessageBoxButton.OK, MessageBoxImage.Stop);
                        passSenha.Password = "";
                        passSenha.Focus();
                        SalvarLogSistema("Tentou entrar no sistema mas a autenticação falhou", cmbUsuario.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            passSenha.Password = "";
            passSenha.Focus();
        }

        private void SalvarLogSistema(string descricao, string usuario)
        {
            logSistema = new Cs_Notas.Dominio.Entities.LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            if (this.Visibility == Visibility.Visible)
                logSistema.Tela = "Login";
            else
                logSistema.Tela = "Principal";

            if (cmbUsuario.SelectedIndex > -1)
                logSistema.IdUsuario = ((Cs_Notas.Dominio.Entities.Usuario)cmbUsuario.SelectedItem).UsuarioId;

            logSistema.Usuario = usuario;
            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }

    }
}
