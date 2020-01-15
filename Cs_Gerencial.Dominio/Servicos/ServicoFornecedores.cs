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
    public class ServicoFornecedores: ServicoBase<Fornecedores>, IServicoFornecedores
    {
        private readonly IRepositorioFornecedores _repositorioFornecedores;

        public ServicoFornecedores(IRepositorioFornecedores repositorioFornecedores)
            : base(repositorioFornecedores)
        {
            _repositorioFornecedores = repositorioFornecedores;
        }

        public IEnumerable<Fornecedores> ConsultarPorRazaoSocial(string razaoSocial)
        {
            return _repositorioFornecedores.ConsultarPorRazaoSocial(razaoSocial);
        }

        public IEnumerable<Fornecedores> ConsultarPorNomeFantasia(string nomeFantasia)
        {
            return _repositorioFornecedores.ConsultarPorNomeFantasia(nomeFantasia);
        }

        public IEnumerable<Fornecedores> ConsultarPorDocumento(string documento)
        {
            return _repositorioFornecedores.ConsultarPorDocumento(documento);
        }
    }
}
