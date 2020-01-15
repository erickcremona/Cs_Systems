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
    public class ServicoEscrituras: ServicoBase<Escrituras>, IServicoEscrituras
    {
        private readonly IRepositorioEscrituras _repositorioEscrituras;

        public ServicoEscrituras(IRepositorioEscrituras repositorioEscrituras)
            : base(repositorioEscrituras)
        {
            _repositorioEscrituras = repositorioEscrituras;
        }

        public Escrituras ObterEscrituraPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return _repositorioEscrituras.ObterEscrituraPorSeloLivroFolhaAto(selo, aleatorio, livro, folhainicio, folhaFim, ato);
        }


        public List<Escrituras> ObterEscriturasPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _repositorioEscrituras.ObterEscriturasPorPeriodo(dataInicio, dataFim);
        }

        public List<Escrituras> ObterEscriturarPorLivro(string livro)
        {
            return _repositorioEscrituras.ObterEscriturarPorLivro(livro);
        }

        public List<Escrituras> ObterEscriturarPorAto(int numeroAto)
        {
            return _repositorioEscrituras.ObterEscriturarPorAto(numeroAto);
        }

        public List<Escrituras> ObterEscriturarPorSelo(string selo)
        {
            return _repositorioEscrituras.ObterEscriturarPorSelo(selo);
        }

        public List<Escrituras> ObterEscriturarPorParticipante(List<int> idsAto)
        {
           return  _repositorioEscrituras.ObterEscriturarPorParticipante(idsAto);
        }
    }
}
