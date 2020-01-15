using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioContas: RepositorioBase<Contas>, IRepositorioContas
    {
        public IEnumerable<Contas> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
           
            return Db.Contas.Where(p => p.DataMovimento >= dataInicio && p.DataMovimento <= dataFim);                
                    
        }
    }
}
