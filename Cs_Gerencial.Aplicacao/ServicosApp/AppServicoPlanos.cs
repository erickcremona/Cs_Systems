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
    public class AppServicoPlanos: AppServicoBase<Planos>, IAppServicoPlanos
    {
        private readonly IServicoPlanos _servicoPlanos;

        public AppServicoPlanos(IServicoPlanos servicoPlanos)
            : base(servicoPlanos)
        {
            _servicoPlanos = servicoPlanos;
        }

        public IEnumerable<Planos> ConsultarPlanosPorDescricao(string descricao)
        {
            return _servicoPlanos.ConsultarPlanosPorDescricao(descricao);
        }
    }
}
