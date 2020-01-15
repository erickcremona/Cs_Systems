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
    public class ServicoNacionalidadesOnu: ServicoBase<NacionalidadesOnu>, IServicoNacionalidadesOnu
    {
        private readonly IRepositorioNacionalidadesOnu _repositorioNacionalidadesOnu;

        public ServicoNacionalidadesOnu(IRepositorioNacionalidadesOnu repositorioNacionalidadesOnu)
            : base(repositorioNacionalidadesOnu)
        {
            _repositorioNacionalidadesOnu = repositorioNacionalidadesOnu;
        }



        public NacionalidadesOnu ObterNacionalidadeOnuPorCodigoPais(int codigo)
        {
            return _repositorioNacionalidadesOnu.ObterNacionalidadeOnuPorCodigoPais(codigo);
        }
    }
}
