using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Cs_Gerencial.Dominio.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Cs_Gerecial.Testes.AppTestes
{
    public class TesteAppCompraSelo
    {
        [Fact]
        public void AppCompraSelo_LerArquivoCompraSelo_True()
        {
            // Arrange
            var servicoCompraSelo = new Mock<IServicoCompraSelo>();
            var compraSelo = new CompraSelo();

            var caminho = @"C:\Users\Erick Marcel\Desktop\Cs_Gerencial\Cs_Gerecial.Testes\ArquivosTeste\ArquivoSelos04318121520160901.XML";

               var arquivo = new CompraSelo()
                {
                    CompraSeloId = 40445,
                    NomeSolicitante = "SILVIA CAMILE BECKER MATTOS DA SILVA",
                    Quantidade = 240,
                    DataGeracao = DateTime.Parse("31/08/2016 11:08:54"),
                    CpfSolicitante = "05198286745",
                    DataPedido = DateTime.Parse("31/08/2016 09:28:24")

                };
            
            servicoCompraSelo.Setup(r => r.LerArquivoCompraSelo(caminho)).Returns(arquivo);

            var appCompraSelo = new AppServicoCompraSelo(servicoCompraSelo.Object);

            // Act
            var retorno = appCompraSelo.LerArquivoCompraSelo(caminho);

            // Assert
            Assert.True(retorno.Quantidade == 240);

        }


        [Fact]
        public void AppCompraSelo_ConsultaPorIdPedido_True()
        {
            // Arrange
            var servicoCompraSelo = new Mock<IServicoCompraSelo>();

            var compraSelo = new CompraSelo();

            var listCompraSelo = new List<CompraSelo>();

            int total = 0;

            for (int i = 0; i < 100; i++)
            {
                total = i / 2;
                

                if(total == 0)
                {
                    compraSelo = new CompraSelo()
                    {
                        PedidoId = i,
                        CompraSeloId = 40445,
                        NomeSolicitante = "SILVIA CAMILE BECKER MATTOS DA SILVA",
                        Quantidade = 240,
                        DataGeracao = DateTime.Parse("31/08/2016 11:08:54"),
                        CpfSolicitante = "05198286745",
                        DataPedido = DateTime.Parse("31/08/2016 09:28:24")

                    };
                }
                else
                {
                    compraSelo = new CompraSelo()
                   {
                       PedidoId = i,
                       CompraSeloId = 40445,
                       NomeSolicitante = "SILVIA CAMILE BECKER MATTOS DA SILVA",
                       Quantidade = 240,
                       DataGeracao = DateTime.Parse("31/08/2016 11:08:54"),
                       CpfSolicitante = "05198286745",
                       DataPedido = DateTime.Parse("31/08/2016 09:28:24")
                   };
                }

                listCompraSelo.Add(compraSelo);
            }

            servicoCompraSelo.Setup(p => p.ConsultaPorIdPedido(45)).Returns(listCompraSelo.Where(p => p.PedidoId == 45));

            var appServicoCompraSelo = new AppServicoCompraSelo(servicoCompraSelo.Object);

            // Act
            var retorno = appServicoCompraSelo.ConsultaPorIdPedido(45);
            

            // Assert
            Assert.True(retorno.Count() == 1);
        }
    }
}
