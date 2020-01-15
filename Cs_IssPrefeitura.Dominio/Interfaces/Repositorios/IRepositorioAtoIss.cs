using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioAtoIss: IRepositorioBase<AtoIss>
    {
        List<string> CarregarListaAtribuicoes();

        List<string> CarregarListaTipoAtos();

        List<AtoIss> ListarAtosPorPeriodo(DateTime inicio, DateTime fim);

        List<AtoIss> VerificarRegistrosExistentesPorData(DateTime data);

        List<AtoIss> ConsultaDetalhada(string tipoConsulta, string dados);

        string TipoCalculoIss();

        decimal AliquotaIss();

    }
}
