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
using CrossCutting;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.PeriodoDatas;

namespace Cs_Gerencial.Windows
{
    /// <summary>
    /// Interaction logic for CadastroLancamentos.xaml
    /// </summary>
    public partial class CadastroLancamentos : Window
    {
        private readonly IAppServicoAtribuicoes _appServicoAtribuicoes = BootStrap.Container.GetInstance<IAppServicoAtribuicoes>();

        private readonly IAppServicoPlanos _appServicoPlanos = BootStrap.Container.GetInstance<IAppServicoPlanos>();

        private readonly IAppServicoFornecedores _appServicoFornecedores = BootStrap.Container.GetInstance<IAppServicoFornecedores>();

        private readonly IAppServicoBancos _appServicoBancos = BootStrap.Container.GetInstance<IAppServicoBancos>();

        private readonly IAppServicoContas _appServicoContas = BootStrap.Container.GetInstance<IAppServicoContas>();

        private readonly IAppServicoLogSistema _appServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        Contas contasDepositoSelecionada;

        Contas contasReceitaSelecionada;

        Contas contasDespesasSelecionada;

        string acaoAtual = string.Empty;

        List<Contas> listaDeposito = new List<Contas>();

        List<Contas> listaReceita = new List<Contas>();

        List<Contas> listaDespesas = new List<Contas>();

        public List<Contas> listaTodos = new List<Contas>();
        
        LogSistema logSistema;

        Usuario _usuario;

        public CadastroLancamentos(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregamentoInicial();
        }

        private void CarregamentoInicial()
        {
            dpConsultaInicio.SelectedDate = DateTime.Now.Date;
            dpConsultaFim.SelectedDate = DateTime.Now.Date;

            var atribuicoes = _appServicoAtribuicoes.GetAll().OrderBy(p => p.Codigo);

            cmbAtribuicaoDeposito.ItemsSource = atribuicoes;
            cmbAtribuicaoDeposito.DisplayMemberPath = "Descricao";
            cmbAtribuicaoDeposito.SelectedValuePath = "Codigo";

            cmbAtribuicaoReceita.ItemsSource = atribuicoes;
            cmbAtribuicaoReceita.DisplayMemberPath = "Descricao";
            cmbAtribuicaoReceita.SelectedValuePath = "Codigo";

            cmbPlanoContasDespesas.ItemsSource = _appServicoPlanos.GetAll().OrderBy(p => p.Descricao);
            cmbPlanoContasDespesas.DisplayMemberPath = "Descricao";
            cmbPlanoContasDespesas.SelectedValuePath = "PlanoId";

            cmbBancoDespesas.ItemsSource = _appServicoBancos.GetAll().OrderBy(p => p.Nome);
            cmbBancoDespesas.DisplayMemberPath = "Nome";
            cmbBancoDespesas.SelectedValuePath = "BancosId";

            cmbFornecedorDespesas.ItemsSource = _appServicoFornecedores.GetAll().OrderBy(p => p.NomeFantasia);
            cmbFornecedorDespesas.DisplayMemberPath = "NomeFantasia";
            cmbFornecedorDespesas.SelectedValuePath = "FornecedorId";

            List<string> formaPagamento = new List<string>();
            formaPagamento.Add("DINHEIRO");
            formaPagamento.Add("CHEQUE");
            formaPagamento.Add("CARTÃO");
            formaPagamento.Add("BOLETO");
            formaPagamento.Add("FATURADO");

            cmbFormaPgDespesas.ItemsSource = formaPagamento;

        }


        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void DigitarSemNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }


        private void DigitarSomenteNumerosEmReaisComVirgual(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
        }
 
        private void DigitarSomenteLetras(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key >= 44 && key <= 69);
        }


        private void txtProtocoloDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtReciboDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtMatriculaDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtFlsInicioDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtFlsFimDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtValorDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (txtValorDeposito.SelectionLength == txtValorDeposito.Text.Length)
            {
                txtValorDeposito.Text = "";
            }

            if (!txtValorDeposito.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorDeposito.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorDeposito.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtProtocoloReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtReciboReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtMatriculaReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtFlsInicio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtFlsFimReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtNumeroReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }
        private void txtCodigoDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtCodigoReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtValorReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (txtValorReceita.SelectionLength == txtValorReceita.Text.Length)
            {
                txtValorReceita.Text = "";
            }

            if (!txtValorReceita.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorReceita.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorReceita.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtValorDespesas_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            if (txtValorDespesas.SelectionLength == txtValorDespesas.Text.Length)
            {
                txtValorDespesas.Text = "";
            }

            if (!txtValorDespesas.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorDespesas.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorDespesas.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void ClickDoBotaoAdicionarDeposito()
        {
            gridDadosDeposito.IsEnabled = true;
            btnAlterarDeposito.IsEnabled = false;
            btnExcluirDeposito.IsEnabled = false;
            btnCancelarDeposito.IsEnabled = true;
            btnSalvarDeposito.IsEnabled = true;
            btnAdicionarDeposito.IsEnabled = false;
            dataGridDeposito.IsEnabled = false;
            btnConsultar.IsEnabled = false;
            btnSincronizar.IsEnabled = false;

            tabItemReceita.IsEnabled = false;
            tabItemDespesas.IsEnabled = false;

            LimparCamposDeposito();
        }

        private void ClickDoBotaoAlterarDeposito()
        {
            gridDadosDeposito.IsEnabled = true;
            btnAlterarDeposito.IsEnabled = false;
            btnExcluirDeposito.IsEnabled = false;
            btnCancelarDeposito.IsEnabled = true;
            btnSalvarDeposito.IsEnabled = true;
            btnAdicionarDeposito.IsEnabled = false;
            dataGridDeposito.IsEnabled = false;
            btnConsultar.IsEnabled = false;
            btnSincronizar.IsEnabled = false;

            tabItemReceita.IsEnabled = false;
            tabItemDespesas.IsEnabled = false;
        }

        private void ClickDoBotaoExcluirDeposito()
        {
            if (contasDepositoSelecionada != null)
            {
                if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _appServicoContas.Remove(contasDepositoSelecionada);

                        SalvarLogSistema("Excluiu o registro Descrição = " + contasDepositoSelecionada.Descricao);
                                                
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        listaDeposito.Remove(contasDepositoSelecionada);

                        dataGridDeposito.Items.Refresh();

                        if (listaDeposito.Count < 1)
                        {
                            btnAlterarDeposito.IsEnabled = false;
                            btnExcluirDeposito.IsEnabled = false;
                        }
                    }
                    
                }
            }
        }

        private void ClickDoBotaoCancelarDeposito()
        {
            gridDadosDeposito.IsEnabled = false;

            if (contasDepositoSelecionada != null)
            {
                btnAlterarDeposito.IsEnabled = true;
                btnExcluirDeposito.IsEnabled = true;
            }
            else
            {
                btnAlterarDeposito.IsEnabled = false;
                btnExcluirDeposito.IsEnabled = false;
            }

            btnConsultar.IsEnabled = true;
            btnSincronizar.IsEnabled = true;

            btnCancelarDeposito.IsEnabled = false;
            btnSalvarDeposito.IsEnabled = true;
            btnAdicionarDeposito.IsEnabled = true;

            tabItemReceita.IsEnabled = true;
            tabItemDespesas.IsEnabled = true;

            dataGridDeposito.IsEnabled = true;

            CarregarCamposDaLinhaSelecionadaDeposito();
        }

        private void ClickDoBotaoSalvarDeposito()
        {
            Contas contaSalvar;

            try
            {
                if (acaoAtual == "adicionarDeposito")
                {
                    contaSalvar = new Contas();
                }
                else
                {
                    contaSalvar = _appServicoContas.GetById(contasDepositoSelecionada.ContaId);
                }

                if (dpDataDeposito.SelectedDate == null)
                {
                    MessageBox.Show("Informe a data do Depósito.", "Data do Depósito", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    dpDataDeposito.Focus();
                    return;
                }

               
                if (txtDescricaoDeposito.Text == "")
                {
                    MessageBox.Show("Informe a Descrição.", "Descrição", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtDescricaoDeposito.Focus();
                    return;
                }

                if (txtValorDeposito.Text == "")
                {
                    MessageBox.Show("Informe o Valor.", "Valor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtValorDeposito.Focus();
                    return;
                }

                if (cmbAtribuicaoDeposito.SelectedIndex < 0)
                {
                    MessageBox.Show("Informe a Atribuição.", "Atribuição", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    cmbAtribuicaoDeposito.Focus();
                    return;
                }

                if (txtCodigoDeposito.Text == "")
                {
                    MessageBox.Show("Informe o Código.", "Código", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtCodigoDeposito.Focus();
                    return;
                }

                contaSalvar.DataMovimento = dpDataDeposito.SelectedDate.Value;
                

                contaSalvar.Atribuicao = ((Atribuicoes)cmbAtribuicaoDeposito.SelectedItem).Codigo;

                if (txtProtocoloDeposito.Text != "")
                    contaSalvar.Protocolo = Convert.ToInt32(txtProtocoloDeposito.Text);

                if (txtReciboDeposito.Text != "")
                    contaSalvar.Recibo = Convert.ToInt32(txtReciboDeposito.Text);

                if (txtMatriculaDeposito.Text != "")
                    contaSalvar.Matricula = txtMatriculaDeposito.Text;

                contaSalvar.Livro = txtLivroDeposito.Text;

                if (txtFlsInicioDeposito.Text != "")
                    contaSalvar.FolhaInicial = Convert.ToInt32(txtFlsInicioDeposito.Text);

                if (txtFlsFimDeposito.Text != "")
                    contaSalvar.FolhaFinal = Convert.ToInt32(txtFlsFimDeposito.Text);

                contaSalvar.Descricao = txtDescricaoDeposito.Text;

                contaSalvar.Total = Convert.ToDecimal(txtValorDeposito.Text);

                contaSalvar.Codigo = Convert.ToInt32(txtCodigoDeposito.Text);

                contaSalvar.Tipo = "DP";

                if (acaoAtual == "adicionarDeposito")
                {
                    _appServicoContas.Add(contaSalvar);
                    SalvarLogSistema("Adicionou o registro Id = " + contaSalvar.ContaId);
                }
                else
                {
                    _appServicoContas.Update(contaSalvar);
                    SalvarLogSistema("Alterou o registro Id = " + contaSalvar.ContaId);
                }

                gridDadosDeposito.IsEnabled = false;
                btnCancelarDeposito.IsEnabled = false;
                btnSalvarDeposito.IsEnabled = false;
                btnAdicionarDeposito.IsEnabled = true;

                if (acaoAtual == "adicionarDeposito")
                    LimparCamposDeposito();

                tabItemReceita.IsEnabled = true;
                tabItemDespesas.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSincronizar.IsEnabled = true;

                dataGridDeposito.IsEnabled = true;

                if (acaoAtual == "adicionarDeposito")
                {
                    listaDeposito = _appServicoContas.ConsultaPorPeriodo(contaSalvar.DataMovimento, contaSalvar.DataMovimento).Where(p => p.Tipo == "DP").ToList();
                }
                dataGridDeposito.ItemsSource = listaDeposito;

                dataGridDeposito.SelectedItem = contaSalvar;

                dataGridDeposito.Items.Refresh();

                MessageBox.Show("Registro salvo com sucesso!", "Registro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);

                if (dataGridDeposito.SelectedIndex > -1)
                {
                    btnAlterarDeposito.IsEnabled = true;
                    btnExcluirDeposito.IsEnabled = true;
                }
                else
                {
                    btnAlterarDeposito.IsEnabled = false;
                    btnExcluirDeposito.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar salvar o registro. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                gridDadosDeposito.IsEnabled = false;
                btnCancelarDeposito.IsEnabled = false;
                btnSalvarDeposito.IsEnabled = false;
                btnAdicionarDeposito.IsEnabled = true;
                dataGridDeposito.IsEnabled = true;
                tabItemReceita.IsEnabled = true;
                tabItemDespesas.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSincronizar.IsEnabled = true;
                LimparCamposDeposito();
            }


        }

        private void ClickDoBotaoAdicionarReceita()
        {
            gridDadosReceita.IsEnabled = true;
            btnAlterarReceita.IsEnabled = false;
            btnExcluirReceita.IsEnabled = false;
            btnCancelarReceita.IsEnabled = true;
            btnSalvarReceita.IsEnabled = true;
            btnAdicionarReceita.IsEnabled = false;
            dataGridReceita.IsEnabled = false;
            btnConsultar.IsEnabled = false;
            btnSincronizar.IsEnabled = false;

            tabItemDeposito.IsEnabled = false;
            tabItemDespesas.IsEnabled = false;

            LimparCamposReceita();
        }

        private void ClickDoBotaoAlterarReceita()
        {
            gridDadosReceita.IsEnabled = true;
            btnAlterarReceita.IsEnabled = false;
            btnExcluirReceita.IsEnabled = false;
            btnCancelarReceita.IsEnabled = true;
            btnSalvarReceita.IsEnabled = true;
            btnAdicionarReceita.IsEnabled = false;
            dataGridReceita.IsEnabled = false;
            btnConsultar.IsEnabled = false;
            btnSincronizar.IsEnabled = false;

            tabItemDeposito.IsEnabled = false;
            tabItemDespesas.IsEnabled = false;
        }

        private void ClickDoBotaoExcluirReceita()
        {
            if (contasReceitaSelecionada != null)
            {
                if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _appServicoContas.Remove(contasReceitaSelecionada);

                        SalvarLogSistema("Excluiu o registro Descrição = " + contasReceitaSelecionada.Descricao);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        listaReceita.Remove(contasReceitaSelecionada);

                        dataGridReceita.Items.Refresh();

                        if (listaReceita.Count < 1)
                        {
                            btnAlterarReceita.IsEnabled = false;
                            btnExcluirReceita.IsEnabled = false;
                        }
                    }
                    
                }
            }
        }

        private void ClickDoBotaoCancelarReceita()
        {
            gridDadosReceita.IsEnabled = false;

            if (contasReceitaSelecionada != null)
            {
                btnAlterarReceita.IsEnabled = true;
                btnExcluirReceita.IsEnabled = true;
            }
            else
            {
                btnAlterarReceita.IsEnabled = false;
                btnExcluirReceita.IsEnabled = false;
            }

            btnConsultar.IsEnabled = true;
            btnSincronizar.IsEnabled = true;

            btnCancelarReceita.IsEnabled = false;
            btnSalvarReceita.IsEnabled = true;
            btnAdicionarReceita.IsEnabled = true;

            tabItemDeposito.IsEnabled = true;
            tabItemDespesas.IsEnabled = true;

            dataGridReceita.IsEnabled = true;

            CarregarCamposDaLinhaSelecionadaReceita();
        }

        private void ClickDoBotaoSalvarReceita()
        {
            Contas contaSalvar;

            try
            {
                if (acaoAtual == "adicionarReceita")
                {
                    contaSalvar = new Contas();
                }
                else
                {
                    contaSalvar = _appServicoContas.GetById(contasReceitaSelecionada.ContaId);
                }

                if (dpDataReceita.SelectedDate == null)
                {
                    MessageBox.Show("Informe a data do Receita.", "Data do Receita", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    dpDataReceita.Focus();
                    return;
                }


                if (txtDescricaoReceita.Text == "")
                {
                    MessageBox.Show("Informe a Descrição.", "Descrição", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtDescricaoReceita.Focus();
                    return;
                }

                if (txtValorReceita.Text == "")
                {
                    MessageBox.Show("Informe o Valor.", "Valor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtValorReceita.Focus();
                    return;
                }

                if (cmbAtribuicaoReceita.SelectedIndex < 0)
                {
                    MessageBox.Show("Informe a Atribuição.", "Atribuição", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    cmbAtribuicaoReceita.Focus();
                    return;
                }

                if (txtCodigoReceita.Text == "")
                {
                    MessageBox.Show("Informe o Código.", "Código", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtCodigoReceita.Focus();
                    return;
                }

                contaSalvar.DataMovimento = dpDataReceita.SelectedDate.Value;

                contaSalvar.DataPagamento = dpDataReceita.SelectedDate.Value;


                contaSalvar.Atribuicao = ((Atribuicoes)cmbAtribuicaoReceita.SelectedItem).Codigo;

                if (txtProtocoloReceita.Text != "")
                    contaSalvar.Protocolo = Convert.ToInt32(txtProtocoloReceita.Text);

                if (txtReciboReceita.Text != "")
                    contaSalvar.Recibo = Convert.ToInt32(txtReciboReceita.Text);

                if (txtMatriculaReceita.Text != "")
                    contaSalvar.Matricula = txtMatriculaReceita.Text;

                contaSalvar.Livro = txtLivroReceita.Text;

                if (txtFlsInicioReceita.Text != "")
                    contaSalvar.FolhaInicial = Convert.ToInt32(txtFlsInicioReceita.Text);

                if (txtFlsFimReceita.Text != "")
                    contaSalvar.FolhaFinal = Convert.ToInt32(txtFlsFimReceita.Text);

                contaSalvar.Descricao = txtDescricaoReceita.Text;

                contaSalvar.Total = Convert.ToDecimal(txtValorReceita.Text);

                contaSalvar.Codigo = Convert.ToInt32(txtCodigoReceita.Text);

                if (txtSerieReceita.Text != "")
                    contaSalvar.Letra = txtSerieReceita.Text;

                if (txtNumeroReceita.Text != "")
                    contaSalvar.Numero = Convert.ToInt32(txtNumeroReceita.Text);

                if (txtAleatorioReceita.Text != "")
                    contaSalvar.Aleatorio = txtAleatorioReceita.Text;


                contaSalvar.Tipo = "RE";

                if (acaoAtual == "adicionarReceita")
                {
                    _appServicoContas.Add(contaSalvar);
                    SalvarLogSistema("Adicionou o registro Id = " + contaSalvar.ContaId);
                }
                else
                {
                    _appServicoContas.Update(contaSalvar);
                    SalvarLogSistema("Alterou o registro Id = " + contaSalvar.ContaId);
                }

                gridDadosReceita.IsEnabled = false;
                btnCancelarReceita.IsEnabled = false;
                btnSalvarReceita.IsEnabled = false;
                btnAdicionarReceita.IsEnabled = true;

                if (acaoAtual == "adicionarReceita")
                    LimparCamposReceita();

                tabItemDeposito.IsEnabled = true;
                tabItemDespesas.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSincronizar.IsEnabled = true;

                dataGridReceita.IsEnabled = true;

                if (acaoAtual == "adicionarReceita")
                {
                    listaReceita = _appServicoContas.ConsultaPorPeriodo(contaSalvar.DataMovimento, contaSalvar.DataMovimento).Where(p => p.Tipo == "RE").ToList();
                }
                dataGridReceita.ItemsSource = listaReceita;

                dataGridReceita.SelectedItem = contaSalvar;

                dataGridReceita.Items.Refresh();

                MessageBox.Show("Registro salvo com sucesso!", "Registro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);

                if (dataGridReceita.SelectedIndex > -1)
                {
                    btnAlterarReceita.IsEnabled = true;
                    btnExcluirReceita.IsEnabled = true;
                }
                else
                {
                    btnAlterarReceita.IsEnabled = false;
                    btnExcluirReceita.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar salvar o registro. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                gridDadosReceita.IsEnabled = false;
                btnCancelarReceita.IsEnabled = false;
                btnSalvarReceita.IsEnabled = false;
                btnAdicionarReceita.IsEnabled = true;
                dataGridReceita.IsEnabled = true;
                tabItemDeposito.IsEnabled = true;
                tabItemDespesas.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSincronizar.IsEnabled = true;
                LimparCamposReceita();
            }
        }

        private void ClickDoBotaoAdicionarDespesas()
        {
            gridDadosDespesas.IsEnabled = true;
            btnAlterarDespesas.IsEnabled = false;
            btnExcluirDespesas.IsEnabled = false;
            btnCancelarDespesas.IsEnabled = true;
            btnSalvarDespesas.IsEnabled = true;
            btnAdicionarDespesas.IsEnabled = false;
            dataGridDespesas.IsEnabled = false;
            btnConsultar.IsEnabled = false;
            btnSincronizar.IsEnabled = false;

            tabItemDeposito.IsEnabled = false;
            tabItemReceita.IsEnabled = false;

            LimparCamposDespesas();
        }

        private void ClickDoBotaoAlterarDespesas()
        {
            gridDadosDespesas.IsEnabled = true;
            btnAlterarDespesas.IsEnabled = false;
            btnExcluirDespesas.IsEnabled = false;
            btnCancelarDespesas.IsEnabled = true;
            btnSalvarDespesas.IsEnabled = true;
            btnAdicionarDespesas.IsEnabled = false;
            dataGridDespesas.IsEnabled = false;
            btnConsultar.IsEnabled = false;
            btnSincronizar.IsEnabled = false;

            tabItemDeposito.IsEnabled = false;
            tabItemReceita.IsEnabled = false;
        }

        private void ClickDoBotaoExcluirDespesas()
        {
            if (contasDespesasSelecionada != null)
            {
                if (MessageBox.Show("Deseja realmente excluir este registro?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _appServicoContas.Remove(contasDespesasSelecionada);

                        SalvarLogSistema("Excluiu o registro Descrição = " + contasDespesasSelecionada.Descricao);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        listaDespesas.Remove(contasDespesasSelecionada);

                        dataGridDespesas.Items.Refresh();

                        if (listaDespesas.Count < 1)
                        {
                            btnAlterarDespesas.IsEnabled = false;
                            btnExcluirDespesas.IsEnabled = false;
                        }

                    }
                }
            }
        }

        private void ClickDoBotaoCancelarDespesas()
        {
            gridDadosDespesas.IsEnabled = false;

            if (contasDespesasSelecionada != null)
            {
                btnAlterarDespesas.IsEnabled = true;
                btnExcluirDespesas.IsEnabled = true;
            }
            else
            {
                btnAlterarDespesas.IsEnabled = false;
                btnExcluirDespesas.IsEnabled = false;
            }

            btnConsultar.IsEnabled = true;
            btnSincronizar.IsEnabled = true;

            btnCancelarDespesas.IsEnabled = false;
            btnSalvarDespesas.IsEnabled = true;
            btnAdicionarDespesas.IsEnabled = true;

            tabItemDeposito.IsEnabled = true;
            tabItemReceita.IsEnabled = true;

            dataGridDespesas.IsEnabled = true;

            CarregarCamposDaLinhaSelecionadaDespesas();
        }

        private void ClickDoBotaoSalvarDespesas()
        {
            Contas contaSalvar;

            try
            {
                if (acaoAtual == "adicionarDespesas")
                {
                    contaSalvar = new Contas();
                }
                else
                {
                    contaSalvar = _appServicoContas.GetById(contasDespesasSelecionada.ContaId);
                }

                if (dpDataVencimentoDespesas.SelectedDate == null)
                {
                    MessageBox.Show("Informe a data do Vencimento.", "Data do Vencimento", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    dpDataVencimentoDespesas.Focus();
                    return;
                }

                if (dpDataPagamentoDespesas.SelectedDate == null)
                {
                    MessageBox.Show("Informe a data do Pagamento.", "Data do Pagamento", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    dpDataPagamentoDespesas.Focus();
                    return;
                }

                if (txtDescricaoDespesas.Text == "")
                {
                    MessageBox.Show("Informe a Descrição.", "Descrição", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtDescricaoDespesas.Focus();
                    return;
                }

                if (txtValorDespesas.Text == "")
                {
                    MessageBox.Show("Informe o Valor.", "Valor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txtValorDespesas.Focus();
                    return;
                }


                contaSalvar.DataMovimento = dpDataVencimentoDespesas.SelectedDate.Value;

                contaSalvar.DataPagamento = dpDataPagamentoDespesas.SelectedDate.Value;

                if (cmbPlanoContasDespesas.SelectedIndex > -1)
                {
                    var plano = (Planos)cmbPlanoContasDespesas.SelectedItem;

                    contaSalvar.IdPlano = plano.PlanoId;
                    contaSalvar.Plano = plano.Descricao;
                }

                if (cmbFornecedorDespesas.SelectedIndex > -1)
                {
                    var fornecedor = (Fornecedores)cmbFornecedorDespesas.SelectedItem;

                    contaSalvar.IdFornecedor = fornecedor.FornecedorId;
                    contaSalvar.Fornecedor = fornecedor.NomeFantasia;
                }

                if (cmbBancoDespesas.SelectedIndex > -1)
                {
                    var banco = (Bancos)cmbBancoDespesas.SelectedItem;

                    contaSalvar.IdBanco = banco.BancosId;
                    contaSalvar.Banco = banco.Nome;
                }

                if (cmbFormaPgDespesas.SelectedIndex > -1)
                    contaSalvar.FormaPagamento = cmbFormaPgDespesas.Text;

                if (txtNumeroChequeDespesas.Text != "")
                    contaSalvar.NumeroCheque = txtNumeroChequeDespesas.Text;

                if (txtDocumentoDespesas.Text != "")
                    contaSalvar.Documento = txtDocumentoDespesas.Text;


                contaSalvar.Descricao = txtDescricaoDespesas.Text;

                contaSalvar.Total = Convert.ToDecimal(txtValorDespesas.Text);

                contaSalvar.Tipo = "DE";

                if (acaoAtual == "adicionarDespesas")
                {
                    _appServicoContas.Add(contaSalvar);
                    SalvarLogSistema("Adicionou o registro id = " + contaSalvar.ContaId);
                }
                else
                {
                    _appServicoContas.Update(contaSalvar);
                    SalvarLogSistema("Alterou o registro id = " + contaSalvar.ContaId);
                }

                gridDadosDespesas.IsEnabled = false;
                btnCancelarDespesas.IsEnabled = false;
                btnSalvarDespesas.IsEnabled = false;
                btnAdicionarDespesas.IsEnabled = true;

                if (acaoAtual == "adicionarDespesas")
                    LimparCamposDespesas();

                tabItemReceita.IsEnabled = true;
                tabItemDeposito.IsEnabled = true;

                btnConsultar.IsEnabled = true;
                btnSincronizar.IsEnabled = true;

                dataGridDespesas.IsEnabled = true;

                if (acaoAtual == "adicionarDespesas")
                {
                    listaDespesas = _appServicoContas.ConsultaPorPeriodo(contaSalvar.DataMovimento, contaSalvar.DataMovimento).Where(p => p.Tipo == "DE").ToList();
                }
                dataGridDespesas.ItemsSource = listaDespesas;

                dataGridDespesas.SelectedItem = contaSalvar;

                dataGridDespesas.Items.Refresh();

                MessageBox.Show("Registro salvo com sucesso!", "Registro Salvo", MessageBoxButton.OK, MessageBoxImage.Information);

                if (dataGridDespesas.SelectedIndex > -1)
                {
                    btnAlterarDespesas.IsEnabled = true;
                    btnExcluirDespesas.IsEnabled = true;
                }
                else
                {
                    btnAlterarDespesas.IsEnabled = false;
                    btnExcluirDespesas.IsEnabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar salvar o registro. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                gridDadosDespesas.IsEnabled = false;
                btnCancelarDespesas.IsEnabled = false;
                btnSalvarDespesas.IsEnabled = false;
                btnAdicionarDespesas.IsEnabled = true;
                dataGridDespesas.IsEnabled = true;
                tabItemReceita.IsEnabled = true;
                tabItemDeposito.IsEnabled = true;
                btnConsultar.IsEnabled = true;
                btnSincronizar.IsEnabled = true;
                LimparCamposDespesas();
            }
        }

        private void dataGridDeposito_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            contasDepositoSelecionada = (Contas)dataGridDeposito.SelectedItem;
            CarregarCamposDaLinhaSelecionadaDeposito();
        }

        private void dataGridReceita_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            contasReceitaSelecionada = (Contas)dataGridReceita.SelectedItem;
            CarregarCamposDaLinhaSelecionadaReceita();
        }

        private void dataGridDespesas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            contasDespesasSelecionada = (Contas)dataGridDespesas.SelectedItem;
            CarregarCamposDaLinhaSelecionadaDespesas();
        }

        private void btnAdicionarDeposito_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "adicionarDeposito";
            ClickDoBotaoAdicionarDeposito();
        }

        private void btnAlterarDeposito_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "alterarDeposito";
            ClickDoBotaoAlterarDeposito();
        }

        private void btnExcluirDeposito_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "excluirDeposito";
            ClickDoBotaoExcluirDeposito();
        }

        private void btnCancelarDeposito_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "cancelarDeposito";
            ClickDoBotaoCancelarDeposito();
        }

        private void btnSalvarDeposito_Click(object sender, RoutedEventArgs e)
        {

            ClickDoBotaoSalvarDeposito();
        }

        private void btnAdicionarReceita_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "adicionarReceita";
            ClickDoBotaoAdicionarReceita();
        }

        private void btnAlterarReceita_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "alterarReceita";
            ClickDoBotaoAlterarReceita();
        }

        private void btnExcluirReceita_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "excluirReceita";
            ClickDoBotaoExcluirReceita();
        }

        private void btnCancelarReceita_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "cancelarReceita";
            ClickDoBotaoCancelarReceita();

        }

        private void btnSalvarReceita_Click(object sender, RoutedEventArgs e)
        {
            ClickDoBotaoSalvarReceita();
        }

        private void txtSerieReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteLetras(sender, e);
        }

        private void btnAdicionarDespesas_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "adicionarDespesas";
            ClickDoBotaoAdicionarDespesas();
        }

        private void btnAlterarDespesas_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "alterarDespesas";
            ClickDoBotaoAlterarDespesas();
        }

        private void btnExcluirDespesas_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "excluirDespesas";
            ClickDoBotaoExcluirDespesas();
        }

        private void btnCancelarDespesas_Click(object sender, RoutedEventArgs e)
        {
            acaoAtual = "cancelarDespesas";
            ClickDoBotaoCancelarDespesas();
        }

        private void btnSalvarDespesas_Click(object sender, RoutedEventArgs e)
        {
            ClickDoBotaoSalvarDespesas();
        }



        private void LimparCamposDeposito()
        {
            dpDataDeposito.SelectedDate = null;

            cmbAtribuicaoDeposito.SelectedIndex = -1;

            txtProtocoloDeposito.Text = "";

            txtReciboDeposito.Text = "";

            txtMatriculaDeposito.Text = "";

            txtLivroDeposito.Text = "";

            txtFlsInicioDeposito.Text = "";

            txtFlsFimDeposito.Text = "";
            
            txtDescricaoDeposito.Text = "";

            txtCodigoDeposito.Text = "";

            txtValorDeposito.Text = "";
        }


        private void LimparCamposReceita()
        {
            dpDataReceita.SelectedDate = null;

            cmbAtribuicaoReceita.SelectedIndex = -1;

            txtProtocoloReceita.Text = "";

            txtReciboReceita.Text = "";

            txtMatriculaReceita.Text = "";

            txtLivroReceita.Text = "";

            txtFlsInicioReceita.Text = "";

            txtFlsFimReceita.Text = "";

            txtDescricaoReceita.Text = "";

            txtCodigoReceita.Text = "";

            txtValorReceita.Text = "";

            txtSerieReceita.Text = "";

            txtNumeroReceita.Text = "";

            txtAleatorioReceita.Text = "";
        }

        private void LimparCamposDespesas()
        {
            dpDataVencimentoDespesas.SelectedDate = null;

            cmbPlanoContasDespesas.SelectedIndex = -1;

            cmbFornecedorDespesas.SelectedIndex = -1;

            cmbBancoDespesas.SelectedIndex = -1;

            cmbFormaPgDespesas.SelectedIndex = -1;

            txtNumeroChequeDespesas.Text = "";

            dpDataPagamentoDespesas.SelectedDate = null;

            txtDocumentoDespesas.Text = "";

            txtDescricaoDespesas.Text = "";

            txtValorDespesas.Text = "";
        }


        private void CarregarCamposDaLinhaSelecionadaDeposito()
        {
            try
            {
                if (contasDepositoSelecionada != null)
                {

                    dpDataDeposito.SelectedDate = contasDepositoSelecionada.DataMovimento;

                    cmbAtribuicaoDeposito.SelectedValue = contasDepositoSelecionada.Atribuicao;

                    if (contasDepositoSelecionada.Protocolo > 0)
                        txtProtocoloDeposito.Text = contasDepositoSelecionada.Protocolo.ToString();
                    else
                        txtProtocoloDeposito.Text = "";

                    if (contasDepositoSelecionada.Recibo > 0)
                        txtReciboDeposito.Text = contasDepositoSelecionada.Recibo.ToString();
                    else
                        txtReciboDeposito.Text = "";

                    if (contasDepositoSelecionada.Matricula != null)
                        txtMatriculaDeposito.Text = contasDepositoSelecionada.Matricula;
                    else
                        txtMatriculaDeposito.Text = "";

                    txtLivroDeposito.Text = contasDepositoSelecionada.Livro;

                    if (contasDepositoSelecionada.FolhaInicial > 0)
                        txtFlsInicioDeposito.Text = contasDepositoSelecionada.FolhaInicial.ToString();
                    else
                        txtFlsInicioDeposito.Text = "";

                    if (contasDepositoSelecionada.FolhaFinal > 0)
                        txtFlsFimDeposito.Text = contasDepositoSelecionada.FolhaFinal.ToString();
                    else
                        txtFlsFimDeposito.Text = "";
                    
                    txtDescricaoDeposito.Text = contasDepositoSelecionada.Descricao;

                    if (contasDepositoSelecionada.Codigo > 0)
                        txtCodigoDeposito.Text = contasDepositoSelecionada.Codigo.ToString();
                    else
                        txtCodigoDeposito.Text = "";

                    txtValorDeposito.Text = string.Format("{0:n2}", contasDepositoSelecionada.Total);
                }
                else
                {
                    LimparCamposDeposito();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar os campos. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarregarCamposDaLinhaSelecionadaReceita()
        {
            try
            {
                if (contasReceitaSelecionada != null)
                {

                    dpDataReceita.SelectedDate = contasReceitaSelecionada.DataMovimento;

                    cmbAtribuicaoReceita.SelectedValue = contasReceitaSelecionada.Atribuicao;

                    if (contasReceitaSelecionada.Protocolo > 0)
                        txtProtocoloReceita.Text = contasReceitaSelecionada.Protocolo.ToString();
                    else
                        txtProtocoloReceita.Text = "";


                    if (contasReceitaSelecionada.Recibo > 0)
                        txtReciboReceita.Text = contasReceitaSelecionada.Recibo.ToString();
                    else
                        txtReciboReceita.Text = "";

                    if (contasReceitaSelecionada.Matricula != null)
                        txtMatriculaReceita.Text = contasReceitaSelecionada.Matricula;
                    else
                        txtMatriculaReceita.Text = "";

                    txtLivroReceita.Text = contasReceitaSelecionada.Livro;

                    if (contasReceitaSelecionada.FolhaInicial > 0)
                        txtFlsInicioReceita.Text = contasReceitaSelecionada.FolhaInicial.ToString();
                    else
                        txtFlsInicioReceita.Text = "";

                    if (contasReceitaSelecionada.FolhaFinal > 0)
                        txtFlsFimReceita.Text = contasReceitaSelecionada.FolhaFinal.ToString();
                    else
                        txtFlsFimReceita.Text = "";

                    txtDescricaoReceita.Text = contasReceitaSelecionada.Descricao;

                    if (contasReceitaSelecionada.Codigo > 0)
                        txtCodigoReceita.Text = contasReceitaSelecionada.Codigo.ToString();
                    else
                        txtCodigoReceita.Text = "";

                    if (contasReceitaSelecionada.Letra != null)
                        txtSerieReceita.Text = contasReceitaSelecionada.Letra;
                    else
                        txtSerieReceita.Text = "";

                    if (contasReceitaSelecionada.Numero > 0)
                        txtNumeroReceita.Text = contasReceitaSelecionada.Numero.ToString();
                    else
                        txtNumeroReceita.Text = "";

                    if (contasReceitaSelecionada.Aleatorio != null)
                        txtAleatorioReceita.Text = contasReceitaSelecionada.Aleatorio;
                    else
                        txtAleatorioReceita.Text = "";

                    txtValorReceita.Text = string.Format("{0:n2}", contasReceitaSelecionada.Total);
                }
                else
                {
                    LimparCamposReceita();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar os campos. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarregarCamposDaLinhaSelecionadaDespesas()
        {
            try
            {
                if (contasDespesasSelecionada != null)
                {

                    dpDataVencimentoDespesas.SelectedDate = contasDespesasSelecionada.DataMovimento;

                    dpDataPagamentoDespesas.SelectedDate = contasDespesasSelecionada.DataPagamento;

                    cmbPlanoContasDespesas.SelectedValue = contasDespesasSelecionada.IdPlano;

                    cmbFornecedorDespesas.SelectedValue = contasDespesasSelecionada.IdFornecedor;

                    cmbBancoDespesas.SelectedValue = contasDespesasSelecionada.IdBanco;

                    cmbFormaPgDespesas.Text = contasDespesasSelecionada.FormaPagamento;

                    txtNumeroChequeDespesas.Text = contasDespesasSelecionada.NumeroCheque;

                    txtDescricaoDespesas.Text = contasDespesasSelecionada.Descricao;

                    txtDocumentoDespesas.Text = contasDespesasSelecionada.Documento;

                    txtValorDespesas.Text = string.Format("{0:n2}", contasDespesasSelecionada.Total);
                }
                else
                {
                    LimparCamposDespesas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar carregar os campos. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {

            if (dpConsultaInicio.SelectedDate == null)
            {
                MessageBox.Show("Informe a Data Inicial.", "Data Inicial", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            if (dpConsultaFim.SelectedDate == null)
            {
                MessageBox.Show("Informe a Data Final.", "Data Final", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            try
            {

                listaTodos = _appServicoContas.ConsultaPorPeriodo(dpConsultaInicio.SelectedDate.Value, dpConsultaFim.SelectedDate.Value).ToList();

                CarregarDataGridDeposito();

                CarregarDataGridReceita();

                CarregarDataGridDespesas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CarregarDataGridDeposito()
        {
            listaDeposito = listaTodos.Where(p => p.Tipo == "DP").ToList();

            dataGridDeposito.ItemsSource = listaDeposito;

            dataGridDeposito.Items.Refresh();

            if (listaDeposito.Count > 0)
            {
                btnAlterarDeposito.IsEnabled = true;
                btnExcluirDeposito.IsEnabled = true;
                dataGridDeposito.SelectedIndex = 0;
            }
            else
            {
                btnAlterarDeposito.IsEnabled = false;
                btnExcluirDeposito.IsEnabled = false;
            }
        }

        public void CarregarDataGridReceita()
        {
            listaReceita = listaTodos.Where(p => p.Tipo == "RE").ToList();

            dataGridReceita.ItemsSource = listaReceita;

            dataGridReceita.Items.Refresh();

            if (listaReceita.Count > 0)
            {
                btnAlterarReceita.IsEnabled = true;
                btnExcluirReceita.IsEnabled = true;
                dataGridReceita.SelectedIndex = 0;
            }
            else
            {
                btnAlterarReceita.IsEnabled = false;
                btnExcluirReceita.IsEnabled = false;
            }
        }

        public void CarregarDataGridDespesas()
        {
            listaDespesas = listaTodos.Where(p => p.Tipo == "DE").ToList();

            dataGridDespesas.ItemsSource = listaDespesas;

            dataGridDespesas.Items.Refresh();

            if (listaDespesas.Count > 0)
            {
                btnAlterarDespesas.IsEnabled = true;
                btnExcluirDespesas.IsEnabled = true;
                dataGridDespesas.SelectedIndex = 0;
            }
            else
            {
                btnAlterarDespesas.IsEnabled = false;
                btnExcluirDespesas.IsEnabled = false;
            }
        }

        private void cmbFormaPgDespesas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFormaPgDespesas.SelectedIndex == 1)
            {
                txtNumeroChequeDespesas.IsEnabled = true;
            }
            else
            {
                txtNumeroChequeDespesas.IsEnabled = false;
                txtNumeroChequeDespesas.Text = "";
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

        private void gridDadosDeposito_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void gridDadosReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void gridDadosDespesas_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtValorDeposito_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorDeposito.Text != "" && txtValorDeposito.Text != ",")
                txtValorDeposito.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorDeposito.Text));
            else
                txtValorDeposito.Text = "";
        }

        private void txtValorReceita_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorReceita.Text != "" && txtValorReceita.Text != ",")
                txtValorReceita.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorReceita.Text));
            else
            txtValorReceita.Text = "";
        }

        private void txtValorDespesas_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorDespesas.Text != "" && txtValorDespesas.Text != ",")
                txtValorDespesas.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorDespesas.Text));
            else
                txtValorDespesas.Text = "";
        }


        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Cadastro de Lançamentos";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _appServicoLogSistema.Add(logSistema);
        }

        private void dpConsultaInicio_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpConsultaInicio.SelectedDate > DateTime.Now.Date)
            {
                dpConsultaInicio.SelectedDate = DateTime.Now.Date;
            }

            dpConsultaFim.SelectedDate = dpConsultaInicio.SelectedDate;

            if (dpConsultaInicio.SelectedDate > dpConsultaFim.SelectedDate)
            {
                dpConsultaFim.SelectedDate = dpConsultaInicio.SelectedDate;
            }
        }

        private void dpConsultaFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpConsultaInicio.SelectedDate != null)
            {
                if (dpConsultaInicio.SelectedDate > dpConsultaFim.SelectedDate)
                {
                    dpConsultaFim.SelectedDate = dpConsultaInicio.SelectedDate;
                }
            }
            else
            {
                dpConsultaInicio.SelectedDate = dpConsultaFim.SelectedDate;                
            }
        }

        private void txtAleatorioReceita_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteLetras(sender, e);
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnSincronizar_Click(object sender, RoutedEventArgs e)
        {
            var sincronizar = new PeriodoDataSincronizarLancamentos(_usuario, this);
            sincronizar.Owner = this;
            sincronizar.ShowDialog();
        }
    }
}
