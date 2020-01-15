using CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cs_Gerecial.Testes.CrossCutting
{
    public class TesteClassCriptografia
    {
        [Fact]
        public void ClassCriptografia_Encrypt_True()
        {
            // Arrange
            string senha = "123";

            // Act
            string encriptada = ClassCriptografia.Encrypt(senha);

            // Assert
            Assert.True(encriptada == "T6q6CvbJHdwV2O7C4cLyvQ==");

        }

        [Fact]
        public void ClassCriptografia_Encrypt_False()
        {
            // Arrange
            string senha = "123";

            // Act
            string encriptada = ClassCriptografia.Encrypt(senha);

            // Assert
            Assert.False(encriptada == "T6q6CvbJHdwV2O7C4cLyvQ=");

        }

        [Fact]
        public void ClassCriptografia_Decrypt_True()
        {
            // Arrange
            string senha = "T6q6CvbJHdwV2O7C4cLyvQ==";

            // Act
            string decriptada = ClassCriptografia.Decrypt(senha);

            // Assert
            Assert.True(decriptada == "123");

        }

        [Fact]
        public void ClassCriptografia_Decrypt_False()
        {
            // Arrange
            string senha = "T6q6CvbJHdwV2O7C4cLyvQ==";

            // Act
            string decriptada = ClassCriptografia.Decrypt(senha);

            // Assert
            Assert.False(decriptada == "1234");

        }
    }
}
