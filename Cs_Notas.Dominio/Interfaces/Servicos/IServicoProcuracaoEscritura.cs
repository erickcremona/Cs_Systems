using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Servicos
{
    public interface IServicoProcuracaoEscritura: IServicoBase<ProcuracaoEscritura>
    {

        List<ProcuracaoEscritura> ObterProcuracoesPorIdAto(int idAto);
    }
}
