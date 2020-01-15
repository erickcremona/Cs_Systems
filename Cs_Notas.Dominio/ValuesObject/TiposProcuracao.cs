using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class TiposProcuracao
    {
        public string Descricao { get; set; }

        public string Sigla { get; set; }


        public List<TiposProcuracao> ObterListaTiposProcuracao()
        {
            List<TiposProcuracao> tiposProcuracao = new List<TiposProcuracao>();
            var tipoProcuracao = new TiposProcuracao();

            tipoProcuracao.Descricao = "GERAL";
            tipoProcuracao.Sigla = "G";
            tiposProcuracao.Add(tipoProcuracao);

            tipoProcuracao = new TiposProcuracao();
            tipoProcuracao.Descricao = "ESPECIAL";
            tipoProcuracao.Sigla = "E";
            tiposProcuracao.Add(tipoProcuracao);

            tipoProcuracao = new TiposProcuracao();
            tipoProcuracao.Descricao = "SUBSTABELECIMENTO";
            tipoProcuracao.Sigla = "S";
            tiposProcuracao.Add(tipoProcuracao);

            tipoProcuracao = new TiposProcuracao();
            tipoProcuracao.Descricao = "REVOGAÇÃO";
            tipoProcuracao.Sigla = "R";
            tiposProcuracao.Add(tipoProcuracao);

            tipoProcuracao = new TiposProcuracao();
            tipoProcuracao.Descricao = "DENTRO DA ESCRITURA";
            tipoProcuracao.Sigla = "D";
            tiposProcuracao.Add(tipoProcuracao);

            tipoProcuracao = new TiposProcuracao();
            tipoProcuracao.Descricao = "CAUSA PRÓPRIA";
            tipoProcuracao.Sigla = "P";
            tiposProcuracao.Add(tipoProcuracao);

            return tiposProcuracao;
            
        }
    }
}
