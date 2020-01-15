using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Servicos
{
    public class ServicoUsuario : ServicoBase<Usuario>, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
            : base(repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return _repositorioUsuario.BuscarPorNome(nome);
        }

        public Usuario VerificarUsuarioSenha(Usuario usuario, string senha)
        {
            return _repositorioUsuario.VerificarUsuarioSenha(usuario, senha);
        }

        public string CriptogravarSenha(string senha)
        {
            return _repositorioUsuario.CriptogravarSenha(senha);
        }

        public string DecriptogravarSenha(string senha)
        {
            return _repositorioUsuario.DecriptogravarSenha(senha);
        }
    }
}
