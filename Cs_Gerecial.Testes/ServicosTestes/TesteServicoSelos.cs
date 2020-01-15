using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Entities_Fracas;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Cs_Gerencial.Dominio.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace Cs_Gerecial.Testes.ServicosTestes
{
    public class TesteServicoSelos
    {
        [Fact]
        public void ServicoSelos_LerArquivoCompraSelo_True()
        {
            // Arrange
            LeituraArquivoSeloComprado retornoLeitura = new LeituraArquivoSeloComprado();

            var caminho = @"C:\Users\erick\Desktop\Cs_Sistemas\Cs_Gerecial.Testes\ArquivosTeste\ArquivoSelos04318121520160901.XML";

            var leituraXml = new XmlTextReader(caminho);

            retornoLeitura.Arquivo = "ArquivoSelos04318121520160901.XML";

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
                                            if (leituraXml.Value != "")
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
           
            // Assert
            Assert.True(retornoLeitura.Quantidade == 240);

        }

        [Fact]
        public void ServicoSelos_ConsultarPorIdCompraSelo_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioSelos>();

            var listaSelos = new List<Selos>();

            var Selo = new Selos();

            for (int i = 0; i < 100; i++)
            {
                Selo = new Selos()
                {
                    IdCompra = i
                };

                listaSelos.Add(Selo);
            }

            repositorio.Setup(p => p.ConsultarPorIdCompraSelo(50)).Returns(listaSelos.Where(p => p.IdCompra == 50));

            var servicoSelos = new ServicoSelos(repositorio.Object);

            //Act
            var retorno = servicoSelos.ConsultarPorIdCompraSelo(50);

            //Assert
            Assert.True(retorno.FirstOrDefault().IdCompra == 50);
        }

        [Fact]
        public void ServicoSelos_ConsultarPorStatusLivre_True()
        {
            //Arrange
            var repositorio = new Mock<IRepositorioSelos>();

            var listaSelos = new List<Selos>();

            var Selos = new Selos();

            for (int i = 0; i < 100; i++)
            {
                Selos = new Selos()
                {
                    SeloId = i,
                    Status = "UTILIZADO"

                };

                if (i == 50)
                    Selos.Status = "LIVRE";

                listaSelos.Add(Selos);

            }

            repositorio.Setup(p => p.ConsultarPorStatusLivre()).Returns(listaSelos.Where(p => p.SeloId == 50));

            var servicoSelos = new ServicoSelos(repositorio.Object);

            //Act
            var retorno = servicoSelos.ConsultarPorStatusLivre();

            //Assert
            Assert.True(retorno.FirstOrDefault().Status == "LIVRE");
        }

        [Fact]
        public void ServicoSelos_ConsultarPorIdSerie_True()
        {
            //Arrange
            var repositorio = new Mock<IRepositorioSelos>();

            var listaSelos = new List<Selos>();

            var Selos = new Selos();

            for (int i = 0; i < 100; i++)
            {
                Selos = new Selos()
                {
                    SeloId = i,
                    IdSerie = i + 1,
                    Status = "UTILIZADO"
                };

                if (Selos.IdSerie == 50)
                    Selos.Status = "LIVRE";

                listaSelos.Add(Selos);
            }

            repositorio.Setup(p => p.ConsultarPorIdSerie(50)).Returns(listaSelos.Where(p => p.IdSerie == 50));

            var servicoSelos = new ServicoSelos(repositorio.Object);

            //Act
            var retorno = servicoSelos.ConsultarPorIdSerie(50);

            //Assert
            Assert.True(retorno.FirstOrDefault().Status == "LIVRE");
        }

        [Fact]
        public void ServicoSelos_ConsultarPorSerieNumero_True()
        {
            //Arrange
            var repositorio = new Mock<IRepositorioSelos>();

            var listaSelos = new List<Selos>();

            var Selos = new Selos();

            for (int i = 0; i < 100; i++)
            {
                Selos = new Selos()
                {
                    SeloId = i,
                    IdSerie = i + 1,
                    Status = "UTILIZADO",
                    Numero = i,
                    Letra = "ABCD"
                };

                if (Selos.Numero == 50)
                    Selos.Status = "LIVRE";

                listaSelos.Add(Selos);
            }

            repositorio.Setup(p => p.ConsultarPorSerieNumero("ABCD", 50)).Returns(listaSelos.Where(p => p.Letra == "ABCD" && p.Numero == 50).FirstOrDefault());

            var servicoSelos = new ServicoSelos(repositorio.Object);

            //Act
            var retorno = servicoSelos.ConsultarPorSerieNumero("ABCD", 50);

            //Assert
            Assert.True(retorno.Status == "LIVRE");
        }                
    }
}
