using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Aplicacao.ServicosApp
{
    public class AppServicoTestamento: AppServicoBase<CadTestamento>, IAppServicoTestamento
    {
        private readonly IServicoTestamento _IServicoTestamento;

        public AppServicoTestamento(IServicoTestamento IServicoTestamento)
            : base(IServicoTestamento)
        {
            _IServicoTestamento = IServicoTestamento;
        }

        public CadTestamento SalvarAlteracaoTestamento(CadTestamento alterar)
        {
            return _IServicoTestamento.SalvarAlteracaoTestamento(alterar);
        }

        public CadTestamento ObterTestamentoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return _IServicoTestamento.ObterTestamentoPorSeloLivroFolhaAto(selo, aleatorio, livro, folhainicio, folhaFim, ato);
        }

        public List<CadTestamento> ObterTestamentoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _IServicoTestamento.ObterTestamentoPorPeriodo(dataInicio, dataFim);
        }

        public List<CadTestamento> ObterTestamentoPorLivro(string livro)
        {
            return _IServicoTestamento.ObterTestamentoPorLivro(livro);
        }

        public List<CadTestamento> ObterTestamentoPorAto(int numeroAto)
        {
            return _IServicoTestamento.ObterTestamentoPorAto(numeroAto);
        }

        public List<CadTestamento> ObterTestamentoPorSelo(string selo)
        {
            return _IServicoTestamento.ObterTestamentoPorSelo(selo);
        }

        public List<CadTestamento> ObterTestamentoPorParticipante(List<int> idsAto)
        {
            return _IServicoTestamento.ObterTestamentoPorParticipante(idsAto);
        }
    }
}
