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
    public class AppServicoAtoIss: AppServicoBase<AtoIss>, IAppServicoAtoIss
    {
        private readonly IServicoAtoIss _servicoAtoIss;

        public AppServicoAtoIss(IServicoAtoIss servicoAtoIss)
            :base(servicoAtoIss)
        {
            _servicoAtoIss = servicoAtoIss;
        }

        public AtoIss CalcularValoresAtoIss(AtoIss atoCalcular)
        {
            return _servicoAtoIss.CalcularValoresAtoIss(atoCalcular);
        }

        public List<AtoIss> LerArquivoXml(string caminho)
        {
            return _servicoAtoIss.LerArquivoXml(caminho);
        }


        public List<string> CarregarListaAtribuicoes()
        {
            return _servicoAtoIss.CarregarListaAtribuicoes();
        }


        public List<string> CarregarListaTipoAtos()
        {
           return _servicoAtoIss.CarregarListaTipoAtos();
        }


        public List<AtoIss> ListarAtosPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _servicoAtoIss.ListarAtosPorPeriodo(inicio, fim);
        }

        public List<AtoIss> VerificarRegistrosExistentesPorData(DateTime data)
        {
            return _servicoAtoIss.VerificarRegistrosExistentesPorData(data);
        }


        public List<AtoIss> ConsultaDetalhada(string tipoConsulta, string dados)
        {
            return _servicoAtoIss.ConsultaDetalhada(tipoConsulta, dados);
        }
    }
}
