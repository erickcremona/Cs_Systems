using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.ServicosApp
{
    public class AppServicoContas: AppServicoBase<Contas>, IAppServicoContas
    {
        private readonly IServicoContas _servicoContas;

        public AppServicoContas(IServicoContas servicoContas)
            : base(servicoContas)
        {
            _servicoContas = servicoContas;
        }

        public IEnumerable<Contas> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _servicoContas.ConsultaPorPeriodo(dataInicio, dataFim);
        }
    }
}
