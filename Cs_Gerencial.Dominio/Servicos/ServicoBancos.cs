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
    public class ServicoBancos: ServicoBase<Bancos>, IServicoBancos
    {

        private readonly IRepositorioBancos _repositorio;

        public ServicoBancos(IRepositorioBancos repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }

    }
}
