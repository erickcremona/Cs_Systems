using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces.Servicos
{
    public interface IServicoPessoas: IServicoBase<Pessoas>
    {
        List<string> ObterListaOrgaoEmissor();

        List<string> ObterListaProfissao();

        List<Pessoas> ObterListaPessoasPorCpfCnpj(string cpfCnpj);

        Pessoas SalvarAlteracao(Pessoas pessoa);
    }
}
