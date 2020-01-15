using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.ValuesObject;
using Cs_Notas.Windows.Escritura;
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

namespace Cs_Notas.Windows.Procuracao
{
    /// <summary>
    /// Lógica interna para AtosConjuntosProcuracao.xaml
    /// </summary>
    public partial class AtosConjuntosProcuracao : Window
    {

        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        private readonly IAppServicoMunicipios _AppServicoMunicipios = BootStrap.Container.GetInstance<IAppServicoMunicipios>();

        private readonly IAppServicoServentia _AppServicoServentia = BootStrap.Container.GetInstance<IAppServicoServentia>();

        private readonly IAppServicoServentiasOutras _AppServicoServentiasOutras = BootStrap.Container.GetInstance<IAppServicoServentiasOutras>();

        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();

        private readonly IAppServicoParteConjuntos _AppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();

        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();

        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();

        private readonly IAppServicoNaturezas _AppServicoNaturezas = BootStrap.Container.GetInstance<IAppServicoNaturezas>();

        private readonly IAppServicoTabelaCustas _AppServicoTabelaCustas = BootStrap.Container.GetInstance<IAppServicoTabelaCustas>();

        List<Naturezas> naturezas = new List<Naturezas>();

        List<TabelaCustas> listaTabelaCustas = new List<TabelaCustas>();

        Selos selo;

        DigitarProcuracao _digitarProcuracao;

        List<string> Ufs = new List<string>();

        Serventia serventia;

        public List<ServentiasOutras> serventiasOutras;

        public ServentiasOutras serventiasOutrasSelecionada;

        string _status;

        AtoConjuntos _atoConjunto;

        public AtosConjuntosProcuracao(DigitarProcuracao digitarProcuracao, string status, AtoConjuntos atoConjunto)
        {
            _digitarProcuracao = digitarProcuracao;
            _status = status;
            _atoConjunto = atoConjunto;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listaTabelaCustas = _AppServicoTabelaCustas.GetAll().ToList();
            CarregarComboBoxNaturezas();
            CarregarComboBoxTabelaAtos();
            CarregarUF();
           
            serventiasOutras = _AppServicoServentiasOutras.GetAll().ToList();

            if (_status == "adicionando")
                CarregarAdicionando();
            else
                CarregarAlterando();

        }
        private void CarregarUF()
        {

            Ufs = _AppServicoMunicipios.ObterUfsDosMunicipios();

            cmbUf.ItemsSource = Ufs;

        }

        private void CarregarAdicionando()
        {
            dtDataAto.SelectedDate = _digitarProcuracao.dtDataAto.SelectedDate.Value;
            txtLivro.Text = _digitarProcuracao.txtLivro.Text;
            txtFlsIni.Text = string.Format("{0}/{1}", _digitarProcuracao.txtFlsIni.Text, _digitarProcuracao.txtFlsFim.Text);
            txtAto.Text = _digitarProcuracao.txtAto.Text;
            ReservarSelo();
            cmbLavradoRio.Text = "SIM";
            cmbUf.Text = "RJ";
            cmbPorProcuracao.Text = "NÃO";
            CarregarServentia();
        }

        private void CarregarServentia()
        {
            serventia = _AppServicoServentia.GetAll().FirstOrDefault();
            txtCodigo.Text = string.Format("{0:0000}", serventia.CodigoServentia);

        }

        private void ReservarSelo()
        {
            try
            {
                int idSeloAtual = _AppServicoConfiguracoes.GetById(1).SerieAtual;

                int qtdSelosLivres = _AppServicoSelos.ConsultarPorIdSerie(idSeloAtual).Where(p => p.Status == "LIVRE").Count();

                int quantidade = 1;

                if (quantidade > qtdSelosLivres)
                {
                    MessageBox.Show("Não foi possível reservar um selo. Favor selecione uma série com selos livres.", "Informação", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    this.Close();
                }

                string natureza = "ATO CONJUNTO";

                DateTime dataReserva = dtDataAto.SelectedDate.Value;

                int folhaInicio = Convert.ToInt16(_digitarProcuracao.txtFlsIni.Text);

                int folhaFim = Convert.ToInt16(_digitarProcuracao.txtFlsFim.Text);

                int ato = Convert.ToInt16(_digitarProcuracao.txtAto.Text);

                List<Selos> selosReservar = _AppServicoSelos.ReservarSelos(idSeloAtual, quantidade, natureza, _digitarProcuracao._usuario.UsuarioId, _digitarProcuracao._usuario.Nome, dataReserva, 2, txtLivro.Text, folhaInicio, folhaFim, ato);

                selo = _AppServicoSelos.GetById(selosReservar.FirstOrDefault().SeloId);

                selo.DataReservado = dataReserva;
                selo.FormReservado = "Atos Conjuntos";
                selo.Reservado = "N";
                selo.Atribuicao = 2;
                selo.Sistema = "NOTAS";
                selo.Livro = txtLivro.Text;
                selo.FolhaInicial = folhaInicio;
                selo.FolhaFinal = folhaFim;
                selo.NumeroAto = ato;
                selo.Natureza = natureza;
                selo.IdUsuarioReservado = _digitarProcuracao._usuario.UsuarioId;
                selo.UsuarioReservado = _digitarProcuracao._usuario.Nome;
                selo.Conjunto = "S";
                _AppServicoSelos.SalvarSeloModificado(selo);

                txtSelo.Text = string.Format("{0}{1:00000}", selo.Letra, selo.Numero);
                txtAleatorio.Text = selo.Aleatorio;

                _atoConjunto.Selo = txtSelo.Text;
                _atoConjunto.Aleatorio = txtAleatorio.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }


        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_status == "adicionando")
            {


                _AppServicoSelos.LiberarSelos(selo);
                _AppServicoSelos.SalvarSeloModificado(selo);

                var atoExcluir = _digitarProcuracao.listaAtoConjuntos.LastOrDefault();
                _digitarProcuracao.listaAtoConjuntos.Remove(atoExcluir);

                var atoExcluir1 = _digitarProcuracao.listaAtos.LastOrDefault();
                _digitarProcuracao.listaAtos.Remove(atoExcluir1);

                var excluirDoBanco = _AppServicoAtoConjuntos.GetById(atoExcluir.ConjuntoId);
                _AppServicoAtoConjuntos.Remove(excluirDoBanco);

                _digitarProcuracao.dataGridAtoConjuntos.Items.Refresh();

                if (_digitarProcuracao.dataGridAtoConjuntos.Items.Count > 0)
                    _digitarProcuracao.dataGridAtoConjuntos.SelectedIndex = 0;
            }

            this.Close();
        }

        private void btnExcluirParte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridParticipantes.Items.Count < 1)
                {
                    return;
                }
                if (dataGridParticipantes.SelectedIndex > -1)
                {

                    if (MessageBox.Show("Confirma a exclusão do participante?", "Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        _digitarProcuracao.estado = "excluindo participante";

                        var itemSelecionado = (Participante)dataGridParticipantes.SelectedItem;

                        var parteConjuntos = _digitarProcuracao.listaParteConjuntos.Where(p => p.IdNome == itemSelecionado.IdNomes && p.IdConjunto == _atoConjunto.ConjuntoId).ToList();

                        for (int i = 0; i < parteConjuntos.Count(); i++)
                        {
                            _digitarProcuracao.listaParteConjuntos.Remove(parteConjuntos[i]);

                            if (parteConjuntos[i].ParteConjuntosId > 0)
                            {
                                var parteConuntosExcluirDoBanco = _AppServicoParteConjuntos.GetById(parteConjuntos[i].ParteConjuntosId);
                                _AppServicoParteConjuntos.Remove(parteConuntosExcluirDoBanco);
                            }

                        }

                        var listaPartesExitestentes = _digitarProcuracao.listaParteConjuntos.Where(p => p.IdNome == itemSelecionado.IdNomes).ToList();

                        if (listaPartesExitestentes.Count < 1)
                        {

                            _digitarProcuracao.listaNomes.Remove(_digitarProcuracao.listaNomes.Where(p => p.NomeId == itemSelecionado.IdNomes).FirstOrDefault());


                            var excluirNomeDoBanco = _AppServicoNomes.GetById(itemSelecionado.IdNomes);
                            _AppServicoNomes.Remove(excluirNomeDoBanco);


                            _digitarProcuracao.listaPessoas.Remove(_digitarProcuracao.listaPessoas.Where(p => p.PessoasId == itemSelecionado.IdPessoa).FirstOrDefault());


                            var excluirPessoaDoBanco = _AppServicoPessoas.GetById(itemSelecionado.IdPessoa);
                            _AppServicoPessoas.Remove(excluirPessoaDoBanco);


                            _digitarProcuracao.participantes.Remove(itemSelecionado);
                            _digitarProcuracao.dataGridParticipantes.Items.Refresh();
                        }

                        CarregarParticipantes();

                        if (dataGridParticipantes.Items.Count > 0)
                            dataGridParticipantes.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um participante para excluir.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. Não foi possível excluir a Parte. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAlterarParte_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridParticipantes.Items.Count < 1)
            {
                return;
            }

            if (cmbNaturezas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Natureza antes de alterar o participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _digitarProcuracao.estado = "alterando participante";

            if (dataGridParticipantes.SelectedIndex > -1)
            {

                CarregarDataGridParticipantes();
            }
            else
            {
                MessageBox.Show("Selecione um participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void btnAdicionarParte_Click(object sender, RoutedEventArgs e)
        {
            _digitarProcuracao.estado = "adicionando participante";


            if (cmbNaturezas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Natureza antes de adicionar o participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            CarregarDataGridParticipantes();
        }

        private void CarregarDataGridParticipantes()
        {
            try
            {
                var qtdNaListaParticipantes = _digitarProcuracao.participantes.Count;

                var digitarParte = new ParticipantesProcuracao(_digitarProcuracao, this);
                digitarParte.Owner = this;
                digitarParte.ShowDialog();

                dataGridParticipantes.ItemsSource = _digitarProcuracao.participantes;
                dataGridParticipantes.Items.Refresh();

                _digitarProcuracao.dataGridParticipantes.ItemsSource = _digitarProcuracao.participantes;
                _digitarProcuracao.dataGridParticipantes.Items.Refresh();

                if (qtdNaListaParticipantes < _digitarProcuracao.participantes.Count)
                {
                    Participante parte = _digitarProcuracao.participantes.LastOrDefault();

                    dataGridParticipantes.SelectedItem = parte;
                    dataGridParticipantes.ScrollIntoView(parte);

                }

                CarregarParticipantes();
                _digitarProcuracao.estado = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar informações das Partes. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dataGridParticipantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _digitarProcuracao.dataGridParticipantes.SelectedItem = dataGridParticipantes.SelectedItem;
        }

        private void dataGridParticipantes_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridParticipantes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnAlterarParte_Click(sender, e);
        }

        private void btnSalvarAtoConjunto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbNaturezas.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione uma Natureza antes de salvar.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if (cmbTipoLivro.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecione o tipo do livro antes de salvar.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if (txtCodigo.Text == "")
                {
                    MessageBox.Show("Selecione informe a serventia antes de salvar.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Close();
        }

        private void Salvar()
        {
            _atoConjunto.Selo = txtSelo.Text;

            _atoConjunto.Aleatorio = txtAleatorio.Text;

            _atoConjunto.Natureza = ((Naturezas)cmbNaturezas.SelectedItem).Codigo;

            _atoConjunto.TabelaCustas = cmbTabelaAtos.Text;

            if (cmbNaturezas.Text != "OUTROS")
                _atoConjunto.TipoAto = cmbNaturezas.Text;
            else
                _atoConjunto.TipoAto = txtOutros.Text;


            _atoConjunto.Data = dtDataAto.SelectedDate.Value;

            _atoConjunto.Livro = txtLivro.Text;

            _atoConjunto.Folhas = txtFlsIni.Text;

            _atoConjunto.Ato = txtAto.Text;

            if (cmbLavradoRio.Text == "SIM")
                _atoConjunto.LavradoRj = "S";
            else
                _atoConjunto.LavradoRj = "N";

            _atoConjunto.UfOrigem = cmbUf.Text;

            if (cmbPorProcuracao.Text == "SIM")
                _atoConjunto.Procuracao = "S";
            else
                _atoConjunto.Procuracao = "N";

            _atoConjunto.TipoLivro = cmbTipoLivro.Text;

            if (txtValor.Text != "")
                _atoConjunto.Valor = Convert.ToDecimal(txtValor.Text);

            if (txtCodigo.Text != "")
                _atoConjunto.CodigoServentia = Convert.ToInt32(txtCodigo.Text);

            _atoConjunto.Serventia = txtServentia.Text;

            _AppServicoAtoConjuntos.Update(_atoConjunto);

            _digitarProcuracao.dataGridAtoConjuntos.Items.Refresh();



            var serie = _atoConjunto.Selo.Substring(0, 4);

            var numero = Convert.ToInt32(_atoConjunto.Selo.Substring(4, 5));

            var seloUtilizado = _AppServicoSelos.ConsultarPorSerieNumero(serie, numero);

            seloUtilizado.Status = "UTILIZADO";

            seloUtilizado.FormUtilizado = "Atos Conjuntos";
            seloUtilizado.Conjunto = "S";
            seloUtilizado.IdAto = _atoConjunto.ConjuntoId;
            seloUtilizado.DataPratica = _atoConjunto.Data;

            seloUtilizado.Escrevente = _digitarProcuracao.cmbEscreventes.Text;
            seloUtilizado.Natureza = _atoConjunto.TipoAto;

            _AppServicoSelos.SalvarSeloModificado(seloUtilizado);
        }


        private void AdicionarItensTabelaCustas()
        {
            var tabelaCustas = (TabelaCustas)cmbTabelaAtos.SelectedItem;


            var itemCustas = new ItensCustas();
            itemCustas.Descricao = tabelaCustas.Descricao;
            itemCustas.Tabela = tabelaCustas.Tabela;
            itemCustas.Item = tabelaCustas.Item;
            itemCustas.SubItem = tabelaCustas.SubItem;
            itemCustas.Quantidade = "1";
            itemCustas.Valor = tabelaCustas.Valor;

            try
            {
                itemCustas.Total = Convert.ToInt16(itemCustas.Quantidade) * itemCustas.Valor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var contem = _digitarProcuracao.listaItensCustas.Where(p => p.Tabela == itemCustas.Tabela && p.Item == itemCustas.Item && p.SubItem == itemCustas.SubItem).FirstOrDefault();

            if (contem == null)
                _digitarProcuracao.listaItensCustas.Add(itemCustas);
            else
            {
                contem.Quantidade = string.Format("{0}", Convert.ToInt16(contem.Quantidade) + 1);
                contem.Descricao = tabelaCustas.Descricao;
                contem.Tabela = tabelaCustas.Tabela;
                contem.Item = tabelaCustas.Item;
                contem.SubItem = tabelaCustas.SubItem;
                contem.Valor = tabelaCustas.Valor;
                contem.Total = Convert.ToInt16(contem.Quantidade) * itemCustas.Valor;
            }



            _digitarProcuracao.CalcularEmolumentos();
            _digitarProcuracao.CalcularMutuaAcoterj();
            _digitarProcuracao.CalcularBotaoTotal();

            _digitarProcuracao.dataGridCustas.Items.Refresh();
        }


        private void CarregarAlterando()
        {
            txtSelo.Text = _atoConjunto.Selo;

            txtAleatorio.Text = _atoConjunto.Aleatorio;



            if (_atoConjunto.Natureza == 999)
            {
                cmbNaturezas.SelectedItem = naturezas.Where(p => p.Codigo == _atoConjunto.Natureza).FirstOrDefault();
                txtOutros.Text = _atoConjunto.TipoAto;
            }
            else
                cmbNaturezas.Text = _atoConjunto.TipoAto;

            cmbTabelaAtos.Text = _atoConjunto.TabelaCustas;

            dtDataAto.SelectedDate = _atoConjunto.Data;

            txtLivro.Text = _atoConjunto.Livro;

            txtFlsIni.Text = _atoConjunto.Folhas;

            txtAto.Text = _atoConjunto.Ato;

            if (_atoConjunto.LavradoRj == "S")
                cmbLavradoRio.Text = "SIM";
            else
                cmbLavradoRio.Text = "NÃO";

            cmbUf.Text = _atoConjunto.UfOrigem;

            if (_atoConjunto.Procuracao == "S")
                cmbPorProcuracao.Text = "SIM";
            else
                cmbPorProcuracao.Text = "NÃO";

            cmbTipoLivro.Text = _atoConjunto.TipoLivro;


            txtValor.Text = string.Format("{0:N2}", _atoConjunto.Valor);


            txtCodigo.Text = _atoConjunto.CodigoServentia.ToString();

            txtServentia.Text = _atoConjunto.Serventia;

            CarregarParticipantes();
        }

        private void CarregarParticipantes()
        {

            var listaParteAtoConjuntos = _digitarProcuracao.listaParteConjuntos.Where(p => p.IdConjunto == _atoConjunto.ConjuntoId);

            var participantes = new List<Participante>();

            for (int i = 0; i < _digitarProcuracao.participantes.Count(); i++)
            {
                for (int c = 0; c < listaParteAtoConjuntos.Count(); c++)
                {
                    if (_digitarProcuracao.participantes[i].IdNomes == listaParteAtoConjuntos.ToList()[c].IdNome)
                    {
                        participantes.Add(_digitarProcuracao.participantes[i]);
                    }
                }
            }

            dataGridParticipantes.ItemsSource = participantes;

            dataGridParticipantes.Items.Refresh();

            if (dataGridParticipantes.Items.Count > 0)
            {
                dataGridParticipantes.SelectedIndex = 0;
            }
        }

        private void cmbNaturezas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbNaturezas.Focus())
            {
                var natureza = naturezas[cmbNaturezas.SelectedIndex];

                if (natureza.Codigo == 999)
                {
                    txtOutros.IsEnabled = true;
                    txtOutros.Focus();
                }
                else
                {
                    txtOutros.Text = "";
                    txtOutros.IsEnabled = false;
                }
            }
        }


        
        private void CarregarComboBoxNaturezas()
        {
            try
            {
                naturezas = _AppServicoNaturezas.GetAll().Where(p => p.Codigo >= 1).ToList();
                cmbNaturezas.ItemsSource = naturezas;
                cmbNaturezas.DisplayMemberPath = "Descricao";

                 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar NATUREZAS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarregarComboBoxTabelaAtos()
        {

            try
            {
                var tabelaCustas = _digitarProcuracao.listaTabelaCustas.Where(p => (p.Ano == _digitarProcuracao.Ano) && ((p.Tabela == "22" && p.Item == "2"))).OrderBy(p => p.Ordem).ToList();
                cmbTabelaAtos.ItemsSource = tabelaCustas;
                cmbTabelaAtos.DisplayMemberPath = "Descricao";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar TABELA DE ATOS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void cmbUfParte_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbRepresentado_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbRepresentado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbUfParte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
                PesquisarServentia();
            else
                txtServentia.Text = "";
        }

        private void PesquisarServentia()
        {
            var codigo = Convert.ToInt32(txtCodigo.Text);

            serventiasOutrasSelecionada = serventiasOutras.Where(p => p.Codigo == codigo).FirstOrDefault();

            if (serventiasOutrasSelecionada != null)
                txtServentia.Text = serventiasOutrasSelecionada.Descricao;
            else
                txtServentia.Text = "";
        }

        private void btnConsultarServentia_Click(object sender, RoutedEventArgs e)
        {
            var consultarServentia = new ConsultaServentias(this);
            consultarServentia.Owner = this;
            consultarServentia.ShowDialog();

            if (serventiasOutrasSelecionada != null)
            {
                txtCodigo.Text = serventiasOutrasSelecionada.Codigo.ToString();
                txtServentia.Text = serventiasOutrasSelecionada.Descricao;
            }
        }

        private void txtValor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!txtValor.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValor.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValor.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void DigitarSomenteNumerosVirgulas(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
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

        private void txtValor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValor.Text != "")
                txtValor.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValor.Text));
        }
    }
}