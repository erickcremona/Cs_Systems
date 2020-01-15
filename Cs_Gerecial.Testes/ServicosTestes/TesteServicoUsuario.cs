using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces;
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
    public class TesteServicoUsuario
    {
        [Fact]
        public void ServicoUsuario_ObterUsuarioPorNome_True()
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
                    NomeUsuario = nome + i,
                    Senha = "123"
                };

                usu.Add(usuario);
            }

            var nomeNumero = nome + numero;

            repositorio.Setup(r => r.BuscarPorNome(nomeNumero)).Returns(usu.Where(p => p.NomeUsuario == nomeNumero));
            var servicoUsuario = new ServicoUsuario(repositorio.Object);

            // Act
            var retorno = servicoUsuario.BuscarPorNome(nomeNumero);

            // Assert
            Assert.True(retorno.FirstOrDefault().NomeUsuario == nomeNumero);

        }

        [Fact]
        public void ServicoUsuario_VerificarUsuarioSenha_True()
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
                    NomeUsuario = nome + i,
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
        public void ServicoUsuario_CriptogravarSenha_True()
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
                    NomeUsuario = nome + i,
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
        public void ServicoUsuario_DecriptogravarSenha_True()
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
                    NomeUsuario = nome + i,
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
