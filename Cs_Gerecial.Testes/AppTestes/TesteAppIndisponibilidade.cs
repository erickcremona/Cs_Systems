using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Entities;
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
    public class TesteAppIndisponibilidade
    {
        [Fact]
        public void AppIndisponibilidades_LerArquivoXml_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

            
            var indisponiblidades = new List<Indisponibilidades>();


            var caminho = @"\\SERVIDOR\Arquivos Cartório\Arquivos RGI\CNIB\2016\01_02_2016_MANHÃ";


            for (int i = 0; i < 141; i++)
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
                indisp.Origem = caminho;    
                indisp.Telefone = "telefone";
                indisp.Usuario = "Usuario";


                indisponiblidades.Add(indisp);
            }






            var servicoIndisp = new AppServicoIndisponibilidades(servico.Object);
            servico.Setup(s => s.LerArquivoXml(caminho)).Returns(indisponiblidades);


            // Act
            var retorno = servicoIndisp.LerArquivoXml(caminho);

            // Assert
            Assert.True(retorno.Count() == 141);
        }


        [Fact]
        public void AppIndisponibilidades_ObterArquivosImportados_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

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


            servico.Setup(r => r.ObterArquivosImportados(caminho)).Returns(indisponiblidades.Where(p => p.Origem == caminho));
            var servicoIndisp = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndisp.ObterArquivosImportados(caminho);

            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void AppIndisponibilidades_ObterIndisponibilidadesPorNome_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

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

            servico.Setup(p => p.ObterIndisponibilidadesPorNome(nome)).Returns(indisponiblidades.Where(p => p.NomeIndividuo == nome));
            var servicoIndispo = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesPorNome(nome);


            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void AppIndisponibilidades_ObterIndisponibilidadesCpfCnpj_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

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

            servico.Setup(p => p.ObterIndisponibilidadesCpfCnpj(cpf)).Returns(indisponiblidades.Where(p => p.CpfCnpj == cpf));
            var servicoIndispo = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesCpfCnpj(cpf);


            // Assert
            Assert.True(retorno.Count() == numero);



        }

        [Fact]
        public void AppIndisponibilidades_ObterIndisponibilidadesProtocolo_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

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

            servico.Setup(p => p.ObterIndisponibilidadesProtocolo(protocolo)).Returns(indisponiblidades.Where(p => p.Protocolo == protocolo));
            var servicoIndispo = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesProtocolo(protocolo);


            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void AppIndisponibilidades_ObterIndisponibilidadesNumeroProcesso_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

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

            servico.Setup(p => p.ObterIndisponibilidadesNumeroProcesso(processo)).Returns(indisponiblidades.Where(p => p.NumeroProcesso == processo));
            var servicoIndispo = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndispo.ObterIndisponibilidadesNumeroProcesso(processo);


            // Assert
            Assert.True(retorno.Count() == numero);

        }

        [Fact]
        public void AppIndisponibilidades_ValidarCpf_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

            string cpf = "091.256.007-02";


            servico.Setup(p => p.ValidarCpf(cpf)).Returns(true);
            var servicoIndispo = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndispo.ValidarCpf(cpf);

            // Assert
            Assert.True(retorno == true);
        }


        [Fact]
        public void AppIndisponibilidades_ValidarCnpj_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

            string cnpj = "14.010.885/0001-14";


            servico.Setup(p => p.ValidarCnpj(cnpj)).Returns(true);
            var servicoIndispo = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndispo.ValidarCnpj(cnpj);

            // Assert
            Assert.True(retorno == true);
        }


        [Fact]
        public void AppIndisponibilidades_ValidarEmail_True()
        {
            // Arrange
            var servico = new Mock<IServicoIndisponibilidades>();

            string email = "erick@erick.com";


            servico.Setup(p => p.ValidarEmail(email)).Returns(true);
            var servicoIndispo = new AppServicoIndisponibilidades(servico.Object);

            // Act
            var retorno = servicoIndispo.ValidarEmail(email);

            // Assert
            Assert.True(retorno == true);
        }

    }
}
