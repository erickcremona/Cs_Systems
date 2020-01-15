using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class AtoConjuntos
    {
        public int ConjuntoId { get; set; }

        public int IdEscritura { get; set; }

        public int IdProcuracao { get; set; }

        public int Ordem { get; set; }

        public string TabelaCustas { get; set; }

        public int Natureza { get; set; }

        public string TipoAto { get; set; }

        public string LavradoRj { get; set; }

        public string UfOrigem { get; set; }

        public int CodigoServentia { get; set; }

        public string Serventia { get; set; }

        public string Selo { get; set; }

        public string Aleatorio { get; set; }

        public string IndSelo { get; set; }

        public DateTime Data { get; set; }

        public string TipoLivro { get; set; }

        public string Livro { get; set; }

        public string Folhas { get; set; }

        public string Ato { get; set; }

        public decimal Valor { get; set; }

        public string Participantes { get; set; }

        public string Procuracao { get; set; }

        public DateTime OrigemDataAto { get; set; }

        public string OrigemLivro { get; set; }

        public string OrigemFolhaInicio { get; set; }

        public string OrigemFolhaFim { get; set; }

        public string OrigemNumeroAto { get; set; }

        public string OrigemLavrado { get; set; }

        public string OrigemTipoLivro { get; set; }

        public string OrigemOutorgado { get; set; }

        public string OrigemServentia { get; set; }

        public string OrigemUf { get; set; }

        public string OrigemNotificacao { get; set; }

        public bool IsChecked { get; set; }
    }
}
