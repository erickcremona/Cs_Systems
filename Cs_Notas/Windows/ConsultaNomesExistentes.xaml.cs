using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
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
    /// Interaction logic for ConsultaNomesExistentes.xaml
    /// </summary>
    public partial class ConsultaNomesExistentes : Window
    {
        List<Pessoas> _pessoas;
        DigitarDadosParticipante _digitarParticipante;
        Pessoas pessoa;

        private readonly IAppServicoNacionalidadesOnu _AppServicoNacionalidadesOnu = BootStrap.Container.GetInstance<IAppServicoNacionalidadesOnu>();

        public ConsultaNomesExistentes(List<Pessoas> pessoas, DigitarDadosParticipante digitarParticipante)
        {
            _pessoas = pessoas;
            _digitarParticipante = digitarParticipante;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridPessoas.ItemsSource = _pessoas;

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
            _digitarParticipante.pessoa = (Pessoas)dataGridPessoas.SelectedItem;
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


            if (sexo == "M")
            {
                ec.Codigo = 1;
                ec.Descricao = "SOLTEIRO";
                estadoCivil.Add(ec);


                ec = new EstadoCivil();
                ec.Codigo = 2;
                ec.Descricao = "CASADO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 3;
                ec.Descricao = "VIÚVO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 4;
                ec.Descricao = "SEPARADO JUDICIALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 5;
                ec.Descricao = "DIVORCIADO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 6;
                ec.Descricao = "SEPARADO CONSENSUALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 7;
                ec.Descricao = "DESQUITADO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 8;
                ec.Descricao = "IGNORADO";
                estadoCivil.Add(ec);
            }
            if (sexo == "F")
            {

                ec.Codigo = 1;
                ec.Descricao = "SOLTEIRA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 2;
                ec.Descricao = "CASADA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 3;
                ec.Descricao = "VIÚVA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 4;
                ec.Descricao = "SEPARADA JUDICIALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 5;
                ec.Descricao = "DIVORCIADA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 6;
                ec.Descricao = "SEPARADA CONSENSUALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 7;
                ec.Descricao = "DESQUITADA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 8;
                ec.Descricao = "IGNORADO";
                estadoCivil.Add(ec);
            }

            if (sexo == null)
                return null;

            return estadoCivil.Where(p => p.Codigo == codEstadoCivil).FirstOrDefault().Descricao;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _digitarParticipante.pessoa = new Pessoas();

            pessoa.CpfCgc = _digitarParticipante.txtCpfCnpj.Text;
        }

    }
}
