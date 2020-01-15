
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

namespace Cs_Notas.Windows
{
    /// <summary>
    /// Interaction logic for DigitarEscritura.xaml
    /// </summary>
    public partial class DigitarEscritura : Window
    {
        Selos _selos;
        Escrituras _escrituras;
        string primeiraDigitacao = "nao";
        Cs_Notas.Dominio.Entities.Usuario _usuario;
        public List<Naturezas> naturezas = new List<Naturezas>();
        List<Censec> naturezaCensec = new List<Censec>();
        List<Adicional> adicionalAtos = new List<Adicional>();
        public List<Participante> participantes = new List<Participante>();
        public List<Pessoas> listaPessoas = new List<Pessoas>();
        public List<Nomes> listaNomes = new List<Nomes>();

        List<Cs_Notas.Dominio.Entities.Usuario> escreventes = new List<Cs_Notas.Dominio.Entities.Usuario>();


        public List<Pessoas> pessoas = new List<Pessoas>();
        public List<Nomes> nomes = new List<Nomes>();

        private readonly IAppServicoNaturezas _AppServicoNaturezas = BootStrap.Container.GetInstance<IAppServicoNaturezas>();
        private readonly IAppServicoCensec _AppServicoCensec = BootStrap.Container.GetInstance<IAppServicoCensec>();
        private readonly IAppServicoAdicional _AppServicoAdicional = BootStrap.Container.GetInstance<IAppServicoAdicional>();
        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();
        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();

        public DigitarEscritura(Selos selos, Cs_Notas.Dominio.Entities.Usuario usuario)
        {
            primeiraDigitacao = "sim";
            _selos = selos;
            _usuario = usuario;
            InitializeComponent();
        }

        public DigitarEscritura(Escrituras escrituras, Cs_Notas.Dominio.Entities.Usuario usuario)
        {
            primeiraDigitacao = "nao";
            _escrituras = escrituras;
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxNaturezas();
            CarregarComboBoxTabelaAtos();
            CarregarEscreventes();

            if (primeiraDigitacao == "sim")
                CarregarDadosSelo();

            if (primeiraDigitacao == "nao")
                CarregarParticipantes();
        }

        private void CarregarParticipantes()
        {
            try
            {
                nomes = _AppServicoNomes.ObterNomesPorIdAto(_escrituras.EscriturasId);
                Participante participante = new Participante();
                foreach (var item in nomes)
                {
                    var pessoa = _AppServicoPessoas.GetById(item.IdPessoa);

                    pessoas.Add(pessoa);

                    participante.IdAto = _escrituras.EscriturasId;
                    participante.IdNomes = item.NomeId;
                    participante.IdPessoa = pessoa.PessoasId;
                    participante.Nome = pessoa.Nome;
                    participante.Descricao = item.Descricao;
                    participante.CpfCnpj = pessoa.CpfCgc;

                    participantes.Add(participante);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações dos Participantes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarEscreventes()
        {
            escreventes = _AppServicoUsuario.GetAll().OrderBy(p => p.Nome).ToList();
            cmbEscreventes.ItemsSource = escreventes;
            cmbEscreventes.DisplayMemberPath = "Nome";

        }

        private void CarregarDadosSelo()
        {
            try
            {
                dtDataAto.SelectedDate = _selos.DataReservado;
                txtLivro.Text = _selos.Livro;
                txtFlsIni.Text = _selos.FolhaInicial.ToString();
                txtFlsFim.Text = _selos.FolhaFinal.ToString();
                txtAto.Text = _selos.NumeroAto.ToString();
                txtRecibo.Text = _selos.Recibo.ToString();
                txtSelo.Text = string.Format("{0}{1}", _selos.Letra, _selos.Numero);
                txtAleatorio.Text = _selos.Aleatorio;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar informações do Selo. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarComboBoxTabelaAtos()
        {
            try
            {
                adicionalAtos = _AppServicoAdicional.GetAll().Where(p => p.Atribuicao == 2 && p.Tipo == "E").OrderBy(p => p.Ordem).ToList();
                cmbTabelaAtos.ItemsSource = adicionalAtos;
                cmbTabelaAtos.DisplayMemberPath = "Descricao";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar TABELA DE ATOS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarregarComboBoxNaturezaCensec()
        {
            try
            {
                naturezaCensec = _AppServicoCensec.GetAll().ToList();
                cmbNaturezaCensec.ItemsSource = naturezaCensec;
                cmbNaturezaCensec.DisplayMemberPath = "Descricao";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar NATUREZAS CENSEC. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
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


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridSeriesDisponiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbNaturezas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var natureza = naturezas[cmbNaturezas.SelectedIndex];

            if (natureza.Censec == "S")
                ckbCensec.IsChecked = true;
            else
                ckbCensec.IsChecked = false;

            if (natureza.Doi == "S")
                ckbDoi.IsChecked = true;
            else
                ckbDoi.IsChecked = false;

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
            if (natureza.Tipo == "E")
            {
                cmbNaturezaCensec.IsEnabled = true;
                CarregarComboBoxNaturezaCensec();
            }
            else
            {
                cmbNaturezaCensec.ItemsSource = null;
                cmbNaturezaCensec.IsEnabled = false;
            }
        }

        private void ckbDoi_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbDoi.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Doi = "S";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void ckbCensec_Checked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbCensec.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Censec = "S";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void ckbDoi_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbDoi.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Doi = "N";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void ckbCensec_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cmbNaturezas.SelectedIndex > -1)
                if (ckbCensec.IsFocused == true)
                {
                    var natureza = naturezas[cmbNaturezas.SelectedIndex];

                    natureza.Censec = "N";

                    _AppServicoNaturezas.Update(natureza);
                }
        }

        private void cmbTabelaAtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                lblTabelaAtos.Content = string.Format("Tabela de Atos ({0})", adicionalAtos[cmbTabelaAtos.SelectedIndex].Codigo);
            }
            catch (Exception) { }
        }

        private void btnAdicionarParte_Click(object sender, RoutedEventArgs e)
        {
            if(cmbNaturezas.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma Natureza antes de adicionar o participante.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var digitarParte = new DigitarDadosParticipante(this);
            digitarParte.Owner = this;
            digitarParte.ShowDialog();
        }
    }
}
