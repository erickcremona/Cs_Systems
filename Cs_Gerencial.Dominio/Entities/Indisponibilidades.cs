using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Indisponibilidades
    {
        public int IndisponibilidadeId { get; set; }

        public string Protocolo { get; set; }

        public DateTime DataPedido { get; set; }

        public string HoraPedido { get; set; }

        public string NumeroProcesso { get; set; }

        public string Telefone { get; set; }

        public string NomeInstituicao { get; set; }

        public string ForumVara { get; set; }

        public string Usuario { get; set; }

        public string Email { get; set; }

        public string NomeIndividuo { get; set; }

        public string CpfCnpj { get; set; }

        public string Cancelado { get; set; }

        public string Cancelamento { get; set; }

        public int TipoCancelamento { get; set; }

        public string DataCancelamento { get; set; }

        public string HoraCancelamento { get; set; }

        public string Origem { get; set; }

    }
}
