using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Servicos
{
    public interface IServicoComplementos: IServicoBase<Complementos>
    {
        List<Complementos> ObterComplementosPorIdAto(int idAto);
    }
}
