using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows.Procuracao;
using Cs_Notas.Windows.Testamento;
using Cs_Notas.WindowsAgurde;
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
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {


        private readonly IAppServicoServentia _AppServicoServentia = BootStrap.Container.GetInstance<IAppServicoServentia>();

        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();


        IEnumerable<Serventia> dadosServentia;

        Configuracoes config;

        Cs_Notas.Dominio.Entities.Usuario _usuario;

        public Principal(Cs_Notas.Dominio.Entities.Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                dadosServentia = _AppServicoServentia.GetAll();
                lblNomeCartorio.Content = dadosServentia.FirstOrDefault().Descricao;
                lblNomeUsuario.Content = string.Format("Usuário: {0}", _usuario.Nome);

                config = _AppServicoConfiguracoes.GetAll().FirstOrDefault();

                if (config == null)
                {
                    config = new Configuracoes();
                    _AppServicoConfiguracoes.Add(config);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("É necessário configurar o Gerencial. O Notas será fechado.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                Application.Current.Shutdown();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void MenuItemCadUsuario_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemCadUsuario.Foreground = Brushes.Black;
        }

        private void MenuItemCadUsuario_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemCadUsuario.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemCadUsuario_Click(object sender, RoutedEventArgs e)
        {
            var cadUsuario = new CadastroUsuario(_usuario);
            cadUsuario.Owner = this;
            cadUsuario.ShowDialog();

            lblNomeUsuario.Content = _usuario.Nome;
        }

        private void MenuItemReservaSelo_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemReservaSelo.Foreground = Brushes.Black;
        }

        private void MenuItemReservaSelo_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemReservaSelo.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemReservaSelo_Click(object sender, RoutedEventArgs e)
        {
            if (_usuario.ReservarSelo == "S" || _usuario.Master == "S" || _usuario.Nome == "Administrador")
            {
                var reservarSelos = new ReservarSelos(_usuario);
                reservarSelos.Owner = this;
                reservarSelos.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário logado não tem permissão para Reservar Selos.", "Permissão Negada", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void MenuItemSerieSelo_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemSerieSelo.Foreground = Brushes.Black;
        }

        private void MenuItemSerieSelo_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemSerieSelo.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemSerieSelo_Click(object sender, RoutedEventArgs e)
        {

            if (_usuario.AlterarSelo == "S" || _usuario.Master == "S" || _usuario.Nome == "Administrador")
            {
                var seloAtual = new SerieSeloAtual(_usuario);
                seloAtual.Owner = this;
                seloAtual.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário logado não tem permissão para Alterar a Série do Selos.", "Permissão Negada", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void btnEscritura_Click(object sender, RoutedEventArgs e)
        {
            var selosReservados = new SelosReservados(_usuario, "ESCRITURA", this);
            selosReservados.Owner = this;
            selosReservados.ShowDialog();
        }

        private void btnProcuração_Click(object sender, RoutedEventArgs e)
        {
            var selosReservados = new SelosReservados(_usuario, "PROCURAÇÃO", this);
            selosReservados.Owner = this;
            selosReservados.ShowDialog();
        }

        private void btnTestamento_Click(object sender, RoutedEventArgs e)
        {
            var selosReservados = new SelosReservados(_usuario, "TESTAMENTO", this);
            selosReservados.Owner = this;
            selosReservados.ShowDialog();
        }

        private void btnCertidao_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItemExportarBaseDados_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemExportarBaseDados.Foreground = Brushes.Black;
        }

        private void MenuItemExportarBaseDados_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemExportarBaseDados.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemExportarBaseDados_Click(object sender, RoutedEventArgs e)
        {
            //if (_usuario.Nome == "Administrador")
            //{
            //    if (MessageBox.Show("Deseja importar Base de Dados?", "Importar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //    {
            //        var exportar = new AguardeImpotarBaseDados();
            //        exportar.Owner = this;
            //        exportar.ShowDialog();
            //    }
            //}
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void menuBtnConsultarEscrituras_Click(object sender, RoutedEventArgs e)
        {
            var consulta = new ConsultarAtos(_usuario);
            consulta.Owner = this;
            consulta.ShowDialog();
        }

        private void MenuItemAtualizarCustas_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItemAtualizarCustas.Foreground = Brushes.Black;
        }

        private void MenuItemAtualizarCustas_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItemAtualizarCustas.Foreground = Brushes.AliceBlue;
        }

        private void MenuItemAtualizarCustas_Click(object sender, RoutedEventArgs e)
        {
            MenuItemAtualizarCustas.Foreground = Brushes.AliceBlue;
        }

        private void menuBtnConsultarEscrituras_MouseEnter(object sender, MouseEventArgs e)
        {
            menuBtnConsultarEscrituras.Foreground = Brushes.Black;
        }

        private void menuBtnConsultarEscrituras_MouseLeave(object sender, MouseEventArgs e)
        {
            menuBtnConsultarEscrituras.Foreground = Brushes.AliceBlue;
        }

      
        private void menuBtnConsultarProcuracao_MouseEnter(object sender, MouseEventArgs e)
        {
            menuBtnConsultarProcuracao.Foreground = Brushes.Black;
        }

        private void menuBtnConsultarProcuracao_MouseLeave(object sender, MouseEventArgs e)
        {
            menuBtnConsultarProcuracao.Foreground = Brushes.AliceBlue;
        }

        private void menuBtnConsultarTestamento_MouseEnter(object sender, MouseEventArgs e)
        {
            menuBtnConsultarTestamento.Foreground = Brushes.Black;
        }

        private void menuBtnConsultarTestamento_MouseLeave(object sender, MouseEventArgs e)
        {
            menuBtnConsultarTestamento.Foreground = Brushes.AliceBlue;
        }

        private void menuBtnConsultarProcuracao_Click(object sender, RoutedEventArgs e)
        {
            var consulta = new ConsultaAtosProcuracao(_usuario);
            consulta.Owner = this;
            consulta.ShowDialog();
        }

        private void menuBtnConsultarTestamento_Click(object sender, RoutedEventArgs e)
        {
            var consulta = new ConsultaAtosTestamento(_usuario);
            consulta.Owner = this;
            consulta.ShowDialog();
        }

       


    }
}
