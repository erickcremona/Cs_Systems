using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Naturezas
    {
        public int NaturezasId { get; set; }

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string Doi { get; set; }

        public string Censec { get; set; }

        public int Cep { get; set; }

        public string Tipo { get; set; }
    }
}
