using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class Conjuge
    {
        public int NumeroConjuge { get; set; }

        public string Descricao { get; set; }

        public List<Conjuge> ObterListaConjuge()
        {
            var retornoLista = new List<Conjuge>();
            var conjuge = new Conjuge();

            conjuge.NumeroConjuge = 1;
            conjuge.Descricao = "PRIMEIRO CÔNJUGE LANÇADO (1)";
            retornoLista.Add(conjuge);

            conjuge = new Conjuge();
            conjuge.NumeroConjuge = 2;
            conjuge.Descricao = "SEGUNDO CÔNJUGE LANÇADO (2)";
            retornoLista.Add(conjuge);

            return retornoLista;
        }
    }
}
