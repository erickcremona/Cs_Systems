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

namespace Cs_Notas.Windows
{
    /// <summary>
    /// Interaction logic for DigitarDadosParticipante.xaml
    /// </summary>
    public partial class DigitarDadosParticipante : Window
    {
        DigitarEscritura _digitarEscritura;
        Nomes nome = new Nomes();
        public Pessoas pessoa = new Pessoas();
        Participante participante = new Participante();
        List<string> Ufs = new List<string>();
        List<Participantes> qualidade = new List<Participantes>();
        List<EstadoCivil> estadoCivil;
        List<Regimes> regimes;
        Naturezas _natureza;

        private readonly IAppServicoMunicipios _AppServicoMunicipios = BootStrap.Container.GetInstance<IAppServicoMunicipios>();

        private readonly IAppServicoParticipantes _AppServicoParticipantes = BootStrap.Container.GetInstance<IAppServicoParticipantes>();

        private readonly IAppServicoRegimes _AppServicoRegimes = BootStrap.Container.GetInstance<IAppServicoRegimes>();

        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();

        private readonly IAppServicoNacionalidades _AppServicoNacionalidades = BootStrap.Container.GetInstance<IAppServicoNacionalidades>();

        private readonly IAppServicoNacionalidadesOnu _AppServicoNacionalidadesOnu = BootStrap.Container.GetInstance<IAppServicoNacionalidadesOnu>();

        public DigitarDadosParticipante(DigitarEscritura digitarEscritura)
        {
            _digitarEscritura = digitarEscritura;
            _natureza = (Naturezas)_digitarEscritura.cmbNaturezas.SelectedItem;
            InitializeComponent();
        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            CarregarUF();
            ValidarCpfCnpj();
            CarregarQualificacao();
            CarregarNacionalidades();
            CarregarNacionalidadesOnu();
            CarregarTipoDoi();
            CarregarSituacaoCpfCnpj();
            CarregarQualidade();
            CarregarConjuge();
            CarregarUfResidencia();
            CarregarUfOab();
            CarregarNacionalidadesResidencia();
        }

        private void CarregarConjuge()
        {
            if (_natureza.Tipo == "D")
            {
                var conjuge = new Conjuge();
                cmbConjuge.ItemsSource = conjuge.ObterListaConjuge();
                cmbConjuge.DisplayMemberPath = "Descricao";
            }
        }

        private void CarregarQualidade()
        {
            var listaQualidades = new List<string>();

            if (_natureza.Tipo == "D")
                gridCensec.IsEnabled = true;

            if (_natureza.Cep == 1 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("SEPARANDO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUDICATÁRIOS");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
            }

            if (_natureza.Cep == 2 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("RECONCILIANDO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUDICATÁRIOS");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
            }

            if (_natureza.Cep == 3 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("DIVORCIANDO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUDICATÁRIOS");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
            }

            if (_natureza.Cep == 4 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("DIVORCIANDO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUDICATÁRIOS");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
            }

            if (_natureza.Cep == 5 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("FALECIDO(A)");
                listaQualidades.Add("VIÚVO(A)");
                listaQualidades.Add("HERDEIRO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUCATÁRIO");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
                listaQualidades.Add("INVENTARIANTE");

            }

            if (_natureza.Cep == 6 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("FALECIDO(A)");
                listaQualidades.Add("VIÚVO(A)");
                listaQualidades.Add("HERDEIRO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUCATÁRIO");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");

            }

            if (_natureza.Cep == 7 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("DIVORCIANDO(A)");
                listaQualidades.Add("SEPARANDO(A)");
                listaQualidades.Add("FALECIDO(A)");
                listaQualidades.Add("VIUVO(A)");
                listaQualidades.Add("HERDEIRO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUDICATÁRIOS");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
            }

            if (_natureza.Cep == 8 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("FALECIDO(A)");
                listaQualidades.Add("VIUVO(A)");
                listaQualidades.Add("INVENTARIANTE");
                listaQualidades.Add("HERDEIRO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUDICATÁRIOS");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
            }

            if (_natureza.Cep == 9 && _natureza.Tipo == "D")
            {
                listaQualidades.Add("FALECIDO(A)");
                listaQualidades.Add("VIUVO(A)");
                listaQualidades.Add("HERDEIRO(A)");
                listaQualidades.Add("DIVORCIANDO(A)");
                listaQualidades.Add("ADVOGADO(A)");
                listaQualidades.Add("CESSIONÁRIO/ADJUDICATÁRIOS");
                listaQualidades.Add("CEDENTE");
                listaQualidades.Add("INTERVENIENTE");
                listaQualidades.Add("ANUENTE");
            }

            cmbQualidadeCensec.ItemsSource = listaQualidades;
        }

        private void CarregarSituacaoCpfCnpj()
        {

            SituacaoCpfCnpj situacao = new SituacaoCpfCnpj();
            cmbSituacaoCadastro.ItemsSource = situacao.ObterListaSituacaoCpfCnpj();
            cmbSituacaoCadastro.DisplayMemberPath = "Descricao";
        }

        private void CarregarTipoDoi()
        {
            if (_natureza.Doi == "S")
            {
                gridDoi.IsEnabled = true;

                var tipoDoi = new TipoDoi();

                cmbTipoDoi.ItemsSource = tipoDoi.ObterListaTipoDoi();
                cmbTipoDoi.DisplayMemberPath = "Descricao";
            }
        }

        private void CarregarNacionalidades()
        {
            var nacionalidades = _AppServicoNacionalidades.GetAll();

            cmbNacionalidade.ItemsSource = nacionalidades;

            cmbNacionalidade.DisplayMemberPath = "AdjetivoPatrio";
        }

        private void CarregarNacionalidadesOnu()
        {
            var nacionalidadesOnu = _AppServicoNacionalidadesOnu.GetAll();

            cmbNacionalidadeOnu.ItemsSource = nacionalidadesOnu;

            cmbNacionalidadeOnu.DisplayMemberPath = "Pais";
        }

        private void CarregarNacionalidadesResidencia()
        {

            if (_natureza.Tipo == "D")
            {
                var nacionalidadesOnu = _AppServicoNacionalidadesOnu.GetAll();

                cmbPaisResidencia.ItemsSource = nacionalidadesOnu;

                cmbPaisResidencia.DisplayMemberPath = "Pais";
            }
        }

        private void CarregarRegimeCasamento()
        {

            regimes = _AppServicoRegimes.GetAll().ToList();

            cmbRegime.ItemsSource = regimes;

            cmbRegime.DisplayMemberPath = "Descricao";
        }

        private void CarregarEstadoCivil()
        {
            var ec = new EstadoCivil();
            var indiceSelecao = cmbEstadoCivil.SelectedIndex;
            cmbEstadoCivil.IsEnabled = true;

            if (rbMasculino.IsChecked == true)
            {
                estadoCivil = ec.ObterListaEstadoCivil(true);
            }
            if (rbFeminino.IsChecked == true)
            {
                estadoCivil = ec.ObterListaEstadoCivil(false);
            }

            cmbEstadoCivil.ItemsSource = estadoCivil;
            cmbEstadoCivil.DisplayMemberPath = "Descricao";
            cmbEstadoCivil.SelectedIndex = indiceSelecao;
        }

        private void CarregarQualificacao()
        {
            qualidade = _AppServicoParticipantes.GetAll().OrderBy(p => p.Descricao).ToList();

            cmbQualificacao.ItemsSource = qualidade;

            cmbQualificacao.DisplayMemberPath = "Descricao";
        }

        private void CarregarUfResidencia()
        {
            if (_natureza.Tipo == "D")
            {
                var UfResidencia = new List<string>();

                UfResidencia = _AppServicoMunicipios.ObterUfsDosMunicipios();

                cmbUfNascimento.ItemsSource = UfResidencia;
            }
        }

        private void CarregarUfOab()
        {
            if (_natureza.Tipo == "D")
            {
                var UfOab = new List<string>();

                UfOab = _AppServicoMunicipios.ObterUfsDosMunicipios();

                cmbUfOAB.ItemsSource = UfOab;
            }
        }

        private void CarregarUF()
        {

            Ufs = _AppServicoMunicipios.ObterUfsDosMunicipios();

            cmbUfParte.ItemsSource = Ufs;

        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void txtCpfCnpj_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void txtCpfCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarCpfCnpj();
        }

        private void ValidarCpfCnpj()
        {
            imgValidaCpfCnpj.Visibility = Visibility.Hidden;
            txtCpfCnpj.Background = Brushes.Red;

            if (txtCpfCnpj.Text.Length == 11)
            {
                bool cpfValido = ValidaCpfCnpj.ValidaCPF(txtCpfCnpj.Text);

                if (cpfValido == true)
                {
                    imgValidaCpfCnpj.Visibility = Visibility.Visible;
                    txtCpfCnpj.Background = Brushes.White;
                    rbFisica.IsChecked = true;
                    rbMasculino.IsEnabled = true;
                    rbFeminino.IsEnabled = true;
                    txtNomeParte.Focus();
                    ProcurarNomesJaCadastrados();
                }
            }
            if (txtCpfCnpj.Text.Length == 14)
            {
                bool cnpjValido = ValidaCpfCnpj.ValidaCNPJ(txtCpfCnpj.Text);

                if (cnpjValido == true)
                {
                    imgValidaCpfCnpj.Visibility = Visibility.Visible;
                    txtCpfCnpj.Background = Brushes.White;
                    rbJuridica.IsChecked = true;
                    rbMasculino.IsChecked = false;
                    rbFeminino.IsChecked = false;
                    rbMasculino.IsEnabled = false;
                    rbFeminino.IsEnabled = false;
                    txtNomeParte.Focus();
                    ProcurarNomesJaCadastrados();
                }
            }
        }

        private void ProcurarNomesJaCadastrados()
        {
            var nomes = new List<Pessoas>();

            nomes = _AppServicoPessoas.ObterListaPessoasPorCpfCnpj(txtCpfCnpj.Text);

            if (nomes.Count > 0)
            {
                var nomesExistentes = new ConsultaNomesExistentes(nomes, this);
                nomesExistentes.Owner = this;
                nomesExistentes.ShowDialog();

            }

            CarregarComponentes();

        }

        private void SalvarPessoaNaLista()
        {

            pessoa.Nome = txtNomeParte.Text.Trim();

            if (rbFisica.IsChecked == true)
                pessoa.TipoPessoa = "F";
            if (rbJuridica.IsChecked == true)
                pessoa.TipoPessoa = "J";

            if (pessoa.PessoasId <= 0)
            {
                pessoa.DataCadastro = DateTime.Now.Date;
            }

            pessoa.CpfCgc = txtCpfCnpj.Text;

            pessoa.Rg = txtIdentidade.Text.Trim();

            pessoa.OrgaoRG = cmbOrgaoEmissor.Text;

            if (pessoa.OrgaoRG.Length > 70)
                pessoa.OrgaoRG = pessoa.OrgaoRG.Substring(0, 69);

            pessoa.DataEmissaoRG = dpDataEmissaoIdentidade.SelectedDate.Value;

            pessoa.Nacionalidade = cmbNacionalidade.Text;

            pessoa.Endereco = txtEndereco.Text.Trim();

            pessoa.Bairro = txtBairro.Text.Trim();

            pessoa.Cidade = cmbMunicipio.Text;

            pessoa.Uf = cmbUfParte.Text;

            pessoa.EsctadoCivil = ((EstadoCivil)cmbEstadoCivil.SelectedItem).Codigo;

            pessoa.Conjuge = txtNomeConjuge.Text.Trim();

            pessoa.RegimeBens = cmbRegime.Text;

            pessoa.DataCasamento = dpDataCasamento.SelectedDate.Value;

            pessoa.DataNascimento = dpDataNascimento.SelectedDate.Value;

            pessoa.NomePai = txtNomePai.Text.Trim();

            pessoa.NomeMae = txtNomeMae.Text.Trim();

            pessoa.Profissao = cmbProfissao.Text.Trim();

            if (pessoa.Profissao.Length > 100)
                pessoa.Profissao = pessoa.Profissao.Substring(0, 99);

            if (rbMasculino.IsChecked == true)
                pessoa.Sexo = "M";
            if (rbFeminino.IsChecked == true)
                pessoa.Sexo = "F";

            pessoa.Naturalidade = cmbUfNascimento.Text;

            if(txtQtdFilhosMaiores.Text != "")
            pessoa.QtdFilhosMaiores = Convert.ToInt16(txtQtdFilhosMaiores.Text);

            pessoa.UfNascimento = cmbUfNascimento.Text;

            pessoa.PaisReside = cmbPaisResidencia.Text;

            pessoa.UfPaisReside = cmbUfParte.Text;

            pessoa.CodigoMunicipioReside = ((Municipios)cmbMunicipioResidencia.SelectedItem).Codigo;

            pessoa.UfOab = cmbUfOAB.Text;

            pessoa.CodigoPais = ((Nacionalidades)cmbNacionalidade.SelectedItem).Codigo;

            pessoa.CodigoPaisOnu = ((NacionalidadesOnu)cmbNacionalidadeOnu.SelectedItem).Codigo;

            _digitarEscritura.listaPessoas.Add(pessoa);
        }


        private void SalvarNomeNaLista()
        {

            nome.Ordem = _digitarEscritura.listaNomes.Max(p => p.Ordem) + 1;

            nome.Principal = "S";

            nome.Nomenclatura = ((Participantes)cmbQualificacao.SelectedItem).Codigo.ToString();

            nome.Descricao = cmbQualificacao.Text;

            nome.Nome = txtNomeParte.Text.Trim();
                        
            if (rbFisica.IsChecked == true)
                nome.TipoPessoa = "F";
            if (rbJuridica.IsChecked == true)
                nome.TipoPessoa = "J";

            nome.Documento = txtCpfCnpj.Text;

            nome.Rg = txtIdentidade.Text.Trim();

            nome.DataEmissao = dpDataEmissaoIdentidade.SelectedDate.Value;

            nome.Orgao = cmbOrgaoEmissor.Text;

            if (nome.Orgao.Length > 70)
                nome.Orgao = nome.Orgao.Substring(0, 59);

            nome.Nacionalidade = cmbNacionalidade.Text;

            nome.DataNascimento = dpDataNascimento.SelectedDate.Value;

            nome.NomePai = txtNomePai.Text.Trim();

            nome.NomeMae = txtNomeMae.Text.Trim();

            nome.Profissao = cmbProfissao.Text.Trim();

            if (nome.Profissao.Length > 60)
                nome.Profissao = nome.Profissao.Substring(0, 59);

            nome.Endereco = txtEndereco.Text.Trim();

            nome.Municipio = cmbMunicipio.Text;

            nome.Uf = cmbUfParte.Text;

            nome.DataCasamento = dpDataCasamento.SelectedDate.Value;

            nome.Conjuge = txtNomeConjuge.Text.Trim();

            if(cmbRepresentado.SelectedIndex == 0)
            nome.Representa = "S";
            if (cmbRepresentado.SelectedIndex == 1)
                nome.Representa = "N";
            
            nome.Bairro = txtBairro.Text.Trim();

            if(txtParticipacao.Text != "")
            nome.Participacao = Convert.ToDecimal(txtParticipacao.Text);

            nome.DataNascimento = dpDataNascimento.SelectedDate.Value;

            nome.Tipo = ((TipoDoi)cmbTipoDoi.SelectedItem).Sigla;

            if(ckbARogo.IsChecked == true)
            {
                if()
            }

            if (rbMasculino.IsChecked == true)
                pessoa.Sexo = "M";
            if (rbFeminino.IsChecked == true)
                pessoa.Sexo = "F";

            pessoa.Naturalidade = cmbUfNascimento.Text;

            if (txtQtdFilhosMaiores.Text != "")
                pessoa.QtdFilhosMaiores = Convert.ToInt16(txtQtdFilhosMaiores.Text);

            pessoa.UfNascimento = cmbUfNascimento.Text;

            pessoa.PaisReside = cmbPaisResidencia.Text;

            pessoa.UfPaisReside = cmbUfParte.Text;

            pessoa.CodigoMunicipioReside = ((Municipios)cmbMunicipioResidencia.SelectedItem).Codigo;

            pessoa.UfOab = cmbUfOAB.Text;

            pessoa.CodigoPais = ((Nacionalidades)cmbNacionalidade.SelectedItem).Codigo;

            pessoa.CodigoPaisOnu = ((NacionalidadesOnu)cmbNacionalidadeOnu.SelectedItem).Codigo;
        }

        private void SalvarParticipanteNaLista()
        {

        }

        private void CarregarComponentes()
        {

            txtNomeParte.Text = pessoa.Nome;
            if (pessoa.TipoPessoa == "F")
                rbFisica.IsChecked = true;
            if (pessoa.TipoPessoa == "J")
                rbJuridica.IsChecked = true;

            if (pessoa.Sexo == "M")
                rbMasculino.IsChecked = true;
            if (pessoa.Sexo == "F")
                rbFeminino.IsChecked = true;

            txtEndereco.Text = pessoa.Endereco;
            txtBairro.Text = pessoa.Bairro;
            cmbUfParte.Text = pessoa.Uf;
            cmbMunicipio.Text = pessoa.Cidade;
            txtIdentidade.Text = pessoa.Rg;
            cmbOrgaoEmissor.Text = pessoa.OrgaoRG;

            if (pessoa.DataEmissaoRG.ToShortDateString() != "01/01/0001")
                dpDataEmissaoIdentidade.SelectedDate = pessoa.DataEmissaoRG;

            cmbProfissao.Text = pessoa.Profissao;
            cmbEstadoCivil.SelectedValuePath = "Codigo";
            cmbEstadoCivil.SelectedValue = pessoa.EsctadoCivil;
            cmbRegime.Text = pessoa.RegimeBens;
            txtNomeConjuge.Text = pessoa.Conjuge;

            if (pessoa.DataNascimento.ToShortDateString() != "01/01/0001")
                dpDataNascimento.Text = pessoa.DataNascimento.ToShortDateString();

            if (pessoa.DataCasamento.ToShortDateString() != "01/01/0001")
                dpDataCasamento.Text = pessoa.DataCasamento.ToShortDateString();

            cmbNacionalidade.Text = pessoa.Nacionalidade;
            
            
            if (pessoa.CodigoPaisOnu > 0)
            {
                cmbNacionalidadeOnu.SelectedValuePath = "Codigo";

                cmbNacionalidadeOnu.SelectedValue = pessoa.CodigoPaisOnu;
            }
            txtNomePai.Text = pessoa.NomePai;
            txtNomeMae.Text = pessoa.NomeMae;

        }

        private void cmbUfParte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUfParte.SelectedIndex > -1)
            {
                cmbMunicipio.ItemsSource = _AppServicoMunicipios.ObterMunicipiosPorUF(Ufs[cmbUfParte.SelectedIndex]).OrderBy(p => p.Nome);

                cmbMunicipio.DisplayMemberPath = "Nome";

                if (_natureza.Tipo == "D")
                {
                    cmbMunicipioResidencia.ItemsSource = _AppServicoMunicipios.ObterMunicipiosPorUF(Ufs[cmbUfParte.SelectedIndex]).OrderBy(p => p.Nome);

                    cmbMunicipioResidencia.DisplayMemberPath = "Nome";
                }
            }
        }

        private void rbMasculino_Checked(object sender, RoutedEventArgs e)
        {
            CarregarEstadoCivil();
        }

        private void rbFeminino_Checked(object sender, RoutedEventArgs e)
        {
            CarregarEstadoCivil();
        }

        private void cmbEstadoCivil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEstadoCivil.SelectedIndex == 0 || cmbEstadoCivil.SelectedIndex == 4)
            {
                cmbRegime.ItemsSource = null;
                cmbRegime.IsEnabled = false;
                dpDataCasamento.SelectedDate = null;
                dpDataCasamento.IsEnabled = false;
                txtNomeConjuge.Text = "";
                txtNomeConjuge.IsEnabled = false;
            }
            else
            {
                cmbRegime.IsEnabled = true;
                dpDataCasamento.IsEnabled = true;
                txtNomeConjuge.IsEnabled = true;
                CarregarRegimeCasamento();
            }
        }

        private void cmbOrgaoEmissor_GotFocus(object sender, RoutedEventArgs e)
        {
            cmbOrgaoEmissor.ItemsSource = _AppServicoPessoas.ObterListaOrgaoEmissor();
        }

        private void cmbProfissao_GotFocus(object sender, RoutedEventArgs e)
        {
            var lista = _AppServicoPessoas.ObterListaProfissao();
            cmbProfissao.ItemsSource = lista.OrderBy(p => p);
        }

        private void cmbMunicipio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbMunicipioResidencia.SelectedIndex = cmbMunicipio.SelectedIndex;
        }

        private void cmbNacionalidadeOnu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbPaisResidencia.SelectedIndex = cmbNacionalidadeOnu.SelectedIndex;
        }

        private void cmbRepresentado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (cmbRepresentado.SelectedIndex == 0)
            {
                imgCpfIncorreto.Visibility = Visibility.Visible;
                txtCpfProcurador.IsEnabled = true;
                txtCpfProcurador.Focus();
            }
            else
            {
                txtCpfProcurador.Text = "";
                txtCpfProcurador.IsEnabled = false;
                imgCpfIncorreto.Visibility = Visibility.Hidden;
            }

        }

        private void txtCpfProcurador_TextChanged(object sender, TextChangedEventArgs e)
        {

            imgCpfCorreto.Visibility = Visibility.Hidden;
            imgCpfIncorreto.Visibility = Visibility.Visible;

            if (txtCpfProcurador.Text.Length == 11)
            {
                bool cpfValido = ValidaCpfCnpj.ValidaCPF(txtCpfProcurador.Text);

                if (cpfValido == true)
                {
                    imgCpfCorreto.Visibility = Visibility.Visible;
                    imgCpfIncorreto.Visibility = Visibility.Hidden;
                }
            }
            if (txtCpfProcurador.Text.Length == 14)
            {
                bool cnpjValido = ValidaCpfCnpj.ValidaCNPJ(txtCpfProcurador.Text);

                if (cnpjValido == true)
                {
                    imgCpfCorreto.Visibility = Visibility.Visible;
                    imgCpfIncorreto.Visibility = Visibility.Hidden;
                }
            }
        }



    }
}
