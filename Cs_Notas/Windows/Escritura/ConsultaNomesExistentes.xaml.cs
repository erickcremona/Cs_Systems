using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Dominio.ValuesObject;
using Cs_Notas.Windows.Procuracao;
using Cs_Notas.Windows.Testamento;
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
    /// Interaction logic for ConsultaNomesExistentes.xaml
    /// </summary>
    public partial class ConsultaNomesExistentes : Window
    {
        List<Pessoas> _pessoas;
        DigitarDadosParticipante _digitarParticipante;
        string formEntrada = string.Empty;
        ParticipantesProcuracao _digitarPartProcuracao;
        Pessoas pessoa;
        Testemunhas _testemunhas;

        DigitarTestamento _digitarTestamento;
         
        private readonly IAppServicoNacionalidadesOnu _AppServicoNacionalidadesOnu = BootStrap.Container.GetInstance<IAppServicoNacionalidadesOnu>();


        public ConsultaNomesExistentes(List<Pessoas> pessoas, DigitarTestamento digitarTestamento)
        {
            _pessoas = pessoas;
            _digitarTestamento = digitarTestamento;
            formEntrada = "testamento";
            InitializeComponent();
        }

        public ConsultaNomesExistentes(List<Pessoas> pessoas, ParticipantesProcuracao digitarParticipante)
        {
            _pessoas = pessoas;
            _digitarPartProcuracao = digitarParticipante;
            formEntrada = "procuracao";
            InitializeComponent();
        }

        public ConsultaNomesExistentes(List<Pessoas> pessoas, DigitarDadosParticipante digitarParticipante)
        {
            _pessoas = pessoas;
            _digitarParticipante = digitarParticipante;
            formEntrada = "escritura";
            InitializeComponent();
        }

        public ConsultaNomesExistentes(List<Pessoas> pessoas, Testemunhas testemunhas)
        {
            _pessoas = pessoas;
            _testemunhas = testemunhas;
            formEntrada = "testemunhas";
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_digitarParticipante.pessoa = new Pessoas();

            dataGridPessoas.ItemsSource = _pessoas.OrderByDescending(p => p.PessoasId);

            lblQtdRegistros.Content = string.Format("OCORRÊNCIAS ENCONTRADAS:  {0}", _pessoas.Count);

            if (dataGridPessoas.Items.Count > 0)
            {
                dataGridPessoas.SelectedIndex = 0;
            }
        }

        private void dataGridSeriesDisponiveis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarComponentes();
        }

        private void dataGridPessoas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var pessoaSelecionada = (Pessoas)dataGridPessoas.SelectedItem;

            if (formEntrada == "procuracao")
            {
                _digitarPartProcuracao.pessoa.Nome = pessoaSelecionada.Nome;


                _digitarPartProcuracao.pessoa.TipoPessoa = pessoaSelecionada.TipoPessoa;


                _digitarPartProcuracao.pessoa.CpfCgc = pessoaSelecionada.CpfCgc;

                _digitarPartProcuracao.pessoa.Rg = pessoaSelecionada.Rg;

                _digitarPartProcuracao.pessoa.OrgaoRG = pessoaSelecionada.OrgaoRG;

                _digitarPartProcuracao.pessoa.DataEmissaoRG = pessoaSelecionada.DataEmissaoRG;

                _digitarPartProcuracao.pessoa.Nacionalidade = pessoaSelecionada.Nacionalidade;

                _digitarPartProcuracao.pessoa.Endereco = pessoaSelecionada.Endereco;

                _digitarPartProcuracao.pessoa.Bairro = pessoaSelecionada.Bairro;

                _digitarPartProcuracao.pessoa.Cidade = pessoaSelecionada.Cidade;

                _digitarPartProcuracao.pessoa.Uf = pessoaSelecionada.Uf;

                _digitarPartProcuracao.pessoa.EsctadoCivil = pessoaSelecionada.EsctadoCivil;

                _digitarPartProcuracao.pessoa.Conjuge = pessoaSelecionada.Conjuge;

                _digitarPartProcuracao.pessoa.RegimeBens = pessoaSelecionada.RegimeBens;


                _digitarPartProcuracao.pessoa.DataCasamento = pessoaSelecionada.DataCasamento;


                _digitarPartProcuracao.pessoa.DataNascimento = pessoaSelecionada.DataNascimento;

                _digitarPartProcuracao.pessoa.NomePai = pessoaSelecionada.NomePai;

                _digitarPartProcuracao.pessoa.NomeMae = pessoaSelecionada.NomeMae;


                _digitarPartProcuracao.pessoa.Profissao = pessoaSelecionada.Profissao;



                _digitarPartProcuracao.pessoa.Sexo = pessoaSelecionada.Sexo;

                _digitarPartProcuracao.pessoa.Naturalidade = pessoaSelecionada.Naturalidade;


                _digitarPartProcuracao.pessoa.QtdFilhosMaiores = pessoaSelecionada.QtdFilhosMaiores;

                _digitarPartProcuracao.pessoa.UfNascimento = pessoaSelecionada.UfNascimento;

                _digitarPartProcuracao.pessoa.PaisReside = pessoaSelecionada.PaisReside;

                _digitarPartProcuracao.pessoa.UfPaisReside = pessoaSelecionada.UfPaisReside;

                _digitarPartProcuracao.pessoa.CodigoMunicipioReside = pessoaSelecionada.CodigoMunicipioReside;



                _digitarPartProcuracao.pessoa.CodigoPais = pessoaSelecionada.CodigoPais;


                _digitarPartProcuracao.pessoa.CodigoPaisOnu = pessoaSelecionada.CodigoPaisOnu;
            }
            if (formEntrada == "escritura")
            {
                _digitarParticipante.pessoa.Nome = pessoaSelecionada.Nome;


                _digitarParticipante.pessoa.TipoPessoa = pessoaSelecionada.TipoPessoa;


                _digitarParticipante.pessoa.CpfCgc = pessoaSelecionada.CpfCgc;

                _digitarParticipante.pessoa.Rg = pessoaSelecionada.Rg;

                _digitarParticipante.pessoa.OrgaoRG = pessoaSelecionada.OrgaoRG;

                _digitarParticipante.pessoa.DataEmissaoRG = pessoaSelecionada.DataEmissaoRG;

                _digitarParticipante.pessoa.Nacionalidade = pessoaSelecionada.Nacionalidade;

                _digitarParticipante.pessoa.Endereco = pessoaSelecionada.Endereco;

                _digitarParticipante.pessoa.Bairro = pessoaSelecionada.Bairro;

                _digitarParticipante.pessoa.Cidade = pessoaSelecionada.Cidade;

                _digitarParticipante.pessoa.Uf = pessoaSelecionada.Uf;

                _digitarParticipante.pessoa.EsctadoCivil = pessoaSelecionada.EsctadoCivil;

                _digitarParticipante.pessoa.Conjuge = pessoaSelecionada.Conjuge;

                _digitarParticipante.pessoa.RegimeBens = pessoaSelecionada.RegimeBens;


                _digitarParticipante.pessoa.DataCasamento = pessoaSelecionada.DataCasamento;


                _digitarParticipante.pessoa.DataNascimento = pessoaSelecionada.DataNascimento;

                _digitarParticipante.pessoa.NomePai = pessoaSelecionada.NomePai;

                _digitarParticipante.pessoa.NomeMae = pessoaSelecionada.NomeMae;


                _digitarParticipante.pessoa.Profissao = pessoaSelecionada.Profissao;



                _digitarParticipante.pessoa.Sexo = pessoaSelecionada.Sexo;

                _digitarParticipante.pessoa.Naturalidade = pessoaSelecionada.Naturalidade;


                _digitarParticipante.pessoa.QtdFilhosMaiores = pessoaSelecionada.QtdFilhosMaiores;

                _digitarParticipante.pessoa.UfNascimento = pessoaSelecionada.UfNascimento;

                _digitarParticipante.pessoa.PaisReside = pessoaSelecionada.PaisReside;

                _digitarParticipante.pessoa.UfPaisReside = pessoaSelecionada.UfPaisReside;

                _digitarParticipante.pessoa.CodigoMunicipioReside = pessoaSelecionada.CodigoMunicipioReside;



                _digitarParticipante.pessoa.CodigoPais = pessoaSelecionada.CodigoPais;


                _digitarParticipante.pessoa.CodigoPaisOnu = pessoaSelecionada.CodigoPaisOnu;
            }
            if (formEntrada == "testamento")
            {
                _digitarTestamento.txtNomeParte.Text = pessoaSelecionada.Nome;

                if (pessoaSelecionada.Sexo == "M")
                    _digitarTestamento.rbMasculino.IsChecked = true;
                else
                    _digitarTestamento.rbFeminino.IsChecked = true;

                _digitarTestamento.dpDataNascimento.SelectedDate = pessoaSelecionada.DataNascimento;

                _digitarTestamento.cmbEstadoCivil.SelectedValue = pessoaSelecionada.EsctadoCivil;

                _digitarTestamento.cmbRegime.Text = pessoaSelecionada.RegimeBens;

                _digitarTestamento.txtNaturalidade.Text = pessoaSelecionada.Naturalidade;

                _digitarTestamento.cmbNacionalidade.Text = pessoaSelecionada.Nacionalidade;

                _digitarTestamento.cmbNacionalidadeOnu.SelectedValue = pessoaSelecionada.CodigoPaisOnu;

                _digitarTestamento.txtIdentidade.Text = pessoaSelecionada.Rg;

                if (pessoaSelecionada.OrgaoRG == "DETRAN" || pessoaSelecionada.OrgaoRG == "IFP")
                _digitarTestamento.cmbOrgaoEmissor.Text = pessoaSelecionada.OrgaoRG;
                else{
                    _digitarTestamento.cmbOrgaoEmissor.Text = "OUTRO";
                    _digitarTestamento.txtOutroOrgao.Text = pessoaSelecionada.OrgaoRG;
                }

                _digitarTestamento.dpDataEmissaoIdentidade.SelectedDate = pessoaSelecionada.DataEmissaoRG;

                _digitarTestamento.txtNomePai.Text = pessoaSelecionada.NomePai;

                _digitarTestamento.txtNomeMae.Text = pessoaSelecionada.NomeMae;
            }

            if (formEntrada == "testemunhas")
            {
                _testemunhas.txtNomeParte.Text = pessoaSelecionada.Nome;

                _testemunhas.txtEndereco.Text = pessoaSelecionada.Endereco;
                
                _testemunhas.cmbEstadoCivil.SelectedValue = pessoaSelecionada.EsctadoCivil;


                _testemunhas.cmbNacionalidade.Text = pessoaSelecionada.Nacionalidade;

                _testemunhas.cmbProfissao.Text = pessoaSelecionada.Profissao;

                _testemunhas.txtIdentidade.Text = pessoaSelecionada.Rg;

                if (pessoaSelecionada.OrgaoRG == "DETRAN" || pessoaSelecionada.OrgaoRG == "IFP")
                    _testemunhas.cmbOrgaoEmissor.Text = pessoaSelecionada.OrgaoRG;
                else
                {
                    _testemunhas.cmbOrgaoEmissor.Text = "OUTRO";
                    _testemunhas.txtOutroOrgao.Text = pessoaSelecionada.OrgaoRG;
                }

                _testemunhas.dpDataEmissaoIdentidade.SelectedDate = pessoaSelecionada.DataEmissaoRG;

            }

            this.Close();
        }

        private void CarregarComponentes()
        {
            if (dataGridPessoas.Items.Count > 0)
            {
                pessoa = (Pessoas)dataGridPessoas.SelectedItem;
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
                txtUf.Text = pessoa.Uf;
                txtMunicipio.Text = pessoa.Cidade;
                txtIdentidade.Text = pessoa.Rg;
                txtOrgaoEmissor.Text = pessoa.OrgaoRG;

                if (pessoa.DataEmissaoRG.ToShortDateString() != "01/01/0001")
                    txtDataEmissao.Text = pessoa.DataEmissaoRG.ToShortDateString();

                txtProfissao.Text = pessoa.Profissao;
                if(pessoa.EsctadoCivil > 0 && pessoa.Sexo != null)
                txtEstadoCivil.Text = EstadoCivil(pessoa.EsctadoCivil, pessoa.Sexo);
                txtRegime.Text = pessoa.RegimeBens;
                txtNomeConjuge.Text = pessoa.Conjuge;

                if (pessoa.DataNascimento.ToShortDateString() != "01/01/0001")
                    txtDataNascimento.Text = pessoa.DataNascimento.ToShortDateString();

                if (pessoa.DataCasamento.ToShortDateString() != "01/01/0001")
                    txtDataCasamento.Text = pessoa.DataCasamento.ToShortDateString();

                txtNacionalidade.Text = pessoa.Nacionalidade;
                


                if (pessoa.CodigoPaisOnu > 0)
                    txtNacionalidadeOnu.Text = _AppServicoNacionalidadesOnu.ObterNacionalidadeOnuPorCodigoPais(pessoa.CodigoPaisOnu).Pais;

                txtNomePai.Text = pessoa.NomePai;
                txtNomeMae.Text = pessoa.NomeMae;
            }
        }

        

        private string EstadoCivil(int codEstadoCivil, string sexo)
        {
            EstadoCivil ec = new EstadoCivil();
            var estadoCivil = new List<EstadoCivil>();

            bool sex;
            if(sexo == "M")
                sex = true;
            else
                sex = false;

            estadoCivil = ec.ObterListaEstadoCivil(sex);

            return estadoCivil.Where(p => p.Codigo == codEstadoCivil).FirstOrDefault().Descricao;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
           
            if(formEntrada == "escritura")
            pessoa.CpfCgc = _digitarParticipante.txtCpfCnpj.Text;
            if (formEntrada == "procuracao")
                pessoa.CpfCgc = _digitarPartProcuracao.txtCpfCnpj.Text;
            if (formEntrada == "testamento")
                pessoa.CpfCgc = _digitarTestamento.txtCpfCnpjTestador.Text;

            if (formEntrada == "testemunhas")
                pessoa.CpfCgc = _testemunhas.txtCpf.Text;
        }

    }
}
