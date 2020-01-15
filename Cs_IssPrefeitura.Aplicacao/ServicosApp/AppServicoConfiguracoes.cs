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
    public class AppServicoConfiguracoes: AppServicoBase<Config>, IAppServicoConfiguracoes
    {
        private readonly IServicoConfiguracoes _servicoConfiguracoes;
        public AppServicoConfiguracoes(IServicoConfiguracoes servicoConfiguracoes)
           : base(servicoConfiguracoes)
        {
            _servicoConfiguracoes = servicoConfiguracoes;
        }
    }
}
