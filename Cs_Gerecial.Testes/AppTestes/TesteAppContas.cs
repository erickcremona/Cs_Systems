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
    public class TesteAppContas
    {
        [Fact]
        public void AppContas_ConsultarPorPeriodo_True()
        {
            // Arrange
            var servicoContas = new Mock<IServicoContas>();


            var listaContas = new List<Contas>();

            var contas = new Contas();

            for (int i = 0; i < 100; i++)
            {
                if (i < 50)
                {
                    contas = new Contas()
                    {
                        ContaId = i,
                        DataMovimento = Convert.ToDateTime("10/05/2016"),
                        Descricao = "TESTE " + 1
                    };
                }
                else
                {
                    contas = new Contas()
                    {
                        ContaId = i,
                        DataMovimento = Convert.ToDateTime("10/04/2016"),
                        Descricao = "TESTE " + 1
                    };

                }

                listaContas.Add(contas);
            }

            servicoContas.Setup(r => r.ConsultaPorPeriodo(Convert.ToDateTime("10/05/2016"), Convert.ToDateTime("10/05/2016"))).Returns(listaContas.Where(p => p.DataMovimento >= Convert.ToDateTime("10/05/2016") && p.DataMovimento <= Convert.ToDateTime("10/05/2016")));
            var appContas = new AppServicoContas(servicoContas.Object);

            // Act
            var retorno = appContas.ConsultaPorPeriodo(Convert.ToDateTime("10/05/2016"), Convert.ToDateTime("10/05/2016")).ToList();

            // Assert
            Assert.True(retorno.Count  == 50);
        }
    }
}
