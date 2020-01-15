using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class CertidaoProcuracao
    {
        public int CertidaoProcuracaoId { get; set; }

        public int IdReferencia { get; set; }

        public DateTime Data { get; set; }

        public string Selo { get; set; }

        public string Cpf1 { get; set; }

        public string Cpf2 { get; set; }

        public string Cpf3 { get; set; }

        public string TipoCobranca { get; set; }

        public decimal Emolumentos { get; set; }

        public decimal Fetj { get; set; }

        public decimal Fundperj { get; set; }

        public decimal Funprj { get; set; }

        public decimal Funarpen { get; set; }

        public decimal Pmcmv { get; set; }

        public decimal Iss { get; set; }
        
        public decimal Total { get; set; }

        public string Login { get; set; }

        public DateTime DataModificado { get; set; }

        public DateTime HoraModificado { get; set; }

        public char Enviado { get; set; }

        public string Aleatorio { get; set; }

        public string Servico { get; set; }

        public string UF_Origem { get; set; }

        public string Recibo { get; set; }

        public char DistribuicaoEnviada { get; set; }
    }
}
