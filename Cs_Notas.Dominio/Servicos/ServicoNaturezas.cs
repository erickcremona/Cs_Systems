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
    public class ServicoNaturezas: ServicoBase<Naturezas>, IServicoNaturezas
    {
        private readonly IRepositorioNaturezas _repositorioNaturezas;

        public ServicoNaturezas(IRepositorioNaturezas repositorioNaturezas)
            : base(repositorioNaturezas)
        {
            _repositorioNaturezas = repositorioNaturezas;
        }
    }
}
