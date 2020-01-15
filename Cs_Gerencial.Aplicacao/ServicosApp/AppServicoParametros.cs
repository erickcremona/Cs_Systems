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
    public class AppServicoParametros : AppServicoBase<Parametros>, IAppServicoParametros
    {
        private readonly IServicoParametros _ServicoParametros;

        public AppServicoParametros(IServicoParametros ServicoParametros)
            : base(ServicoParametros)
        {
            _ServicoParametros = ServicoParametros;
        }
    }
}
