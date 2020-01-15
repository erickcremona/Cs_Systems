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
    public class ServicoPessoas: ServicoBase<Pessoas>, IServicoPessoas
    {
        private readonly IRepositorioPessoas _repositorioPessoas;
        public ServicoPessoas(IRepositorioPessoas repositorioPessoas)
            :base(repositorioPessoas)
        {
            _repositorioPessoas = repositorioPessoas;
        }

        public List<string> ObterListaOrgaoEmissor()
        {
            return _repositorioPessoas.ObterListaOrgaoEmissor();
        }


        public List<string> ObterListaProfissao()
        {
            return _repositorioPessoas.ObterListaProfissao();
        }


        public List<Pessoas> ObterListaPessoasPorCpfCnpj(string cpfCnpj)
        {
            return _repositorioPessoas.ObterListaPessoasPorCpfCnpj(cpfCnpj);
        }


        public Pessoas SalvarAlteracao(Pessoas pessoa)
        {
            return _repositorioPessoas.SalvarAlteracao(pessoa);
        }
    }
}
