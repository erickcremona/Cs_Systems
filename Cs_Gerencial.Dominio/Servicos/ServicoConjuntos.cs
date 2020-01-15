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
    public class ServicoConjuntos: ServicoBase<Conjuntos>, IServicoConjuntos
    {
        private readonly IRepositorioConjuntos _repositorioConjuntos;

        public ServicoConjuntos(IRepositorioConjuntos repositorioConjuntos)
            : base(repositorioConjuntos)
        {
            _repositorioConjuntos = repositorioConjuntos;
        }
    }
}
