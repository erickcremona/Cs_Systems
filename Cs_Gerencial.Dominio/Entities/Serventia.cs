using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Entities
{
    public class Serventia
    {
        public int ServentiaId { get; set; }
        public int CodigoServentia { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string Responsavel { get; set; }
        public string Titular { get; set; }
        public string Substituto { get; set; }


    }
}
