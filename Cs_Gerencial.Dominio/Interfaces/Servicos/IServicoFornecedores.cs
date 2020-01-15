using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces.Servicos
{
    public interface IServicoFornecedores: IServicoBase<Fornecedores>
    {
        IEnumerable<Fornecedores> ConsultarPorRazaoSocial(string razaoSocial);

        IEnumerable<Fornecedores> ConsultarPorNomeFantasia(string nomeFantasia);

        IEnumerable<Fornecedores> ConsultarPorDocumento(string documento);
    }
}
