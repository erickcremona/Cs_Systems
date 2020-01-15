using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Servicos
{
    public interface IServicoCadProcuracao: IServicoBase<CadProcuracao>
    {
        CadProcuracao SalvarAlteracaoProcuracao(CadProcuracao alterar);

        CadProcuracao ObterProcuracaoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato);

        List<CadProcuracao> ObterProcuracaoPorPeriodo(DateTime dataInicio, DateTime dataFim);

        List<CadProcuracao> ObterProcuracaoPorLivro(string livro);

        List<CadProcuracao> ObterProcuracaoPorAto(int numeroAto);

        List<CadProcuracao> ObterProcuracaoPorSelo(string selo);

        List<CadProcuracao> ObterProcuracaoPorParticipante(List<int> idsAto);

    }
}
