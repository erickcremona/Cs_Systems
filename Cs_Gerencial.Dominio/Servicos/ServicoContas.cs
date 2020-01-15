using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Servicos
{
     public class ServicoContas: ServicoBase<Contas>, IServicoContas
    {
         private readonly IRepositorioContas _repositorioContas;

         public ServicoContas(IRepositorioContas repositorioContas)
             : base(repositorioContas)
         {
             _repositorioContas = repositorioContas;
         }



         public IEnumerable<Contas> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim)
         {
            return  _repositorioContas.ConsultaPorPeriodo(dataInicio, dataFim);
         }
    }
}
