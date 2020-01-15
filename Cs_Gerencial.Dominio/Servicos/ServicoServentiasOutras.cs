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
    public class ServicoServentiasOutras: ServicoBase<ServentiasOutras>, IServicoServentiasOutras
    {
        private readonly IRepositorioServentiasOutras _repositorioServentiasOutras;

        public ServicoServentiasOutras(IRepositorioServentiasOutras repositorioServentiasOutras)
            : base(repositorioServentiasOutras)
        {
            _repositorioServentiasOutras = repositorioServentiasOutras;
        }

        public ServentiasOutras ObterServentiaPorCodigo(int codigo)
        {
            return _repositorioServentiasOutras.ObterServentiaPorCodigo(codigo);
        }
    }
}
