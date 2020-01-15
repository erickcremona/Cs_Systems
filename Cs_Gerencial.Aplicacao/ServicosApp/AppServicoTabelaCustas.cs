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
    public class AppServicoTabelaCustas: AppServicoBase<TabelaCustas>, IAppServicoTabelaCustas
    {
        private readonly IServicoTabelaCustas _servicoTabelaCustas;

        public AppServicoTabelaCustas(IServicoTabelaCustas servicoTabelaCustas)
            :base(servicoTabelaCustas)
        {
            _servicoTabelaCustas = servicoTabelaCustas;
        }

        public List<TabelaCustas> CalcularItensCustasComValor(decimal baseCalculo, int ano)
        {
            return _servicoTabelaCustas.CalcularItensCustasComValor(baseCalculo, ano);
        }

        public List<TabelaCustas> CalcularItensCustas(string tipo, int ano)
        {
            return _servicoTabelaCustas.CalcularItensCustas(tipo, ano);
        }

        public bool AtualizarCustas(int ano)
        {
            return _servicoTabelaCustas.AtualizarCustas(ano);
        }
    }
}
