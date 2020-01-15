using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioItensCustas: IRepositorioBase<ItensCustas>
    {
        List<ItensCustas> ObterItensCustasPorIdAto(int idAto);

        List<ItensCustas> ObterItensCustasPorIdProcuracao(int idProcuracao);

        List<ItensCustas> ObterItensCustasPorIdTestamento(int idTestamento);
    }
}
