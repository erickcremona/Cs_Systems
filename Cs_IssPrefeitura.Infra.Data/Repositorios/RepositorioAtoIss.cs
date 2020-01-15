using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Infra.Data.Repositorios
{
    public class RepositorioAtoIss: RepositorioBase<AtoIss>, IRepositorioAtoIss
    {
        public List<string> CarregarListaAtribuicoes()
        {
            return Db.AtoIss.Select(p => p.Atribuicao).Distinct().ToList();
        }

        public List<string> CarregarListaTipoAtos()
        {
            return Db.AtoIss.Select(p => p.TipoAto).Distinct().ToList();
        }


        public List<AtoIss> ListarAtosPorPeriodo(DateTime inicio, DateTime fim)
        {
            
            return Db.AtoIss.Where(p => p.Data >= inicio && p.Data <= fim).OrderBy(p => p.Data).ThenBy(p => p.Atribuicao).ThenBy(p => p.TipoAto).ToList();
        }

        public List<AtoIss> VerificarRegistrosExistentesPorData(DateTime data)
        {
            return Db.AtoIss.Where(p => p.Data == data.Date).ToList();   
        }



        public List<AtoIss> ConsultaDetalhada(string tipoConsulta, string dados)
        {
            var retornoLista = new List<AtoIss>();

            switch (tipoConsulta)
            {
                case "ATRIBUIÇÃO":
                    retornoLista = Db.AtoIss.Where(p => p.Atribuicao == dados).ToList();
                    break;

                case "TIPO DE ATO":
                    retornoLista = Db.AtoIss.Where(p => p.TipoAto == dados).ToList();
                    break;

                case "SELO":
                    retornoLista = Db.AtoIss.Where(p => p.Selo == dados).ToList();
                    break;

                default:
                    break;
            }

            return retornoLista;
        }


        public string TipoCalculoIss()
        {
            return Db.Configuracoes.Select(p => p.TipoCalculoIss).FirstOrDefault();
        }


        public decimal AliquotaIss()
        {
            decimal aliquota = Convert.ToDecimal(Db.Configuracoes.Select(p => p.ValorAliquota).FirstOrDefault());

            return aliquota;
        }
    }
}
