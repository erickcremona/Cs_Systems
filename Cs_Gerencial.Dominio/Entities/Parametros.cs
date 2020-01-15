using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Parametros
    {
        public int ParametrosId { get; set; }

        public string PathSelosNaoImportados { get; set; }

        public string PathSelosImportados { get; set; }

        public string SenhaMaster { get; set; }

        public string PathSelosCenib { get; set; }

        public decimal AlicotaIss { get; set; }
    }
}
