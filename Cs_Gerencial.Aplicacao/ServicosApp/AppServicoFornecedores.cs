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
    public class AppServicoFornecedores: AppServicoBase<Fornecedores>, IAppServicoFornecedores
    {
        private readonly IServicoFornecedores _servicoFornecedores;

        public AppServicoFornecedores(IServicoFornecedores servicoFornecedores)
            : base(servicoFornecedores)
        {
            _servicoFornecedores = servicoFornecedores;
        }



        public IEnumerable<Fornecedores> ConsultarPorRazaoSocial(string razaoSocial)
        {
            return _servicoFornecedores.ConsultarPorRazaoSocial(razaoSocial);
        }

        public IEnumerable<Fornecedores> ConsultarPorNomeFantasia(string nomeFantasia)
        {
            return _servicoFornecedores.ConsultarPorNomeFantasia(nomeFantasia);
        }

        public IEnumerable<Fornecedores> ConsultarPorDocumento(string documento)
        {
            return _servicoFornecedores.ConsultarPorDocumento(documento);
        }
    }
}
