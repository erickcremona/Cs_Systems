using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Servicos
{
    public class ServicoTestamento: ServicoBase<CadTestamento>, IServicoTestamento
    {
        private readonly IRepositorioTestamento _IRepositorioTestamento;

        public ServicoTestamento(IRepositorioTestamento IRepositorioTestamento)
            : base(IRepositorioTestamento)
        {
            _IRepositorioTestamento = IRepositorioTestamento;
        }

        public CadTestamento SalvarAlteracaoTestamento(CadTestamento alterar)
        {
            return _IRepositorioTestamento.SalvarAlteracaoTestamento(alterar);
        }

        public CadTestamento ObterTestamentoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return _IRepositorioTestamento.ObterTestamentoPorSeloLivroFolhaAto(selo, aleatorio, livro, folhainicio, folhaFim, ato);
        }

        public List<CadTestamento> ObterTestamentoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _IRepositorioTestamento.ObterTestamentoPorPeriodo(dataInicio, dataFim);
        }

        public List<CadTestamento> ObterTestamentoPorLivro(string livro)
        {
            return _IRepositorioTestamento.ObterTestamentoPorLivro(livro);
        }

        public List<CadTestamento> ObterTestamentoPorAto(int numeroAto)
        {
            return _IRepositorioTestamento.ObterTestamentoPorAto(numeroAto);
        }

        public List<CadTestamento> ObterTestamentoPorSelo(string selo)
        {
            return _IRepositorioTestamento.ObterTestamentoPorSelo(selo);
        }

        public List<CadTestamento> ObterTestamentoPorParticipante(List<int> idsAto)
        {
            return _IRepositorioTestamento.ObterTestamentoPorParticipante(idsAto);
        }
    }
}
