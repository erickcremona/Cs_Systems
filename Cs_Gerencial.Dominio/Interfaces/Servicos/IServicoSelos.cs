using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Entities_Fracas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Dominio.Interfaces.Servicos
{
    public interface IServicoSelos: IServicoBase<Selos>
    {
        LeituraArquivoSeloComprado LerArquivoCompraSelo(string caminho);
        
        IEnumerable<Selos> ConsultarPorIdCompraSelo(int idCompraSelo);

        IEnumerable<Selos> ConsultarPorStatusLivre();

        IEnumerable<Selos> ConsultarPorIdSerie(int idSerie);

        Selos ConsultarPorSerieNumero(string serie, int numero);

        Selos LiberarSelos(Selos selosParaLiberar);

        Selos BaixarSelosManualmente(Selos selosParaBaixarManualmente, Usuario usuario);

        List<Selos> AdicionarListaSelosImportar(LeituraArquivoSeloComprado leituraArquivoSeloComprado, CompraSelo compraSelo, Series series);

        IEnumerable<Selos> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim);

        List<Selos> ReservarSelos(int idSerie, int quantidade, string natureza, int idUsuario, string nomeUsuario,
            DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato);

        List<Selos> ReservarSelosCCT(int quantidade, string natureza, int idUsuario, string nomeUsuario,
          DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato);

        int ObterUltimoIdReservado();

        Selos SalvarSeloModificado(Selos modificarSelo);

        IEnumerable<Selos> ConsultarPorSelosReservados(string tipoAto);
    }
}
