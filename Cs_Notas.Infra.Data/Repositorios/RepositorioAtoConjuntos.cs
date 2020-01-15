using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioAtoConjuntos: RepositorioBase<AtoConjuntos>, IRepositorioAtoConjuntos
    {

        public List<AtoConjuntos> ObterAtosConjuntosPorIdAto(int idAto)
        {
            return Db.AtoConjuntos.Where(p => p.IdEscritura == idAto).ToList();
        }


        public List<AtoConjuntos> ObterAtosConjuntosPorIdProcuracao(int idProcurcacao)
        {
            return Db.AtoConjuntos.Where(p => p.IdProcuracao == idProcurcacao).ToList();
        }
    }
}
