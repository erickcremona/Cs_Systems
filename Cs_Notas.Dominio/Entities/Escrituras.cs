using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Escrituras
    {
        public int EscriturasId { get; set; }

        public int CertidaoId { get; set; }

        public string TipoAto { get; set; }

        public DateTime DataAtoRegistro { get; set; }

        public string CpfEscrevente { get; set; }

        public string EscreventeAtoRegistro { get; set; }

        public DateTime DataAtoCertidao { get; set; }

        public string EscreventeAtoCertidao { get; set; }
               
        public string SeloEscritura { get; set; }

        public string Aleatorio { get; set; }

        public string LivroEscritura { get; set; }
        
        public int FolhasInicio { get; set; }

        public int FolhasFim { get; set; }

        public int NumeroAto { get; set; }

        public string Recibo { get; set; }

        public int CodigoAto { get; set; }

        public string Natureza { get; set; }

        public string Descricao { get; set; }

        public decimal ValorEscritua { get; set; }

        public string TipoCobranca { get; set; }

        public decimal Emolumentos { get; set; }

        public decimal Fetj { get; set; }

        public decimal Fundperj { get; set; }

        public decimal Funprj { get; set; }

        public decimal Funarpen { get; set; }

        public decimal Pmcmv { get; set; }

        public decimal Iss { get; set; }

        public decimal Mutua { get; set; }

        public decimal Acoterj { get; set; }

        public decimal Distribuicao { get; set; }

        public decimal Total { get; set; }

        public int Paginas { get; set; }

        public int Unidades { get; set; }

        public int Diligencias { get; set; }

        public string IndProcuracao { get; set; }

        public string IndAlvara { get; set; }

        public DateTime DataDistribuicao { get; set; }

        public int NumeroDistribuicao { get; set; }

        public string DistribuicaoEnviada { get; set; }

        public int Orcamento { get; set; }

        public string Objeto { get; set; }

        public string Observacao { get; set; }

        public string OficioRecebido { get; set; }

        public string OficioGerado { get; set; }

        public string Censec { get; set; }

        public string TipoCensec { get; set; }

        public int TipoAtoCesdi { get; set; }

        public int NaturezaCensec { get; set; }

        public string Desconhecido { get; set; }

        public string LivroReferencia { get; set; }

        public string FolhaReferencia { get; set; }

        public string UfReferencia { get; set; }

        public int CidadeReferencia { get; set; }

        public string CartorioReferencia { get; set; }

        public int CodigoServentia { get; set; }

        public string Serventia { get; set; }

        public string UfOrigem { get; set; }

        public string Path { get; set; }

        public string Cancelado { get; set; }

        public string Enviado { get; set; }

        public string Login { get; set; }

        public DateTime DataModificacao { get; set; }

        public DateTime HoraModificacao { get; set; }

        public int QtdFilhosMenores { get; set; }

        public int ResponsavelFilhosMenores { get; set; }

        public string Letra { get; set; }

        public int IdCodigoTabelaCustas { get; set; }
    }
}
