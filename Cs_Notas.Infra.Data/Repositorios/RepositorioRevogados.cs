using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioRevogados: RepositorioBase<Revogados>, IRepositorioRevogados
    {

        public List<Revogados> ObterRevogadosPorIdTestamento(int idTestamento)
        {
            return Db.Revogados.Where(p => p.IdTestamento == idTestamento).ToList();
        }
    }
}
