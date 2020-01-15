using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class TabelaCustas
    {
        public int TabelaCustasId { get; set; }

        public int Atribuicao { get; set; }

        public int Ordem { get; set; }

        public string Tabela { get; set; }

        public string Item { get; set; }

        public string SubItem { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public int Ano { get; set; }
    }
}
