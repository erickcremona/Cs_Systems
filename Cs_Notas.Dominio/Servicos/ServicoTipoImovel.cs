using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Servicos
{
    public class ServicoTipoImovel: ServicoBase<TipoImovel>, IServicoTipoImovel
    {
        private readonly IRepositorioTipoImovel _repositorioTipoImovel;

        public ServicoTipoImovel(IRepositorioTipoImovel repositorioTipoImovel)
            :base(repositorioTipoImovel)
        {
            _repositorioTipoImovel = repositorioTipoImovel;
        }
    }
}
