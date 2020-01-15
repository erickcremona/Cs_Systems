using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Aplicacao.ServicosApp
{
    public class AppServicoUsuario: AppServicoBase<Usuario>, IAppServicoUsuario
    {
        private readonly IServicoUsuario _servicoUsuario;

        public AppServicoUsuario(IServicoUsuario servicoUsuario)
            :base(servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return _servicoUsuario.BuscarPorNome(nome);
        }

        public Usuario VerificarUsuarioSenha(Usuario usuario, string senha)
        {
            return _servicoUsuario.VerificarUsuarioSenha(usuario, senha);
        }

        public string CriptogravarSenha(string senha)
        {
            return _servicoUsuario.CriptogravarSenha(senha);
        }

        public string DecriptogravarSenha(string senha)
        {
            return _servicoUsuario.DecriptogravarSenha(senha);
        }
    }
}
