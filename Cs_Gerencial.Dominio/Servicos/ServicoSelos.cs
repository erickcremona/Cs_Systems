using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Entities_Fracas;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Cs_Gerencial.Dominio.Servicos
{
    public class ServicoSelos : ServicoBase<Selos>, IServicoSelos
    {

        private readonly IRepositorioSelos _repositorioSelos;

        public ServicoSelos(IRepositorioSelos repositorioSelos)
            : base(repositorioSelos)
        {
            _repositorioSelos = repositorioSelos;
        }

        public LeituraArquivoSeloComprado LerArquivoCompraSelo(string caminho)
        {
            LeituraArquivoSeloComprado retornoLeitura = new LeituraArquivoSeloComprado();

            FileInfo arquivo = new FileInfo(caminho);
          
            var leituraXml = new XmlTextReader(caminho);

            retornoLeitura.Arquivo = arquivo.Name;

                    while (leituraXml.Read())
            {
                switch (leituraXml.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (leituraXml.Name)
                        {
                            case "Pedido":

                                while (leituraXml.MoveToNextAttribute())
                                {                                    
                                    switch (leituraXml.Name)
                                    {                                        
                                        case "DataGeracao":
                                            if (leituraXml.Value != "")
                                            retornoLeitura.DataGeracao = DateTime.Parse(leituraXml.Value);
                                            break;

                                            case "SolicitanteNome":
                                            retornoLeitura.SolicitanteNome = leituraXml.Value;
                                            break;
                                            
                                            case "SolicitanteCPF":
                                            retornoLeitura.SolicitanteCpf = leituraXml.Value;
                                            break;

                                            case "Quantidade":
                                            if (leituraXml.Value != "")
                                            retornoLeitura.Quantidade = int.Parse(leituraXml.Value);
                                            break;

                                            case "DataPedido":
                                            if (leituraXml.Value != "")
                                            retornoLeitura.DataPedido = DateTime.Parse(leituraXml.Value);
                                            break;

                                            case "CodigoServico":
                                            retornoLeitura.CodigoServico = leituraXml.Value;
                                            break;

                                            case "Id":
                                            retornoLeitura.Id = int.Parse(leituraXml.Value);
                                            break;

                                            case "GRERJ":
                                            retornoLeitura.Grerj = leituraXml.Value;
                                            break;

                                            case "PagamentoGRERJ":
                                            if(leituraXml.Value != "")
                                            retornoLeitura.DataPagamento = DateTime.Parse(leituraXml.Value);
                                            break;

                                        default:
                                            break;
                                    }
                                }
                                break;

                            case "FaixaSelo":
                                while (leituraXml.MoveToNextAttribute())
                                {

                                    switch (leituraXml.Name)
                                    {
                                        case "SequenciaFim":
                                            retornoLeitura.SequenciaFim = int.Parse(leituraXml.Value);
                                            break;

                                        case "SequenciaInicio":
                                            retornoLeitura.SequenciaInicio = int.Parse(leituraXml.Value);
                                            break;

                                        case "Serie":
                                            retornoLeitura.Serie = leituraXml.Value;
                                            break;
                                    }

                                }
                                break;
                        }
                        break;

                    
                }
            }

            return retornoLeitura;

        }


        public List<Selos> AdicionarListaSelosImportar(LeituraArquivoSeloComprado leituraArquivoSeloComprado, CompraSelo compraSelo, Series series)
        {
            return _repositorioSelos.AdicionarListaSelosImportar(leituraArquivoSeloComprado, compraSelo, series);
        }
              
        public IEnumerable<Selos> ConsultarPorIdCompraSelo(int idCompraSelo)
        {
            return _repositorioSelos.ConsultarPorIdCompraSelo(idCompraSelo);
        }
        
        public IEnumerable<Selos> ConsultarPorStatusLivre()
        {
            return _repositorioSelos.ConsultarPorStatusLivre();
        }
        
        public IEnumerable<Selos> ConsultarPorIdSerie(int idSerie)
        {
            return _repositorioSelos.ConsultarPorIdSerie(idSerie);
        }
        
        public Selos ConsultarPorSerieNumero(string serie, int numero)
        {
            return _repositorioSelos.ConsultarPorSerieNumero(serie, numero);
        }
        
        public Selos LiberarSelos(Selos selosParaLiberar)
        {            
            selosParaLiberar.Status = "LIVRE";
            selosParaLiberar.Sistema = null;
            selosParaLiberar.IdReservado = 0;
            selosParaLiberar.Reservado = null;
            selosParaLiberar.DataReservado = new DateTime().Date;
            selosParaLiberar.IdUsuarioReservado = 0;
            selosParaLiberar.UsuarioReservado = null;
            selosParaLiberar.FormReservado = null;
            selosParaLiberar.FormUtilizado = null;
            selosParaLiberar.IdAto = 0;
            selosParaLiberar.idReferencia = 0;
            selosParaLiberar.Atribuicao = 0;
            selosParaLiberar.DataPratica = new DateTime().Date;
            selosParaLiberar.Livro = null;
            selosParaLiberar.FolhaInicial = 0;
            selosParaLiberar.FolhaFinal = 0;
            selosParaLiberar.NumeroAto = 0;
            selosParaLiberar.Protocolo = 0;
            selosParaLiberar.Recibo = 0;
            selosParaLiberar.Codigo = 0;
            selosParaLiberar.Conjunto = null;
            selosParaLiberar.Natureza = null;
            selosParaLiberar.Escrevente = null;
            selosParaLiberar.Convenio = null;
            selosParaLiberar.TipoCobranca = null;
            selosParaLiberar.Emolumentos = 0;
            selosParaLiberar.Fetj = 0;
            selosParaLiberar.Fundperj = 0;
            selosParaLiberar.Funperj = 0;
            selosParaLiberar.Funarpen = 0;
            selosParaLiberar.Pmcmv = 0;
            selosParaLiberar.Mutua = 0;
            selosParaLiberar.Acoterj = 0;
            selosParaLiberar.Distribuicao = 0;
            selosParaLiberar.Indisponibilidade = 0;
            selosParaLiberar.Prenotacao = 0;
            selosParaLiberar.Ar = 0;
            selosParaLiberar.TarifaBancaria = 0;
            selosParaLiberar.Total = 0;
            selosParaLiberar.Check = false;

            return selosParaLiberar;
        }


        public Selos BaixarSelosManualmente(Selos selosParaBaixarManualmente, Usuario usuario)
        {


            selosParaBaixarManualmente.Status = "BAIXADO";
            selosParaBaixarManualmente.Sistema = "GERENCIAL";
            selosParaBaixarManualmente.IdReservado = 0;
            selosParaBaixarManualmente.Reservado = null;
            selosParaBaixarManualmente.DataReservado = DateTime.Now.Date;
            selosParaBaixarManualmente.IdUsuarioReservado = usuario.UsuarioId;
            selosParaBaixarManualmente.UsuarioReservado = usuario.NomeUsuario;
            selosParaBaixarManualmente.FormReservado = null;
            selosParaBaixarManualmente.FormUtilizado = null;
            selosParaBaixarManualmente.IdAto = 0;
            selosParaBaixarManualmente.idReferencia = 0;
            selosParaBaixarManualmente.Atribuicao = 0;
            selosParaBaixarManualmente.DataPratica = new DateTime().Date;
            selosParaBaixarManualmente.Livro = null;
            selosParaBaixarManualmente.FolhaInicial = 0;
            selosParaBaixarManualmente.FolhaFinal = 0;
            selosParaBaixarManualmente.NumeroAto = 0;
            selosParaBaixarManualmente.Protocolo = 0;
            selosParaBaixarManualmente.Recibo = 0;
            selosParaBaixarManualmente.Codigo = 0;
            selosParaBaixarManualmente.Conjunto = null;
            selosParaBaixarManualmente.Natureza = "SELO BAIXADO MANUALMENTE";
            selosParaBaixarManualmente.Escrevente = null;
            selosParaBaixarManualmente.Convenio = null;
            selosParaBaixarManualmente.TipoCobranca = null;
            selosParaBaixarManualmente.Emolumentos = 0;
            selosParaBaixarManualmente.Fetj = 0;
            selosParaBaixarManualmente.Fundperj = 0;
            selosParaBaixarManualmente.Funperj = 0;
            selosParaBaixarManualmente.Funarpen = 0;
            selosParaBaixarManualmente.Pmcmv = 0;
            selosParaBaixarManualmente.Mutua = 0;
            selosParaBaixarManualmente.Acoterj = 0;
            selosParaBaixarManualmente.Distribuicao = 0;
            selosParaBaixarManualmente.Indisponibilidade = 0;
            selosParaBaixarManualmente.Prenotacao = 0;
            selosParaBaixarManualmente.Ar = 0;
            selosParaBaixarManualmente.TarifaBancaria = 0;
            selosParaBaixarManualmente.Total = 0;
            selosParaBaixarManualmente.Check = false;





            return selosParaBaixarManualmente;
        }




        public IEnumerable<Selos> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _repositorioSelos.ConsultaPorPeriodo(dataInicio, dataFim);
        }


        public List<Selos> ReservarSelos(int idSerie, int quantidade, string natureza, int idUsuario, string nomeUsuario,
            DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato)
        {
            return _repositorioSelos.ReservarSelos(idSerie, quantidade, natureza, idUsuario, nomeUsuario, dataReservado, atribuicao, livro, folhaInicio, folhaFim, ato);
        }


        public int ObterUltimoIdReservado()
        {
            return _repositorioSelos.ObterUltimoIdReservado();
        }


        public Selos SalvarSeloModificado(Selos modificarSelo)
        {
            return _repositorioSelos.SalvarSeloModificado(modificarSelo);
        }


        public IEnumerable<Selos> ConsultarPorSelosReservados(string tipoAto)
        {
            return _repositorioSelos.ConsultarPorSelosReservados(tipoAto);
        }


        public List<Selos> ReservarSelosCCT(int quantidade, string natureza, int idUsuario, string nomeUsuario, DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato)
        {
            return _repositorioSelos.ReservarSelosCCT(quantidade, natureza, idUsuario, nomeUsuario, dataReservado, atribuicao, livro, folhaInicio, folhaFim, ato);
        }
    }
}
