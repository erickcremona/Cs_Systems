using CrossCutting;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return Db.Usuario.Where(p => p.NomeUsuario == nome).ToList();
        }


        public Usuario VerificarUsuarioSenha(Usuario usuario, string senha)
        {
            var _usuario = new Usuario();


            if (usuario.Senha == senha)
                _usuario = usuario;

            return _usuario;
        }


        
        public string CriptogravarSenha(string senha)
        {
            return ClassCriptografia.Encrypt(senha);
        }

        public string DecriptogravarSenha(string senha)
        {
            return ClassCriptografia.Decrypt(senha);
        }
    }
}
