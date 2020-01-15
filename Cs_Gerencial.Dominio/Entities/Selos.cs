using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Selos
    {



        public int SeloId { get; set; }

        public string Letra { get; set; }

        public int Numero { get; set; }

        public string Aleatorio { get; set; }

        public string Cct { get; set; }

        public int IdCompra { get; set; }

        public int IdSerie { get; set; }

        public string Status { get; set; }

        public string Sistema { get; set; }

        public int IdReservado { get; set; }

        public string Reservado { get; set; }

        public DateTime DataReservado { get; set; }

        public int IdUsuarioReservado { get; set; }

        public string UsuarioReservado { get; set; }

        public string FormReservado { get; set; }

        public string FormUtilizado { get; set; }

        public int IdAto { get; set; }

        public int idReferencia { get; set; }

        public int Atribuicao { get; set; }

        public DateTime DataPratica { get; set; }

        public string Matricula { get; set; }

        public string Livro { get; set; }

        public int FolhaInicial { get; set; }

        public int FolhaFinal { get; set; }

        public int NumeroAto { get; set; }

        public int Protocolo { get; set; }

        public int Recibo { get; set; }

        public int Codigo { get; set; }

        public string Conjunto { get; set; }

        public string Natureza { get; set; }

        public string Escrevente { get; set; }

        public string Convenio { get; set; }

        public string TipoCobranca { get; set; }

        public decimal Emolumentos { get; set; }

        public decimal Fetj { get; set; }

        public decimal Fundperj { get; set; }

        public decimal Funperj { get; set; }

        public decimal Funarpen { get; set; }

        public decimal Pmcmv { get; set; }

        public decimal Iss { get; set; }

        public decimal Mutua { get; set; }

        public decimal Acoterj { get; set; }

        public decimal Distribuicao { get; set; }

        public decimal Indisponibilidade { get; set; }

        public decimal Prenotacao { get; set; }

        public decimal Ar { get; set; }

        public decimal TarifaBancaria { get; set; }

        public decimal Total { get; set; }

        public bool Check { get; set; }

        public virtual CompraSelo CompraSelo { get; set; }

        public virtual Series Series { get; set; }
    }
}
