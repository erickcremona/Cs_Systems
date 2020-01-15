using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Municipios
    {
        public int MunicipioId { get; set; }

        public int Codigo { get; set; }

        public string Uf { get; set; }

        public string Nome { get; set; }
    }
}
