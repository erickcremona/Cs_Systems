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
    public class ServicoCadProcuracao: ServicoBase<CadProcuracao>, IServicoCadProcuracao
    {
        private readonly IRepositorioCadProcuracao _IRepositorioCadProcuracao;

        public ServicoCadProcuracao(IRepositorioCadProcuracao IRepositorioCadProcuracao)
            :base(IRepositorioCadProcuracao)
        {
            _IRepositorioCadProcuracao = IRepositorioCadProcuracao;
        }

        public CadProcuracao SalvarAlteracaoProcuracao(CadProcuracao alterar)
        {
            return _IRepositorioCadProcuracao.SalvarAlteracaoProcuracao(alterar);
        }


        public CadProcuracao ObterProcuracaoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return _IRepositorioCadProcuracao.ObterProcuracaoPorSeloLivroFolhaAto(selo, aleatorio, livro, folhainicio, folhaFim, ato);
        }

        public List<CadProcuracao> ObterProcuracaoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _IRepositorioCadProcuracao.ObterProcuracaoPorPeriodo(dataInicio, dataFim);
        }

        public List<CadProcuracao> ObterProcuracaoPorLivro(string livro)
        {
            return _IRepositorioCadProcuracao.ObterProcuracaoPorLivro(livro);
        }

        public List<CadProcuracao> ObterProcuracaoPorAto(int numeroAto)
        {
            return _IRepositorioCadProcuracao.ObterProcuracaoPorAto(numeroAto);
        }

        public List<CadProcuracao> ObterProcuracaoPorSelo(string selo)
        {
            return _IRepositorioCadProcuracao.ObterProcuracaoPorSelo(selo);
        }

        public List<CadProcuracao> ObterProcuracaoPorParticipante(List<int> idsAto)
        {
            return _IRepositorioCadProcuracao.ObterProcuracaoPorParticipante(idsAto);
        }
    }
}
