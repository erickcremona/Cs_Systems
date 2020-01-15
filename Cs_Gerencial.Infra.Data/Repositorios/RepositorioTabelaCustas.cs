using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioTabelaCustas : RepositorioBase<TabelaCustas>, IRepositorioTabelaCustas
    {
        public List<TabelaCustas> CalcularItensCustasComValor(decimal baseCalculo, int ano)
        {
            var listaItens = new List<TabelaCustas>();

            var listaCustas = Db.TabelaCustas.Where(p => p.Tabela == "22" && p.Tabela == "16" && p.Ano == ano).ToList();


            if (baseCalculo <= 15000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "1").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }
            if (baseCalculo > 15000.00M && baseCalculo <= 30000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "2").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }
            if (baseCalculo > 30000.00M && baseCalculo <= 45000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "3").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }
            if (baseCalculo > 45000.00M && baseCalculo <= 60000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }

            if (baseCalculo > 60000.00M && baseCalculo <= 80000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "5").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }

            if (baseCalculo > 80000.00M && baseCalculo <= 100000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "6").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }
            if (baseCalculo > 100000.00M && baseCalculo <= 200000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "7").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }
            if (baseCalculo > 200000.00M && baseCalculo <= 400000.00M)
            {
                listaItens.Add(listaCustas.Where(p => p.SubItem == "8").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
                listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());
            }

            return listaItens;
        }

        public List<TabelaCustas> CalcularItensCustas(string tipo, int ano)
        {
            var listaItens = new List<TabelaCustas>();

            var listaCustas = Db.TabelaCustas.Where(p => (p.Tabela == "22" || p.Tabela == "16") && p.Ano == ano).ToList();

            tipo = tipo.ToUpper();

            listaItens.Add(listaCustas.Where(p => p.Descricao == tipo).FirstOrDefault());
            listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "4").FirstOrDefault());
            listaItens.Add(listaCustas.Where(p => p.Tabela == "16" && p.Item == "5").FirstOrDefault());

            return listaItens;
        }

        public bool AtualizarCustas(int ano)
        {



            return true;
        }

    }
}
