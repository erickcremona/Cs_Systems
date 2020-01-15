using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Entities
{
    public class Config
    {
        public int ConfiguracoesId { get; set; }

        public string Titular { get; set; }

        public string CpfTitular { get; set; }

        public string Substituto { get; set; }

        public int Codigo { get; set; }

        public string Cmc { get; set; }

        public string RazaoSocial { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Cep { get; set; }

        public string Telefone1 { get; set; }

        public string Telefone2 { get; set; }

        public string Email { get; set; }

        public string Cnpj { get; set; }

        public int ProximoLivro { get; set; }

        public int ProximaFolha { get; set; }

        public string TipoCalculoIss { get; set; }

        public double ValorAliquota { get; set; }

        public int TotalFolhasPorLivro { get; set; }

        public string NomeArquivoImportando { get; set; }
    }
}
