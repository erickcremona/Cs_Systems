using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cs_Gerencial.Dominio.Servicos
{
    public class ServicoCompraSelo: ServicoBase<CompraSelo>, IServicoCompraSelo
    {
        private readonly IRepositorioCompraSelo _repositorioCompraSelo;

        public ServicoCompraSelo(IRepositorioCompraSelo repositorioCompraSelo)
            : base(repositorioCompraSelo)
        {
            _repositorioCompraSelo = repositorioCompraSelo;
        }

        public CompraSelo LerArquivoCompraSelo(string caminho)
        {
            XElement xml = XElement.Load(caminho);
            CompraSelo arquivo = null;
            foreach (XElement x in xml.Elements())
            {
                arquivo = new CompraSelo()
                {
                    CompraSeloId = int.Parse(x.Attribute("id").Value),
                    NomeSolicitante = x.Attribute("SolicitanteNome").Value,
                    Quantidade = int.Parse(x.Attribute("Quantidade").Value),
                    DataGeracao = DateTime.Parse(x.Attribute("DataGeracao").Value),
                    CpfSolicitante = x.Attribute("SolicitanteCpf").Value,
                    DataPedido = DateTime.Parse(x.Attribute("DataPedido").Value)
                    
                };

            }

            return arquivo;
        }


        public IEnumerable<CompraSelo> ConsultaPorIdPedido(int idPedido)
        {
            return _repositorioCompraSelo.ConsultaPorIdPedido(idPedido);
        }
    }
}
