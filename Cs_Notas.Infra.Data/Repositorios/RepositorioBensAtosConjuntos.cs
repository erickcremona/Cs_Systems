using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioBensAtosConjuntos: RepositorioBase<BensAtosConjuntos>, IRepositorioBensAtosConjuntos
    {
        public List<BensAtosConjuntos> ObterBensAtoConjuntosPorIdAto(int idAto)
        {
            return Db.BensAtosConjuntos.Where(p => p.IdEscritura == idAto).ToList();
        }
    }
}
