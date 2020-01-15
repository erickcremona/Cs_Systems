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
    public class AppServicoNomes : AppServicoBase<Nomes>, IAppServicoNomes
    {
        private readonly IServicoNomes _servicoNomes;
        public AppServicoNomes(IServicoNomes servicoNomes)
            :base(servicoNomes)
        {
            _servicoNomes = servicoNomes;
        }

        public List<Nomes> ObterNomesPorIdAto(int IdAto)
        {
            return _servicoNomes.ObterNomesPorIdAto(IdAto);
        }


        public List<Nomes> ObterNomesPorNome(string nome)
        {
            return _servicoNomes.ObterNomesPorNome(nome);
        }


        public List<Nomes> ObterNomesPorIdProcuracao(int IdProcuracao)
        {
            return _servicoNomes.ObterNomesPorIdProcuracao(IdProcuracao);
        }


        public List<Nomes> ObterNomesPorIdTestamento(int IdTestamento)
        {
            return _servicoNomes.ObterNomesPorIdTestamento(IdTestamento);
        }
    }
}
