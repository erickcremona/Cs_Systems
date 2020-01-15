using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class TipoEndereco
    {
        public string Sigla { get; set; }

        public string Descricao { get; set; }


        public List<TipoEndereco> ObterTiposEndereco()
        {
            TipoEndereco tpEnd = new TipoEndereco();

            List<TipoEndereco> listaRetorno = new List<TipoEndereco>();

            tpEnd.Sigla = "R";
            tpEnd.Descricao = "RESIDENCIAL";
            listaRetorno.Add(tpEnd);

            tpEnd = new TipoEndereco();
            tpEnd.Sigla = "C";
            tpEnd.Descricao = "COMERCIAL";
            listaRetorno.Add(tpEnd);

            return listaRetorno;

        }
    }
}
