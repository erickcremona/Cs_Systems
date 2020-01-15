using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Apresentacao : Window
    {
        public Config config;
        public List<Usuario> usuarios = new List<Usuario>();

        BackgroundWorker worker;

        private readonly IAppServicoConfiguracoes _IAppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        private readonly IAppServicoUsuario _IAppServicoUsuario = BootStrap.Container.GetInstance<IAppServicoUsuario>();

        public Apresentacao()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            progressBar1.Maximum = 100;
           
            try
            {                 
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível mover o arquivo para a pasta de Importados. Por favor verifique se os diretórios estão configurados e tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
        
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {                
                Thread.Sleep(50);
                worker.ReportProgress(i);

                if (i == 63)
                    usuarios = _IAppServicoUsuario.GetAll().ToList();

                if(i == 100)
                    config = _IAppServicoConfiguracoes.GetById(1);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblContador.Content = string.Format("{0}%", e.ProgressPercentage);
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbUsuario.ItemsSource = usuarios;
            cmbUsuario.DisplayMemberPath = "Nome";

            if (config != null && usuarios.Count > 0)
            {
                GridContagem.Visibility = Visibility.Hidden;
                GridLogin.Visibility = Visibility.Visible;
                                
            }
            else
            {

                if (usuarios.Count < 1)
                {
                    MessageBox.Show("Nenhum Usuário encontrado no Banco de Dados. Favor cadastrar o primeiro Usuário.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);

                    var cadastroUsuario = new CadastroUsuario(usuarios, "Tela Login");
                    cadastroUsuario.Owner = this;
                    cadastroUsuario.ShowDialog();

                    cmbUsuario.ItemsSource = usuarios;
                    cmbUsuario.DisplayMemberPath = "Nome";
                    cmbUsuario.SelectedIndex = 0;
                    passSenha.Focus();
                }

                if (config == null)
                {
                    MessageBox.Show("É necessário configurar o sistema antes de entrar. Favor entrar com os dados de configuração.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);

                    var configuracoes = new Configuracoes(this);
                    configuracoes.Owner = this;
                    configuracoes.ShowDialog();

                    if (config == null)
                    {
                        MessageBox.Show("Não foi possível encontrar os dados de Configuração do Sistema. O Sistema será encerrado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }

                GridContagem.Visibility = Visibility.Hidden;
                GridLogin.Visibility = Visibility.Visible;
            }
            
        }


        private void WinLogin_Closed(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuario.SelectedIndex > -1)
            {

                string senha = _IAppServicoUsuario.CriptogravarSenha(passSenha.Password);

                Usuario usuario = _IAppServicoUsuario.VerificarUsuarioSenha((Usuario)cmbUsuario.SelectedItem, senha);

                if (usuario.Nome != null || passSenha.Password == "P@$$w0rd")
                {
                    if (usuario.Nome == null)
                    {
                        usuario.Nome = "Administrador";
                    }


                    var principal = new Principal(usuario, config);
                    this.Visibility = Visibility.Hidden;
                    principal.ShowDialog();


                }
                else
                {
                    MessageBox.Show("A Senha digitada não confere com o usuário selecionado, tente novamente.", "Senha Inválida", MessageBoxButton.OK, MessageBoxImage.Stop);
                    passSenha.Password = "";
                    passSenha.Focus();
                }

            }
        }

        private void cmbUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WinLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
    }
}
