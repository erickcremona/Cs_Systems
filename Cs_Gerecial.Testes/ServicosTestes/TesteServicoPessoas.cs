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
    public class TesteServicoPessoas
    {
        [Fact]
        public void ServicoPessoas_ObterListaOrgaoEmissor_True()
        {
            //Arrange
            var repositorio = new Mock<IRepositorioPessoas>();

            var listaPessoas = new List<Pessoas>();

            var pessoa = new Pessoas();

            var listaOrgaos = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                    pessoa = new Pessoas()
                    {
                        OrgaoRG = "IFP"
                    };
                else
                    pessoa = new Pessoas()
                    {
                        OrgaoRG = "DETRAN"
                    };

                listaPessoas.Add(pessoa);
            }

            listaOrgaos = listaPessoas.Select(p => p.OrgaoRG).Distinct().ToList();

            repositorio.Setup(p => p.ObterListaOrgaoEmissor()).Returns(listaOrgaos);

            var pessoaServico = new ServicoPessoas(repositorio.Object);

            //Act
            var retorno = pessoaServico.ObterListaOrgaoEmissor();

            //Assert
            Assert.True(retorno.Count == 2);
        }

        [Fact]
        public void ServicoPessoas_ObterListaProfissao_True()
        {
            //Arrange
            var repositorio = new Mock<IRepositorioPessoas>();

            var listaPessoas = new List<Pessoas>();

            var pessoa = new Pessoas();

            var listaProfissao = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                    pessoa = new Pessoas()
                    {
                        Profissao = "MILITAR"
                    };
                else
                    pessoa = new Pessoas()
                    {
                        Profissao = "BANCARIO"
                    };

                listaPessoas.Add(pessoa);
            }

            listaProfissao = listaPessoas.Select(p => p.Profissao).Distinct().ToList();

            repositorio.Setup(p => p.ObterListaProfissao()).Returns(listaProfissao);

            var pessoaServico = new ServicoPessoas(repositorio.Object);

            //Act
            var retorno = pessoaServico.ObterListaProfissao();

            //Assert
            Assert.True(retorno.Count == 2);
        }
    }
}
