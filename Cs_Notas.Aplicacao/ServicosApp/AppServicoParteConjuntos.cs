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
    public class AppServicoParteConjuntos: AppServicoBase<ParteConjuntos>, IAppServicoParteConjuntos
    {
        private readonly IServicoParteConjuntos _servicoParteConjuntos;
        public AppServicoParteConjuntos(IServicoParteConjuntos servicoParteConjuntos)
            :base(servicoParteConjuntos)
        {
            _servicoParteConjuntos = servicoParteConjuntos;
        }


        public List<ParteConjuntos> ListarPorIdAto(int idAto)
        {
            return _servicoParteConjuntos.ListarPorIdAto(idAto);
        }


        public List<ParteConjuntos> ListarPorIdNome(int idNome)
        {
            return _servicoParteConjuntos.ListarPorIdNome(idNome);
        }


        public List<ParteConjuntos> ObterNomesPorIdProcuracao(int IdProcuracao)
        {
            return _servicoParteConjuntos.ObterNomesPorIdProcuracao(IdProcuracao);
        }
    }
}
