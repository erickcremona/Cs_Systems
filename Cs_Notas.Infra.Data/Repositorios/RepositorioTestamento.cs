using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioTestamento: RepositorioBase<CadTestamento>, IRepositorioTestamento
    {

        public CadTestamento SalvarAlteracaoTestamento(CadTestamento alterar)
        {
            var salvar = Db.Testamento.Where(p => p.TestamentoId == alterar.TestamentoId).FirstOrDefault();

            salvar.Acoterj = alterar.Acoterj;
            salvar.Aleatorio = alterar.Aleatorio;
            salvar.Cancelado = alterar.Cancelado;
            salvar.Codigo = alterar.Codigo;
            salvar.CodigoPais = alterar.CodigoPais;
            salvar.CodigoPaisOnu = alterar.CodigoPaisOnu;
            salvar.CodigoServentia = alterar.CodigoServentia;
            salvar.Cpf = alterar.Cpf;
            salvar.CpfEscrevente = alterar.CpfEscrevente;
            salvar.DataAto = alterar.DataAto;
            salvar.DataDistribuicao = alterar.DataDistribuicao;
            salvar.DataEmissaoRg = alterar.DataEmissaoRg;
            salvar.DataModificado = alterar.DataModificado;
            salvar.DataNascimento = alterar.DataNascimento;
            salvar.Distribuicao = alterar.Distribuicao;
            salvar.DistribuicaoEnviada = alterar.DistribuicaoEnviada;
            salvar.Email = alterar.Email;
            salvar.Emolumentos = alterar.Emolumentos;
            salvar.Enviado = alterar.Enviado;
            salvar.Escrevente = alterar.Escrevente;
            salvar.EstadoCivil = alterar.EstadoCivil;
            salvar.Fetj = alterar.Fetj;
            salvar.FolhaFim = alterar.FolhaFim;
            salvar.FolhaInicio = alterar.FolhaInicio;
            salvar.Funarpen = alterar.Funarpen;
            salvar.Fundperj = alterar.Fundperj;
            salvar.Funprj = alterar.Funprj;
            salvar.HoraModificado = alterar.HoraModificado;
            salvar.Iss = alterar.Iss;
            salvar.Justificativa = alterar.Justificativa;
            salvar.Letra = alterar.Letra;
            salvar.Livro = alterar.Livro;
            salvar.Local = alterar.Local;
            salvar.Login = alterar.Login;
            salvar.Mae = alterar.Mae;
            salvar.Mutua = alterar.Mutua;
            salvar.Nacionalidade = alterar.Nacionalidade;
            salvar.Naturalidade = alterar.Naturalidade;
            salvar.Natureza = alterar.Natureza;
            salvar.Nome = alterar.Nome;
            salvar.NumeroAto = alterar.NumeroAto;
            salvar.NumeroDistribuicao = alterar.NumeroDistribuicao;
            salvar.OrgaoRg = alterar.OrgaoRg;
            salvar.Pai = alterar.Pai;
            salvar.Path = alterar.Path;
            salvar.Pmcmv = alterar.Pmcmv;
            salvar.Recibo = alterar.Recibo;
            salvar.RegimeCasamento = alterar.RegimeCasamento;
            salvar.Revogatorio = alterar.Revogatorio;
            salvar.Rg = alterar.Rg;
            salvar.Selo = alterar.Selo;
            salvar.Serventia = alterar.Serventia;
            salvar.Sexo = alterar.Sexo;
            salvar.TipoAto = alterar.TipoAto;
            salvar.TipoCobranca = alterar.TipoCobranca;
            salvar.TipoJustificativa = alterar.TipoJustificativa;
            salvar.TipoTestamento = alterar.TipoTestamento;
            salvar.Total = alterar.Total;
            salvar.Uf = alterar.Uf;
            
            Update(salvar);
            return salvar;
        }

        public CadTestamento ObterTestamentoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return Db.Testamento.Where(p => p.Selo == selo && p.Aleatorio == aleatorio && p.Livro == livro && p.FolhaInicio == folhainicio && p.FolhaFim == folhaFim && p.NumeroAto == ato).FirstOrDefault();
        }

        public List<CadTestamento> ObterTestamentoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Db.Testamento.Where(p => p.DataAto >= dataInicio && p.DataAto <= dataFim).OrderByDescending(p => p.DataAto).ToList();
        }

        public List<CadTestamento> ObterTestamentoPorLivro(string livro)
        {
            return Db.Testamento.Where(p => p.Livro == livro).OrderByDescending(p => p.DataAto).ToList();
        }

        public List<CadTestamento> ObterTestamentoPorAto(int numeroAto)
        {
            return Db.Testamento.Where(p => p.NumeroAto == numeroAto).OrderByDescending(p => p.DataAto).ToList();
        }

        public List<CadTestamento> ObterTestamentoPorSelo(string selo)
        {
            return Db.Testamento.Where(p => p.Selo == selo).OrderByDescending(p => p.DataAto).ToList();
        }

        public List<CadTestamento> ObterTestamentoPorParticipante(List<int> idsAto)
        {
            var testamento = new List<CadTestamento>();

            for (int i = 0; i < idsAto.Count(); i++)
            {
                testamento.Add(Db.Testamento.Where(p => p.TestamentoId == idsAto[i]).OrderByDescending(p => p.DataAto).FirstOrDefault());
            }
            return testamento;
        }
    }
}
