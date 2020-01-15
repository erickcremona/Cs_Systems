using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Entities
{
    public class Configuracoes
    {
        public int ConfiguracoesId { get; set; }

        public string Titular { get; set; }

        public string Substituto { get; set; }

        public string RazaoSocial { get; set; }

        public string Cnpj { get; set; }

        public int ProximoLivro { get; set; }

        public int ProximaFolha { get; set; }

        public string TipoCalculoIss { get; set; }

        public float Valorliquota { get; set; }

        public int TotalFolhasPorLivro { get; set; }
    }
}
