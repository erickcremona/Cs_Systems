using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Dominio.Interfaces.Repositorios;
using Cs_IssPrefeitura.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Servicos
{
    public class ServicoConfiguracoes: ServicoBase<Config>, IServicoConfiguracoes
    {
        private readonly IRepositorioConfiguracoes _repositorioConfiguracoes;
        public ServicoConfiguracoes(IRepositorioConfiguracoes repositorioConfiguracoes)
            :base(repositorioConfiguracoes)
        {
            _repositorioConfiguracoes = repositorioConfiguracoes;
        }
    }
}
