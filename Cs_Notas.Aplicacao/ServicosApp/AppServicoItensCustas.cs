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
    public class AppServicoItensCustas: AppServicoBase<ItensCustas>, IAppServicoItensCustas
    {

        private readonly IServicoItensCustas _servicoItensCustas;

        public AppServicoItensCustas(IServicoItensCustas servicoItensCustas)
            :base(servicoItensCustas)
        {
            _servicoItensCustas = servicoItensCustas;
        }


        public List<ItensCustas> ObterItensCustasPorIdAto(int idAto)
        {
            return _servicoItensCustas.ObterItensCustasPorIdAto(idAto);
        }


        public List<ItensCustas> ObterItensCustasPorIdProcuracao(int idProcuracao)
        {
            return _servicoItensCustas.ObterItensCustasPorIdProcuracao(idProcuracao);
        }


        public List<ItensCustas> ObterItensCustasPorIdTestamento(int idTestamento)
        {
            return _servicoItensCustas.ObterItensCustasPorIdTestamento(idTestamento);
        }
    }
}
