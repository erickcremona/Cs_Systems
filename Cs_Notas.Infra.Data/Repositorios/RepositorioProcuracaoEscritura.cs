using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioProcuracaoEscritura: RepositorioBase<ProcuracaoEscritura>, IRepositorioProcuracaoEscritura
    {
        public List<ProcuracaoEscritura> ObterProcuracoesPorIdAto(int idAto)
        {
            return Db.ProcuracaoEscritura.Where(p => p.IdEscritura == idAto).ToList();
        }
    }
}
