using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Servicos
{
    public class ServicoServentia: ServicoBase<Serventia>, IServicoServentia
    {
        private readonly IRepositorioServentia _repositorioServentia;

        public ServicoServentia(IRepositorioServentia repositorioServentia)
            : base(repositorioServentia)
        {
            _repositorioServentia = repositorioServentia;
        }
    }
}
