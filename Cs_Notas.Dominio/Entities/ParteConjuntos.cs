using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class ParteConjuntos
    {
        public int ParteConjuntosId { get; set; }

        public int IdEscritura { get; set; }

        public int IdProcuracao { get; set; }

        public int IdNome { get; set; }

        public int IdConjunto { get; set; }
    }
}
