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
    public class AppServicoEscrituras: AppServicoBase<Escrituras>, IAppServicoEscrituras
    {
        private readonly IServicoEscrituras _servicoEscrituras;

        public AppServicoEscrituras(IServicoEscrituras servicoEscrituras)
            : base(servicoEscrituras)
        {
            _servicoEscrituras = servicoEscrituras;
        }

        public Escrituras ObterEscrituraPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
            return _servicoEscrituras.ObterEscrituraPorSeloLivroFolhaAto(selo, aleatorio, livro, folhainicio, folhaFim, ato);
        }


        public List<Escrituras> ObterEscriturasPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _servicoEscrituras.ObterEscriturasPorPeriodo(dataInicio, dataFim);
        }

        public List<Escrituras> ObterEscriturarPorLivro(string livro)
        {
            return _servicoEscrituras.ObterEscriturarPorLivro(livro);
        }

        public List<Escrituras> ObterEscriturarPorAto(int numeroAto)
        {
            return _servicoEscrituras.ObterEscriturarPorAto(numeroAto);
        }

        public List<Escrituras> ObterEscriturarPorSelo(string selo)
        {
            return _servicoEscrituras.ObterEscriturarPorSelo(selo);
        }

        public List<Escrituras> ObterEscriturarPorParticipante(List<int> idsAto)
        {
            return _servicoEscrituras.ObterEscriturarPorParticipante(idsAto);
        }
    }
}
