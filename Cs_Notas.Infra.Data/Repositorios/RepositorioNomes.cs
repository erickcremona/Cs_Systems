using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioNomes : RepositorioBase<Nomes>, IRepositorioNomes
    {
        public List<Nomes> ObterNomesPorIdAto(int IdAto)
        {

            return Db.Nomes.Where(p => p.IdEscritura == IdAto).ToList();

        }


        public List<Nomes> ObterNomesPorNome(string nome)
        {
            return Db.Nomes.Where(p => p.Nome == nome).ToList();

        }


        public List<Nomes> ObterNomesPorIdProcuracao(int IdProcuracao)
        {

            return Db.Nomes.Where(p => p.IdProcuracao == IdProcuracao).ToList();

        }


        public List<Nomes> ObterNomesPorIdTestamento(int IdTestamento)
        {

            return Db.Nomes.Where(p => p.IdTestamento == IdTestamento).ToList();

        }
    }
}
