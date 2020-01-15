using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Infra.Data.Repositorios
{
    public class RepositorioApuracaoIss: RepositorioBase<ApuracaoIss>, IRepositorioApuracaoIss
    {
        public List<ApuracaoIss> ObterListaApuracaoPorMesAno(int mes, int ano)
        {
            return Db.ApuracaoIss.Where(p => p.Mes == mes && p.Ano == ano && p.Cancelado == "NÃO").ToList();
        }


        public List<ApuracaoIss> ObterListaApuracaoPorMes(int mes)
        {
            return Db.ApuracaoIss.Where(p => p.Mes == mes && p.Cancelado == "NÃO").OrderBy(p => p.Ano).ToList();
        }

        public List<ApuracaoIss> ObterListaApuracaoPorAno(int ano)
        {
            return Db.ApuracaoIss.Where(p => p.Ano == ano && p.Cancelado == "NÃO").OrderBy(p => p.Mes).ToList();
        }


        public int ObterUltimoNumero()
        {            
            var verificaExiste = Db.ApuracaoIss.FirstOrDefault();

            if (verificaExiste != null)
            {
                
                return Db.ApuracaoIss.Max(p => p.Numero);
            }
            else
                return 0;
        }

        public int ObterUltimaSerie(int ano)
        {
            var verificaExiste = Db.ApuracaoIss.Where(p => p.Ano == ano).ToList();

            if (verificaExiste != null || verificaExiste.Count == 0)
            {
                if (verificaExiste.Count == 0)
                    return 0;
                else
                {
                    if (verificaExiste.Max(p => p.Serie <= 11))
                        return verificaExiste.Max(p => p.Serie);
                    else
                        return 0;
                }
            }
            else
                return 0;
        }
    }
}
