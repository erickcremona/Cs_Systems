using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Contas
    {
        
        public int ContaId { get; set; }

        public int IdFornecedor { get; set; }

        public int IdBanco { get; set; }

        public int IdPlano { get; set; }

        public int IdAto { get; set; }

        public int Atribuicao { get; set; }

        public string Livro { get; set; }

        public int FolhaInicial { get; set; }

        public int FolhaFinal { get; set; }

        public int Protocolo { get; set; }

        public string Matricula { get; set; }

        public int Recibo { get; set; }

        public string Letra { get; set; }

        public int Numero { get; set; }

        public string Aleatorio { get; set; }

        public int Codigo { get; set; }

        public string Fornecedor { get; set; }

        public string Banco { get; set; }

        public string Plano { get; set; }

        public string Documento { get; set; }

        public string Tipo { get; set; }

        public DateTime DataMovimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public string Descricao { get; set; }

        public decimal Total { get; set; }

        public string FormaPagamento { get; set; }

        public string NumeroCheque { get; set; }

        public string Deposito { get; set; }


    }
}
