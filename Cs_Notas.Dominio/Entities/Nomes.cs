using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Nomes
    {
        public int NomeId { get; set; }

        public int IdPessoa { get; set; }

        public int IdEscritura { get; set; }

        public int IdProcuracao { get; set; }

        public int IdTestamento { get; set; }

        public int Ordem { get; set; }

        public string Principal { get; set; }

        public string Nomenclatura { get; set; }

        public string Descricao { get; set; }

        public string Nome { get; set; }

        public string TipoPessoa { get; set; }

        public string Documento { get; set; }

        public string Rg { get; set; }

        public DateTime DataEmissao { get; set; }

        public string Orgao { get; set; }

        public string Nacionalidade { get; set; }

        public string EstadoCivil { get; set; }

        public string RegimeCasamento { get; set; }

        public string Justificativa { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NomePai { get; set; }

        public string NomeMae { get; set; }

        public string Profissao { get; set; }

        public string Endereco { get; set; }

        public string Municipio { get; set; }

        public string Uf { get; set; }

        public DateTime DataCasamento { get; set; }

        public string Conjuge { get; set; }

        public DateTime DataObito { get; set; }

        public string LivroObito { get; set; }

        public string FolhasObito { get; set; }

        public string SeloObito { get; set; }

        public string Representa { get; set; }

        public string Bairro { get; set; }

        public decimal Participacao { get; set; }

        public string Tipo { get; set; }

        public string Procurador { get; set; }

        public string CpfProcurador { get; set; }

        public string CnpjRepresenta { get; set; }

        public string TipoRepresenta { get; set; }

        public string NomeRepresenta { get; set; }

        public string NumeroBIB { get; set; }

        public string Ocultar { get; set; }

        public string Escritura { get; set; }

        public string OcultarDistribuicao { get; set; }

        public string NumeroCRE { get; set; }

        public string Qualidade { get; set; }

        public int Tpj { get; set; }

        public int Situacao { get; set; }

        public string OcultarXML { get; set; }

        public string Hash { get; set; }

        public string PreTeste { get; set; }

        public int NumeroConjuge { get; set; }

        
    }
}
