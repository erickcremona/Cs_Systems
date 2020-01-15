using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Participantes
    {
        public int ParticipantesId { get; set; }

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string Oculto { get; set; }

        public string Doi { get; set; }

        public string Distribuicao { get; set; }

        public string OcultarXmlTd { get; set; }
    }
}
