using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.WindowsAguarde;
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
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Usuario _usuario;

        private readonly IAppServicoServentia _AppServicoServentia = BootStrap.Container.GetInstance<IAppServicoServentia>();

        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();



        IEnumerable<Serventia> dadosServentia;

        public Parametros parametros;

        public string autorizacao;

        public Principal(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblNomeUsuario.Content = string.Format("{0} {1}", "USUÁRIO: ", _usuario.NomeUsuario);

            dadosServentia = _AppServicoServentia.GetAll();

            parametros = _AppServicoParametros.GetAll().FirstOrDefault();

            if (dadosServentia.Count() < 1)
            {
                MessageBox.Show("Cadastre os dados da Serventia.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                var cadServentia = new CadastroServentia(_usuario, this);
                cadServentia.Owner = this;
                cadServentia.btnCancelar.IsEnabled = false;
                cadServentia.ShowDialog();

                dadosServentia = _AppServicoServentia.GetAll();
            }

            lblNomeCartorio.Content = dadosServentia.FirstOrDefault().Descricao;
        }


        private void MenuSubItemServentia_Click(object sender, RoutedEventArgs e)
        {
            if (_usuario.NomeUsuario != "Administrador")
            {
                VerificarSenhaMaster();

                if (autorizacao != "autorizado")
                {
                    return;
                }
            }

            var serventia = new CadastroServentia(_usuario, this);
            serventia.Owner = this;
            serventia.ShowDialog();

            dadosServentia = _AppServicoServentia.GetAll();

            lblNomeCartorio.Content = dadosServentia.FirstOrDefault().Descricao;
        }


        private void MenuSubItemUsuario_Click(object sender, RoutedEventArgs e)
        {

            if (_usuario.NomeUsuario != "Administrador")
            {
                VerificarSenhaMaster();

                if (autorizacao != "autorizado")
                {
                    return;
                }
            }

            var cadastroUsuario = new CadastroUsuario(_usuario);
            cadastroUsuario.Owner = this;
            cadastroUsuario.ShowDialog();
            lblNomeUsuario.Content = _usuario.NomeUsuario;
        }

        private void MenuSubItemImprimirIndisponibilidade_Click(object sender, RoutedEventArgs e)
        {
            var indisponibilidade = new CadastroIndisponibilidade(_usuario);
            indisponibilidade.Owner = this;
            indisponibilidade.ShowDialog();
        }

        private void btnLancamentos_Click(object sender, RoutedEventArgs e)
        {
            var lancamentos = new CadastroLancamentos(_usuario);
            lancamentos.Owner = this;
            lancamentos.ShowDialog();
        }

        private void btnFornecedores_Click(object sender, RoutedEventArgs e)
        {
            var fornecedor = new CadastroFornecedor(_usuario);
            fornecedor.Owner = this;
            fornecedor.ShowDialog();
        }

        private void btnBancos_Click(object sender, RoutedEventArgs e)
        {
            var bancos = new CadastroBancos(_usuario);
            bancos.Owner = this;
            bancos.ShowDialog();
        }

        private void btnPlanos_Click(object sender, RoutedEventArgs e)
        {
            var plano = new CadastroPlanoContas(_usuario);
            plano.Owner = this;
            plano.ShowDialog();


        }

        private void btnSeloEletronico_Click(object sender, RoutedEventArgs e)
        {
            var selos = new AguardeProcessandoSelos(this, _usuario);
            selos.Owner = this;
            selos.ShowDialog();
        }

        private void MenuSubItemConfigDiretorios_Click(object sender, RoutedEventArgs e)
        {
            if (_usuario.NomeUsuario != "Administrador")
            {
                VerificarSenhaMaster();

                if (autorizacao != "autorizado")
                {
                    return;
                }
            }

            var configDiretorios = new ParametrosConfigDiretorios(_usuario);
            configDiretorios.Owner = this;
            configDiretorios.ShowDialog();
        }

        private void MenuSubItemSenha_Click(object sender, RoutedEventArgs e)
        {

           
            var senhaMaster = new CadastroSenhaMaster(_usuario);
            senhaMaster.Owner = this;
            senhaMaster.ShowDialog();
        }


        private string VerificarSenhaMaster()
        {
            autorizacao = string.Empty;


            var verificarSenha = new InformarSenhaMaster(this);
            verificarSenha.Owner = this;
            verificarSenha.ShowDialog();

            if (autorizacao != "autorizado")
            {

                return "não autorizado";
            }

            return autorizacao;
        }

    }
}
