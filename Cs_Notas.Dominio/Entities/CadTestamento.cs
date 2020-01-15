using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class CadTestamento
    {
        public int TestamentoId { get; set; }

        public string TipoAto { get; set; }

        public string Revogatorio { get; set; }

        public string Selo { get; set; }

        public string Aleatorio { get; set; }

        public string Recibo { get; set; }

        public DateTime DataAto { get; set; }

        public string Escrevente { get; set; }

        public string CpfEscrevente { get; set; }

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

        public string Livro { get; set; }

        public int FolhaInicio { get; set; }

        public int FolhaFim { get; set; }

        public int NumeroAto { get; set; }

        public string Local { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public DateTime DataEmissaoRg { get; set; }

        public string OrgaoRg { get; set; }

        public string Nacionalidade { get; set; }

        public int CodigoPais { get; set; }

        public string EstadoCivil { get; set; }

        public string RegimeCasamento { get; set; }

        public string Justificativa { get; set; }

        public string Enviado { get; set; }

        public string TipoTestamento { get; set; }

        public string Login { get; set; }

        public DateTime DataModificado { get; set; }

        public string HoraModificado { get; set; }

        public string Cancelado { get; set; }

        public string Natureza { get; set; }

        public int Codigo { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Naturalidade { get; set; }

        public string Path { get; set; }

        public int NumeroDistribuicao { get; set; }

        public DateTime DataDistribuicao { get; set; }

        public string DistribuicaoEnviada { get; set; }

        public string Mae { get; set; }

        public string Pai { get; set; }

        public int CodigoServentia { get; set; }

        public int Serventia { get; set; }

        public string Uf { get; set; }

        public int CodigoPaisOnu { get; set; }

        public string Sexo { get; set; }

        public int TipoJustificativa { get; set; }

        public string Letra { get; set; }

        public string Email { get; set; }

    }
}
