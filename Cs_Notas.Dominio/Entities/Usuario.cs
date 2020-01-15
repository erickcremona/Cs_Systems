using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Qualificacao { get; set; }

        public string Matricula { get; set; }

        public string Senha { get; set; }

        public string Master { get; set; }

        public string AlterarAto { get; set; }

        public string ExcluirAto { get; set; }

        public string SelarAto { get; set; }

        public string LiberarSelo { get; set; }

        public string ReservarSelo { get; set; }

        public string AlterarSelo { get; set; }

        public string AlterarEmolumentos { get; set; }

    }
}

