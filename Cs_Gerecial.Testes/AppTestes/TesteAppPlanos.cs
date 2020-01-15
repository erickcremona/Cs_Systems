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
    public class TesteAppPlanos
    {
        [Fact]
        public void AppPlano_ConsultarPlanosPorDescricao_True()
        {
            // Arrange
            var servicoPlanos = new Mock<IServicoPlanos>();

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

            servicoPlanos.Setup(r => r.ConsultarPlanosPorDescricao(nomeNumero)).Returns(ListPlanos.Where(p => p.Descricao == nomeNumero));
            var appPlanos = new AppServicoPlanos(servicoPlanos.Object);

            // Act
            var retorno = appPlanos.ConsultarPlanosPorDescricao(nomeNumero).ToList();

            // Assert
            Assert.True(retorno.FirstOrDefault().Descricao == nomeNumero);
        }
    }
}
