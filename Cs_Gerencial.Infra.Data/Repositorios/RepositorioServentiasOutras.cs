using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioServentiasOutras: RepositorioBase<ServentiasOutras>, IRepositorioServentiasOutras
    {
        public ServentiasOutras ObterServentiaPorCodigo(int codigo)
        {
            return Db.ServentiasOutras.Where(p => p.Codigo == codigo).FirstOrDefault();
        }
    }
}
