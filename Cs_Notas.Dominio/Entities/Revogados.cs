using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Revogados
    {
        public int RevogadosId { get; set; }

        public int IdTestamento { get; set; }

        public string LavradoRio { get; set; }

        public string Selo { get; set; }

        public string Serventia { get; set; }

        public DateTime Data { get; set; }

        public string Livro { get; set; }

        public int Ato { get; set; }

        public string Uf { get; set; }

        public int CodigoServentia { get; set; }

        public string Aleatorio { get; set; }

        public string Eletronico { get; set; }
    }
}
