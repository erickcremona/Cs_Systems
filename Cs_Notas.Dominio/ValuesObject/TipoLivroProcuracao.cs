using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class TipoLivroProcuracao
    {
        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public List<TipoLivroProcuracao> ObterTipoLivroProcuracaoOrigem()
        {
            TipoLivroProcuracao tipo = new TipoLivroProcuracao();

            List<TipoLivroProcuracao> listaRetorno = new List<TipoLivroProcuracao>();

            tipo.Sigla = "P";
            tipo.Descricao = "PROCURAÇÃO";
            listaRetorno.Add(tipo);

            tipo = new TipoLivroProcuracao();
            tipo.Sigla = "E";
            tipo.Descricao = "ESCRITURA";
            listaRetorno.Add(tipo);

            tipo = new TipoLivroProcuracao();
            tipo.Sigla = "M";
            tipo.Descricao = "MISTO";
            listaRetorno.Add(tipo);

            return listaRetorno;
        }

        public List<TipoLivroProcuracao> ObterTipoLivroProcuracao()
        {
            TipoLivroProcuracao tipo = new TipoLivroProcuracao();

            List<TipoLivroProcuracao> listaRetorno = new List<TipoLivroProcuracao>();

            tipo.Sigla = "P";
            tipo.Descricao = "PROCURAÇÃO";
            listaRetorno.Add(tipo);

            tipo = new TipoLivroProcuracao();
            tipo.Sigla = "M";
            tipo.Descricao = "MISTO";
            listaRetorno.Add(tipo);

            return listaRetorno;
        }
    }
}
