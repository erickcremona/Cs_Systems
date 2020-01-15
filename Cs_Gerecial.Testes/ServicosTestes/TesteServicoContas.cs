using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
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
    public class TesteServicoContas
    {
        [Fact]
        public void ContasServico_ConsultarPorPeriodo_True()
        {

            // Arrange
            var repositorioContas = new Mock<IRepositorioContas>();


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

            repositorioContas.Setup(r => r.ConsultaPorPeriodo(Convert.ToDateTime("10/05/2016"), Convert.ToDateTime("10/05/2016"))).Returns(listaContas.Where(p => p.DataMovimento >= Convert.ToDateTime("10/05/2016") && p.DataMovimento <= Convert.ToDateTime("10/05/2016")));
            var appContas = new ServicoContas(repositorioContas.Object);

            // Act
            var retorno = appContas.ConsultaPorPeriodo(Convert.ToDateTime("10/05/2016"), Convert.ToDateTime("10/05/2016")).ToList();

            // Assert
            Assert.True(retorno.Count == 50);
        }
    }
}
