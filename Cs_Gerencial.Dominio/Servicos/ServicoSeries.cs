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
    public class ServicoSeries: ServicoBase<Series>, IServicoSeries
    {
        private readonly IRepositorioSeries _repositorioSeries;

        public ServicoSeries(IRepositorioSeries repositorioSeries)
            : base(repositorioSeries)
        {
            _repositorioSeries = repositorioSeries;
        }


        public IEnumerable<Series> ConsultarPorIdCompraSelo(int idCompraSelo)
        {
            return _repositorioSeries.ConsultarPorIdCompraSelo(idCompraSelo);
        }
    }
}
