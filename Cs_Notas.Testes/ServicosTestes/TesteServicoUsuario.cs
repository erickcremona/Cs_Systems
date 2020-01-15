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
    public class TesteServicoUsuario
    {
        [Fact]
        public void UsuarioServico_ObterUsuarioPorNome_True()
        {

            // Arrange
            var repositorio = new Mock<IRepositorioUsuario>();

            var nome = "Erick";

            var numero = 6;

            var usu = new List<Usuario>();

            var usuario = new Usuario();

            for (int i = 0; i < 10; i++)
            {
                usuario = new Usuario()
                {
                    UsuarioId = i,
                    Nome = nome + i,
                    Senha = "123"
                };

                usu.Add(usuario);
            }

            var nomeNumero = nome + numero;

            repositorio.Setup(r => r.BuscarPorNome(nomeNumero)).Returns(usu.Where(p => p.Nome == nomeNumero));
            var servicoUsuario = new ServicoUsuario(repositorio.Object);

            // Act
            var retorno = servicoUsuario.BuscarPorNome(nomeNumero);

            // Assert
            Assert.True(retorno.FirstOrDefault().Nome == nomeNumero);

        }

         [Fact]
        public void UsuarioServico_VerificarUsuarioSenha_True()
        {

            // Arrange
            var repositorio = new Mock<IRepositorioUsuario>();

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
                    Nome = nome + i,
                    Senha = senha + i
                };

                usu.Add(usuario);

                if (i == numero)
                    usuarioRetorno = usuario;

            }

            var senhaSenha = senha + numero;

            repositorio.Setup(r => r.VerificarUsuarioSenha(usu[numero], senhaSenha)).Returns(usuarioRetorno);

            var servicoUsuario = new ServicoUsuario(repositorio.Object);

            // Act
            var retorno = servicoUsuario.VerificarUsuarioSenha(usu[numero], senhaSenha);

            // Assert
            Assert.True(retorno.Senha == senhaSenha);
        }

         [Fact]
         public void UsuarioServico_CriptogravarSenha_True()
         {
             // Arrange
             var repositorio = new Mock<IRepositorioUsuario>();

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
                     Nome = nome + i,
                     Senha = senha + i
                 };

                 usu.Add(usuario);

                 if (i == numero)
                     usuarioRetorno = usuario;

             }

             var senhaSenha = senha + numero;

             repositorio.Setup(r => r.CriptogravarSenha(usuarioRetorno.Senha)).Returns(senhaSenha);

             var servicoUsuario = new ServicoUsuario(repositorio.Object);

             // Act

             var retorno = servicoUsuario.CriptogravarSenha(senhaSenha);

             // Assert
             Assert.True(retorno == senhaSenha);
         }


         [Fact]
         public void UsuarioServico_DecriptogravarSenha_True()
         {
             // Arrange
             var repositorio = new Mock<IRepositorioUsuario>();

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
                     Nome = nome + i,
                     Senha = senha + i
                 };

                 usu.Add(usuario);

                 if (i == numero)
                     usuarioRetorno = usuario;

             }

             var senhaSenha = senha + numero;

             repositorio.Setup(r => r.DecriptogravarSenha(usuarioRetorno.Senha)).Returns(senhaSenha);

             var servicoUsuario = new ServicoUsuario(repositorio.Object);

             // Act

             var retorno = servicoUsuario.DecriptogravarSenha(senhaSenha);

             // Assert
             Assert.True(retorno == senhaSenha);
         }
    }
}
