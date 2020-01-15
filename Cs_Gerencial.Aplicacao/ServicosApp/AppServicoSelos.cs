
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Entities_Fracas;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.ServicosApp
{
    public class AppServicoSelos: AppServicoBase<Selos>, IAppServicoSelos
    {
        private readonly IServicoSelos _servicoSelos;

        public AppServicoSelos(IServicoSelos servicoSelos)
            :base(servicoSelos)
        {
            _servicoSelos = servicoSelos;
        }



        public LeituraArquivoSeloComprado LerArquivoCompraSelo(string caminho)
        {
            return _servicoSelos.LerArquivoCompraSelo(caminho);
        }


        public IEnumerable<Selos> ConsultarPorIdCompraSelo(int idCompraSelo)
        {
            return _servicoSelos.ConsultarPorIdCompraSelo(idCompraSelo);
        }


        public IEnumerable<Selos> ConsultarPorStatusLivre()
        {
            return _servicoSelos.ConsultarPorStatusLivre();
        }


        public IEnumerable<Selos> ConsultarPorIdSerie(int idSerie)
        {
            return _servicoSelos.ConsultarPorIdSerie(idSerie);
        }


        public Selos ConsultarPorSerieNumero(string serie, int numero)
        {
            return _servicoSelos.ConsultarPorSerieNumero(serie, numero);
        }


        public Selos LiberarSelos(Selos selosParaLiberar)
        {
            return _servicoSelos.LiberarSelos(selosParaLiberar);
        }

        public Selos BaixarSelosManualmente(Selos selosParaBaixarManualmente, Usuario usuario)
        {
            return _servicoSelos.BaixarSelosManualmente(selosParaBaixarManualmente, usuario);
        }
        

        public List<Selos> AdicionarListaSelosImportar(LeituraArquivoSeloComprado leituraArquivoSeloComprado, CompraSelo compraSelo, Series series)
        {
            return _servicoSelos.AdicionarListaSelosImportar(leituraArquivoSeloComprado, compraSelo, series);
        }


        public IEnumerable<Selos> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _servicoSelos.ConsultaPorPeriodo(dataInicio, dataFim);
        }


        public List<Selos> ReservarSelos(int idSerie, int quantidade, string natureza, int idUsuario, string nomeUsuario,
             DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato)
        {
            return _servicoSelos.ReservarSelos(idSerie, quantidade, natureza, idUsuario, nomeUsuario, dataReservado, atribuicao, livro, folhaInicio, folhaFim, ato);
        }


        public int ObterUltimoIdReservado()
        {
            return _servicoSelos.ObterUltimoIdReservado();
        }


        public Selos SalvarSeloModificado(Selos modificarSelo)
        {
            return _servicoSelos.SalvarSeloModificado(modificarSelo);
        }


        public IEnumerable<Selos> ConsultarPorSelosReservados(string tipoAto)
        {
            return _servicoSelos.ConsultarPorSelosReservados(tipoAto);
        }


        public List<Selos> ReservarSelosCCT(int quantidade, string natureza, int idUsuario, string nomeUsuario, DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato)
        {
            return _servicoSelos.ReservarSelosCCT(quantidade, natureza, idUsuario, nomeUsuario, dataReservado, atribuicao, livro, folhaInicio, folhaFim, ato);
        }
    }
}
