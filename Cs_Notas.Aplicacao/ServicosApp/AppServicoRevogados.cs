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
    public class AppServicoRevogados: AppServicoBase<Revogados>, IAppServicoRevogados
    {
        private readonly IServicoRevogados _IServicoRevogados;

        public AppServicoRevogados(IServicoRevogados IServicoRevogados)
            : base(IServicoRevogados)
        {
            _IServicoRevogados = IServicoRevogados;
        }

        public List<Revogados> ObterRevogadosPorIdTestamento(int idTestamento)
        {
            return _IServicoRevogados.ObterRevogadosPorIdTestamento(idTestamento);
        }
    }
}
