using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
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

namespace Cs_Notas.Windows.Escritura
{
    /// <summary>
    /// Interaction logic for IniciarPrimeiraDigitacaoEscritura.xaml
    /// </summary>
    public partial class IniciarPrimeiraDigitacaoEscritura : Window
    {

         List<Selos> _selos;
         Escrituras _escrituras = new Escrituras();
         Cs_Notas.Dominio.Entities.Usuario _usuario;
         List<TabelaCustas> listaTabelaCustas = new List<TabelaCustas>();
         List<Cs_Notas.Dominio.Entities.Usuario> escreventes = new List<Cs_Notas.Dominio.Entities.Usuario>();
         List<AtoConjuntos> listaAtoConjuntos = new List<AtoConjuntos>();
         List<AtoConjuntos> listaAtos = new List<AtoConjuntos>();
         List<TabelaCustas> tabelaCustas = new List<TabelaCustas>();
         List<Censec> naturezaCensec = new List<Censec>();
         List<Naturezas> naturezas = new List<Naturezas>();
         int Ano;
         List<int> anosCustasExistentes = new List<int>();

         private readonly IAppServicoTabelaCustas _AppServicoTabelaCustas = BootStrap.Container.GetInstance<IAppServicoTabelaCustas>();
         private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _AppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();
         private readonly IAppServicoCensec _AppServicoCensec = BootStrap.Container.GetInstance<IAppServicoCensec>();
         private readonly IAppServicoNaturezas _AppServicoNaturezas = BootStrap.Container.GetInstance<IAppServicoNaturezas>();

         Principal _principal;

         public IniciarPrimeiraDigitacaoEscritura(List<Selos> selos, Cs_Notas.Dominio.Entities.Usuario usuario, Principal principal)
        {
            _selos = selos;
            _usuario = usuario;
            _principal = principal;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Ano = _selos.FirstOrDefault().DataReservado.Date.Year;

            listaTabelaCustas = _AppServicoTabelaCustas.GetAll().ToList();
            
            anosCustasExistentes = listaTabelaCustas.Select(p => p.Ano).Distinct().ToList();
            
            CarregarComboBoxTabelaAtos();

            CarregarEscreventes();

            CarregarDadosSelo();
        }


        private void CarregarEscreventes()
        {
            try
            {
                escreventes = _AppServicoUsuario.GetAll().OrderBy(p => p.Nome).ToList();
                cmbEscreventes.ItemsSource = escreventes;
                cmbEscreventes.DisplayMemberPath = "Nome";
                cmbEscreventes.SelectedValuePath = "UsuarioId";

                cmbEscreventes.SelectedValue = _selos.FirstOrDefault().IdUsuarioReservado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as informações de Escreventes. Favor Comunicar o Erro ao Desenvolvedor do Sistema. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
            }
        }

        private void CarregarDadosSelo()
        {
            try
            {
                dtDataAto.SelectedDate = _selos.FirstOrDefault().DataReservado;
                txtLivro.Text = _selos.FirstOrDefault().Livro;
                txtFlsIni.Text = string.Format("{0:000}", _selos.FirstOrDefault().FolhaInicial);
                txtFlsFim.Text = string.Format("{0:000}", _selos.FirstOrDefault().FolhaFinal);
                txtAto.Text = string.Format("{0:000}", _selos.FirstOrDefault().NumeroAto);
                txtSelo.Text = string.Format("{0}{1}", _selos.FirstOrDefault().Letra, _selos.FirstOrDefault().Numero);
                txtAleatorio.Text = _selos.FirstOrDefault().Aleatorio;

               
                for (int i = 0; i < _selos.Count; i++)
                {
                    var atoConjunto = new AtoConjuntos();
                    atoConjunto.IdEscritura = i + 1;
                    atoConjunto.ConjuntoId = i + 1;
                    atoConjunto.Selo = string.Format("{0}{1}", _selos[i].Letra, _selos[i].Numero);
                    atoConjunto.Aleatorio = _selos[i].Aleatorio;
                    atoConjunto.Ordem = i + 1;
                    atoConjunto.Data = _selos[i].DataReservado;
                    atoConjunto.Livro = _selos[i].Livro;
                    atoConjunto.Folhas = string.Format("{0}-{1}", _selos[i].FolhaInicial, _selos[i].FolhaFinal);
                    atoConjunto.Ato = string.Format("{0}", _selos[i].NumeroAto);
                    if (i == 0)
                        atoConjunto.TipoAto = "PRINCIPAL";
                    else
                    {
                        atoConjunto.TipoAto = "ATO CONJUNTO";
                        listaAtoConjuntos.Add(atoConjunto);
                    }
                    listaAtos.Add(atoConjunto);
                }
               

                dataGridAtoConjuntos.ItemsSource = listaAtoConjuntos;
                if (listaAtoConjuntos.Count > 0)
                    dataGridAtoConjuntos.SelectedIndex = 0;
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
                tabelaCustas = listaTabelaCustas.Where(p => (p.Ano == Ano) && ((p.Tabela == "22" && p.Item == "1") || (p.Tabela == "22" && p.Item == "1.1") || (p.Tabela == "22" && p.Item == "1.2")
                  || (p.Tabela == "22" && p.Item == "1.3") || (p.Tabela == "22" && p.Item == "1.4" && p.SubItem == "*") || (p.Tabela == "22" && p.Item == "7") ||
                  (p.Tabela == "22" && p.Item == "6" && p.SubItem == "*"))).OrderBy(p => p.Ordem).ToList();
                cmbTabelaAtos.ItemsSource = tabelaCustas;
                cmbTabelaAtos.DisplayMemberPath = "Descricao";
                cmbTabelaAtos.SelectedIndex = 0;

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

        private void cmbTabelaAtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                CarregarComboBoxNaturezas();                

            }
            catch (Exception) { }
        }

        private void cmbNaturezas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar NATUREZAS. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
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


        private void btnSalvarSair_Click(object sender, RoutedEventArgs e)
        {
            List<string> listaPreencher = ConferirPreenchimentoDosCampos();

            if (listaPreencher.Count > 0)
            {
                string msgReservado = "Campo(s) de Preenchimento obrigatório encontrado(s): \n \n";

                foreach (var item in listaPreencher)
                {
                    msgReservado += string.Format("{0}\n", item);

                }


                if (listaPreencher.Count > 0)
                {
                    MessageBox.Show(msgReservado, "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
            }

            _escrituras.CertidaoId = 0;

            _escrituras.TipoAto = "RE";

            _escrituras.IdCodigoTabelaCustas = ((TabelaCustas)cmbTabelaAtos.SelectedItem).TabelaCustasId;


            if (dtDataAto.SelectedDate != null)
                _escrituras.DataAtoRegistro = dtDataAto.SelectedDate.Value;

            if (cmbEscreventes.SelectedIndex > -1)
            {
                var escrevente = (Cs_Notas.Dominio.Entities.Usuario)cmbEscreventes.SelectedItem;

                _escrituras.EscreventeAtoRegistro = escrevente.Nome;

                _escrituras.CpfEscrevente = escrevente.Cpf;
            }

            _escrituras.SeloEscritura = txtSelo.Text;

            _escrituras.Aleatorio = txtAleatorio.Text;

            _escrituras.LivroEscritura = txtLivro.Text;

            if (txtFlsIni.Text != "")
                _escrituras.FolhasInicio = Convert.ToInt32(txtFlsIni.Text);

            if (txtFlsFim.Text != "")
                _escrituras.FolhasFim = Convert.ToInt32(txtFlsFim.Text);

            if (txtAto.Text != "")
                _escrituras.NumeroAto = Convert.ToInt32(txtAto.Text);

            if (cmbNaturezas.SelectedIndex > -1)
            {
                var natureza = (Naturezas)cmbNaturezas.SelectedItem;

                _escrituras.Natureza = natureza.Codigo.ToString();

                _escrituras.Descricao = natureza.Descricao;

                _escrituras.Censec = natureza.Censec;

                _escrituras.TipoCensec = natureza.Tipo;

                _escrituras.TipoAtoCesdi = natureza.Cep;
            }
                 
            
            _escrituras.DistribuicaoEnviada = "N";

            if (cmbNaturezaCensec.SelectedIndex > -1)
            {
                var naturezaCensec = (Censec)cmbNaturezaCensec.SelectedItem;

                _escrituras.NaturezaCensec = naturezaCensec.Codigo;
            }

            _escrituras.Cancelado = "N";
            _escrituras.Enviado = "N";

            _escrituras.Login = _usuario.Nome;

            _escrituras.DataModificacao = DateTime.Now.Date;
            _escrituras.HoraModificacao = Convert.ToDateTime(DateTime.Now.ToShortTimeString());

           
            var aguarde = new AguardeSalvandoEscritura( _escrituras, listaAtoConjuntos, _principal, _usuario, _selos);
            this.Close();
            aguarde.Owner = _principal;
            aguarde.ShowDialog();
            
            
            

        }


        private List<string> ConferirPreenchimentoDosCampos()
        {
            var naoPreenchido = new List<string>();

            if (cmbTabelaAtos.SelectedItem == null)
                naoPreenchido.Add("Tabela de Atos;");

            if (cmbNaturezas.SelectedItem == null)
                naoPreenchido.Add("Natureza;");

            if (cmbNaturezaCensec.SelectedItem == null && cmbNaturezaCensec.IsEnabled == true)
                naoPreenchido.Add("Natureza Censec;");

            if (dtDataAto.SelectedDate == null)
                naoPreenchido.Add("Data;");
                        

            if (cmbEscreventes.SelectedItem == null)
                naoPreenchido.Add("Escrevente;");



            return naoPreenchido;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void dataGridAtoConjuntos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void dtDataAto_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Ano != dtDataAto.SelectedDate.Value.Date.Year)
            {
                if (anosCustasExistentes.Contains(dtDataAto.SelectedDate.Value.Date.Year))
                {
                    Ano = dtDataAto.SelectedDate.Value.Date.Year;

                    CarregarComboBoxTabelaAtos();


                    cmbTabelaAtos.SelectedIndex = 0;
                    
                }
                else
                {
                    MessageBox.Show("Ano Selecionado não encontrado na Tabela de Custas.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                    dtDataAto.SelectedDate = _escrituras.DataAtoRegistro;
                }
            }
        }
    }
}
