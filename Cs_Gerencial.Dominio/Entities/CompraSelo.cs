using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class CompraSelo
    {
        public int CompraSeloId { get; set; }
        public int PedidoId { get; set; }
        public DateTime DataPedido { get; set; }
        public string HoraPedido { get; set; }
        public int Quantidade { get; set; }
        public string Grerj { get; set; }
        public DateTime DataPagamento { get; set; }
        public string HoraPagamento { get; set; }
        public string CpfSolicitante { get; set; }
        public string NomeSolicitante { get; set; }
        public DateTime DataGeracao { get; set; }
        public string HoraGeracao { get; set; }
        public string Arquivo { get; set; }
    }
}
