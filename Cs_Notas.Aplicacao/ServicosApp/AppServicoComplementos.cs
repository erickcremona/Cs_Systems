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
    public class AppServicoComplementos: AppServicoBase<Complementos>, IAppServicoComplementos
    {
        private readonly IServicoComplementos _servicoComplementos;

        public AppServicoComplementos(IServicoComplementos servicoComplementos)
            : base(servicoComplementos)
        {
            _servicoComplementos = servicoComplementos;
        }
        public List<Complementos> ObterComplementosPorIdAto(int idAto)
        {
           return _servicoComplementos.ObterComplementosPorIdAto(idAto);
        }
    }
}
