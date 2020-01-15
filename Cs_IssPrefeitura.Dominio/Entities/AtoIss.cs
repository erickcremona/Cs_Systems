using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Entities
{
    public class AtoIss
    {
        public int AtoIssId { get; set; }
        public DateTime Data { get; set; }
        public string Atribuicao { get; set; }
        public string TipoAto { get; set; }
        public string Selo { get; set; }
        public string Aleatorio { get; set; }
        public string TipoCobranca { get; set; }
        public decimal Emolumentos { get; set; }
        public decimal Fetj { get; set; }
        public decimal Fundperj { get; set; }
        public decimal Funperj { get; set; }
        public decimal Funarpen { get; set; }
        public decimal Ressag { get; set; }
        public decimal Mutua { get; set; }
        public decimal Acoterj { get; set; }
        public decimal Distribuidor { get; set; }
        public decimal Iss { get; set; }
        public decimal Total { get; set; }
        public int IdApuracaoIss { get; set; }
    }
}
