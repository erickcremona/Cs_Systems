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
    public class AppServicoBensAtosConjuntos: AppServicoBase<BensAtosConjuntos>, IAppServicoBensAtosConjuntos
    {
        private readonly IServicoBensAtosConjuntos _servicoBensAtosConjuntos;

        public AppServicoBensAtosConjuntos(IServicoBensAtosConjuntos servicoBensAtosConjuntos)
            :base(servicoBensAtosConjuntos)
        {
            _servicoBensAtosConjuntos = servicoBensAtosConjuntos;
        }

        public List<BensAtosConjuntos> ObterBensAtoConjuntosPorIdAto(int idAto)
        {
            return _servicoBensAtosConjuntos.ObterBensAtoConjuntosPorIdAto(idAto);
        }
    }
}
