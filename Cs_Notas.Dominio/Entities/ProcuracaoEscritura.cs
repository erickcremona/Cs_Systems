using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class ProcuracaoEscritura
    {
        public int ProcuracaoEscrituraId { get; set; }

        public int IdEscritura { get; set; }

        public DateTime Data { get; set; }

        public string Livro { get; set; }

        public string Folhas { get; set; }

        public string Ato { get; set; }

        public string Selo { get; set; }

        public string Aleatorio { get; set; }

        public string Outorgantes { get; set; }

        public string Outorgados { get; set; }

        public string Lavrado { get; set; }

        public int CodigoServentia { get; set; }

        public string Serventia { get; set; }

        public string UfOrigem { get; set; }
    }
}
