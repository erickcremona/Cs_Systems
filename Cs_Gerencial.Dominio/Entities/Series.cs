using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Series
    {
        public int SerieId { get; set; }

        public int IdCompra { get; set; }

        public string Letra { get; set; }

        public int Inicial { get; set; }

        public int Final { get; set; }

        public int Quantidade { get; set; }


    }
}
