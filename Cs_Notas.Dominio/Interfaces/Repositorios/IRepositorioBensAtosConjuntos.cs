using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBensAtosConjuntos: IRepositorioBase<BensAtosConjuntos>
    {
        List<BensAtosConjuntos> ObterBensAtoConjuntosPorIdAto(int idAto);
    }
}
