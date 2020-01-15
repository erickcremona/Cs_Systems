using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class CadProcuracao
    {
        public int ProcuracaoId { get; set; }

        public string Tipo { get; set; }

        public string Local { get; set; }

        public string Poderes { get; set; }

        public string Resumo { get; set; }

        public string Selo { get; set; }

        public string Livro { get; set; }

        public int FolhaInicio { get; set; }

        public int FolhaFim { get; set; }

        public int NumeroAto { get; set; }

        public DateTime DataLavratura { get; set; }

        public string Observacao { get; set; }

        public string DescricaoTipo { get; set; }

        public string SeloTipo { get; set; }

        public int NumeroAtoTipo { get; set; }

        public DateTime DataLavraturaTipo { get; set; }

        public string LivroTipo { get; set; }

        public int FolhaInicioTipo { get; set; }

        public int FolhaFimTipo { get; set; }

        public string ServentiaTipo { get; set; }

        public string ConsultaTipo { get; set; }

        public string OutrosLocal { get; set; }

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

        public string CpfEscrevente { get; set; }

        public string TipoAto { get; set; }

        public string TipoLivro { get; set; }

        public string TipoLivroTipo { get; set; }

        public DateTime DataVigencia { get; set; }

        public string SeloEscritura { get; set; }

        public string CodigoLivro { get; set; }

        public string LavradoRj { get; set; }

        public string TipoCobranca { get; set; }

        public string Login { get; set; }

        public DateTime DataModificado { get; set; }

        public string HoraModificado { get; set; }

        public int Codigo { get; set; }

        public string Bens { get; set; }

        public string Cancelado { get; set; }

        public string Natureza { get; set; }

        public string Recibo { get; set; }

        public string Ausente { get; set; }

        public string Notificacao { get; set; }

        public string Enviado { get; set; }

        public string Texto { get; set; }

        public DateTime DataDistribuicao { get; set; }

        public string Path { get; set; }

        public string DescricaoCustas { get; set; }

        public int NumeroDistribuicao { get; set; }

        public string DistribuicaoEnviada { get; set; }

        public string UfOrigem { get; set; }

        public string CodigoMunicipioOrigem { get; set; }

        public int Outorgantes { get; set; }

        public int Diligencias { get; set; }

        public int CodigoServentiaTipo { get; set; }

        public string AleatorioTipo { get; set; }

        public string Aleatorio { get; set; }

        public string AleatorioEscritura { get; set; }

        public string Letra { get; set; }

    }
}
