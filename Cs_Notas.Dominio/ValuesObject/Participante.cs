using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class Participante
    {
        public int IdPessoa { get; set; }
        
        public int IdNomes { get; set; }

        public int IdAto { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string CpfCnpj { get; set; }

    }
}
