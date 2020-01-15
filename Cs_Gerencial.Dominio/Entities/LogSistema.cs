using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class LogSistema
    {
        public int LogId { get; set; }

        public string Tela { get; set; }

        public DateTime Data { get; set; }

        public string Hora { get; set; }

        public string Descricao { get; set; }

        public int IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Maquina { get; set; }
    }
}
