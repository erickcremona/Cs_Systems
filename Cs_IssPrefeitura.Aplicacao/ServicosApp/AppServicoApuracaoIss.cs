using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Aplicacao.ServicosApp
{
    public class AppServicoApuracaoIss: AppServicoBase<ApuracaoIss>, IAppServicoApuracaoIss
    {
        private readonly IServicoApuracaoIss _servicoApuracaoIss;

        public AppServicoApuracaoIss(IServicoApuracaoIss servicoApuracaoIss)
            :base(servicoApuracaoIss)
        {
            _servicoApuracaoIss = servicoApuracaoIss;
        }

        public List<ApuracaoIss> ObterListaApuracaoPorMesAno(int mes, int ano)
        {
            return _servicoApuracaoIss.ObterListaApuracaoPorMesAno(mes, ano);
        }


        public List<ApuracaoIss> ObterListaApuracaoPorMes(int mes)
        {
            return _servicoApuracaoIss.ObterListaApuracaoPorMes(mes);
        }

        public List<ApuracaoIss> ObterListaApuracaoPorAno(int ano)
        {
            return _servicoApuracaoIss.ObterListaApuracaoPorAno(ano);
        }


        public int ObterUltimoNumero()
        {
            return _servicoApuracaoIss.ObterUltimoNumero();
        }

        public int ObterUltimaSerie(int ano)
        {
            return _servicoApuracaoIss.ObterUltimaSerie(ano);
        }
    }
}
