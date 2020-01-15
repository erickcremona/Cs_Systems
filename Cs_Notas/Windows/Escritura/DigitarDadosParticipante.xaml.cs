using CrossCutting;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.ValuesObject;
using Cs_Notas.Windows.Escritura;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();

        private readonly IAppServicoParteConjuntos _AppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();

        string _ato;

        DigitarAtoConjunto _digitarAtoConjunto;

        public DigitarDadosParticipante(DigitarEscritura digitarEscritura)
        {
            _digitarEscritura = digitarEscritura;
            _natureza = (Naturezas)_digitarEscritura.cmbNaturezas.SelectedItem;
            _ato = "principal";
            InitializeComponent();
        }

        public DigitarDadosParticipante(DigitarEscritura digitarEscritura, DigitarAtoConjunto digitarAtoConjunto)
        {
            _digitarEscritura = digitarEscritura;
            _digitarAtoConjunto = digitarAtoConjunto;
            _natureza = (Naturezas)_digitarAtoConjunto.cmbNaturezas.SelectedItem;
            _ato = "conjunto";
            InitializeComponent();
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
            txtCpfCnpj.Focus();



            if (_digitarEscritura.estado == "alterando participante")
            {
                nome = _digitarEscritura.listaNomes.Where(p => p.NomeId == ((Participante)_digitarEscritura.dataGridParticipantes.SelectedItem).IdNomes).FirstOrDefault();

                pessoa = _digitarEscritura.listaPessoas.Where(p => p.PessoasId == ((Participante)_digitarEscritura.dataGridParticipantes.SelectedItem).IdPessoa).FirstOrDefault();

                CarregarComponentesAlterar();
            }




            dataGridAtoConjunto.ItemsSource = _digitarEscritura.listaAtos;
            CarregarParteConjuntosNaLista();
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
            gbEstadoCivil.IsEnabled = true;

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

        private void DigitarSomenteNumerosVirgulas(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
        }

        private void txtCpfCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ValidarCpfCnpj();
            }
            catch(Exception){};
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

                    if (_digitarEscritura.estado == "adicionando participante")
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

                    if (_digitarEscritura.estado == "adicionando participante")
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


            pessoa.CpfCgc = txtCpfCnpj.Text;

            pessoa.Rg = txtIdentidade.Text.Trim();

            pessoa.OrgaoRG = cmbOrgaoEmissor.Text;

            if (pessoa.OrgaoRG != null && pessoa.OrgaoRG.Length > 70)
                pessoa.OrgaoRG = pessoa.OrgaoRG.Substring(0, 69);

            if (dpDataEmissaoIdentidade.SelectedDate != null)
                pessoa.DataEmissaoRG = dpDataEmissaoIdentidade.SelectedDate.Value;

            pessoa.Nacionalidade = cmbNacionalidade.Text;

            pessoa.Endereco = txtEndereco.Text.Trim();

            pessoa.Bairro = txtBairro.Text.Trim();

            pessoa.Cidade = cmbMunicipio.Text;

            pessoa.Uf = cmbUfParte.Text;

            if (cmbEstadoCivil.SelectedIndex > -1)
                pessoa.EsctadoCivil = ((EstadoCivil)cmbEstadoCivil.SelectedItem).Codigo;

            pessoa.Conjuge = txtNomeConjuge.Text.Trim();

            pessoa.RegimeBens = cmbRegime.Text;

            if (dpDataCasamento.SelectedDate != null)
                pessoa.DataCasamento = dpDataCasamento.SelectedDate.Value;

            if (dpDataNascimento.SelectedDate != null)
                pessoa.DataNascimento = dpDataNascimento.SelectedDate.Value;

            pessoa.NomePai = txtNomePai.Text.Trim();

            pessoa.NomeMae = txtNomeMae.Text.Trim();

            if (cmbProfissao.Text != "" && cmbProfissao.Text != null)
                pessoa.Profissao = cmbProfissao.Text.Trim();

            if (pessoa.Profissao != null && pessoa.Profissao.Length > 100)
                pessoa.Profissao = pessoa.Profissao.Substring(0, 99);

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

            if (cmbMunicipioResidencia.SelectedIndex > -1)
                pessoa.CodigoMunicipioReside = ((Municipios)cmbMunicipioResidencia.SelectedItem).Codigo;

            pessoa.UfOab = cmbUfOAB.Text;

            if (cmbNacionalidade.SelectedIndex > -1)
                pessoa.CodigoPais = ((Nacionalidades)cmbNacionalidade.SelectedItem).Codigo;

            if (cmbNacionalidadeOnu.SelectedIndex > -1)
                pessoa.CodigoPaisOnu = ((NacionalidadesOnu)cmbNacionalidadeOnu.SelectedItem).Codigo;



            if (_digitarEscritura.estado == "adicionando participante")
            {
                pessoa.DataCadastro = DateTime.Now.Date;

                _AppServicoPessoas.Add(pessoa);

                _digitarEscritura.listaPessoas.Add(pessoa);
            }
            else
            {
                _AppServicoPessoas.SalvarAlteracao(pessoa);

                var pessoaAlterar = _digitarEscritura.listaPessoas.Where(p => p.PessoasId == pessoa.PessoasId).FirstOrDefault();

                pessoaAlterar = pessoa;

            }
        }




        private void SalvarNomeNaLista()
        {

            if (_digitarEscritura.listaAtos[0].IsChecked == true)
                nome.Principal = "S";
            else
                nome.Principal = "N";

            if (cmbQualificacao.SelectedIndex > -1)
                nome.Nomenclatura = ((Participantes)cmbQualificacao.SelectedItem).Codigo.ToString();

            nome.Descricao = cmbQualificacao.Text;

            nome.Nome = txtNomeParte.Text.Trim();

            if (rbFisica.IsChecked == true)
                nome.TipoPessoa = "F";
            if (rbJuridica.IsChecked == true)
                nome.TipoPessoa = "J";

            nome.Documento = txtCpfCnpj.Text;

            nome.Rg = txtIdentidade.Text.Trim();

            if (dpDataEmissaoIdentidade.SelectedDate != null)
                nome.DataEmissao = dpDataEmissaoIdentidade.SelectedDate.Value;

            nome.Orgao = cmbOrgaoEmissor.Text;

            if (nome.Orgao != null && nome.Orgao.Length > 70)
                nome.Orgao = nome.Orgao.Substring(0, 59);

            //nome.Profissao = cmbProfissao.Text;

            //nome.EstadoCivil = cmbEstadoCivil.Text;

            //nome.RegimeCasamento = ((Regimes)cmbRegime.SelectedItem).RegimesId.ToString();


            nome.Nacionalidade = cmbNacionalidade.Text;

            if (dpDataNascimento.SelectedDate != null)
                nome.DataNascimento = dpDataNascimento.SelectedDate.Value;

            nome.NomePai = txtNomePai.Text.Trim();

            nome.NomeMae = txtNomeMae.Text.Trim();

            if (nome.Profissao != null)
                nome.Profissao = cmbProfissao.Text.Trim();

            if (nome.Profissao != null && nome.Profissao.Length > 60)
                nome.Profissao = nome.Profissao.Substring(0, 59);

            nome.Endereco = txtEndereco.Text.Trim();

            nome.Municipio = cmbMunicipio.Text;

            nome.Uf = cmbUfParte.Text;

            if (dpDataCasamento.SelectedDate != null)
                nome.DataCasamento = dpDataCasamento.SelectedDate.Value;

            nome.Conjuge = txtNomeConjuge.Text.Trim();

            nome.Bairro = txtBairro.Text.Trim();

            if (txtParticipacao.Text != "")
                nome.Participacao = Convert.ToDecimal(txtParticipacao.Text);

            if (dpDataNascimento.SelectedDate != null)
                nome.DataNascimento = dpDataNascimento.SelectedDate.Value;

            if (cmbTipoDoi.SelectedIndex > -1)
                nome.Tipo = ((TipoDoi)cmbTipoDoi.SelectedItem).Sigla;

            if (ckbARogo.IsChecked == true)
                nome.Representa = "S";
            else
                nome.Representa = "N";

            if (cmbRepresentado.SelectedIndex == 0)
            {
                nome.Procurador = "S";
                nome.CpfProcurador = txtCpfProcurador.Text;
            }

            if (cmbRepresentado.SelectedIndex == 1)
                nome.Procurador = "N";

            nome.NumeroBIB = txtNumeroBib.Text;

            if (ckbOcultarEscritura.IsChecked == true)
                nome.Ocultar = "S";
            else
                nome.Ocultar = "N";

            nome.Escritura = ParteNaEscritura();

            if (ckbOcultarDistribuicao.IsChecked == true)
                nome.OcultarDistribuicao = "S";
            else
                nome.OcultarDistribuicao = "N";

            nome.NumeroCRE = txtNumeroCre.Text;

            if (cmbQualidadeCensec.SelectedIndex > -1)
                nome.Qualidade = cmbQualidadeCensec.Text;

            if (cmbSituacaoCadastro.SelectedIndex > -1)
                nome.Situacao = ((SituacaoCpfCnpj)cmbSituacaoCadastro.SelectedItem).Codigo;
            else
                nome.Situacao = -1;

            if (ckbOcultarXml.IsChecked == true)
                nome.OcultarXML = "S";
            else
                nome.OcultarXML = "N";

            nome.Hash = txtNumeroHash.Text.Trim();

            if (cmbConjuge.SelectedIndex > -1)
                nome.NumeroConjuge = ((Conjuge)cmbConjuge.SelectedItem).NumeroConjuge;
            else
                nome.NumeroConjuge = -1;

            if (_digitarEscritura.estado == "adicionando participante")
            {
                nome.IdPessoa = pessoa.PessoasId;
                nome.IdEscritura = _digitarEscritura._escrituras.EscriturasId;

                _AppServicoNomes.Add(nome);
                _digitarEscritura.listaNomes.Add(nome);

            }
            else
            {

                _AppServicoNomes.Update(nome);

                var nomeAlterar = _digitarEscritura.listaNomes.Where(p => p.NomeId == nome.NomeId).FirstOrDefault();

                nomeAlterar = nome;


            }
        }




        private void CarregarParteConjuntosNaLista()
        {
            var parteConjuntos = _digitarEscritura.listaParteConjuntos.Where(p => p.IdNome == nome.NomeId).ToList();


            foreach (var item in _digitarEscritura.listaAtos)
            {
                item.IsChecked = false;

                if (nome.Principal == "S")
                    _digitarEscritura.listaAtos[0].IsChecked = true;

                if (_ato == "conjunto")
                {

                    if (((AtoConjuntos)_digitarEscritura.dataGridAtoConjuntos.SelectedItem).ConjuntoId == item.ConjuntoId)
                        item.IsChecked = true;

                    if (_digitarEscritura.estado == "alterando participante")
                        for (int i = 0; i < parteConjuntos.Count; i++)
                        {
                            if (item.ConjuntoId == parteConjuntos[i].IdConjunto)
                                item.IsChecked = true;

                        }
                    else
                    {
                        if (_ato == "principal")
                            item.IsChecked = true;
                    }
                }
                else
                {
                    if (_digitarEscritura.estado == "alterando participante")
                        for (int i = 0; i < parteConjuntos.Count; i++)
                        {
                            if (item.ConjuntoId == parteConjuntos[i].IdConjunto)
                                item.IsChecked = true;

                            
                        }
                    else
                        item.IsChecked = true;
                }
            }
        }

        private void SalvarParteConjuntosNaLista()
        {
            var parteConjuntos = new ParteConjuntos();

            if (_digitarEscritura.estado == "alterando participante")
            {
                var listaParteConjuntos = _digitarEscritura.listaParteConjuntos.Where(p => p.IdNome == nome.NomeId).ToList();

                foreach (var item in listaParteConjuntos)
                {
                    if (item.IdConjunto != 0)
                    {
                        var remover = _AppServicoParteConjuntos.GetById(item.ParteConjuntosId);
                        _AppServicoParteConjuntos.Remove(remover);

                    }
                    _digitarEscritura.listaParteConjuntos.Remove(item);

                }
            }


            for (int i = 0; i < _digitarEscritura.listaAtos.Count; i++)
            {

                if (_digitarEscritura.listaAtos[i].IsChecked == true)
                {
                    parteConjuntos = new ParteConjuntos();

                    parteConjuntos.IdEscritura = _digitarEscritura.listaAtos[i].IdEscritura;
                    parteConjuntos.IdNome = nome.NomeId;
                    parteConjuntos.IdConjunto = _digitarEscritura.listaAtos[i].ConjuntoId;
                    if(i > 0)
                    _AppServicoParteConjuntos.Add(parteConjuntos);
                    _digitarEscritura.listaParteConjuntos.Add(parteConjuntos);


                }
            }
        }

        private void SalvarParticipanteNaLista()
        {
            participante.Nome = nome.Nome;
            participante.IdNomes = nome.NomeId;
            participante.IdPessoa = pessoa.PessoasId;
            participante.Descricao = nome.Descricao;
            participante.CpfCnpj = pessoa.CpfCgc;

            if (_digitarEscritura.estado == "adicionando participante")
                _digitarEscritura.participantes.Add(participante);
            else
            {
                participante = _digitarEscritura.participantes.Where(p => p.IdNomes == nome.NomeId).FirstOrDefault();

                participante.Nome = nome.Nome;
                participante.Descricao = nome.Descricao;
                participante.CpfCnpj = pessoa.CpfCgc;

                _digitarEscritura.parte = participante;
            }
        }



        private string ParteNaEscritura()
        {
            return "";
        }

        private void CarregarComponentesAlterar()
        {
            txtCpfCnpj.Text = pessoa.CpfCgc;
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


            cmbQualificacao.Text = nome.Descricao;

            txtNumeroHash.Text = nome.Hash;

            txtNumeroBib.Text = nome.NumeroBIB;

            txtNumeroCre.Text = nome.NumeroCRE;

            cmbTipoDoi.SelectedValuePath = "Sigla";
            cmbTipoDoi.SelectedValue = nome.Tipo;


            cmbSituacaoCadastro.SelectedValuePath = "Codigo";
            cmbSituacaoCadastro.SelectedValue = nome.Situacao;

            txtParticipacao.Text = nome.Participacao.ToString();

            if (nome.Procurador == "S")
                cmbRepresentado.SelectedIndex = 0;
            if (nome.Procurador == "N")
                cmbRepresentado.SelectedIndex = 1;

            if (nome.CpfProcurador != null)
                txtCpfProcurador.Text = nome.CpfProcurador;

            cmbQualidadeCensec.Text = nome.Qualidade;

            txtQtdFilhosMaiores.Text = pessoa.QtdFilhosMaiores.ToString();

            cmbUfOAB.Text = pessoa.UfOab;

            cmbConjuge.SelectedValuePath = "NumeroConjuge";
            cmbConjuge.SelectedValue = nome.NumeroConjuge;

            cmbMunicipioResidencia.SelectedValuePath = "Codigo";
            cmbMunicipioResidencia.SelectedValue = pessoa.CodigoMunicipioReside;

            cmbUfNascimento.Text = pessoa.UfNascimento;

            cmbPaisResidencia.Text = pessoa.PaisReside;

            if (nome.Ocultar == "S")
                ckbOcultarEscritura.IsChecked = true;

            if (nome.OcultarDistribuicao == "S")
                ckbOcultarDistribuicao.IsChecked = true;

            if (nome.OcultarXML == "S")
                ckbOcultarXml.IsChecked = true;

            if (nome.Representa == "S")
                ckbARogo.IsChecked = true;

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
            gbSexo.Foreground = Brushes.Black;
        }

        private void rbFeminino_Checked(object sender, RoutedEventArgs e)
        {
            CarregarEstadoCivil();
        }

        private void cmbEstadoCivil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEstadoCivil.SelectedIndex == 0 || cmbEstadoCivil.SelectedIndex == 4 || cmbEstadoCivil.SelectedIndex == 7)
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

            gbEstadoCivil.Foreground = Brushes.Black;
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
                    lblCpfProcurador.Foreground = Brushes.Black;
                }
            }


        }

        private void btnSalvarParte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> listaPreencher = ConferirPreenchimentoDosCampos();

                if (listaPreencher.Count > 0)
                {
                    string msgReservado = "Campo(s) de Preenchimento obrigatório encontrado(s): \n \n";

                    foreach (var item in listaPreencher)
                    {
                        msgReservado += string.Format("{0}\n", item);

                    }

                    var pergunta = "\nÉ possível que tenha problemas mais tarde ao enviar os dados para o Censec ou Doi.\n\nDeseja salvar mesmo assim?";
                    if (MessageBox.Show(msgReservado + pergunta, "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }

                SalvarPessoaNaLista();
                SalvarNomeNaLista();
                SalvarParticipanteNaLista();
                SalvarParteConjuntosNaLista();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o participante. Favor entrar em contato com o Desenvolvedor do sistema." + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

            if (rbFisica.IsChecked == false && rbJuridica.IsChecked == false)
            {
                gbTipoPessoa.Foreground = Brushes.Red;
                naoPreenchido.Add("Tipo Pessoa não informado;");
            }

            if (rbFisica.IsChecked == true)
            if (rbMasculino.IsChecked == false && rbFeminino.IsChecked == false)
            {
                gbSexo.Foreground = Brushes.Red;
                naoPreenchido.Add("Sexo não informado;");
            }

            if (cmbQualificacao.Text == "")
            {
                gbQualificacao.Foreground = Brushes.Red;
                naoPreenchido.Add("Qualificação não informado;");
            }

            if (rbFisica.IsChecked == true)
            if (txtIdentidade.Text == "")
            {
                gbIdentidade.Foreground = Brushes.Red;
                naoPreenchido.Add("Identidade não informado;");
            }

            if (rbFisica.IsChecked == true)
            if (cmbOrgaoEmissor.Text == "")
            {
                gbOrgaoEmissor.Foreground = Brushes.Red;
                naoPreenchido.Add("Orgão Emissor não informado;");
            }

            if (rbFisica.IsChecked == true)
            if (dpDataEmissaoIdentidade.Text == "")
            {
                gbDtOrgaoEmissor.Foreground = Brushes.Red;
                naoPreenchido.Add("Data Emissão não informado;");
            }

            if (rbFisica.IsChecked == true)
            if (cmbEstadoCivil.Text == "")
            {
                gbEstadoCivil.Foreground = Brushes.Red;
                naoPreenchido.Add("Estado Civil não informado;");
            }

            if (rbFisica.IsChecked == true)
                if (cmbEstadoCivil.SelectedIndex != -1 && cmbEstadoCivil.SelectedIndex != 0 && cmbEstadoCivil.SelectedIndex != 4 && cmbEstadoCivil.SelectedIndex != 7)
            {
                if (cmbRegime.Text == "")
                {
                    gbRegime.Foreground = Brushes.Red;
                    naoPreenchido.Add("Regime Casamento não informado;");
                }

                if (txtNomeConjuge.Text == "")
                {
                    gbNomeConjuge.Foreground = Brushes.Red;
                    naoPreenchido.Add("Nome Cônjuge não informado;");
                }

                if (dpDataCasamento.Text == "")
                {
                    gbDtCasamento.Foreground = Brushes.Red;
                    naoPreenchido.Add("Data Casamento não informado;");
                }
            }



            if (_natureza.Doi == "S")
            {
                if (cmbTipoDoi.Text == "")
                {
                    lblTipoDoi.Foreground = Brushes.Red;
                    naoPreenchido.Add("Tipo DOI não informado;");
                }

                if (cmbSituacaoCadastro.Text == "")
                {
                    lblSituacaoCpfCnpj.Foreground = Brushes.Red;
                    naoPreenchido.Add("Situação não informado;");
                }

                if (txtParticipacao.Text == "")
                {
                    lblParticipacao.Foreground = Brushes.Red;
                    naoPreenchido.Add("Participação não informado;");
                }

                if (cmbRepresentado.SelectedIndex == 0)
                {
                    if (txtCpfProcurador.Text == "")
                    {
                        lblCpfProcurador.Foreground = Brushes.Red;
                        naoPreenchido.Add("CPF Procurador não informado;");
                    }
                }

            }


            if (_natureza.Tipo == "D")
            {
                if (rbFisica.IsChecked == true)
                if (dpDataNascimento.Text == "")
                {
                    gbDtNascimento.Foreground = Brushes.Red;
                    naoPreenchido.Add("Data Nascimento não informado;");
                }

                if (cmbQualidadeCensec.Text == "")
                {
                    lblQualidade.Foreground = Brushes.Red;
                    naoPreenchido.Add("Qualidade não informado;");
                }

                if (txtQtdFilhosMaiores.Text == "")
                {
                    lblQtdFilhosMaiores.Foreground = Brushes.Red;
                    naoPreenchido.Add("Quantidade de filhos maiores não informado;");
                }

                if (cmbUfOAB.Text == "")
                {
                    lblUfOab.Foreground = Brushes.Red;
                    naoPreenchido.Add("UF OAB não informado;");
                }

                if (cmbConjuge.Text == "")
                {
                    lblConjuge.Foreground = Brushes.Red;
                    naoPreenchido.Add("Numero de Ordem de Lançamento do Cônjuge não informado;");
                }

                if (cmbMunicipioResidencia.Text == "")
                {
                    lblMunicipioResidencia.Foreground = Brushes.Red;
                    naoPreenchido.Add("Município Residência não informado;");
                }

                if (cmbUfNascimento.Text == "")
                {
                    lblUfNascimento.Foreground = Brushes.Red;
                    naoPreenchido.Add("UF Nascimento não informado;");
                }

                if (cmbPaisResidencia.Text == "")
                {
                    lblPaisResidencia.Foreground = Brushes.Red;
                    naoPreenchido.Add("País Nascimento não informado;");
                }
            }

            return naoPreenchido;
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

        private void txtNomeParte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

        }

        private void rbFisica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbJuridica_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbMasculino_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void rbFeminino_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtEndereco_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtBairro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbUfParte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbMunicipio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbQualificacao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtIdentidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbOrgaoEmissor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            if (e.Key != Key.Enter)
            {
                gbOrgaoEmissor.Foreground = Brushes.Black;
            }
        }

        private void dpDataEmissaoIdentidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbProfissao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbEstadoCivil_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbRegime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNomeConjuge_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dpDataCasamento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void dpDataNascimento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbNacionalidade_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbNacionalidadeOnu_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNomePai_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNomeMae_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNumeroHash_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNumeroBib_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void txtNumeroCre_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void cmbTipoDoi_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbSituacaoCadastro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtParticipacao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);


            if (!txtParticipacao.Text.Contains(","))
                DigitarSomenteNumerosVirgulas(sender, e);
            else
            {
                int indexVirgula = txtParticipacao.Text.IndexOf(",");

                if (indexVirgula + 3 == txtParticipacao.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }


        private void DigitarSemNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void cmbRepresentado_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCpfProcurador_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbQualidadeCensec_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtQtdFilhosMaiores_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void cmbUfOAB_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbConjuge_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbMunicipioResidencia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbUfNascimento_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbPaisResidencia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbOcultarXml_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbOcultarEscritura_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbOcultarDistribuicao_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void ckbARogo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtNomeParte_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNomeParte.Text.Length > 0)
                gbNomeParte.Foreground = Brushes.Black;
        }

        private void rbFisica_Checked(object sender, RoutedEventArgs e)
        {
            gbTipoPessoa.Foreground = Brushes.Black;
        }

        private void rbJuridica_Checked(object sender, RoutedEventArgs e)
        {
            gbTipoPessoa.Foreground = Brushes.Black;
        }

        private void cmbQualificacao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gbQualificacao.Foreground = Brushes.Black;
        }

        private void txtIdentidade_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtIdentidade.Text.Length > 0)
                gbIdentidade.Foreground = Brushes.Black;
        }

        private void cmbOrgaoEmissor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gbOrgaoEmissor.Foreground = Brushes.Black;
        }

        private void dpDataEmissaoIdentidade_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            gbDtOrgaoEmissor.Foreground = Brushes.Black;
        }

        private void cmbRegime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gbRegime.Foreground = Brushes.Black;
        }

        private void txtNomeConjuge_TextChanged(object sender, TextChangedEventArgs e)
        {
            gbNomeConjuge.Foreground = Brushes.Black;
        }

        private void dpDataNascimento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            gbDtCasamento.Foreground = Brushes.Black;
        }

        private void cmbTipoDoi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblTipoDoi.Foreground = Brushes.Black;
        }

        private void cmbSituacaoCadastro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblSituacaoCpfCnpj.Foreground = Brushes.Black;
        }

        private void txtParticipacao_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblParticipacao.Foreground = Brushes.Black;
        }

        private void cmbQualidadeCensec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblQualidade.Foreground = Brushes.Black;
        }

        private void txtQtdFilhosMaiores_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblQtdFilhosMaiores.Foreground = Brushes.Black;
        }

        private void cmbUfOAB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblUfOab.Foreground = Brushes.Black;
        }

        private void cmbConjuge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblConjuge.Foreground = Brushes.Black;
        }

        private void cmbMunicipioResidencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblMunicipioResidencia.Foreground = Brushes.Black;
        }

        private void cmbUfNascimento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblUfNascimento.Foreground = Brushes.Black;
        }

        private void cmbPaisResidencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPaisResidencia.Foreground = Brushes.Black;
        }

        private void txtParticipacao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtParticipacao.Text != "" && txtParticipacao.Text != null)
                txtParticipacao.Text = string.Format("{0:n2}", Convert.ToDecimal(txtParticipacao.Text));
        }

        private void cmbOrgaoEmissor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbOrgaoEmissor.Text != "" && cmbOrgaoEmissor.Text != null)
                cmbOrgaoEmissor.Text = cmbOrgaoEmissor.Text.ToUpper();
        }

        private void cmbProfissao_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbProfissao.Text != "" && cmbProfissao.Text != null)
                cmbProfissao.Text = cmbProfissao.Text.ToUpper();
        }


        private void DesmarcarTodosCheckes()
        {
            try
            {

                foreach (var item in _digitarEscritura.listaAtos)
                {
                    item.IsChecked = false;

                }

                _digitarEscritura.listaAtos[0].IsChecked = true;
                dataGridAtoConjunto.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MarcarTodosCheckes()
        {
            try
            {
                foreach (var item in _digitarEscritura.listaAtos)
                {
                    item.IsChecked = true;
                    dataGridAtoConjunto.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridAtoConjunto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var quant = 0;
            foreach (var item in _digitarEscritura.listaAtos)
            {
                if (item.IsChecked == true)
                {
                    quant++;
                }
            }

            if (((AtoConjuntos)dataGridAtoConjunto.SelectedItem).IsChecked == true && quant > 1)
            {
                _digitarEscritura.listaAtos[dataGridAtoConjunto.SelectedIndex].IsChecked = false;
            }
            else
            {
                _digitarEscritura.listaAtos[dataGridAtoConjunto.SelectedIndex].IsChecked = true;
            }

            dataGridAtoConjunto.Items.Refresh();
        }

        private void MenuItemMarcarTodos_Click(object sender, RoutedEventArgs e)
        {
            MarcarTodosCheckes();
        }

        private void MenuItemDesmarcarTodos_Click(object sender, RoutedEventArgs e)
        {
            DesmarcarTodosCheckes();
        }

    }
}
