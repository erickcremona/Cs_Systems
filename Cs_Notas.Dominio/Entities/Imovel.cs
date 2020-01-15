using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Imovel
    {
        public int ImovelId { get; set; }

        public int IdEscritura { get; set; }

        public int Ordem { get; set; }

        public string TipoRecolhimento { get; set; }

        public string TipoImovel { get; set; }

        public string InscricaoImobiliaria { get; set; }

        public string Local { get; set; }

        public string Incra { get; set; }

        public string Area { get; set; }

        public string Denominacao { get; set; }

        public string SRF { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Municipio { get; set; }

        public string Uf { get; set; }

        public string Guia { get; set; }

        public string Adquirente { get; set; }

        public string Cedente { get; set; }

        public string MaiorPorcao { get; set; }

        public decimal Valor { get; set; }

        public string ParteTranferida { get; set; }

        public string TipoTransacao { get; set; }

        public string DescricaoTransacao { get; set; }

        public string Retificacao { get; set; }

        public DateTime DataAlienacao { get; set; }

        public string FormaAlienacao { get; set; }

        public string ValorNaoConsta { get; set; }

        public decimal ValorAlienacao { get; set; }

        public decimal BaseItbiItcd { get; set; }

        public string TipoImovelDoi { get; set; }

        public string DescricaoTipoImovel { get; set; }

        public string Construcao { get; set; }

        public string AreaNaoConsta { get; set; }

        public int Numero { get; set; }

        public string Cep { get; set; }

        public string ValorItbi { get; set; }

        public string Matricula { get; set; }

        public string Complemento { get; set; }

        public string Rgi { get; set; }

        public string SubTipo { get; set; }

        public string LocalTerreno { get; set; }

        public decimal ValorGuia { get; set; }

        public string Temp { get; set; }

        public string Detalhes { get; set; }

        public string Situacao { get; set; }

        public int CodigoMunicipio { get; set; }

        public int Unidade { get; set; }

        public int Serventia { get; set; }

        public string TipoImposto { get; set; }

        public string Principal { get; set; }

        public string TipoBem { get; set; }

        public string Objeto { get; set; }
    }
}
