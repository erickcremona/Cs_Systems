using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Repositorios
{
    public class RepositorioEscrituras: RepositorioBase<Escrituras>, IRepositorioEscrituras
    {
        public Escrituras ObterEscrituraPorSeloLivroFolhaAto(string selo, string aleatorio, string livro, int folhainicio, int folhaFim, int ato)
        {
           return Db.Escrituras.Where(p => p.SeloEscritura == selo && p.Aleatorio == aleatorio && p.LivroEscritura == livro && p.FolhasInicio == folhainicio && p.FolhasFim == folhaFim && p.NumeroAto == ato).FirstOrDefault();
        }


        public List<Escrituras> ObterEscriturasPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Db.Escrituras.Where( p => p.DataAtoRegistro >= dataInicio && p.DataAtoRegistro <= dataFim).OrderByDescending(p => p.DataAtoRegistro).ToList();
        }

        public List<Escrituras> ObterEscriturarPorLivro(string livro)
        {
            return Db.Escrituras.Where(p => p.LivroEscritura == livro).OrderByDescending(p => p.DataAtoRegistro).ToList();
        }

        public List<Escrituras> ObterEscriturarPorAto(int numeroAto)
        {
            return Db.Escrituras.Where(p => p.NumeroAto == numeroAto).OrderByDescending(p => p.DataAtoRegistro).ToList();
        }

        public List<Escrituras> ObterEscriturarPorSelo(string selo)
        {
            return Db.Escrituras.Where(p => p.SeloEscritura == selo).OrderByDescending(p => p.DataAtoRegistro).ToList();
        }

        public List<Escrituras> ObterEscriturarPorParticipante(List<int> idsAto)
        {
            var escrituras = new List<Escrituras>();

            for (int i = 0; i < idsAto.Count(); i++)
            {
              escrituras.Add(Db.Escrituras.Where(p => p.EscriturasId == idsAto[i]).OrderByDescending(p => p.DataAtoRegistro).FirstOrDefault());
            }
            return escrituras;
        }

        



     }
}
