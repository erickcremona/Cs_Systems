using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Complementos
    {
        public int ComplementoId { get; set; }

        public DateTime Data { get; set; }

        public string Cct { get; set; }

        public string TipoCobranca { get; set; }

        public int IdEscritura { get; set; }

        public int IdProcuracao { get; set; }

        public DateTime DataPratica { get; set; }

        public int Livro { get; set; }

        public int FolhaInicio { get; set; }

        public int FolhaFim { get; set; }

        public int NumeroAto { get; set; }

        public string Selo { get; set; }

        public string Aleatorio { get; set; }

        public decimal Emolumentos { get; set; }

        public decimal Fetj { get; set; }

        public decimal Fundperj { get; set; }

        public decimal Funprj { get; set; }

        public decimal Funarpen { get; set; }

        public decimal Pmcmv { get; set; }

        public decimal Iss { get; set; }
        
        public decimal Total { get; set; }

        public string NomeEscrevente { get; set; }

        public string CpfEscrevente { get; set; }

        public string Enviado { get; set; }
    }
}
