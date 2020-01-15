using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class TipoDoi
    {
        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public List<TipoDoi> ObterListaTipoDoi()
        {
            var listaTipoDoi = new List<TipoDoi>();

            var tipoDoi = new TipoDoi();

            tipoDoi.Sigla = "AL";
            tipoDoi.Descricao = "ALIENANTE";
            listaTipoDoi.Add(tipoDoi);


            tipoDoi = new TipoDoi();
            tipoDoi.Sigla = "AD";
            tipoDoi.Descricao = "ADQUIRENTE";
            listaTipoDoi.Add(tipoDoi);

            tipoDoi = new TipoDoi();
            tipoDoi.Sigla = "AA";
            tipoDoi.Descricao = "RECIPROCAMENTE";
            listaTipoDoi.Add(tipoDoi);

            return listaTipoDoi;
        }
    }
}
