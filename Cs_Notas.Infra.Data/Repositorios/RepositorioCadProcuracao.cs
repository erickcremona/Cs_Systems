using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioCadProcuracao: RepositorioBase<CadProcuracao>, IRepositorioCadProcuracao
    {

        public CadProcuracao SalvarAlteracaoProcuracao(CadProcuracao alterar)
        {
            var salvar = Db.CadProcuracao.Where(p => p.ProcuracaoId == alterar.ProcuracaoId).FirstOrDefault();

            salvar.Acoterj = alterar.Acoterj;
            salvar.Aleatorio = alterar.Aleatorio;
            salvar.AleatorioEscritura = alterar.AleatorioEscritura;
            salvar.AleatorioTipo = alterar.AleatorioTipo;
            salvar.Ausente = alterar.Ausente;
            salvar.Bens = alterar.Bens;
            salvar.Cancelado = alterar.Cancelado;
            salvar.Codigo = alterar.Codigo;
            salvar.CodigoLivro = alterar.CodigoLivro;
            salvar.CodigoMunicipioOrigem = alterar.CodigoMunicipioOrigem;
            salvar.CodigoServentiaTipo = alterar.CodigoServentiaTipo;
            salvar.ConsultaTipo = alterar.ConsultaTipo;
            salvar.CpfEscrevente = alterar.CpfEscrevente;
            salvar.DataDistribuicao = alterar.DataDistribuicao;
            salvar.DataLavratura = alterar.DataLavratura;
            salvar.DataLavraturaTipo = alterar.DataLavraturaTipo;
            salvar.DataModificado = alterar.DataModificado;
            salvar.DataVigencia = alterar.DataVigencia;
            salvar.DescricaoCustas = alterar.DescricaoCustas;
            salvar.DescricaoTipo = alterar.DescricaoTipo;
            salvar.Diligencias = alterar.Diligencias;
            salvar.Distribuicao = alterar.Distribuicao;
            salvar.DistribuicaoEnviada = alterar.DistribuicaoEnviada;
            salvar.Emolumentos = alterar.Emolumentos;
            salvar.Enviado = alterar.Enviado;
            salvar.Fetj = alterar.Fetj;
            salvar.FolhaFim = alterar.FolhaFim;
            salvar.FolhaFimTipo = alterar.FolhaFimTipo;
            salvar.FolhaInicio = alterar.FolhaInicio;
            salvar.FolhaInicioTipo = alterar.FolhaInicioTipo;
            salvar.Funarpen = alterar.Funarpen;
            salvar.Fundperj = alterar.Fundperj;
            salvar.Funprj = alterar.Funprj;
            salvar.HoraModificado = alterar.HoraModificado;
            salvar.Iss = alterar.Iss;
            salvar.LavradoRj = alterar.LavradoRj;
            salvar.Letra = alterar.Letra;
            salvar.Livro = alterar.Livro;
            salvar.LivroTipo = alterar.LivroTipo;
            salvar.Local = alterar.Local;
            salvar.Login = alterar.Login;
            salvar.Mutua = alterar.Mutua;
            salvar.Natureza = alterar.Natureza;
            salvar.Notificacao = alterar.Notificacao;
            salvar.NumeroAto = alterar.NumeroAto;
            salvar.NumeroAtoTipo = alterar.NumeroAtoTipo;
            salvar.NumeroDistribuicao = alterar.NumeroDistribuicao;
            salvar.Observacao = alterar.Observacao;
            salvar.Outorgantes = alterar.Outorgantes;
            salvar.OutrosLocal = alterar.OutrosLocal;
            salvar.Path = alterar.Path;
            salvar.Pmcmv = alterar.Pmcmv;
            salvar.Poderes = alterar.Poderes;
            salvar.Recibo = alterar.Recibo;
            salvar.Resumo = alterar.Resumo;
            salvar.Selo = alterar.Selo;
            salvar.SeloEscritura = alterar.SeloEscritura;
            salvar.SeloTipo = alterar.SeloTipo;
            salvar.ServentiaTipo = alterar.ServentiaTipo;
            salvar.Texto = alterar.Texto;
            salvar.Tipo = alterar.Tipo;
            salvar.TipoAto = alterar.TipoAto;
            salvar.TipoCobranca = alterar.TipoCobranca;
            salvar.TipoLivro = alterar.TipoLivro;
            salvar.TipoLivroTipo = alterar.TipoLivroTipo;
            salvar.Total = alterar.Total;
            salvar.UfOrigem = alterar.UfOrigem;
                

            Update(salvar);
            return salvar;
        }


        public CadProcuracao ObterProcuracaoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return Db.CadProcuracao.Where(p => p.Selo == selo && p.Aleatorio == aleatorio && p.Livro == livro && p.FolhaInicio == folhainicio && p.FolhaFim == folhaFim && p.NumeroAto == ato).FirstOrDefault();
        }

        public List<CadProcuracao> ObterProcuracaoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Db.CadProcuracao.Where(p => p.DataLavratura >= dataInicio && p.DataLavratura <= dataFim).OrderByDescending(p => p.DataLavratura).ToList();
        }

        public List<CadProcuracao> ObterProcuracaoPorLivro(string livro)
        {
            return Db.CadProcuracao.Where(p => p.Livro == livro).OrderByDescending(p => p.DataLavratura).ToList();
        }

        public List<CadProcuracao> ObterProcuracaoPorAto(int numeroAto)
        {
            return Db.CadProcuracao.Where(p => p.NumeroAto == numeroAto).OrderByDescending(p => p.DataLavratura).ToList();
        }

        public List<CadProcuracao> ObterProcuracaoPorSelo(string selo)
        {
            return Db.CadProcuracao.Where(p => p.Selo == selo).OrderByDescending(p => p.DataLavratura).ToList();
        }

        public List<CadProcuracao> ObterProcuracaoPorParticipante(List<int> idsAto)
        {
            var procuracao = new List<CadProcuracao>();

            for (int i = 0; i < idsAto.Count(); i++)
            {
                procuracao.Add(Db.CadProcuracao.Where(p => p.ProcuracaoId == idsAto[i]).OrderByDescending(p => p.DataLavratura).FirstOrDefault());
            }
            return procuracao;
        }
    }
}
