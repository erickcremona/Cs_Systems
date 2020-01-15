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
    public class ServicoProcuracaoEscritura: ServicoBase<ProcuracaoEscritura>, IServicoProcuracaoEscritura
    {
        private readonly IRepositorioProcuracaoEscritura _repositorioProcuracaoEscritura;

        public ServicoProcuracaoEscritura(IRepositorioProcuracaoEscritura repositorioProcuracaoEscritura)
            : base(repositorioProcuracaoEscritura)
        {
            _repositorioProcuracaoEscritura = repositorioProcuracaoEscritura;
        }

        public List<ProcuracaoEscritura> ObterProcuracoesPorIdAto(int idAto)
        {
            return _repositorioProcuracaoEscritura.ObterProcuracoesPorIdAto(idAto);
        }
    }
}
