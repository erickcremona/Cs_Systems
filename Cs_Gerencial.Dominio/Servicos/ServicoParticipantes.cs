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
    public class ServicoParticipantes: ServicoBase<Participantes>, IServicoParticipantes
    {
        private readonly IRepositorioParticipantes _repositorioParticipantes;

        public ServicoParticipantes(IRepositorioParticipantes repositorioParticipantes)
            :base(repositorioParticipantes)
        {
            _repositorioParticipantes = repositorioParticipantes;
        }
    }
}
