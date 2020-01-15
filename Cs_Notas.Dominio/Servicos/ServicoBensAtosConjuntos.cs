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
    public class ServicoBensAtosConjuntos: ServicoBase<BensAtosConjuntos>, IServicoBensAtosConjuntos
    {
        private readonly IRepositorioBensAtosConjuntos _repositorioBensAtosConjuntos;

        public ServicoBensAtosConjuntos(IRepositorioBensAtosConjuntos repositorioBensAtosConjuntos)
            : base(repositorioBensAtosConjuntos)
        {
            _repositorioBensAtosConjuntos = repositorioBensAtosConjuntos;
        }



        public List<BensAtosConjuntos> ObterBensAtoConjuntosPorIdAto(int idAto)
        {
            return _repositorioBensAtosConjuntos.ObterBensAtoConjuntosPorIdAto(idAto);
        }
    }
}
