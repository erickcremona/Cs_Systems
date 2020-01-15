using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Servicos
{
    public class ServicoComplementos: ServicoBase<Complementos>, IServicoComplementos
    {
        private readonly IRepositorioComplementos _repositorioComplementos;

        public ServicoComplementos(IRepositorioComplementos repositorioComplementos)
            :base(repositorioComplementos)
        {
            _repositorioComplementos = repositorioComplementos;
        }

        public List<Complementos> ObterComplementosPorIdAto(int idAto)
        {
            return _repositorioComplementos.ObterComplementosPorIdAto(idAto);
        }
    }
}
