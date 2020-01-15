using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioMunicipios: RepositorioBase<Municipios>, IRepositorioMunicipios
    {
        public List<Municipios> ObterMunicipiosPorUF(string UF)
        {
           return  Db.Municipios.Where(p => p.Uf == UF).ToList();
        }

        public List<string> ObterUfsDosMunicipios()
        {
            return Db.Municipios.Where(p => p.Uf != "ET" && p.Uf != "BR" && p.Uf != "IG").Select(p => p.Uf).Distinct().ToList();
        }
    }
}
