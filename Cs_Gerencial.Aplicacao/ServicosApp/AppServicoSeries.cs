using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.ServicosApp
{
    public class AppServicoSeries: AppServicoBase<Series>, IAppServicoSeries
    {
        private readonly IServicoSeries _servicoSeries;

        public AppServicoSeries(IServicoSeries servicoSeries)
            : base(servicoSeries)
        {
            _servicoSeries = servicoSeries;
        }

        public IEnumerable<Series> ConsultarPorIdCompraSelo(int idCompraSelo)
        {
            return _servicoSeries.ConsultarPorIdCompraSelo(idCompraSelo);
        }
    }
}
