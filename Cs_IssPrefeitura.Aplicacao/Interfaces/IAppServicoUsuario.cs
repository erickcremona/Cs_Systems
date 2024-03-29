﻿using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Aplicacao.Interfaces
{
    public interface IAppServicoUsuario: IAppServicoBase<Usuario>
    {
        IEnumerable<Usuario> BuscarPorNome(string nome);

        Usuario VerificarUsuarioSenha(Usuario usuario, string senha);

        string CriptogravarSenha(string senha);

        string DecriptogravarSenha(string senha);
    }
}
