using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Aplicacao.Interfaces
{
    public interface IAppServicoProcuracaoEscritura: IAppServicoBase<ProcuracaoEscritura>
    {
        List<ProcuracaoEscritura> ObterProcuracoesPorIdAto(int idAto);

        ProcuracaoEscritura ObterUmObjetoProcuracao(DateTime data, string serventia, string livro, string folhas,
            string ato, string outorgates, string outorgados, string selo, string aleatorio, bool sim, bool nao, out string mensagem);
    }
}
