using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Aplicacao.Interfaces
{
    public interface IAppServicoRevogados: IAppServicoBase<Revogados>
    {
        List<Revogados> ObterRevogadosPorIdTestamento(int idTestamento);
    }
}
