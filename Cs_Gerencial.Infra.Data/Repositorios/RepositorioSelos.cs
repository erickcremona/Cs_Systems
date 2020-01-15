using CrossCutting;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Entities_Fracas;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioSelos : RepositorioBase<Selos>, IRepositorioSelos
    {
        public IEnumerable<Selos> ConsultarPorIdCompraSelo(int idCompraSelo)
        {
            return Db.Selos.Where(p => p.IdCompra == idCompraSelo);
        }

        public IEnumerable<Selos> ConsultarPorStatusLivre()
        {
            Db = new Contexto.Context();
            return Db.Selos.Where(p => p.Status == "LIVRE");
        }


        public IEnumerable<Selos> ConsultarPorIdSerie(int idSerie)
        {
            Db = new Contexto.Context();
            return Db.Selos.Where(p => p.IdSerie == idSerie);
        }


        public Selos ConsultarPorSerieNumero(string serie, int numero)
        {
            return Db.Selos.Where(p => p.Letra == serie && p.Numero == numero).FirstOrDefault();
        }

        public List<Selos> AdicionarListaSelosImportar(LeituraArquivoSeloComprado leituraArquivoSeloComprado, CompraSelo compraSelo, Series series)
        {


            var selosAdicionar = new List<Selos>();

            for (int i = leituraArquivoSeloComprado.SequenciaInicio; i <= leituraArquivoSeloComprado.SequenciaFim; i++)
            {
                var selos = new Selos();
                selos.Letra = leituraArquivoSeloComprado.Serie;
                selos.Numero = i;

                if (leituraArquivoSeloComprado.Serie.Substring(0, 1) != "G")
                {
                    selos.Cct = "N";
                }
                else
                {
                    selos.Cct = "S";
                }

                selos.IdCompra = compraSelo.CompraSeloId;

                selos.IdSerie = series.SerieId;

                selos.Status = "LIVRE";

                selosAdicionar.Add(selos);


            }

            return selosAdicionar;
        }


        public IEnumerable<Selos> ConsultaPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return Db.Selos.Where(p => p.DataPratica >= dataInicio.Date && p.DataPratica <= dataFim.Date);
        }




        public List<Selos> ReservarSelos(int idSerie, int quantidade, string natureza, int idUsuario, string nomeUsuario,
            DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato)
        {
            List<Selos> selosReservados = new List<Selos>();
            var idReferencia = 0;


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    for (int i = 0; i < quantidade; i++)
                    {
                        Db = new Contexto.Context();
                        Selos selo = Db.Selos.Where(p => p.IdSerie == idSerie && p.Status == "LIVRE").OrderBy(p => p.Numero).FirstOrDefault();
                        selo.IdReservado = Db.Selos.Max(p => p.IdReservado) + 1;
                        
                        if (i == 0)
                        {
                            idReferencia = Db.Selos.Max(p => p.idReferencia) + 1;
                            selo.idReferencia = idReferencia;
                        }
                        else
                            selo.idReferencia = idReferencia;

                        selo.Status = "RESERVADO";
                        

                        Update(selo);
                        selosReservados.Add(selo);
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return selosReservados;

        }

        public List<Selos> ReservarSelosCCT(int quantidade, string natureza, int idUsuario, string nomeUsuario,
            DateTime dataReservado, int atribuicao, string livro, int folhaInicio, int folhaFim, int ato)
        {
            List<Selos> selosReservados = new List<Selos>();
            var idReferencia = 0;


            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    for (int i = 0; i < quantidade; i++)
                    {
                        Db = new Contexto.Context();
                        Selos selo = Db.Selos.Where(p => p.Cct == "S" && p.Status == "LIVRE").OrderBy(p => p.SeloId).FirstOrDefault();
                        
                        if (selo != null)
                        {
                            selo.IdReservado = Db.Selos.Max(p => p.IdReservado) + 1;

                            if (i == 0)
                            {
                                idReferencia = Db.Selos.Max(p => p.idReferencia) + 1;
                                selo.idReferencia = idReferencia;
                            }
                            else
                                selo.idReferencia = idReferencia;

                            selo.Status = "RESERVADO";


                            Update(selo);
                            selosReservados.Add(selo);
                        }
                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return selosReservados;

        }


        public int ObterUltimoIdReservado()
        {
            return Db.Selos.Max(p => p.IdReservado);
        }


        public Selos SalvarSeloModificado(Selos modificarSelo)
        {

            Selos modificar;

            using (TransactionScope scope = new TransactionScope())
            {

                try
                {

                    Db = new Contexto.Context();
                    modificar = Db.Selos.Where(p => p.SeloId == modificarSelo.SeloId).FirstOrDefault();

                    modificar.Status = modificarSelo.Status;
                    modificar.Acoterj = modificarSelo.Acoterj;
                    modificar.Aleatorio = modificarSelo.Aleatorio;
                    modificar.Ar = modificarSelo.Ar;
                    modificar.Atribuicao = modificarSelo.Atribuicao;
                    modificar.Cct = modificarSelo.Cct;
                    modificar.Check = modificarSelo.Check;
                    modificar.Codigo = modificarSelo.Codigo;
                    modificar.Conjunto = modificarSelo.Conjunto;
                    modificar.Convenio = modificarSelo.Convenio;
                    modificar.DataPratica = modificarSelo.DataPratica;
                    modificar.DataReservado = modificarSelo.DataReservado;
                    modificar.Distribuicao = modificarSelo.Distribuicao;
                    modificar.Emolumentos = modificarSelo.Emolumentos;
                    modificar.Escrevente = modificarSelo.Escrevente;
                    modificar.Fetj = modificarSelo.Fetj;
                    modificar.FolhaFinal = modificarSelo.FolhaFinal;
                    modificar.FolhaInicial = modificarSelo.FolhaInicial;
                    modificar.FormReservado = modificarSelo.FormReservado;
                    modificar.FormUtilizado = modificarSelo.FormUtilizado;
                    modificar.Funarpen = modificarSelo.Funarpen;
                    modificar.Fundperj = modificarSelo.Fundperj;
                    modificar.Funperj = modificarSelo.Funperj;
                    modificar.IdAto = modificarSelo.IdAto;
                    modificar.idReferencia = modificarSelo.idReferencia;
                    modificar.IdReservado = modificarSelo.IdReservado;
                    modificar.IdUsuarioReservado = modificarSelo.IdUsuarioReservado;
                    modificar.Indisponibilidade = modificarSelo.Indisponibilidade;
                    modificar.Iss = modificarSelo.Iss;
                    modificar.Letra = modificarSelo.Letra;
                    modificar.Livro = modificarSelo.Livro;
                    modificar.Matricula = modificarSelo.Matricula;
                    modificar.Mutua = modificarSelo.Mutua;
                    modificar.Natureza = modificarSelo.Natureza;
                    modificar.Numero = modificarSelo.Numero;
                    modificar.NumeroAto = modificarSelo.NumeroAto;
                    modificar.Pmcmv = modificarSelo.Pmcmv;
                    modificar.Prenotacao = modificarSelo.Prenotacao;
                    modificar.Protocolo = modificarSelo.Protocolo;
                    modificar.Recibo = modificarSelo.Recibo;
                    modificar.Reservado = modificarSelo.Reservado;
                    modificar.Sistema = modificarSelo.Sistema;
                    modificar.TarifaBancaria = modificarSelo.TarifaBancaria;
                    modificar.TipoCobranca = modificarSelo.TipoCobranca;
                    modificar.Total = modificarSelo.Total;
                    modificar.UsuarioReservado = modificarSelo.UsuarioReservado;


                    Db.SaveChanges();

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return modificar;
            
        }


        public IEnumerable<Selos> ConsultarPorSelosReservados(string tipoAto)
        {
            return Db.Selos.Where(p => p.Status == "RESERVADO" && p.Natureza == tipoAto).ToList();
        }
    }
}
