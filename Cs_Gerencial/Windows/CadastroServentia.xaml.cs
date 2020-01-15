using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cs_Gerencial.Windows
{
    /// <summary>
    /// Interaction logic for CadastroServentia.xaml
    /// </summary>
    public partial class CadastroServentia : Window
    {
        Usuario _usuario;

        string salvar;

        Serventia serventiaAtual;

        LogSistema logSistema;

        Principal _principal;

        List<Atribuicoes> atribuicoes;

        List<Atribuicoes> atribuicoesAtuais;

        bool adicionarAtribuicao = true;

        string verificarSeAlterou;

        private readonly IAppServicoServentia _AppServicoServentia = BootStrap.Container.GetInstance<IAppServicoServentia>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();

        private readonly IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<IAppServicoUsuario>();

        private readonly IAppServicoAtribuicoes _AppServicoAtribuicoes = BootStrap.Container.GetInstance<IAppServicoAtribuicoes>();

        public CadastroServentia(Usuario usuario, Principal principal)
        {
            _usuario = usuario;
            _principal = principal;
            InitializeComponent();
        }


        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3);
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtCep_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtTelefone1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtTelefone2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtCep_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtCep.Text != "")
                txtCep.Text = FormatarCep(txtCep.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string FormatarCep(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");

                if (cep.Length == 8)
                {
                    cep = string.Format("{0}-{1}", cep.Substring(0, 5), cep.Substring(5, 3));
                }
                else
                {
                    cep = string.Format("{0:00000000}", Convert.ToInt32(cep));

                    cep = string.Format("{0}-{1}", cep.Substring(0, 5), cep.Substring(5, 3));
                }


                return cep;
            }
            catch (Exception) { return null; }
        }

        private string FormatarTelefone(string telefone)
        {
            try { 
            telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "");


            if (telefone.Length == 10)
            {
                telefone = string.Format("({0}){1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 4), telefone.Substring(6, 4));
            }
            else
            {

                telefone = string.Format("{0:0000000000}", Convert.ToInt32(telefone));

                telefone = string.Format("({0}){1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 4), telefone.Substring(6, 4));
            }

            return telefone;
            }
            catch (Exception) { return null; }
        }

        private void txtTelefone1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTelefone1.Text != "")
                    txtTelefone1.Text = FormatarTelefone(txtTelefone1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTelefone2_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTelefone2.Text != "")
                    txtTelefone2.Text = FormatarTelefone(txtTelefone2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCep_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCep.Text = txtCep.Text.Replace("-", "");
        }

        private void txtTelefone1_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTelefone1.Text = txtTelefone1.Text.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private void txtTelefone2_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTelefone2.Text = txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Serventia> serventia = _AppServicoServentia.GetAll();
            
            atribuicoes = _AppServicoAtribuicoes.GetAll().ToList();

            atribuicoesAtuais = new List<Atribuicoes>(atribuicoes);


            if(serventia.Count() > 0)
            {
                salvar = "alterar";
                serventiaAtual = serventia.FirstOrDefault();
                verificarSeAlterou = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}",
                    serventiaAtual.CodigoServentia, serventiaAtual.Descricao, serventiaAtual.Endereco, serventiaAtual.Bairro, serventiaAtual.Cidade,
                     serventiaAtual.Uf, serventiaAtual.Cep, serventiaAtual.Telefone, serventiaAtual.Telefone2, serventiaAtual.Responsavel,
                     serventiaAtual.Substituto, serventiaAtual.Email);
                CarregarCampos(serventiaAtual);
                
            }
            else
            {
                salvar = "salvar";
                serventiaAtual = new Serventia();
            }

            
        }

        private void CarregarCampos(Serventia serventia)
        {
            adicionarAtribuicao = false;

            foreach (var item in atribuicoes)
            {
                 Atribuicoes atribuicao = atribuicoes.Where(p => p.Descricao.Contains(item.Descricao)).FirstOrDefault();

                 switch (atribuicao.Codigo)
                 {
                     case 1:
                         ckbDistribuicao.IsChecked = true;
                         break;

                     case 2:
                         ckbNotas.IsChecked = true;
                         break;

                     case 3:
                         ckbRcpn.IsChecked = true;
                         break;

                     case 4:
                         ckbProtesto.IsChecked = true;
                         break;

                     case 5:
                         ckbRgi.IsChecked = true;
                         break;

                     case 6:
                         ckbTitulosDocumentos.IsChecked = true;
                         break;

                     case 7:
                         ckbRcpj.IsChecked = true;
                         break;

                     case 8:
                         ckbInterdicoesTutelas.IsChecked = true;
                         break;

                     default:
                         break;
                 }
                               
            }

            adicionarAtribuicao = true;

            txtCodigo.Text = serventia.CodigoServentia.ToString();
            txtDescricao.Text = serventia.Descricao;
            txtEndereco.Text = serventia.Endereco;
            txtBairro.Text = serventia.Bairro;
            txtCidade.Text = serventia.Cidade;
            txtUf.Text = serventia.Uf;
            txtEstado.Text = serventia.Estado;
            txtCep.Text = FormatarCep(serventia.Cep);
            txtTelefone1.Text = FormatarTelefone(serventia.Telefone);
            txtTelefone2.Text = FormatarTelefone(serventia.Telefone2);
            txtResponsavel.Text = serventia.Responsavel;
            txtSubstituto.Text = serventia.Substituto;
            txtEmail.Text = serventia.Email;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Informe o Código da Serventia.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtCodigo.Focus();
                return;
            }

            txtDescricao.Text =  txtDescricao.Text.Trim();

            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Informe a Descrição da Serventia.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtDescricao.Focus();
                return;
            }

            serventiaAtual.CodigoServentia = Convert.ToInt16(txtCodigo.Text);
            serventiaAtual.Descricao = txtDescricao.Text;
            serventiaAtual.Endereco = txtEndereco.Text;
            serventiaAtual.Bairro = txtBairro.Text;
            serventiaAtual.Cidade = txtCidade.Text;
            serventiaAtual.Uf = txtUf.Text;
            serventiaAtual.Estado = txtEstado.Text;
            serventiaAtual.Cep = txtCep.Text.Replace("-","");
            serventiaAtual.Telefone = txtTelefone1.Text.Replace("(", "").Replace(")", "").Replace("-", "");
            serventiaAtual.Telefone2 = txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "");
            serventiaAtual.Responsavel = txtResponsavel.Text;
            serventiaAtual.Substituto = txtSubstituto.Text;
            serventiaAtual.Email = txtEmail.Text;

           
            try
            {
                
                if (salvar == "alterar")
                {
                    _AppServicoServentia.Update(serventiaAtual);

                    SalvarAtribuicoes();

                    string alteracao = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}",
                    txtCodigo.Text, txtDescricao.Text, txtEndereco.Text, txtBairro.Text, txtCidade.Text,
                     txtUf.Text, txtCep.Text, txtTelefone1.Text, txtTelefone2.Text, txtResponsavel.Text,
                     txtResponsavel.Text, txtSubstituto.Text, txtEmail.Text);

                    

                    if(verificarSeAlterou != alteracao)
                    SalvarLogSistema("Alterou dados da Serventia");

                    
                }
                else
                {
                    _AppServicoServentia.Add(serventiaAtual);

                    SalvarAtribuicoes();

                    var parametros = new Parametros();
                    parametros.SenhaMaster = _AppServicoUsuario.CriptogravarSenha(txtCodigo.Text);
                    parametros.PathSelosNaoImportados = @"C:\";
                    parametros.PathSelosImportados = @"C:\";
                    parametros.PathSelosCenib = @"C:\";
                    _AppServicoParametros.Add(parametros);

                    _principal.parametros = parametros;

                    SalvarLogSistema("Primeira inclusão dos dados da Serventia");
                }

                allowClosing = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                allowClosing = true;
                Close();
            }
            
        }

        private void SalvarAtribuicoes()
        {


            foreach (var item in atribuicoesAtuais)
            {
                _AppServicoAtribuicoes.Remove(item);
            }

            foreach (var item in atribuicoes)
            {
                _AppServicoAtribuicoes.Add(item);
            }
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Cadastro da Serventia";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }



        // Desabilitar botao Close do form ------------------------------------------------------

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;

            if (hwndSource != null)
            {
                hwndSource.AddHook(HwndSourceHook);
            }

        }

        private bool allowClosing = false;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        private const uint MF_BYCOMMAND = 0x00000000;
        private const uint MF_GRAYED = 0x00000001;

        private const uint SC_CLOSE = 0xF060;

        private const int WM_SHOWWINDOW = 0x00000018;
        private const int WM_CLOSE = 0x10;

        private IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_SHOWWINDOW:
                    {
                        IntPtr hMenu = GetSystemMenu(hwnd, false);
                        if (hMenu != IntPtr.Zero)
                        {
                            EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
                        }
                    }
                    break;
                case WM_CLOSE:
                    if (!allowClosing)
                    {
                        handled = true;
                    }
                    break;
            }
            return IntPtr.Zero;
        }
        // Desabilitar botao Close do form ---------------------------------------------------------




        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            allowClosing = true;
            Close();
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

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbDistribuicao_Checked(object sender, RoutedEventArgs e)
        {

            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 1;

                atribuicao.Descricao = ckbDistribuicao.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbDistribuicao_Unchecked(object sender, RoutedEventArgs e)
        {

            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 1).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }

        private void ckbNotas_Checked(object sender, RoutedEventArgs e)
        {
            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 2;

                atribuicao.Descricao = ckbNotas.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbNotas_Unchecked(object sender, RoutedEventArgs e)
        {
            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 2).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }

        private void ckbRcpn_Checked(object sender, RoutedEventArgs e)
        {
            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 3;

                atribuicao.Descricao = ckbRcpn.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbRcpn_Unchecked(object sender, RoutedEventArgs e)
        {
            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 3).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }

        private void ckbProtesto_Checked(object sender, RoutedEventArgs e)
        {
            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 4;

                atribuicao.Descricao = ckbProtesto.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbProtesto_Unchecked(object sender, RoutedEventArgs e)
        {
            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 4).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }

        private void ckbRgi_Checked(object sender, RoutedEventArgs e)
        {
            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 5;

                atribuicao.Descricao = ckbRgi.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbRgi_Unchecked(object sender, RoutedEventArgs e)
        {
            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 5).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }

        private void ckbTitulosDocumentos_Checked(object sender, RoutedEventArgs e)
        {
            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 6;

                atribuicao.Descricao = ckbTitulosDocumentos.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbTitulosDocumentos_Unchecked(object sender, RoutedEventArgs e)
        {
            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 6).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }

        private void ckbRcpj_Checked(object sender, RoutedEventArgs e)
        {
            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 7;

                atribuicao.Descricao = ckbRcpj.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbRcpj_Unchecked(object sender, RoutedEventArgs e)
        {
            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 7).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }

        private void ckbInterdicoesTutelas_Checked(object sender, RoutedEventArgs e)
        {
            if (adicionarAtribuicao)
            {
                Atribuicoes atribuicao = new Atribuicoes();

                atribuicao.Codigo = 8;

                atribuicao.Descricao = ckbInterdicoesTutelas.Content.ToString();

                atribuicoes.Add(atribuicao);
            }
        }

        private void ckbInterdicoesTutelas_Unchecked(object sender, RoutedEventArgs e)
        {
            Atribuicoes atribuicao = atribuicoes.Where(p => p.Codigo == 8).FirstOrDefault();
            atribuicoes.Remove(atribuicao);
        }


    }
}
