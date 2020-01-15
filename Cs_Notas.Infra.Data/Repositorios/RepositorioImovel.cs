using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioImovel: RepositorioBase<Imovel>, IRepositorioImovel
    {

        public List<Imovel> ObterImoveisPorIdAto(int idAto)
        {
            return Db.Imovel.Where(p => p.IdEscritura == idAto).ToList();
        }
    }
}
