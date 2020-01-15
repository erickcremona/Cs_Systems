using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Servicos
{
    public interface IServicoBensAtosConjuntos: IServicoBase<BensAtosConjuntos>
    {
        List<BensAtosConjuntos> ObterBensAtoConjuntosPorIdAto(int idAto);
    }
}
