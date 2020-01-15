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
    public class ServicoNomes: ServicoBase<Nomes>, IServicoNomes
    {
        private readonly IRepositorioNomes _repositorioNomes;
        public ServicoNomes(IRepositorioNomes repositorioNomes)
            :base(repositorioNomes)
        {
            _repositorioNomes = repositorioNomes;
        }

        public List<Nomes> ObterNomesPorIdAto(int IdAto)
        {
            return _repositorioNomes.ObterNomesPorIdAto(IdAto);
        }


        public List<Nomes> ObterNomesPorNome(string nome)
        {
            return _repositorioNomes.ObterNomesPorNome(nome);
        }

        public List<Nomes> ObterNomesPorIdProcuracao(int IdProcuracao)
        {
            return _repositorioNomes.ObterNomesPorIdProcuracao(IdProcuracao);
        }


        public List<Nomes> ObterNomesPorIdTestamento(int IdTestamento)
        {
            return _repositorioNomes.ObterNomesPorIdTestamento(IdTestamento);
        }
    }
}
