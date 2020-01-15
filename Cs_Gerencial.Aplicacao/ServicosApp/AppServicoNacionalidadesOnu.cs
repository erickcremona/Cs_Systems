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
    public class AppServicoNacionalidadesOnu: AppServicoBase<NacionalidadesOnu>, IAppServicoNacionalidadesOnu
    {
        private readonly IServicoNacionalidadesOnu _servicoNacionalidadesOnu;

        public AppServicoNacionalidadesOnu(IServicoNacionalidadesOnu servicoNacionalidadesOnu)
            : base(servicoNacionalidadesOnu)
        {
            _servicoNacionalidadesOnu = servicoNacionalidadesOnu;
        }

        public NacionalidadesOnu ObterNacionalidadeOnuPorCodigoPais(int codigo)
        {
            return _servicoNacionalidadesOnu.ObterNacionalidadeOnuPorCodigoPais(codigo);
        }
    }
}
