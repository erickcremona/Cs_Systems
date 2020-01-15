using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Aplicacao.ServicosApp
{
    public class AppServicoRegimes: AppServicoBase<Regimes>, IAppServicoRegimes
    {
        private readonly IServicoRegimes _servicoRegimes;

        public AppServicoRegimes(IServicoRegimes servicoRegimes)
            :base(servicoRegimes)
        {
            _servicoRegimes = servicoRegimes;
        }
    }
}
