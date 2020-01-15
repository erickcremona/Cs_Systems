using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Dominio.Interfaces.Repositorios;
using Cs_IssPrefeitura.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Servicos
{
    public class ServicoApuracaoIss: ServicoBase<ApuracaoIss>, IServicoApuracaoIss
    {
        private readonly IRepositorioApuracaoIss _repositorioApuracaoIss;

        public ServicoApuracaoIss(IRepositorioApuracaoIss repositorioApuracaoIss)
            : base(repositorioApuracaoIss)
        {
            _repositorioApuracaoIss = repositorioApuracaoIss;
        }

        public List<ApuracaoIss> ObterListaApuracaoPorMesAno(int mes, int ano)
        {
            return _repositorioApuracaoIss.ObterListaApuracaoPorMesAno(mes, ano);
        }


        public List<ApuracaoIss> ObterListaApuracaoPorMes(int mes)
        {
            return _repositorioApuracaoIss.ObterListaApuracaoPorMes(mes);
        }

        public List<ApuracaoIss> ObterListaApuracaoPorAno(int ano)
        {
            return _repositorioApuracaoIss.ObterListaApuracaoPorAno(ano);
        }


        public int ObterUltimoNumero()
        {
            return _repositorioApuracaoIss.ObterUltimoNumero();
        }

        public int ObterUltimaSerie(int ano)
        {
            return _repositorioApuracaoIss.ObterUltimaSerie(ano);
        }
    }
}
