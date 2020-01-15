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
    public class AppServicoAdicional: AppServicoBase<Adicional>, IAppServicoAdicional
    {
        private readonly IServicoAdicional _servicoAdicional;
        public AppServicoAdicional(IServicoAdicional servicoAdicional)
            :base(servicoAdicional)
        {
            _servicoAdicional = servicoAdicional;
        }
    }
}
