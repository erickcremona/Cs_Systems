using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.Interfaces
{
    public interface IAppServicoPessoas: IAppServicoBase<Pessoas>
    {
        List<string> ObterListaOrgaoEmissor();

        List<string> ObterListaProfissao();

        List<Pessoas> ObterListaPessoasPorCpfCnpj(string cpfCnpj);

        Pessoas SalvarAlteracao(Pessoas pessoa);
    }
}
