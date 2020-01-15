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
    public class ServicoTabelaCustas: ServicoBase<TabelaCustas>, IServicoTabelaCustas
    {
        private readonly IRepositorioTabelaCustas _repositorioTabelaCustas;
        public ServicoTabelaCustas(IRepositorioTabelaCustas repositorioTabelaCustas)
            :base(repositorioTabelaCustas)
        {
            _repositorioTabelaCustas = repositorioTabelaCustas;
        }

        public List<TabelaCustas> CalcularItensCustasComValor(decimal baseCalculo, int ano)
        {
            return _repositorioTabelaCustas.CalcularItensCustasComValor(baseCalculo, ano);
        }

        public List<TabelaCustas> CalcularItensCustas(string tipo, int ano)
        {
            return _repositorioTabelaCustas.CalcularItensCustas(tipo, ano);
        }

        public bool AtualizarCustas(int ano)
        {
            return _repositorioTabelaCustas.AtualizarCustas(ano);
        }
    }
}
