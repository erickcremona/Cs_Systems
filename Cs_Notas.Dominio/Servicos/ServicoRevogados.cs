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
    public class ServicoRevogados: ServicoBase<Revogados>, IServicoRevogados
    {
        private readonly IRepositorioRevogados _IRepositorioRevogados;

        public ServicoRevogados(IRepositorioRevogados IRepositorioRevogados)
            : base(IRepositorioRevogados)
        {
            _IRepositorioRevogados = IRepositorioRevogados;
        }



        public List<Revogados> ObterRevogadosPorIdTestamento(int idTestamento)
        {
            return _IRepositorioRevogados.ObterRevogadosPorIdTestamento(idTestamento);
        }
    }
}
