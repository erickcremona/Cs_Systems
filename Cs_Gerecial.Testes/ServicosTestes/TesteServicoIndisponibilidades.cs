using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cs_Gerecial.Testes.ServicosTestes
{
    public class TesteServicoIndisponibilidades
    {

        [Fact]
        public void ServicoIndisponibilidades_LerArquivoXml_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            var caminho = @"C:\Users\erick\Desktop\Cs_Sistemas\Cs_Gerecial.Testes\ArquivosTeste\01_02_2016_MANHÃ.xml";
            var servicoIndisp = new ServicoIndisponibilidades(repositorio.Object);


            // Act
            var retorno = servicoIndisp.LerArquivoXml(caminho);

            // Assert
            Assert.True(retorno.Count() == 141);
        }


        [Fact]
        public void ServicoIndisponibilidades_ObterArquivosImportados_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            var indisponiblidades = new List<Indisponibilidades>();

            var numero = 50;

            var caminho = @"\\SERVIDOR\Arquivos Cartório\Arquivos RGI\CNIB\2016\01_02_2016_MANHÃ";


            for (int i = 0; i < 100; i++)
            {
                var indisp = new Indisponibilidades();

                indisp.Protocolo = "0" + i;
                indisp.Cancelado = "N";
                indisp.CpfCnpj = "091.256.007-02";
                indisp.DataPedido = DateTime.Now.Date;
                indisp.Email = "erick@erick.com";
                indisp.ForumVara = "Forum/Vara";
                indisp.HoraPedido = "11:30:00";
                indisp.IndisponibilidadeId = i;
                indisp.NomeIndividuo = "Nome Individuo";
                indisp.NomeInstituicao = "Nome instituição";
                indisp.NumeroProcesso = "00225000" + i;

                if (i < numero)
                {
                    indisp.Origem = caminho;
                }
                else
                {
                    indisp.Origem = caminho + i;
                }

                indisp.Telefone = "telefone";
                indisp.Usuario = "Usuario";


                indisponiblidades.Add(indisp);
            }


            repositorio.Setup(r => r.ObterArquivosImportados(caminho)).Returns(indisponiblidades.Where(p => p.Origem == caminho));
            var servicoIndisp = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndisp.ObterArquivosImportados(caminho);

            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void ServicoIndisponibilidades_ObterIndisponibilidadesPorNome_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            var numero = 10;

            var nome = "Erick Marcel";

            var indisponiblidades = new List<Indisponibilidades>();

            for (int i = 0; i < 100; i++)
            {
                var indisp = new Indisponibilidades();

                indisp.Protocolo = "0" + i;
                indisp.Cancelado = "N";
                indisp.CpfCnpj = "091.256.007-02";
                indisp.DataPedido = DateTime.Now.Date;
                indisp.Email = "erick@erick.com";
                indisp.ForumVara = "Forum/Vara";
                indisp.HoraPedido = "11:30:00";
                indisp.IndisponibilidadeId = i;

                if (i < numero)
                    indisp.NomeIndividuo = nome;
                else
                    indisp.NomeIndividuo = "Nome Individuo " + 1;

                indisp.NomeInstituicao = "Nome instituição";
                indisp.NumeroProcesso = "00225000" + i;
                indisp.Origem = @"\\SERVIDOR\Arquivos Cartório\Arquivos RGI\CNIB\2016\01_02_2016_MANHÃ";
                indisp.Telefone = "telefone";
                indisp.Usuario = "Usuario";

                indisponiblidades.Add(indisp);
            }

            repositorio.Setup(p => p.ObterIndisponibilidadesPorNome(nome)).Returns(indisponiblidades.Where(p => p.NomeIndividuo == nome));
            var servicoIndispo = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesPorNome(nome);


            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void ServicoIndisponibilidades_ObterIndisponibilidadesCpfCnpj_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            var numero = 10;

            var nome = "Erick Marcel";

            var cpf = "091.256.007-02";

            var cnpj = "14.010.885/0001-14";

            var indisponiblidades = new List<Indisponibilidades>();

            for (int i = 0; i < 100; i++)
            {
                var indisp = new Indisponibilidades();

                indisp.Protocolo = "0" + i;
                indisp.Cancelado = "N";

                if (i < numero)
                    indisp.CpfCnpj = cpf;
                else
                    indisp.CpfCnpj = cnpj;

                indisp.DataPedido = DateTime.Now.Date;
                indisp.Email = "erick@erick.com";
                indisp.ForumVara = "Forum/Vara";
                indisp.HoraPedido = "11:30:00";
                indisp.IndisponibilidadeId = i;
                indisp.NomeIndividuo = nome;
                indisp.NomeInstituicao = "Nome instituição";
                indisp.NumeroProcesso = "00225000" + i;
                indisp.Origem = @"\\SERVIDOR\Arquivos Cartório\Arquivos RGI\CNIB\2016\01_02_2016_MANHÃ";
                indisp.Telefone = "telefone";
                indisp.Usuario = "Usuario";


                indisponiblidades.Add(indisp);
            }

            repositorio.Setup(p => p.ObterIndisponibilidadesCpfCnpj(cpf)).Returns(indisponiblidades.Where(p => p.CpfCnpj == cpf));
            var servicoIndispo = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesCpfCnpj(cpf);


            // Assert
            Assert.True(retorno.Count() == numero);

            
           
        }

        [Fact]
        public void ServicoIndisponibilidades_ObterIndisponibilidadesProtocolo_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            var numero = 10;

            var nome = "Erick Marcel";

            var cpf = "091.256.007-02";

            var protocolo = "1234555555555";

            var indisponiblidades = new List<Indisponibilidades>();

            for (int i = 0; i < 100; i++)
            {
                var indisp = new Indisponibilidades();
                if (i < numero)
                    indisp.Protocolo = protocolo;
                else
                    indisp.Protocolo = "0" + i;

                indisp.Cancelado = protocolo + i;
                indisp.CpfCnpj = cpf;
                indisp.DataPedido = DateTime.Now.Date;
                indisp.Email = "erick@erick.com";
                indisp.ForumVara = "Forum/Vara";
                indisp.HoraPedido = "11:30:00";
                indisp.IndisponibilidadeId = i;
                indisp.NomeIndividuo = nome;
                indisp.NomeInstituicao = "Nome instituição";
                indisp.NumeroProcesso = "00225000" + i;
                indisp.Origem = @"\\SERVIDOR\Arquivos Cartório\Arquivos RGI\CNIB\2016\01_02_2016_MANHÃ";
                indisp.Telefone = "telefone";
                indisp.Usuario = "Usuario";


                indisponiblidades.Add(indisp);
            }

            repositorio.Setup(p => p.ObterIndisponibilidadesProtocolo(protocolo)).Returns(indisponiblidades.Where(p => p.Protocolo == protocolo));
            var servicoIndispo = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesProtocolo(protocolo);


            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void ServicoIndisponibilidades_ObterIndisponibilidadesNumeroProcesso_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            var numero = 10;

            var nome = "Erick Marcel";

            var cpf = "091.256.007-02";

            var protocolo = "1234555555555";

            var processo = "2525652333";

            var indisponiblidades = new List<Indisponibilidades>();

            for (int i = 0; i < 100; i++)
            {
                var indisp = new Indisponibilidades();
                
                    indisp.Protocolo = protocolo;
                

                indisp.Cancelado = protocolo + i;
                indisp.CpfCnpj = cpf;
                indisp.DataPedido = DateTime.Now.Date;
                indisp.Email = "erick@erick.com";
                indisp.ForumVara = "Forum/Vara";
                indisp.HoraPedido = "11:30:00";
                indisp.IndisponibilidadeId = i;
                indisp.NomeIndividuo = nome;
                indisp.NomeInstituicao = "Nome instituição";
                if (i < numero)
                    indisp.NumeroProcesso = processo;
                else
                    indisp.NumeroProcesso = processo + i;
                indisp.Origem = @"\\SERVIDOR\Arquivos Cartório\Arquivos RGI\CNIB\2016\01_02_2016_MANHÃ";
                indisp.Telefone = "telefone";
                indisp.Usuario = "Usuario";


                indisponiblidades.Add(indisp);
            }

            repositorio.Setup(p => p.ObterIndisponibilidadesNumeroProcesso(processo)).Returns(indisponiblidades.Where(p => p.NumeroProcesso == processo));
            var servicoIndispo = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesNumeroProcesso(processo);


            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void ServicoIndisponibilidades_ValidarCpf_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            string cpf = "091.256.007-02";

            
            repositorio.Setup(p => p.ValidarCpf(cpf)).Returns(true);
            var servicoIndispo = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndispo.ValidarCpf(cpf);

            // Assert
            Assert.True(retorno == true);
        }


        [Fact]
        public void ServicoIndisponibilidades_ValidarCnpj_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            string cnpj = "14.010.885/0001-14";


            repositorio.Setup(p => p.ValidarCnpj(cnpj)).Returns(true);
            var servicoIndispo = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndispo.ValidarCnpj(cnpj);

            // Assert
            Assert.True(retorno == true);
        }


        [Fact]
        public void ServicoIndisponibilidades_ValidarEmail_True()
        {
            // Arrange
            var repositorio = new Mock<IRepositorioIndisponibilidades>();

            string email = "erick@erick.com";


            repositorio.Setup(p => p.ValidarEmail(email)).Returns(true);
            var servicoIndispo = new ServicoIndisponibilidades(repositorio.Object);

            // Act
            var retorno = servicoIndispo.ValidarEmail(email);

            // Assert
            Assert.True(retorno == true);
        }
    }
}
