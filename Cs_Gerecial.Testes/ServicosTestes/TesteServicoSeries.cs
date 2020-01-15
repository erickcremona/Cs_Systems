using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
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
    public class TesteServicoSeries
    {
        [Fact]
        public void ServicoSeries_ConsultarPorIdCompraSelo_True()
        {
            //Arrange
            var repositorio = new Mock<IRepositorioSeries>();

            var listaSeries = new List<Series>();

            var serie = new Series();

            for (int i = 0; i < 100; i++)
            {
                serie = new Series()
                {
                    SerieId = i,
                    IdCompra = i,

                };

                if (i == 50)
                {
                    serie.Inicial = 10000;
                    serie.Final = 10020;
                    serie.Letra = "ABCD";
                    serie.Quantidade = 20;
                }
                listaSeries.Add(serie);
            }

            repositorio.Setup(p => p.ConsultarPorIdCompraSelo(50)).Returns(listaSeries.Where(p => p.IdCompra == 50));

            var servicoSeries = new ServicoSeries(repositorio.Object);

            //Act
            var retorno = servicoSeries.ConsultarPorIdCompraSelo(50);

            //Assert
            Assert.True(retorno.FirstOrDefault().Quantidade == 20);
        }
    }
}
