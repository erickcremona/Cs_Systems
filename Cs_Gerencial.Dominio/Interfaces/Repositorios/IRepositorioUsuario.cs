using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        IEnumerable<Usuario> BuscarPorNome(string nome);

        Usuario VerificarUsuarioSenha(Usuario usuario, string senha);

        string CriptogravarSenha(string senha);

        string DecriptogravarSenha(string senha);
    }
}
