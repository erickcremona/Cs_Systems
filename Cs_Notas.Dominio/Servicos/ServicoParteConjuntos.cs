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
    public class ServicoParteConjuntos: ServicoBase<ParteConjuntos>, IServicoParteConjuntos
    {
        private readonly IRepositorioParteConjuntos _repositorioParteConjuntos;
        public ServicoParteConjuntos(IRepositorioParteConjuntos repositorioParteConjuntos)
            :base(repositorioParteConjuntos)
        {
            _repositorioParteConjuntos = repositorioParteConjuntos;
        }

        public List<ParteConjuntos> ListarPorIdAto(int idAto)
        {
            return _repositorioParteConjuntos.ListarPorIdAto(idAto);
        }


        public List<ParteConjuntos> ListarPorIdNome(int idNome)
        {
            return _repositorioParteConjuntos.ListarPorIdNome(idNome);
        }


        public List<ParteConjuntos> ObterNomesPorIdProcuracao(int IdProcuracao)
        {
            return _repositorioParteConjuntos.ObterNomesPorIdProcuracao(IdProcuracao);
        }
    }
}
