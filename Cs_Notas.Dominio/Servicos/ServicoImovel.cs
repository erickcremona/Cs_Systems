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
    public class ServicoImovel: ServicoBase<Imovel>, IServicoImovel
    {
        private readonly IRepositorioImovel _repositorioImovel;
        public ServicoImovel(IRepositorioImovel repositorioImovel)
            : base(repositorioImovel)
        {
            _repositorioImovel = repositorioImovel;
        }

        public List<Imovel> ObterImoveisPorIdAto(int idAto)
        {
            return _repositorioImovel.ObterImoveisPorIdAto(idAto);
        }
    }
}
