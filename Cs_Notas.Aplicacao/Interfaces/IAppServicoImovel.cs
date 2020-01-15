using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Aplicacao.Interfaces
{
    public interface IAppServicoImovel: IAppServicoBase<Imovel>
    {
        List<Imovel> ObterImoveisPorIdAto(int idAto);
    }
}
