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
    public class AppServicoNaturezas: AppServicoBase<Naturezas>, IAppServicoNaturezas
    {
        private readonly IServicoNaturezas _servicoNaturezas;

        public AppServicoNaturezas(IServicoNaturezas servicoNaturezas)
            :base(servicoNaturezas)
        {
            _servicoNaturezas = servicoNaturezas;
        }
    }
}
