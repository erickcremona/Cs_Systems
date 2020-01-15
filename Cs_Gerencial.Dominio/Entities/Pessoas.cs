using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Pessoas
    {
        public int PessoasId { get; set; }

        public string Nome { get; set; }

        public string TipoPessoa { get; set; }

        public DateTime DataCadastro { get; set; }

        public string CpfCgc { get; set; }

        public string Rg { get; set; }

        public string OrgaoRG { get; set; }

        public DateTime DataEmissaoRG { get; set; }

        public string Nacionalidade { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }

        public int EsctadoCivil { get; set; }

        public string Conjuge { get; set; }

        public string RegimeBens { get; set; }

        public DateTime DataCasamento { get; set; }

        public DateTime DataObito { get; set; }

        public string LivroObito { get; set; }

        public string FolhaObito { get; set; }

        public string SeloObito { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NomePai { get; set; }

        public string NomeMae { get; set; }

        public string Profissao { get; set; }

        public string Justificativa { get; set; }

        public string Digital { get; set; }

        public string TipoEndereco { get; set; }

        public string Sexo { get; set; }

        public string Sobrenome { get; set; }

        public string IfpDetran { get; set; }

        public string Observacao { get; set; }

        public string Naturalidade { get; set; }

        public string Atualizado { get; set; }

        public string Digitador { get; set; }

        public int QtdFilhosMaiores { get; set; }

        public string UfNascimento { get; set; }

        public string PaisReside { get; set; }

        public string UfPaisReside { get; set; }

        public int CodigoMunicipioReside { get; set; }

        public string UfOab { get; set; }

        public int CodigoPais { get; set; }

        public int CodigoPaisOnu { get; set; }
    }
}
