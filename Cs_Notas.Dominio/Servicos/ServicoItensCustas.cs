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
    public class ServicoItensCustas: ServicoBase<ItensCustas>, IServicoItensCustas
    {

        private readonly IRepositorioItensCustas _repositorioItensCustas;

        public ServicoItensCustas(IRepositorioItensCustas repositorioItensCustas)
            :base(repositorioItensCustas)
        {
            _repositorioItensCustas = repositorioItensCustas;
        }

        public List<ItensCustas> ObterItensCustasPorIdAto(int idAto)
        {
           return _repositorioItensCustas.ObterItensCustasPorIdAto(idAto);
        }


        public List<ItensCustas> ObterItensCustasPorIdProcuracao(int idProcuracao)
        {
            return _repositorioItensCustas.ObterItensCustasPorIdProcuracao(idProcuracao);
        }


        public List<ItensCustas> ObterItensCustasPorIdTestamento(int idTestamento)
        {
            return _repositorioItensCustas.ObterItensCustasPorIdTestamento(idTestamento);
        }
    }
}
