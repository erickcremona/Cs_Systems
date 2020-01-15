using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioTabelaCustas: IRepositorioBase<TabelaCustas>
    {
        List<TabelaCustas> CalcularItensCustasComValor(decimal baseCalculo, int ano);

        List<TabelaCustas> CalcularItensCustas(string tipo, int ano);

        bool AtualizarCustas(int ano);
    }
}
