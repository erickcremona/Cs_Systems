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
    public class AppServicoNacionalidades: AppServicoBase<Nacionalidades>, IAppServicoNacionalidades
    {
        private readonly IServicoNacionalidades _servicoNacionalidades;

        public AppServicoNacionalidades(IServicoNacionalidades servicoNacionalidades)
            : base(servicoNacionalidades)
        {
            _servicoNacionalidades = servicoNacionalidades;
        }
    }
}
