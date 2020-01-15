using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.Interfaces
{
    public interface IAppServicoFornecedores: IAppServicoBase<Fornecedores>
    {
        IEnumerable<Fornecedores> ConsultarPorRazaoSocial(string razaoSocial);

        IEnumerable<Fornecedores> ConsultarPorNomeFantasia(string nomeFantasia);

        IEnumerable<Fornecedores> ConsultarPorDocumento(string documento);
    }
}
