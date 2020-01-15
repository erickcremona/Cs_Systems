using CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cs_Gerecial.Testes.CrossCutting
{
    public class TesteValidarCpfCnpj
    {
        [Fact]
        public bool ValidaCpfCnpj_ValidarCpf_True()
        {
            // Arrange

            string cpf = "091.256.007-02";

             //Act
             var  retorno = ValidaCpfCnpj.ValidaCPF(cpf);

            //Assert
            Assert.True(retorno == true);

            return retorno;
        }

        [Fact]
        public bool ValidaCpfCnpj_ValidarCpf_False()
        {
            // Arrange

            string cpf = "091.256.007-01";

            //Act
            var retorno = ValidaCpfCnpj.ValidaCPF(cpf);

            //Assert
            Assert.True(retorno == false);

            return retorno;
        }


        [Fact]
        public bool ValidaCpfCnpj_ValidarCnpj_True()
        {
            // Arrange

            string cnpj = "14.010.885/0001-14";

            //Act
            var retorno = ValidaCpfCnpj.ValidaCNPJ(cnpj);

            //Assert
            Assert.True(retorno == true);

            return retorno;
        }

        [Fact]
        public bool ValidaCpfCnpj_ValidarCnpj_False()
        {
            // Arrange

            string cnpj = "14.010.885/0001-10";

            //Act
            var retorno = ValidaCpfCnpj.ValidaCNPJ(cnpj);

            //Assert
            Assert.True(retorno == false);

            return retorno;
        }

        [Fact]
        public bool ValidaCpfCnpj_ValidarCep_False()
        {
            // Arrange

            string cep = "28970-00a";

            //Act
            var retorno = ValidaCpfCnpj.ValidaCep(cep);

            //Assert
            Assert.True(retorno == false);

            return retorno;
        }

        [Fact]
        public bool ValidaCpfCnpj_ValidarCep_True()
        {
            // Arrange

            string cep = "28970-000";

            //Act
            var retorno = ValidaCpfCnpj.ValidaCep(cep);

            //Assert
            Assert.True(retorno == true);

            return retorno;
        }

        [Fact]
        public bool ValidaCpfCnpj_ValidarEmail_False()
        {
            // Arrange

            string email = "erick.com";

            //Act
            var retorno = ValidaCpfCnpj.ValidaEmail(email);

            //Assert
            Assert.True(retorno == false);

            return retorno;
        }

        [Fact]
        public bool ValidaCpfCnpj_ValidarEmail_True()
        {
            // Arrange

            string email = "erick@erick.com";

            //Act
            var retorno = ValidaCpfCnpj.ValidaEmail(email);

            //Assert
            Assert.True(retorno == true);

            return retorno;
        }
    }
}
