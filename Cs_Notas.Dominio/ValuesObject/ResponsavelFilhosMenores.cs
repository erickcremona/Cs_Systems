using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class ResponsavelFilhosMenores
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public List<ResponsavelFilhosMenores> ListarResponsavelFilhosMenores()
        {
            var item = new ResponsavelFilhosMenores();
            var lista = new List<ResponsavelFilhosMenores>();

            item = new ResponsavelFilhosMenores(){
                Codigo = 1,
                Descricao = "Cônjuge 01"
            };
            lista.Add(item);

            item = new ResponsavelFilhosMenores()
            {
                Codigo = 2,
                Descricao = "Cônjuge 02"
            };
            lista.Add(item);

            item = new ResponsavelFilhosMenores()
            {
                Codigo = 3,
                Descricao = "Ambos Cônjuge"
            };
            lista.Add(item);

            item = new ResponsavelFilhosMenores()
            {
                Codigo = 4,
                Descricao = "Outros"
            };
            lista.Add(item);

            item = new ResponsavelFilhosMenores()
            {
                Codigo = 1,
                Descricao = "Sem Declaração"
            };
            lista.Add(item);

            return lista;
        }
    }
}
