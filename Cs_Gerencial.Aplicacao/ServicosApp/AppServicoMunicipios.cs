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
    public class AppServicoMunicipios: AppServicoBase<Municipios>, IAppServicoMunicipios
    {
        private readonly IServicoMunicipios _servicoMunicipios;

        public AppServicoMunicipios(IServicoMunicipios servicoMunicipios)
            : base(servicoMunicipios)
        {
            _servicoMunicipios = servicoMunicipios;
        }

        public List<Municipios> ObterMunicipiosPorUF(string UF)
        {
            return _servicoMunicipios.ObterMunicipiosPorUF(UF);
        }

        public List<string> ObterUfsDosMunicipios()
        {
            return _servicoMunicipios.ObterUfsDosMunicipios();
        }
    }
}
