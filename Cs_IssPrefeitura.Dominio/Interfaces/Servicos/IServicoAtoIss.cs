using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cs_IssPrefeitura.Dominio.Interfaces.Servicos
{
    public interface IServicoAtoIss: IServicoBase<AtoIss>
    {
        AtoIss CalcularValoresAtoIss(AtoIss atoCalcular);

        List<AtoIss> LerArquivoXml(string caminho);

        List<string> CarregarListaAtribuicoes();

        List<string> CarregarListaTipoAtos();

        List<AtoIss> ListarAtosPorPeriodo(DateTime inicio, DateTime fim);

        List<AtoIss> VerificarRegistrosExistentesPorData(DateTime data);

        List<AtoIss> ConsultaDetalhada(string tipoConsulta, string dados);
        
    }
}
