using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioPlanos: IRepositorioBase<Planos>
    {
        IEnumerable<Planos> ConsultarPlanosPorDescricao(string descricao);
    }
}
