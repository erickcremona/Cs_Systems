using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class LocalProcuracao
    {
        public string Descricao { get; set; }

        public string Sigla { get; set; }

        public List<LocalProcuracao> ObterListaLocalProcuracao()
        {
            var local = new LocalProcuracao();
            var listaLocalProcuracao = new List<LocalProcuracao>();

            local.Descricao = "SEDE";
            local.Sigla = "S";
            listaLocalProcuracao.Add(local);

            local = new LocalProcuracao();
            local.Descricao = "FILIAL";
            local.Sigla = "F";
            listaLocalProcuracao.Add(local);

            local = new LocalProcuracao();
            local.Descricao = "OUTROS";
            local.Sigla = "O";
            listaLocalProcuracao.Add(local);

            return listaLocalProcuracao;

        }
    }
}
