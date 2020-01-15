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
    public class ServicoLogSistema: ServicoBase<LogSistema>,IServicoLogSistema
    {
        private readonly IRepositorioLogSistema _repositorioLogSistema;

        public ServicoLogSistema(IRepositorioLogSistema repositorioLogSistema)
            : base(repositorioLogSistema)
        {
            _repositorioLogSistema = repositorioLogSistema;
        }
    }
}
