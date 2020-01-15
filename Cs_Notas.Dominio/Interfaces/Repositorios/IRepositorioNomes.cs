using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioNomes: IRepositorioBase<Nomes>
    {
        List<Nomes> ObterNomesPorIdAto(int IdAto);

        List<Nomes> ObterNomesPorNome(string nome);

        List<Nomes> ObterNomesPorIdProcuracao(int IdProcuracao);

        List<Nomes> ObterNomesPorIdTestamento(int IdTestamento);
    }
}
