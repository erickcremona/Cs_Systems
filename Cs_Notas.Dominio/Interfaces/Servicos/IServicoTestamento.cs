using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Servicos
{
    public interface IServicoTestamento: IServicoBase<CadTestamento>
    {
        CadTestamento SalvarAlteracaoTestamento(CadTestamento alterar);

        CadTestamento ObterTestamentoPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato);

        List<CadTestamento> ObterTestamentoPorPeriodo(DateTime dataInicio, DateTime dataFim);

        List<CadTestamento> ObterTestamentoPorLivro(string livro);

        List<CadTestamento> ObterTestamentoPorAto(int numeroAto);

        List<CadTestamento> ObterTestamentoPorSelo(string selo);

        List<CadTestamento> ObterTestamentoPorParticipante(List<int> idsAto);
    }
}
