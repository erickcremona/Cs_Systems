using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using Cs_Notas.Dominio.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cs_Notas.Testes.ServicosTestes
{
    public class TesteServicoNomes
    {
        [Fact]
        public void ServicoNomes_ObterNomesPorIdAto_True()
        {

            //Arrange
            var repositorio = new Mock<IRepositorioNomes>();

            var nome = new Nomes();

            var listaNomes = new List<Nomes>();

            for (int i = 0; i < 100; i++)
            {
                if(i >= 50 && i <= 54)
                {
                nome = new Nomes()
                {
                    IdEscritura = 12345,
                    Nome = "ERICK MARCEL "+ i
                };
                }
                else{
                    nome = new Nomes()
                {
                    IdEscritura = i,
                    Nome = "ERICK MARCEL "+ i
                };
                }
                listaNomes.Add(nome);
            }

            repositorio.Setup(p => p.ObterNomesPorIdAto(12345)).Returns(listaNomes.Where(p => p.IdEscritura == 12345).ToList());
            var servicoNomes = new ServicoNomes(repositorio.Object);

            //Act
            var retorno = servicoNomes.ObterNomesPorIdAto(12345);

            //Assert
            Assert.True(retorno.Count == 5);

        }
    }
}
