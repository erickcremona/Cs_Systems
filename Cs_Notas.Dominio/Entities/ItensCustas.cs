using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class ItensCustas
    {
        public int ItensCustasId { get; set; }

        public int IdEscritura { get; set; }

        public int IdProcuracao { get; set; }

        public int IdTestamento { get; set; }

        public string Tabela { get; set; }

        public string Item { get; set; }

        public string SubItem { get; set; }

        public string Quantidade { get; set; }

        public string Complemento { get; set; }

        public string Excessao { get; set; }

        public decimal Valor { get; set; }

        public decimal Total { get; set; }

        public string Descricao { get; set; }
    }
}
