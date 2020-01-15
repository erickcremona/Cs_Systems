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
    /// Interaction logic for CadastroSenhaMaster.xaml
    /// </summary>
    public partial class CadastroSenhaMaster : Window
    {

        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();

        private readonly IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<IAppServicoUsuario>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        Usuario _usuario;

        Parametros parametros;

        string senhaAtual;

        LogSistema logSistema;

        public CadastroSenhaMaster(Usuario usuario)
        {
            _usuario = usuario;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            parametros = _AppServicoParametros.GetAll().FirstOrDefault();

            senhaAtual = _AppServicoUsuario.DecriptogravarSenha(parametros.SenhaMaster);

            if (_usuario.NomeUsuario == "Administrador")
            {
                gropBoxSenhaAtual.IsEnabled = false;
                passSenhaNova.IsEnabled = true;
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            parametros.SenhaMaster = _AppServicoUsuario.CriptogravarSenha(passSenhaNova.Password);

            _AppServicoParametros.Update(parametros);

            SalvarLogSistema("Alterou a Senha Master");

            Close();
        }

        private void passSenhaAtual_PasswordChanged(object sender, RoutedEventArgs e)
        {
            VerificarSenhaMasterAtual();
        }

        private void passSenhaNova_PasswordChanged(object sender, RoutedEventArgs e)
        {
            VerificarSenhaMasterAtual();
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Cadastro Senha Master";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }

        private void VerificarSenhaMasterAtual()
        {
            if (senhaAtual == passSenhaAtual.Password || _usuario.NomeUsuario == "Administrador")
            {
                
                passSenhaNova.IsEnabled = true;

                if(passSenhaNova.Password.Length >= 4)
                    btnSalvar.IsEnabled = true;
                else
                    btnSalvar.IsEnabled = false;
            }
            else
            {
                passSenhaNova.IsEnabled = false;
                btnSalvar.IsEnabled = false;
            }

            if (_usuario.NomeUsuario == "Administrador")
            {
                btnSalvar.IsEnabled = true;
                passSenhaNova.IsEnabled = true;
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

        private void passSenhaAtual_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void passSenhaNova_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }
    }
}
