using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class SituacaoCpfCnpj
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public List<SituacaoCpfCnpj> ObterListaSituacaoCpfCnpj()
        {
            var listaSituacao = new List<SituacaoCpfCnpj>();

            var situacao = new SituacaoCpfCnpj();

            situacao.Codigo = 0;
            situacao.Descricao = "Inscrito no Cpf/Cnpj ";
            listaSituacao.Add(situacao);

            situacao = new SituacaoCpfCnpj();
            situacao.Codigo = 1;
            situacao.Descricao = "Sem CPF/CNPJ - Decisão Judicial";
            listaSituacao.Add(situacao);

            situacao = new SituacaoCpfCnpj();
            situacao.Codigo = 2;
            situacao.Descricao = "Sem CNPJ - Anterior a IN 200";
            listaSituacao.Add(situacao);

            situacao = new SituacaoCpfCnpj();
            situacao.Codigo = 3;
            situacao.Descricao = "Sem CPF - Anterio a IN 190";
            listaSituacao.Add(situacao);

            return listaSituacao;
        }
    }
}
