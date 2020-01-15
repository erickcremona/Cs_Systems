using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Servicos
{
    public class ServicoAtribuicoes: ServicoBase<Atribuicoes>, IServicoAtribuicoes
    {

        private readonly IRepositorioAtribuicoes _repositorioAtribuicoes;
        public ServicoAtribuicoes(IRepositorioAtribuicoes repositorioAtribuicoes)
            :base(repositorioAtribuicoes)
        {
            _repositorioAtribuicoes = repositorioAtribuicoes;
        }
    }
}
