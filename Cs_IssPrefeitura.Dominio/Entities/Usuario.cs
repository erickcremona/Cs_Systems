using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public bool ImportarMas { get; set; }

        public bool FechamentoMes { get; set; }

        public bool AlterarAtos { get; set; }

        public bool AbrirFecharLivro { get; set; }

        public bool ImprimirFechamentoMes { get; set; }

        public bool UsuarioMaster { get; set; }
    }
}
