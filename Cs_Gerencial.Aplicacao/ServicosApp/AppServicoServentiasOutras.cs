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
    public class AppServicoServentiasOutras : AppServicoBase<ServentiasOutras>, IAppServicoServentiasOutras
    {
        private readonly IServicoServentiasOutras _serventiasOutras;

        public AppServicoServentiasOutras(IServicoServentiasOutras serventiasOutras)
            : base(serventiasOutras)
        {
            _serventiasOutras = serventiasOutras;
        }

        public ServentiasOutras ObterServentiaPorCodigo(int codigo)
        {
            return _serventiasOutras.ObterServentiaPorCodigo(codigo);
        }
    }
}
