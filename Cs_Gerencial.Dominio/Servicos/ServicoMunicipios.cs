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
    public class ServicoMunicipios: ServicoBase<Municipios>, IServicoMunicipios
    {

        private readonly IRepositorioMunicipios _repositorioMunicipios;

        public ServicoMunicipios(IRepositorioMunicipios repositorioMunicipios)
            : base(repositorioMunicipios)
        {
            _repositorioMunicipios = repositorioMunicipios;
        }



        public List<Municipios> ObterMunicipiosPorUF(string UF)
        {
            return _repositorioMunicipios.ObterMunicipiosPorUF(UF);
        }

        public List<string> ObterUfsDosMunicipios()
        {
            return _repositorioMunicipios.ObterUfsDosMunicipios();
        }
    }
}
