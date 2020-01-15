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
    public class TesteServicoFornecedores
    {
        [Fact]
        public void ServicoFornecedores_ConsultaPorRazaoSocial_True()
        {

            // Arrange
            var repositorioFornecedores = new Mock<IRepositorioFornecedores>();

            var listaFornecedores = new List<Fornecedores>();

            var fornecedor = new Fornecedores();

            for (int i = 0; i < 100; i++)
            {
                if (i < 50)
                {
                    fornecedor = new Fornecedores()
                    {
                        FornecedorId = i,
                        RazaoSocial = "Razão Social",
                        NomeFantasia = "Nome Fantasia",
                        Cnpj = "09125600702"
                    };
                }
                else
                {
                    fornecedor = new Fornecedores()
                    {
                        FornecedorId = i,
                        RazaoSocial = "Razão Social " + i,
                        NomeFantasia = "Nome Fantasia" + i,
                        Cnpj = "28530921000185"
                    };

                }

                listaFornecedores.Add(fornecedor);
            }

            repositorioFornecedores.Setup(p => p.ConsultarPorRazaoSocial("Razão Social")).Returns(listaFornecedores.Where(p => p.RazaoSocial == "Razão Social"));

            var servicoFornecedor = new ServicoFornecedores(repositorioFornecedores.Object);


            // Act
            var retorno = servicoFornecedor.ConsultarPorRazaoSocial("Razão Social").ToList();


            // Assert
            Assert.True(retorno.Count == 50);

        }


        [Fact]
        public void ServicoFornecedores_ConsultaPorNomeFantasia_True()
        {

            // Arrange
            var repositorioFornecedores = new Mock<IRepositorioFornecedores>();


            var listaFornecedores = new List<Fornecedores>();

            var fornecedor = new Fornecedores();

            for (int i = 0; i < 100; i++)
            {
                if (i < 50)
                {
                    fornecedor = new Fornecedores()
                    {
                        FornecedorId = i,
                        RazaoSocial = "Razão Social",
                        NomeFantasia = "Nome Fantasia",
                        Cnpj = "09125600702"
                    };
                }
                else
                {
                    fornecedor = new Fornecedores()
                    {
                        FornecedorId = i,
                        RazaoSocial = "Razão Social " + i,
                        NomeFantasia = "Nome Fantasia" + i,
                        Cnpj = "28530921000185"
                    };

                }

                listaFornecedores.Add(fornecedor);
            }

            repositorioFornecedores.Setup(p => p.ConsultarPorNomeFantasia("Nome Fantasia")).Returns(listaFornecedores.Where(p => p.NomeFantasia == "Nome Fantasia"));

            var servicoFornecedor = new ServicoFornecedores(repositorioFornecedores.Object);


            // Act
            var retorno = servicoFornecedor.ConsultarPorNomeFantasia("Nome Fantasia").ToList();


            // Assert
            Assert.True(retorno.Count == 50);

        }


        [Fact]
        public void ServicoFornecedores_ConsultaPorDocumento_True()
        {
            // Arrange
            var repositorioFornecedores = new Mock<IRepositorioFornecedores>();

            var listaFornecedores = new List<Fornecedores>();

            var fornecedor = new Fornecedores();

            for (int i = 0; i < 100; i++)
            {
                if (i < 50)
                {
                    fornecedor = new Fornecedores()
                    {
                        FornecedorId = i,
                        RazaoSocial = "Razão Social",
                        NomeFantasia = "Nome Fantasia",
                        Cnpj = "09125600702"
                    };
                }
                else
                {
                    fornecedor = new Fornecedores()
                    {
                        FornecedorId = i,
                        RazaoSocial = "Razão Social " + i,
                        NomeFantasia = "Nome Fantasia" + i,
                        Cnpj = "28530921000185"
                    };

                }

                listaFornecedores.Add(fornecedor);
            }

            repositorioFornecedores.Setup(p => p.ConsultarPorDocumento("09125600702")).Returns(listaFornecedores.Where(p => p.Cnpj == "09125600702"));

            var servicoFornecedor = new ServicoFornecedores(repositorioFornecedores.Object);


            // Act
            var retorno = servicoFornecedor.ConsultarPorDocumento("09125600702").ToList();


            // Assert
            Assert.True(retorno.Count == 50);

        }
    }
}
