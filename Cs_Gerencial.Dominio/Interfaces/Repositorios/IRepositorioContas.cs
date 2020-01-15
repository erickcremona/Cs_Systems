using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioContas: IRepositorioBase<Contas>
    {
        IEnumerable<Contas> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
