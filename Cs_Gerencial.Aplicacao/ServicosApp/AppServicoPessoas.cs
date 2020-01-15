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
    public class AppServicoPessoas: AppServicoBase<Pessoas>, IAppServicoPessoas
    {
        private readonly IServicoPessoas _servicoPessoas; 
        public AppServicoPessoas(IServicoPessoas servicoPessoas)
            :base(servicoPessoas)
        {
            _servicoPessoas = servicoPessoas;
        }

        public List<string> ObterListaOrgaoEmissor()
        {
            return _servicoPessoas.ObterListaOrgaoEmissor();
        }


        public List<string> ObterListaProfissao()
        {
            return _servicoPessoas.ObterListaProfissao();
        }


        public List<Pessoas> ObterListaPessoasPorCpfCnpj(string cpfCnpj)
        {
             return _servicoPessoas.ObterListaPessoasPorCpfCnpj(cpfCnpj);
        }


        public Pessoas SalvarAlteracao(Pessoas pessoa)
        {
            return _servicoPessoas.SalvarAlteracao(pessoa);
        }
    }
}
