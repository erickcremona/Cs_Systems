using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Servicos
{
    public interface IServicoEscrituras: IServicoBase<Escrituras>
    {
        Escrituras ObterEscrituraPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato);

        List<Escrituras> ObterEscriturasPorPeriodo(DateTime dataInicio, DateTime dataFim);

        List<Escrituras> ObterEscriturarPorLivro(string livro);

        List<Escrituras> ObterEscriturarPorAto(int numeroAto);

        List<Escrituras> ObterEscriturarPorSelo(string selo);

        List<Escrituras> ObterEscriturarPorParticipante(List<int> idsAto);

    }
}
