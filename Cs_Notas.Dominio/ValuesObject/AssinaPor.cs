using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class AssinaPor
    {
        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public List<AssinaPor> ObterTiposAssinaPor()
        {
            AssinaPor assina = new AssinaPor();

            List<AssinaPor> listaRetorno = new List<AssinaPor>();

            assina.Sigla = "0";
            assina.Descricao = "OUTORGANTE";
            listaRetorno.Add(assina);

            assina = new AssinaPor();
            assina.Sigla = "1";
            assina.Descricao = "OUTORGADO";
            listaRetorno.Add(assina);

            return listaRetorno;
        }
    }
}
