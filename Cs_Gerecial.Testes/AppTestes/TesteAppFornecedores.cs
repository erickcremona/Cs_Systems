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
    public class TesteAppFornecedores
    {
        [Fact]
        public void AppFornecedores_ConsultaPorRazaoSocial_True()
        {

            // Arrange
            var servicoFornecedores = new Mock<IServicoFornecedores>();


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

            servicoFornecedores.Setup(p => p.ConsultarPorRazaoSocial("Razão Social")).Returns(listaFornecedores.Where(p => p.RazaoSocial == "Razão Social"));

            var AppFornecedor = new AppServicoFornecedores(servicoFornecedores.Object);
            
            
            // Act
            var retorno = AppFornecedor.ConsultarPorRazaoSocial("Razão Social").ToList();

            
            // Assert
            Assert.True(retorno.Count == 50);

        }


        [Fact]
        public void AppFornecedores_ConsultaPorNomeFantasia_True()
        {

            // Arrange
            var servicoFornecedores = new Mock<IServicoFornecedores>();


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

            servicoFornecedores.Setup(p => p.ConsultarPorNomeFantasia("Nome Fantasia")).Returns(listaFornecedores.Where(p => p.NomeFantasia == "Nome Fantasia"));

            var AppFornecedor = new AppServicoFornecedores(servicoFornecedores.Object);


            // Act
            var retorno = AppFornecedor.ConsultarPorNomeFantasia("Nome Fantasia").ToList();


            // Assert
            Assert.True(retorno.Count == 50);

        }


        [Fact]
        public void AppFornecedores_ConsultaPorDocumento_True()
        {
            // Arrange
            var servicoFornecedores = new Mock<IServicoFornecedores>();

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

            servicoFornecedores.Setup(p => p.ConsultarPorDocumento("09125600702")).Returns(listaFornecedores.Where(p => p.Cnpj == "09125600702"));

            var AppFornecedor = new AppServicoFornecedores(servicoFornecedores.Object);


            // Act
            var retorno = AppFornecedor.ConsultarPorDocumento("09125600702").ToList();


            // Assert
            Assert.True(retorno.Count == 50);

        }


    }
}
