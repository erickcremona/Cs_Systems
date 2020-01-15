using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Servicos
{
    public interface IServicoAtoConjuntos: IServicoBase<AtoConjuntos>
    {
        List<AtoConjuntos> ObterAtosConjuntosPorIdAto(int idAto);

        List<AtoConjuntos> ObterAtosConjuntosPorIdProcuracao(int idProcurcacao);
    }
}
