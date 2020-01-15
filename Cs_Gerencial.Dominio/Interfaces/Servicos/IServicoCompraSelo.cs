using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces.Servicos
{
    public interface IServicoCompraSelo: IServicoBase<CompraSelo>
    {
        CompraSelo LerArquivoCompraSelo(string caminho);

        IEnumerable<CompraSelo> ConsultaPorIdPedido(int idPedido);
    }
}
