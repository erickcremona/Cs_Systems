using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Adicional
    {
        public int AdicionalId { get; set; }

        public string Ativo { get; set; }

        public int Ordem { get; set; }

        public int Atribuicao { get; set; }

        public int Codigo { get; set; }

        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public decimal Emolumentos { get; set; }

        public decimal Fetj { get; set; }

        public decimal Fundperj { get; set; }

        public decimal Funperj { get; set; }

        public decimal Funarpen { get; set; }

        public decimal Pmcmv { get; set; }
            
        public decimal Mutua { get; set; }

        public decimal Iss { get; set; }
        
        public decimal Acoterj { get; set; }

        public decimal Distribuicao { get; set; }

        public decimal Total { get; set; }

        public decimal Minimo { get; set; }

        public decimal Maximo { get; set; }

        public int Dias { get; set; }

        public string Convenio { get; set; }

       
    }
}
