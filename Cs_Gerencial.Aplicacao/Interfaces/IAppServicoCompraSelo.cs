using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.Interfaces
{
    public interface IAppServicoCompraSelo : IAppServicoBase<CompraSelo>
    {
        CompraSelo LerArquivoCompraSelo(string caminho);

        IEnumerable<CompraSelo> ConsultaPorIdPedido(int idPedido);
    }
}
