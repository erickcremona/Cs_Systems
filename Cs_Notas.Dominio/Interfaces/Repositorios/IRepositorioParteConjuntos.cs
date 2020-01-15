using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioParteConjuntos: IRepositorioBase<ParteConjuntos>
    {
        List<ParteConjuntos> ListarPorIdAto(int idAto);

        List<ParteConjuntos> ListarPorIdNome(int idNome);

        List<ParteConjuntos> ObterNomesPorIdProcuracao(int IdProcuracao);
    }
}
