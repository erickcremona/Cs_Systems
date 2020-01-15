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
    public class ServicoPlanos: ServicoBase<Planos>, IServicoPlanos
    {
        private readonly IRepositorioPlanos _repositorioPlanos;

        public ServicoPlanos(IRepositorioPlanos repositorioPlanos)
            : base(repositorioPlanos)
        {
            _repositorioPlanos = repositorioPlanos;
        }

        public IEnumerable<Planos> ConsultarPlanosPorDescricao(string descricao)
        {
           return _repositorioPlanos.ConsultarPlanosPorDescricao(descricao);
        }
    }
}
