using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class JustificativaCpf
    {

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public List<JustificativaCpf> ObterJustificativas()
        {
            JustificativaCpf just = new JustificativaCpf();

            List<JustificativaCpf> listaRetorno = new List<JustificativaCpf>();

            just.Codigo = 1;
            just.Descricao = "NÃO POSSUI";
            listaRetorno.Add(just);

            just = new JustificativaCpf();
            just.Codigo = 2;
            just.Descricao = "NÃO DECLARADO";
            listaRetorno.Add(just);

            just = new JustificativaCpf();
            just.Codigo = 3;
            just.Descricao = "ESTRANGEIRO";
            listaRetorno.Add(just);

            return listaRetorno;
        }
    }
}
