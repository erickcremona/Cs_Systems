using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioCompraSelo : RepositorioBase<CompraSelo>, IRepositorioCompraSelo
    {
        public IEnumerable<CompraSelo> ConsultaPorIdPedido(int idPedido)
        {
            return Db.CompraSelo.Where(p => p.PedidoId == idPedido);
        }
    }
}
