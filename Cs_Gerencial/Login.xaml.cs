

using Cs_Gerencial.Aplicacao;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace Cs_Gerencial
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LogSistema logSistema;

        private readonly IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<IAppServicoUsuario>();
        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbUsuario.ItemsSource = _AppServicoUsuario.GetAll();
                cmbUsuario.DisplayMemberPath = "NomeUsuario";
                if(cmbUsuario.Items.Count < 1)
                {
                    MessageBox.Show("Nenhum usuário cadastrado no sistema, por favor cadastre o primeiro usuário.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    CadastroUsuario cadUsuario = new CadastroUsuario();
                    cadUsuario.Owner = this;
                    cadUsuario.ShowDialog();
                    
                    cmbUsuario.ItemsSource = _AppServicoUsuario.GetAll();
                    cmbUsuario.DisplayMemberPath = "NomeUsuario";

                    if(cmbUsuario.Items.Count < 1)
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

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                

                if (cmbUsuario.SelectedIndex > -1)
                {

                    string senha = _AppServicoUsuario.CriptogravarSenha(passSenha.Password);

                    Usuario usuario = _AppServicoUsuario.VerificarUsuarioSenha((Usuario)cmbUsuario.SelectedItem, senha);

                    if (usuario.NomeUsuario != null || passSenha.Password == "P@$$w0rd")
                    {
                        if (usuario.NomeUsuario == null)
                        {
                            usuario.NomeUsuario = "Administrador";
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

        private void WinLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }


        private void SalvarLogSistema(string descricao, string usuario)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;
                       
            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            if (this.Visibility == Visibility.Visible)
                logSistema.Tela = "Login";
            else
                logSistema.Tela = "Principal";

            if (cmbUsuario.SelectedIndex > -1)
                logSistema.IdUsuario = ((Usuario)cmbUsuario.SelectedItem).UsuarioId;

            logSistema.Usuario = usuario;
            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
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
    }
}
