using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioSeries: RepositorioBase<Series>, IRepositorioSeries
    {
        public IEnumerable<Series> ConsultarPorIdCompraSelo(int idCompraSelo)
        {
            return Db.Series.Where(p => p.IdCompra == idCompraSelo);
        }
    }
}
