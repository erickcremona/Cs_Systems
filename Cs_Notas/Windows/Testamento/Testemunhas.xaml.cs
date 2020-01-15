using CrossCutting;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.ValuesObject;
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

namespace Cs_Notas.Windows.Testamento
{
    /// <summary>
    /// Lógica interna para Testemunhas.xaml
    /// </summary>
    public partial class Testemunhas : Window
    {

        public DigitarTestamento _digitarTestamento;
        List<EstadoCivil> estadoCivil;
        string estado = string.Empty;
        Nomes nome = new Nomes();
        public Pessoas pessoa = new Pessoas();
        Participante participante = new Participante();
        
        private readonly IAppServicoNacionalidades _AppServicoNacionalidades = BootStrap.Container.GetInstance<IAppServicoNacionalidades>();
        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        public Testemunhas(DigitarTestamento digitarTestamento)
        {

            _digitarTestamento = digitarTestamento;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            FecharCampos();
            dataGridParticipantes.IsEnabled = true;
            btnAdicionarParte.IsEnabled = true;
            btnCancelar.IsEnabled = false;
            btnSalvar.IsEnabled = false;

            if (dataGridParticipantes.SelectedItem != null)
                CarregarCampos();
            else
                LimparCampos();

            TornarCamposPretos();

            estado = "pronto";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarNacionalidades();
            CarregarEstadoCivil();
            FecharCampos();

            btnCancelar.IsEnabled = false;
            btnSalvar.IsEnabled = false;

            dataGridParticipantes.ItemsSource = _digitarTestamento.participantes;
            dataGridParticipantes.SelectedIndex = 0;

            if (dataGridParticipantes.Items.Count > 0)
                dataGridParticipantes.IsEnabled = true;
            else
                dataGridParticipantes.IsEnabled = false;

            btnAdicionarParte.Focus();
        }

        private void CarregarEstadoCivil()
        {
            var ec = new EstadoCivil();
            var indiceSelecao = cmbEstadoCivil.SelectedIndex;
            gbEstadoCivil.IsEnabled = true;


            estadoCivil = ec.ObterListaEstadoCivil(true);


            cmbEstadoCivil.ItemsSource = estadoCivil;
            cmbEstadoCivil.DisplayMemberPath = "Descricao";
            cmbEstadoCivil.SelectedValuePath = "Codigo";
            cmbEstadoCivil.SelectedIndex = indiceSelecao;
        }


        private void CarregarNacionalidades()
        {
            var nacionalidades = _AppServicoNacionalidades.GetAll();

            cmbNacionalidade.ItemsSource = nacionalidades;

            cmbNacionalidade.DisplayMemberPath = "AdjetivoPatrio";
        }


        private void txtCpfCnpj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
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

        private void txtCpfCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ValidarCpfCnpj();
            }
            catch (Exception) { };
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void txtCpf_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }



        private void ValidarCpfCnpj()
        {
            imgValidaCpfCnpj.Visibility = Visibility.Hidden;
            txtCpf.Background = Brushes.Red;

            if (txtCpf.Text.Length == 11)
            {
                bool cpfValido = ValidaCpfCnpj.ValidaCPF(txtCpf.Text);

                if (cpfValido == true)
                {
                    imgValidaCpfCnpj.Visibility = Visibility.Visible;
                    txtCpf.Background = Brushes.White;
                    txtNomeParte.Focus();

                    if (txtCpf.Focus())
                        ProcurarNomesJaCadastrados();
                }
            }
        }

        private void ProcurarNomesJaCadastrados()
        {
            var nomes = new List<Pessoas>();

            nomes = _AppServicoPessoas.ObterListaPessoasPorCpfCnpj(txtCpf.Text);

            if (nomes.Count > 0)
            {
                var nomesExistentes = new ConsultaNomesExistentes(nomes, this);
                nomesExistentes.Owner = this;
                nomesExistentes.ShowDialog();

            }


        }

        private void LimparCampos()
        {
            txtCpf.Text = "";
            txtNomeParte.Text = "";
            ckbARogo.IsChecked = false;
            cmbEstadoCivil.SelectedIndex = -1;
            txtEndereco.Text = "";
            cmbNacionalidade.Text = "brasileiro(a)";
            cmbProfissao.Text = "";
            txtIdentidade.Text = "";
            txtOutroOrgao.Text = "";
            cmbOrgaoEmissor.SelectedIndex = -1;
            dpDataEmissaoIdentidade.SelectedDate = null;
        }

        private void CarregarCampos()
        {
            TornarCamposPretos();

            if (dataGridParticipantes.SelectedItem != null)
            {
                participante = (Participante)dataGridParticipantes.SelectedItem;

                nome = _digitarTestamento.listaNomes.Where(p => p.NomeId == participante.IdNomes).FirstOrDefault();

                pessoa = _digitarTestamento.listaPessoas.Where(p => p.PessoasId == participante.IdPessoa).FirstOrDefault();

                txtCpf.Text = pessoa.CpfCgc;
                txtNomeParte.Text = pessoa.Nome;

                if (nome.Representa == "S")
                    ckbARogo.IsChecked = true;
                else
                    ckbARogo.IsChecked = false;

                cmbEstadoCivil.SelectedValue = pessoa.EsctadoCivil;
                txtEndereco.Text = pessoa.Endereco;
                cmbNacionalidade.Text = pessoa.Nacionalidade;
                cmbProfissao.Text = pessoa.Profissao;
                txtIdentidade.Text = pessoa.Rg;
                if (pessoa.OrgaoRG == "DETRAN" || pessoa.OrgaoRG == "IFP")
                    cmbOrgaoEmissor.Text = pessoa.OrgaoRG;
                else
                {
                    cmbOrgaoEmissor.SelectedIndex = 2;
                    txtOutroOrgao.Text = pessoa.OrgaoRG;
                }

                dpDataEmissaoIdentidade.SelectedDate = pessoa.DataEmissaoRG;
            }
            else
            {
                LimparCampos();

            }

        }

        private void AbrirCampos()
        {
            groupBoxCpfCnpjTestador.IsEnabled = true;
            gbNomeParte.IsEnabled = true;
            ckbARogo.IsEnabled = true;
            gbEstadoCivil.IsEnabled = true;
            gbEndereco.IsEnabled = true;
            gbNacionalidade.IsEnabled = true;
            gbProfissao.IsEnabled = true;
            gbIdentidade.IsEnabled = true;
            gbOrgaoEmissor.IsEnabled = true;
            gbDtOrgaoEmissor.IsEnabled = true;
            gbOutroOrgao.IsEnabled = true;
        }

        private void FecharCampos()
        {
            groupBoxCpfCnpjTestador.IsEnabled = false;
            gbNomeParte.IsEnabled = false;
            ckbARogo.IsEnabled = false;
            gbEstadoCivil.IsEnabled = false;
            gbEndereco.IsEnabled = false;
            gbNacionalidade.IsEnabled = false;
            gbProfissao.IsEnabled = false;
            gbIdentidade.IsEnabled = false;
            gbOrgaoEmissor.IsEnabled = false;
            gbDtOrgaoEmissor.IsEnabled = false;
            gbOutroOrgao.IsEnabled = false;
        }

        private void cmbOrgaoEmissor_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void cmbOrgaoEmissor_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void cmbOrgaoEmissor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void btnAdicionarParte_Click(object sender, RoutedEventArgs e)
        {
            estado = "novo";
            AbrirCampos();
            LimparCampos();
            btnCancelar.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            dataGridParticipantes.IsEnabled = false;
            btnAdicionarParte.IsEnabled = false;
            txtCpf.Focus();
        }


        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (btnAdicionarParte.IsEnabled == true)
                this.Close();
            else
                MessageBox.Show("Para fechar é necessário salvar ou cancelar o cadastro atual.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void txtNomeParte_TextChanged(object sender, TextChangedEventArgs e)
        {
            gbNomeParte.Foreground = Brushes.Black;
            
        }

        private void txtNomeParte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbARogo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtEndereco_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbEstadoCivil_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbEstadoCivil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbNacionalidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbProfissao_GotFocus(object sender, RoutedEventArgs e)
        {
            var lista = _AppServicoPessoas.ObterListaProfissao();
            cmbProfissao.ItemsSource = lista.OrderBy(p => p);
        }

        private void cmbProfissao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbProfissao.Text != "" && cmbProfissao.Text != null)
                cmbProfissao.Text = cmbProfissao.Text.ToUpper();
        }

        private void txtIdentidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtIdentidade_TextChanged(object sender, TextChangedEventArgs e)
        {
            gbIdentidade.Foreground = Brushes.Black;
            
        }

        private void dpDataEmissaoIdentidade_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            gbDtOrgaoEmissor.Foreground = Brushes.Black;
        }

        private void dpDataEmissaoIdentidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dataGridParticipantes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbProfissao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbOrgaoEmissor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOrgaoEmissor.SelectedIndex < 2)
            {
                txtOutroOrgao.Text = "";
                txtOutroOrgao.IsEnabled = false;
            }
            else
            {
                txtOutroOrgao.IsEnabled = true;
                txtOutroOrgao.Focus();
            }

            gbOrgaoEmissor.Foreground = Brushes.Black;
        }

        private void dataGridParticipantes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AlterarTestemunha();
        }

        private void AlterarTestemunha()
        {
            estado = "alterar";

            AbrirCampos();

            btnCancelar.IsEnabled = true;
            btnSalvar.IsEnabled = true;
            dataGridParticipantes.IsEnabled = false;
            btnAdicionarParte.IsEnabled = false;

            txtCpf.Focus();

            txtCpf.SelectAll();
        }


        private void dataGridParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarCampos();

            if (dataGridParticipantes.Items.Count > 0)
                menu.IsEnabled = true;
            else
                menu.IsEnabled = false;

        }

        private void TornarCamposPretos()
        {
            gbNomeParte.Foreground = Brushes.Black;
            gbIdentidade.Foreground = Brushes.Black;
            gbOrgaoEmissor.Foreground = Brushes.Black;
            gbDtOrgaoEmissor.Foreground = Brushes.Black;
            gbOutroOrgao.Foreground = Brushes.Black;
        }

        private List<string> ConferirPreenchimentoDosCampos()
        {
            var naoPreenchido = new List<string>();

            if (imgValidaCpfCnpj.Visibility == Visibility.Hidden)
                naoPreenchido.Add("Cpf / Cnpj incorreto ou não informado;");

            if (txtNomeParte.Text.Trim() == "")
            {
                gbNomeParte.Foreground = Brushes.Red;
                naoPreenchido.Add("Nome não informado;");
            }
            else
            {
                gbNomeParte.Foreground = Brushes.Black;
            }


            if (txtIdentidade.Text == "")
            {
                gbIdentidade.Foreground = Brushes.Red;
                naoPreenchido.Add("Identidade não informado;");
            }
            else
            {
                gbIdentidade.Foreground = Brushes.Black;
            }

            

            if (cmbOrgaoEmissor.SelectedIndex == -1)
            {
                gbOrgaoEmissor.Foreground = Brushes.Red;
                naoPreenchido.Add("Orgão Emissor não informado;");
            }
            else
            {

                gbOutroOrgao.Foreground = Brushes.Black;

                if (cmbOrgaoEmissor.SelectedIndex == 2 && txtOutroOrgao.Text == "")
                {
                    gbOutroOrgao.Foreground = Brushes.Red;
                    naoPreenchido.Add("Orgão Emissor não informado;");

                }
                else
                {
                    gbOutroOrgao.Foreground = Brushes.Black;
                }


            }

            if (cmbOrgaoEmissor.SelectedIndex < 2)
            {

                if (dpDataEmissaoIdentidade.SelectedDate == null)
                {
                    gbDtOrgaoEmissor.Foreground = Brushes.Red;
                    naoPreenchido.Add("Data de Emissão não informado;");
                }
                else
                {
                    gbDtOrgaoEmissor.Foreground = Brushes.Black;
                }

            }



            return naoPreenchido;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            
            List<string> listaPreencher = ConferirPreenchimentoDosCampos();

            if (listaPreencher.Count > 0)
            {
                string msgReservado = "Campo(s) de Preenchimento obrigatório encontrado(s): \n \n";

                foreach (var item in listaPreencher)
                {
                    msgReservado += string.Format("{0}\n", item);

                }

                var pergunta = "\nÉ possível que tenha problemas mais tarde ao enviar os dados para o Censec.\n\nDeseja salvar mesmo assim?";
               
                if (MessageBox.Show(msgReservado + pergunta, "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            try
            {

                SalvarTestemunha();
                FecharCampos();
                dataGridParticipantes.IsEnabled = true;
                btnAdicionarParte.IsEnabled = true;
                btnCancelar.IsEnabled = false;
                btnSalvar.IsEnabled = false;

                estado = "pronto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SalvarTestemunha()
        {
            SalvarPessoaNaLista();

            SalvarNomeNaLista();

            SalvarParticipanteNaLista();

            dataGridParticipantes.Items.Refresh();

            dataGridParticipantes.SelectedItem = participante;
            dataGridParticipantes.ScrollIntoView(participante);
        }

        private void SalvarParticipanteNaLista()
        {

            if (estado == "novo")
                participante = new Participante();


            participante.Nome = nome.Nome;
            participante.IdNomes = nome.NomeId;
            participante.IdPessoa = pessoa.PessoasId;
            participante.Descricao = nome.Descricao;
            participante.CpfCnpj = pessoa.CpfCgc;

            if (estado == "novo")
                _digitarTestamento.participantes.Add(participante);
            else
            {
                participante = _digitarTestamento.participantes.Where(p => p.IdNomes == nome.NomeId).FirstOrDefault();

                participante.Nome = nome.Nome;
                participante.Descricao = nome.Descricao;
                participante.CpfCnpj = pessoa.CpfCgc;

            }
        }



        private void SalvarPessoaNaLista()
        {

            if (estado == "novo")
            {
                pessoa = new Pessoas();
                if (_digitarTestamento.listaPessoas.Count > 0)
                    pessoa.PessoasId = _digitarTestamento.listaPessoas.Max(p => p.PessoasId) + 1;
                else
                    pessoa.PessoasId = 1;
            }
            else
                pessoa = _digitarTestamento.listaPessoas.Where(p => p.PessoasId == ((Participante)dataGridParticipantes.SelectedItem).IdPessoa).FirstOrDefault();

            pessoa.TipoPessoa = "F";

            pessoa.Nome = txtNomeParte.Text = txtNomeParte.Text.Trim();

            pessoa.CpfCgc = txtCpf.Text;

            pessoa.Rg = txtIdentidade.Text.Trim();

            pessoa.OrgaoRG = cmbOrgaoEmissor.Text;

            if (pessoa.OrgaoRG != null && pessoa.OrgaoRG.Length > 70)
                pessoa.OrgaoRG = pessoa.OrgaoRG.Substring(0, 69);

            if (dpDataEmissaoIdentidade.SelectedDate != null)
                pessoa.DataEmissaoRG = dpDataEmissaoIdentidade.SelectedDate.Value;

            pessoa.Nacionalidade = cmbNacionalidade.Text;

            pessoa.Endereco = txtEndereco.Text.Trim();

            if (cmbEstadoCivil.SelectedIndex > -1)
                pessoa.EsctadoCivil = ((EstadoCivil)cmbEstadoCivil.SelectedItem).Codigo;


            if (cmbProfissao.Text != "" && cmbProfissao.Text != null)
                pessoa.Profissao = cmbProfissao.Text.Trim();

            if (pessoa.Profissao != null && pessoa.Profissao.Length > 100)
                pessoa.Profissao = pessoa.Profissao.Substring(0, 99);


            if (cmbNacionalidade.SelectedIndex > -1)
                pessoa.CodigoPais = ((Nacionalidades)cmbNacionalidade.SelectedItem).Codigo;



            if (estado == "novo")
            {
                pessoa.DataCadastro = DateTime.Now.Date;

                _digitarTestamento.listaPessoas.Add(pessoa);
            }
            else
            {
                var pessoaAlterar = _digitarTestamento.listaPessoas.Where(p => p.PessoasId == pessoa.PessoasId).FirstOrDefault();

                pessoaAlterar = pessoa;

            }
        }




        private void SalvarNomeNaLista()
        {


            if (estado == "novo")
            {
                nome = new Nomes();
                if (_digitarTestamento.listaNomes.Count > 0)
                    nome.NomeId = _digitarTestamento.listaNomes.Max(p => p.NomeId) + 1;
                else
                    nome.NomeId = 1;
            }
            else
                nome = _digitarTestamento.listaNomes.Where(p => p.NomeId == ((Participante)dataGridParticipantes.SelectedItem).IdNomes).FirstOrDefault();



            nome.Descricao = "TESTEMUNHA";

            nome.Nome = txtNomeParte.Text = txtNomeParte.Text.Trim();

            nome.Documento = txtCpf.Text;

            nome.Rg = txtIdentidade.Text.Trim();

            if (dpDataEmissaoIdentidade.SelectedDate != null)
                nome.DataEmissao = dpDataEmissaoIdentidade.SelectedDate.Value;

            nome.Orgao = cmbOrgaoEmissor.Text;

            if (nome.Orgao != null && nome.Orgao.Length > 70)
                nome.Orgao = nome.Orgao.Substring(0, 59);


            nome.Nacionalidade = cmbNacionalidade.Text;


            if (nome.Profissao != null)
                nome.Profissao = cmbProfissao.Text.Trim();

            if (nome.Profissao != null && nome.Profissao.Length > 60)
                nome.Profissao = nome.Profissao.Substring(0, 59);

            nome.Endereco = txtEndereco.Text.Trim();


            if (ckbARogo.IsChecked == true)
                nome.Representa = "S";
            else
                nome.Representa = "N";





            if (estado == "novo")
            {
                nome.IdPessoa = pessoa.PessoasId;

                _digitarTestamento.listaNomes.Add(nome);

            }
            else
            {

                var nomeAlterar = _digitarTestamento.listaNomes.Where(p => p.NomeId == nome.NomeId).FirstOrDefault();

                nomeAlterar = nome;


            }
        }

        private void txtOutroOrgao_TextChanged(object sender, TextChangedEventArgs e)
        {

            gbOutroOrgao.Foreground = Brushes.Black;
        }

        private void MenuItemExcluir_Click(object sender, RoutedEventArgs e)
        {
            

            _digitarTestamento.listaNomes.Remove(nome);

            _digitarTestamento.listaPessoas.Remove(pessoa);

            _digitarTestamento.participantes.Remove(participante);

            dataGridParticipantes.Items.Refresh();


            if (dataGridParticipantes.Items.Count > 0)
            {
                dataGridParticipantes.IsEnabled = true;
                dataGridParticipantes.SelectedIndex = 0;
            }
            else
                dataGridParticipantes.IsEnabled = false;

            
        }

        private void MenuItemAlterar_Click(object sender, RoutedEventArgs e)
        {
            AlterarTestemunha();
        }
    }
}
