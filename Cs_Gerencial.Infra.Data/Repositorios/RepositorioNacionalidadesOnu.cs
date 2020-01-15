using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioNacionalidadesOnu: RepositorioBase<NacionalidadesOnu>, IRepositorioNacionalidadesOnu
    {
        public NacionalidadesOnu ObterNacionalidadeOnuPorCodigoPais(int codigo)
        {
           return Db.NacionalidadesOnu.Where(p => p.Codigo == codigo).FirstOrDefault();
        }
    }
}
