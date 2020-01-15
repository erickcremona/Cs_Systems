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
    public class AppServicoAtoConjuntos: AppServicoBase<AtoConjuntos>, IAppServicoAtoConjuntos
    {
        private readonly IServicoAtoConjuntos _servicoConjuntos;
        public AppServicoAtoConjuntos(IServicoAtoConjuntos servicoConjuntos)
            :base(servicoConjuntos)
        {
            _servicoConjuntos = servicoConjuntos;
        }

        public List<AtoConjuntos> ObterAtosConjuntosPorIdAto(int idAto)
        {
            return _servicoConjuntos.ObterAtosConjuntosPorIdAto(idAto);
        }


        public List<AtoConjuntos> ObterAtosConjuntosPorIdProcuracao(int idProcurcacao)
        {
            return _servicoConjuntos.ObterAtosConjuntosPorIdProcuracao(idProcurcacao);
        }
    }
}
