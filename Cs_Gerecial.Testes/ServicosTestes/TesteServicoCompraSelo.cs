using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Cs_Gerencial.Dominio.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cs_Gerecial.Testes.ServicosTestes
{
    public class TesteServicoCompraSelo
    {
        [Fact]
        public void ServicoCompraSelo_LerArquivoCompraSelo_True()
        {
            // Arrange
            var repositorioCompraSelo = new Mock<IServicoCompraSelo>();
            var compraSelo = new CompraSelo();

            var caminho = @"C:\Users\erick\Desktop\Cs_Sistemas\Cs_Gerecial.Testes\ArquivosTeste\ArquivoSelos04318121520160901.XML";

            var arquivo = new CompraSelo()
            {
                CompraSeloId = 40445,
                NomeSolicitante = "SILVIA CAMILE BECKER MATTOS DA SILVA",
                Quantidade = 240,
                DataGeracao = DateTime.Parse("31/08/2016 11:08:54"),
                CpfSolicitante = "05198286745",
                DataPedido = DateTime.Parse("31/08/2016 09:28:24")

            };

            repositorioCompraSelo.Setup(r => r.LerArquivoCompraSelo(caminho)).Returns(arquivo);


            var appCompraSelo = new AppServicoCompraSelo(repositorioCompraSelo.Object);

            // Act
            var retorno = appCompraSelo.LerArquivoCompraSelo(caminho);

            // Assert
            Assert.True(retorno.Quantidade == 240);

        }


        [Fact]
        public void ServicoCompraSelo_ConsultaPorIdPedido_True()
        {
            // Arrange
            var repositorioCompraSelo = new Mock<IRepositorioCompraSelo>();

            var compraSelo = new CompraSelo();

            var listCompraSelo = new List<CompraSelo>();

            int total = 0;

            for (int i = 0; i < 100; i++)
            {
                total = i / 2;


                if (total == 0)
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

            repositorioCompraSelo.Setup(p => p.ConsultaPorIdPedido(45)).Returns(listCompraSelo.Where(p => p.PedidoId == 45));

            var servicoCompraSelo = new ServicoCompraSelo(repositorioCompraSelo.Object);

            // Act
            var retorno = servicoCompraSelo.ConsultaPorIdPedido(45);


            // Assert
            Assert.True(retorno.Count() == 1);
        }
    }
}
