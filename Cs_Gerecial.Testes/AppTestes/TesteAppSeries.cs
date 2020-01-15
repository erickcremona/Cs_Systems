using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cs_Gerecial.Testes.AppTestes
{
    public class TesteAppSeries
    {
        [Fact]
        public void AppSeries_ConsultarPorIdCompraSelo_True()
        {
            //Arrange
            var servico = new Mock<IServicoSeries>();

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

            servico.Setup(p => p.ConsultarPorIdCompraSelo(50)).Returns(listaSeries.Where(p => p.IdCompra == 50));

            var appServicoSeries = new AppServicoSeries(servico.Object);

            //Act
            var retorno = appServicoSeries.ConsultarPorIdCompraSelo(50);

            //Assert
            Assert.True(retorno.FirstOrDefault().Quantidade == 20);
        }
    }
}
