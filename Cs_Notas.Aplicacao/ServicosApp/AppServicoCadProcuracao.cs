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
    public class AppServicoCadProcuracao: AppServicoBase<CadProcuracao>, IAppServicoCadProcuracao
    {
        private readonly IServicoCadProcuracao _IServicoCadProcuracao;

        public AppServicoCadProcuracao(IServicoCadProcuracao IServicoCadProcuracao)
            : base(IServicoCadProcuracao)
        {
            _IServicoCadProcuracao = IServicoCadProcuracao;
        }

        public CadProcuracao SalvarAlteracaoProcuracao(CadProcuracao alterar)
        {
            return _IServicoCadProcuracao.SalvarAlteracaoProcuracao(alterar);
        }

        public CadProcuracao ObterProcuracaoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return _IServicoCadProcuracao.ObterProcuracaoPorSeloLivroFolhaAto(selo, aleatorio, livro, folhainicio, folhaFim, ato);
        }

        public List<CadProcuracao> ObterProcuracaoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _IServicoCadProcuracao.ObterProcuracaoPorPeriodo(dataInicio, dataFim);
        }

        public List<CadProcuracao> ObterProcuracaoPorLivro(string livro)
        {
            return _IServicoCadProcuracao.ObterProcuracaoPorLivro(livro);
        }

        public List<CadProcuracao> ObterProcuracaoPorAto(int numeroAto)
        {
            return _IServicoCadProcuracao.ObterProcuracaoPorAto(numeroAto);
        }

        public List<CadProcuracao> ObterProcuracaoPorSelo(string selo)
        {
            return _IServicoCadProcuracao.ObterProcuracaoPorSelo(selo);
        }

        public List<CadProcuracao> ObterProcuracaoPorParticipante(List<int> idsAto)
        {
            return _IServicoCadProcuracao.ObterProcuracaoPorParticipante(idsAto);
        }
    }
}
