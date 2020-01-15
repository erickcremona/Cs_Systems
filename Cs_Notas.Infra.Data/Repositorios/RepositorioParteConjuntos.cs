using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioParteConjuntos: RepositorioBase<ParteConjuntos>,  IRepositorioParteConjuntos
    {
        public List<ParteConjuntos> ListarPorIdAto(int idAto)
        {
            return Db.ParteConjuntos.Where(p => p.IdEscritura == idAto).OrderBy(p => p.ParteConjuntosId).ToList();
        }


        public List<ParteConjuntos> ListarPorIdNome(int idNome)
        {
            return Db.ParteConjuntos.Where(p => p.IdNome == idNome).ToList();
        }


        public List<ParteConjuntos> ObterNomesPorIdProcuracao(int IdProcuracao)
        {
            return Db.ParteConjuntos.Where(p => p.IdProcuracao == IdProcuracao).OrderBy(p => p.ParteConjuntosId).ToList();
        }
    }
}
