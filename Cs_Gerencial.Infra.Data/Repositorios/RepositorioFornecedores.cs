using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioFornecedores: RepositorioBase<Fornecedores>, IRepositorioFornecedores
    {
        public IEnumerable<Fornecedores> ConsultarPorRazaoSocial(string razaoSocial)
        {
            return Db.Fornecedores.
                Where(p => p.RazaoSocial.Contains(razaoSocial)).
                OrderBy(p => p.RazaoSocial);
        }

        public IEnumerable<Fornecedores> ConsultarPorNomeFantasia(string nomeFantasia)
        {
            return Db.Fornecedores.
                Where(p => p.NomeFantasia.Contains(nomeFantasia)).
                OrderBy(p => p.NomeFantasia);
        }

        public IEnumerable<Fornecedores> ConsultarPorDocumento(string documento)
        {
            return Db.Fornecedores.
                Where(p => p.Cnpj.Contains(documento)).
                OrderBy(p => p.NomeFantasia);
        }
    }
}
