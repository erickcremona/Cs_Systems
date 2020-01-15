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
    public class ServicoAtoConjuntos: ServicoBase<AtoConjuntos>, IServicoAtoConjuntos
    {
        private readonly IRepositorioAtoConjuntos _repositorioConjuntos;
        public ServicoAtoConjuntos(IRepositorioAtoConjuntos repositorioConjuntos)
            :base(repositorioConjuntos)
        {
            _repositorioConjuntos = repositorioConjuntos;
        }

        public List<AtoConjuntos> ObterAtosConjuntosPorIdAto(int idAto)
        {
            return _repositorioConjuntos.ObterAtosConjuntosPorIdAto(idAto);
        }


        public List<AtoConjuntos> ObterAtosConjuntosPorIdProcuracao(int idProcurcacao)
        {
            return _repositorioConjuntos.ObterAtosConjuntosPorIdProcuracao(idProcurcacao);
        }
    }
}
