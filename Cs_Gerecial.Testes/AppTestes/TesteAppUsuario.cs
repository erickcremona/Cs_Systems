using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Cs_Gerencial.Dominio.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Cs_Gerencial.Aplicacao.ServicosApp;

namespace Cs_Gerecial.Testes.AppTestes
{
    public class TesteAppUsuario
    {
        [Fact]
        public void AppUsuario_BuscarPorNome_True()
        {

            // Arrange
            var servicoUsuaro = new Mock<IServicoUsuario>();

            var nome = "Erick";

            var numero = 6;

            var usu = new List<Usuario>();

            var usuario = new Usuario();

            for (int i = 0; i < 10; i++)
            {
                usuario = new Usuario()
                {
                    UsuarioId = i,
                    NomeUsuario = nome + i,
                    Senha = "123"
                };

                usu.Add(usuario);
            }
            var nomeNumero = nome + numero;

            servicoUsuaro.Setup(r => r.BuscarPorNome(nomeNumero)).Returns(usu.Where(p => p.NomeUsuario == nomeNumero));
            var appUsuario = new AppServicoUsuario(servicoUsuaro.Object);

            // Act
            var retorno = appUsuario.BuscarPorNome(nomeNumero).ToList();

            // Assert
            Assert.True(retorno.FirstOrDefault().NomeUsuario == nomeNumero);
        }

        [Fact]
        public void AppUsuario_VerificarUsuarioSenha_True()
        {

            // Arrange
            var servicoUsuaro = new Mock<IServicoUsuario>();

            var nome = "Erick";

            var senha = "123";

            var numero = 2;

            var usu = new List<Usuario>();

            var usuario = new Usuario();

            var usuarioRetorno = new Usuario();

            for (int i = 0; i < 10; i++)
            {
                usuario = new Usuario()
                {
                    UsuarioId = i,
                    NomeUsuario = nome + i,
                    Senha = senha + i
                };

                usu.Add(usuario);

                if (i == numero)
                    usuarioRetorno = usuario;

            }

            var senhaSenha = senha + numero;

            servicoUsuaro.Setup(r => r.VerificarUsuarioSenha(usu[numero], senhaSenha)).Returns(usuarioRetorno);

            var servicoUsuario = new AppServicoUsuario(servicoUsuaro.Object);

            // Act
            var retorno = servicoUsuario.VerificarUsuarioSenha(usu[numero], senhaSenha);

            // Assert
            Assert.True(retorno.Senha == senhaSenha);
        }

        [Fact]
        public void AppUsuario_CriptogravarSenha_True()
        {
            // Arrange
            var servicoUsuaro = new Mock<IServicoUsuario>();

            var nome = "Erick";

            var senha = "123";

            var numero = 2;

            var usu = new List<Usuario>();

            var usuario = new Usuario();

            var usuarioRetorno = new Usuario();

            for (int i = 0; i < 10; i++)
            {
                usuario = new Usuario()
                {
                    UsuarioId = i,
                    NomeUsuario = nome + i,
                    Senha = senha + i
                };

                usu.Add(usuario);

                if (i == numero)
                    usuarioRetorno = usuario;

            }

            var senhaSenha = senha + numero;

            servicoUsuaro.Setup(r => r.CriptogravarSenha(usuarioRetorno.Senha)).Returns(senhaSenha);

            var servicoUsuario = new AppServicoUsuario(servicoUsuaro.Object);

            // Act

            var retorno = servicoUsuario.CriptogravarSenha(senhaSenha);

            // Assert
            Assert.True(retorno == senhaSenha);
        }

        [Fact]
        public void AppUsuario_DecriptogravarSenha_True()
        {
            // Arrange
            var servicoUsuaro = new Mock<IServicoUsuario>();

            var nome = "Erick";

            var senha = "123";

            var numero = 2;

            var usu = new List<Usuario>();

            var usuario = new Usuario();

            var usuarioRetorno = new Usuario();

            for (int i = 0; i < 10; i++)
            {
                usuario = new Usuario()
                {
                    UsuarioId = i,
                    NomeUsuario = nome + i,
                    Senha = senha + i
                };

                usu.Add(usuario);

                if (i == numero)
                    usuarioRetorno = usuario;

            }

            var senhaSenha = senha + numero;

            servicoUsuaro.Setup(r => r.DecriptogravarSenha(usuarioRetorno.Senha)).Returns(senhaSenha);

            var servicoUsuario = new AppServicoUsuario(servicoUsuaro.Object);

            // Act

            var retorno = servicoUsuario.DecriptogravarSenha(senhaSenha);

            // Assert
            Assert.True(retorno == senhaSenha);
        }

    }
}
