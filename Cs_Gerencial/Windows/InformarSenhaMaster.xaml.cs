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
    /// Interaction logic for InformarSenhaMaster.xaml
    /// </summary>
    public partial class InformarSenhaMaster : Window
    {
        private readonly IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<IAppServicoUsuario>();

        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();

        string metodo;

        Principal _principal;

        public InformarSenhaMaster(Principal principal)
        {
            _principal = principal;
            metodo = "princial";
            InitializeComponent();
        }
        
        EstoqueSelos _estoqueSelos;

        
        public InformarSenhaMaster(EstoqueSelos estoqueSelos)
        {
            _estoqueSelos = estoqueSelos;
            metodo = "estoqueSelos";
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (metodo)
                {
                    case "princial":
                        SalvarPrincipal();
                        break;
                    case "estoqueSelos":
                        SalvarEstoqueSelos();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

            passSenhaAtual.Focus();
        }

       
        private void SalvarEstoqueSelos()
        {

            string senha = _AppServicoUsuario.DecriptogravarSenha(_estoqueSelos.parametros.SenhaMaster);

            if (senha == passSenhaAtual.Password)
            {
                _estoqueSelos.autorizacao = "autorizado";
            }
            else
            {
                MessageBox.Show("Senha inválida", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                _estoqueSelos.autorizacao = "não autorizado";
                passSenhaAtual.Focus();
                passSenhaAtual.SelectAll();

                return;
            }

            Close();
        }

        private void SalvarPrincipal()
        {
            
            string senha = _AppServicoUsuario.DecriptogravarSenha(_principal.parametros.SenhaMaster);

            if (senha == passSenhaAtual.Password)
            {
                _principal.autorizacao = "autorizado";
            }
            else
            {
                MessageBox.Show("Senha inválida", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                _principal.autorizacao = "não autorizado";
                passSenhaAtual.Focus();
                passSenhaAtual.SelectAll();

                return;
            }

            Close();
        }

        private void passSenhaAtual_PreviewKeyDown(object sender, KeyEventArgs e)
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
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
