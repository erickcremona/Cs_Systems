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
    public class TesteServicoPlanos
    {
        [Fact]
        public void ServicoPlano_ConsultarPlanosPorDescricao_True()
        {
            // Arrange
            var repositorioPlanos = new Mock<IRepositorioPlanos>();

            var nome = "Teste";

            var numero = 6;

            var ListPlanos = new List<Planos>();

            var planos = new Planos();

            for (int i = 0; i < 10; i++)
            {
                planos = new Planos()
                {
                    Descricao = "Teste" + i
                };

                ListPlanos.Add(planos);
            }
            var nomeNumero = nome + numero;

            repositorioPlanos.Setup(r => r.ConsultarPlanosPorDescricao(nomeNumero)).Returns(ListPlanos.Where(p => p.Descricao == nomeNumero));
            var servicoPlanos = new ServicoPlanos(repositorioPlanos.Object);

            // Act
            var retorno = servicoPlanos.ConsultarPlanosPorDescricao(nomeNumero).ToList();

            // Assert
            Assert.True(retorno.FirstOrDefault().Descricao == nomeNumero);
        }
    }
}
