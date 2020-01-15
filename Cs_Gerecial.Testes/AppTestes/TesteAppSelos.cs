using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Entities_Fracas;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cs_Gerecial.Testes.AppTestes
{
    public class TesteAppSelos
    {
        [Fact]
        public void AppSelos_LerArquivoCompraSelo_True()
        {
            var servico = new Mock<IServicoSelos>();

            // Arrange
            var retornoLeitura = new LeituraArquivoSeloComprado();

            var caminho = @"C:\Users\erick\Desktop\Cs_Sistemas\Cs_Gerecial.Testes\ArquivosTeste\ArquivoSelos04318121520160901.XML";

            retornoLeitura.Quantidade = 240;

            servico.Setup(p => p.LerArquivoCompraSelo(caminho)).Returns(retornoLeitura);

            var appSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appSelos.LerArquivoCompraSelo(caminho);

            //Assert
            Assert.True(retorno.Quantidade == 240);
        }

        [Fact]
        public void AppSelos_ConsultarPorIdCompraSelo_True()
        {
            //Arrange
            var servico = new Mock<IServicoSelos>();

            var listaSelos = new List<Selos>();

            var selo = new Selos();

            for (int i = 0; i < 100; i++)
            {
                selo = new Selos()
                {
                    IdCompra = i
                };

                if (selo.IdCompra == 50)
                    selo.Recibo = 1234;

                listaSelos.Add(selo);
            }

            servico.Setup(p => p.ConsultarPorIdCompraSelo(50)).Returns(listaSelos.Where(p => p.IdCompra == 50));

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.ConsultarPorIdCompraSelo(50);

            //Assert
            Assert.True(retorno.FirstOrDefault().Recibo == 1234);
        }

        [Fact]
        public void AppSelos_ConsultarPorStatusLivre_True()
        {
            //Arrange
            var servico = new Mock<IServicoSelos>();

            var listaSelos = new List<Selos>();

            var selo = new Selos();

            for (int i = 0; i < 100; i++)
            {
                selo = new Selos()
                {
                    IdAto = i,
                    Status = "UTILIZADO"
                };

                if (selo.IdAto == 50)
                    selo.Status = "LIVRE";

                listaSelos.Add(selo);
            }

            servico.Setup(p => p.ConsultarPorStatusLivre()).Returns(listaSelos.Where(p => p.Status == "LIVRE"));

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.ConsultarPorStatusLivre();

            //Assert
            Assert.True(retorno.FirstOrDefault().IdAto == 50);
        }

        [Fact]
        public void AppSelos_ConsultarPorIdSerie_True()
        {
            //Arrange
            var servico = new Mock<IServicoSelos>();

            var listaSelos = new List<Selos>();

            var selo = new Selos();

            for (int i = 0; i < 100; i++)
            {
                selo = new Selos()
                {
                    IdSerie = i,
                    Status = "UTILIZADO"
                };

                if (selo.IdSerie == 50)
                    selo.Status = "LIVRE";

                listaSelos.Add(selo);
            }

            servico.Setup(p => p.ConsultarPorIdSerie(50)).Returns(listaSelos.Where(p => p.IdSerie == 50));

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.ConsultarPorIdSerie(50);

            //Assert
            Assert.True(retorno.FirstOrDefault().Status == "LIVRE");
        }

        [Fact]
        public void AppSelos_ConsultarPorSerieNumero_True()
        {
            var servico = new Mock<IServicoSelos>();

            var selo = new Selos();

            var listaSelos = new List<Selos>();

            for (int i = 0; i < 100; i++)
            {
                selo = new Selos()
                {
                    IdAto = i,
                    Letra = "ABCD",
                    Numero = i,
                    Status = "UTILIZADO"
                };

                if (selo.Numero == 50)
                    selo.Status = "LIVRE";

                listaSelos.Add(selo);
            }

            servico.Setup(p => p.ConsultarPorSerieNumero("ABCD", 50)).Returns(listaSelos.Where(p => p.Letra == "ABCD" && p.Numero == 50).FirstOrDefault());

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.ConsultarPorSerieNumero("ABCD", 50);

            //Assert
            Assert.True(retorno.Status == "LIVRE");
        }

        [Fact]
        public void AppSelos_LiberarSelos_True()
        {

            //Arrange
            var servico = new Mock<IServicoSelos>();

            var selosParaLiberar = new Selos();

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

            servico.Setup(p => p.LiberarSelos(selosParaLiberar)).Returns(selosParaLiberar);

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.LiberarSelos(selosParaLiberar);

            //Assert
            Assert.True(retorno.Status == "LIVRE");
        }

        [Fact]
        public void AppSelos_BaixarSelosManualmente_True()
        {

            //Arrange
            var servico = new Mock<IServicoSelos>();

            var selosParaBaixarManualmente = new Selos();

            var usuario = new Usuario();
            usuario.UsuarioId = 1;
            usuario.NomeUsuario = "ERICK MARCEL DA SILVA CREMONA";
            
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

            servico.Setup(p => p.BaixarSelosManualmente(selosParaBaixarManualmente, usuario)).Returns(selosParaBaixarManualmente);

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.BaixarSelosManualmente(selosParaBaixarManualmente, usuario);

            //Assert
            Assert.True(retorno.Status == "BAIXADO");
        }


        [Fact]
        public void AppSelos_ConsultarPorPeriodo_True()
        {
            var servico = new Mock<IServicoSelos>();

            var selo = new Selos();

            var dataInicio = Convert.ToDateTime("01/01/2016");

            var dataFim = Convert.ToDateTime("31/01/2016");

            var listaSelos = new List<Selos>();

            for (int i = 0; i < 100; i++)
            {
                selo = new Selos()
                {
                    IdAto = i,
                    Letra = "ABCD",
                    Numero = i,
                    Status = "UTILIZADO"
                };

                if (selo.Numero == 50)
                    selo.DataPratica = dataInicio;
                else
                    selo.DataPratica = dataFim;

                listaSelos.Add(selo);
            }

            servico.Setup(p => p.ConsultaPorPeriodo(dataInicio, dataInicio)).Returns(listaSelos.Where(p => p.DataPratica >= dataInicio && p.DataPratica <= dataInicio));

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.ConsultaPorPeriodo(dataInicio, dataInicio);

            //Assert
            Assert.True(retorno.Count() == 1 && retorno.FirstOrDefault().IdAto == 50);
        }

        [Fact]
        public void AppSelos_ObterUltimoIdReservado_True()
        {
            var servico = new Mock<IServicoSelos>();

            var selo = new Selos();

            var dataInicio = Convert.ToDateTime("01/01/2016");

            var dataFim = Convert.ToDateTime("31/01/2016");

            var listaSelos = new List<Selos>();

            for (int i = 0; i < 100; i++)
            {
                selo = new Selos()
                {
                    IdReservado = i,
                    Letra = "ABCD",
                    Numero = i,
                    Status = "UTILIZADO"
                };

                if (selo.Numero == 50)
                    selo.DataPratica = dataInicio;
                else
                    selo.DataPratica = dataFim;

                listaSelos.Add(selo);
            }


            servico.Setup(p => p.ObterUltimoIdReservado()).Returns(listaSelos.LastOrDefault().IdReservado);

            var appServicoSelos = new AppServicoSelos(servico.Object);

            //Act
            var retorno = appServicoSelos.ObterUltimoIdReservado();

            //Assert
            Assert.True(retorno == 99);
        }
    }
}
