using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Configuracoes
    {
        public int ConfiguracoesId { get; set; }
        public decimal Mutua { get; set; }
        public decimal Acoterj { get; set; }
        public decimal Distribuicao { get; set; }
        public decimal Indisponibilidade { get; set; }
        public string PathXML { get; set; }
        public string PathModelo { get; set; }
        public string PathEscritura { get; set; }
        public string PathProcuracao { get; set; }
        public string PathTestamento { get; set; }
        public string PathDistribuicao { get; set; }
        public string PathImagem { get; set; }
        public string PathLogoTipo { get; set; }
        public string PathCensec { get; set; }
        public string PathRecibo { get; set; }
        public string PathRgi { get; set; }
        public string Recibo { get; set; }
        public string MostrarCustas { get; set; }
        public string Cabecalho { get; set; }
        public string ImagemConfirmacao { get; set; }
        public string CabecalhoConfirmacao { get; set; }
        public string OcultarObjetoConfirmacao { get; set; }
        public string ObjetoRsumo { get; set; }
        public string ControlarDist { get; set; }
        public string PerguntaImpressao { get; set; }
        public int CodigoMovimento { get; set; }
        public int Tabela { get; set; }
        public string Cidades { get; set; }
        public string ExportaRecibo { get; set; }
        public string Impressora { get; set; }
        public string ImprimirRecibo { get; set; }
        public string DistribuicaoPara { get; set; }
        public string ConjugeDist { get; set; }
        public string QualifResumoDist { get; set; }
        public int SerieAtual { get; set; }
        public string SenhaMaster { get; set; }
        public string TabeliaoDistribuicao { get; set; }
        public string DigitarSelo { get; set; }
        public int VersaoMinuta { get; set; }
        public string EtiquetaCabecalho { get; set; }
        public int EtiquetaAntes { get; set; }
        public int EtiquetaApos { get; set; }
        public int EtiquetaEsquerda { get; set; }
        public string EtiquetaAltura { get; set; }
        public string EtiquetaLargura { get; set; }
        public string EtiquetaNegrito { get; set; }
        public string BlkaToDist { get; set; }
        public string TipoDiligencia { get; set; }
        public string Diligencia_Pmcmv { get; set; }
        public int SeloCertLeft { get; set; }
        public int SeloCertTop { get; set; }
        public string Rgi { get; set; }
    }
}
