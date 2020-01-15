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
    public class AppServicoImovel: AppServicoBase<Imovel>, IAppServicoImovel
    {
        private readonly IServicoImovel _servicoImovel;
        public AppServicoImovel(IServicoImovel servicoImovel)
            :base(servicoImovel)
        {
            _servicoImovel = servicoImovel;
        }

        public List<Imovel> ObterImoveisPorIdAto(int idAto)
        {
            return _servicoImovel.ObterImoveisPorIdAto(idAto);
        }
    }
}
