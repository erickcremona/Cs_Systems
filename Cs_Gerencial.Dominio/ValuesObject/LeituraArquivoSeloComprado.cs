using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities_Fracas
{
    public class LeituraArquivoSeloComprado
    {
        public int Id { get; set; }

        public DateTime DataGeracao { get; set; }

        public string SolicitanteNome { get; set; }

        public string SolicitanteCpf { get; set; }

        public int Quantidade { get; set; }

        public DateTime DataPedido { get; set; }

        public int SequenciaFim { get; set; }

        public int SequenciaInicio { get; set; }

        public string Serie { get; set; }

        public string CodigoServico { get; set; }

        public string Grerj { get; set; }

        public string Arquivo { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
