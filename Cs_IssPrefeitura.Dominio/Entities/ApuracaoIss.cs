using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Entities
{
    public class ApuracaoIss
    {
        public int ApuracaoIssId { get; set; }

        public DateTime DataFechamento { get; set; }

        public int Mes { get; set; }

        public string NomeMes { get; set; }

        public int Ano { get; set; }

        public string Periodo { get; set; }

        public int Livro { get; set; }

        public int Folha { get; set; }

        public string Recibo { get; set; }

        public int Serie { get; set; }

        public int Numero { get; set; }

        public string Cancelado { get; set; }

        public decimal Faturamento { get; set; }

        public decimal FundosEspeciais { get; set; }

        public decimal BaseCalculo { get; set; }

        public float Aliquota { get; set; }

        public decimal ValorIssRecolhido { get; set; }

    }
}
