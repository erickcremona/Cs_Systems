using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioPlanos: RepositorioBase<Planos>, IRepositorioPlanos
    {
        public IEnumerable<Planos> ConsultarPlanosPorDescricao(string descricao)
        {
            return Db.Planos.Where(p => p.Descricao.Contains(descricao)).OrderBy(p => p.Descricao);
        }
    }
}
