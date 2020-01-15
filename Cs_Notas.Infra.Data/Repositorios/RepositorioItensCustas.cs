using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioItensCustas : RepositorioBase<ItensCustas>, IRepositorioItensCustas
    {

        public List<ItensCustas> ObterItensCustasPorIdAto(int idAto)
        {
            return Db.ItensCustas.Where(p => p.IdEscritura == idAto).ToList();
        }


        public List<ItensCustas> ObterItensCustasPorIdProcuracao(int idProcuracao)
        {
            return Db.ItensCustas.Where(p => p.IdProcuracao == idProcuracao).ToList();
        }


        public List<ItensCustas> ObterItensCustasPorIdTestamento(int idTestamento)
        {
            return Db.ItensCustas.Where(p => p.IdTestamento == idTestamento).ToList();
        }
    }
}
