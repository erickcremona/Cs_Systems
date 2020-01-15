using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.ServicosApp
{
    public class AppServicoCompraSelo: AppServicoBase<CompraSelo>, IAppServicoCompraSelo
    {
        private readonly IServicoCompraSelo _servicoCompraSelo;

        public AppServicoCompraSelo(IServicoCompraSelo servicoCompraSelo)
            : base(servicoCompraSelo)
        {
            _servicoCompraSelo = servicoCompraSelo;
        }

        public CompraSelo LerArquivoCompraSelo(string caminho)
        {
            return _servicoCompraSelo.LerArquivoCompraSelo(caminho);
        }

        public IEnumerable<CompraSelo> ConsultaPorIdPedido(int idPedido)
        {
            return _servicoCompraSelo.ConsultaPorIdPedido(idPedido);
        }

    }
}
