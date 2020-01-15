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
    public class AppServicoLogSistema: AppServicoBase<LogSistema>, IAppServicoLogSistema
    {
         private readonly IServicoLogSistema _servicoLogSistema;

        public AppServicoLogSistema(IServicoLogSistema servicoLogSistema)
            : base(servicoLogSistema)
        {
            _servicoLogSistema = servicoLogSistema;
        }
    }
}
