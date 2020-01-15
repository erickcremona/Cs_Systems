using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Aplicacao.ServicosApp
{
    public class AppServicoConfiguracoes: AppServicoBase<Configuracoes>, IAppServicoConfiguracoes
    {
        private readonly IServicoConfiguracoes _ServicoConfiguracoes;
        public AppServicoConfiguracoes(IServicoConfiguracoes ServicoConfiguracoes)
            :base   (ServicoConfiguracoes)
        {
            _ServicoConfiguracoes = ServicoConfiguracoes;
        }
    }
}
