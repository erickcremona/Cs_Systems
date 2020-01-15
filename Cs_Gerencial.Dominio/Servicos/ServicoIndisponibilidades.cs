using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Cs_Gerencial.Dominio.Servicos
{
    public class ServicoIndisponibilidades : ServicoBase<Indisponibilidades>, IServicoIndisponibilidades
    {

        private readonly IRepositorioIndisponibilidades _repositorioIndisponibilidades;



        public ServicoIndisponibilidades(IRepositorioIndisponibilidades repositorioIndisponibilidades)
            : base(repositorioIndisponibilidades)
        {
            _repositorioIndisponibilidades = repositorioIndisponibilidades;
        }


        public IEnumerable<Indisponibilidades> LerArquivoXml(string caminho)
        {

            XmlTextReader leituraXml;
            Indisponibilidades indispAdd = new Indisponibilidades();
            List<Indisponibilidades> indisponibilidades;
            indisponibilidades = new List<Indisponibilidades>();

            string leituraAtual = string.Empty;

            leituraXml = new XmlTextReader(caminho);

            while (leituraXml.Read())
            {
                switch (leituraXml.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (leituraXml.Name)
                        {
                            case "CANCELAMENTODEINDISPONIBILIDADE":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "CANCELAMENTO_TIPO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "CANCELAMENTO_DATA":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "PROTOCOLOINDISPONIBILIDADE":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "DATAPEDIDO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "NUMERODOPROCESSO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "TELEFONE":
                                leituraAtual = leituraXml.Name;
                                break;


                            case "NOMEINSTITUICAO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "FORUMVARA":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "USUARIO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "EMAIL":
                                leituraAtual = leituraXml.Name;
                                break;


                            case "CANCELAMENTO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "INDISPONIBILIDADE":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "NOME":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "CPFCNPJ":
                                leituraAtual = leituraXml.Name;
                                break;
                        }



                        break;

                    case XmlNodeType.Text:

                        switch (leituraAtual)
                        {
                            case "CANCELAMENTODEINDISPONIBILIDADE":
                                indispAdd.Cancelamento = leituraXml.Value;
                                indispAdd.Cancelado = "S";
                                break;

                            case "CANCELAMENTO_TIPO":
                                indispAdd.TipoCancelamento = Convert.ToInt32(leituraXml.Value);
                                break;

                            case "CANCELAMENTO_DATA":
                                if (leituraXml.Value != "")
                                    indispAdd.DataCancelamento = leituraXml.Value.Substring(0, 10);
                                if (leituraXml.Value != "")
                                    indispAdd.HoraCancelamento = leituraXml.Value.Substring(11, 8);
                                break;

                            case "PROTOCOLOINDISPONIBILIDADE":
                                indispAdd.Protocolo = leituraXml.Value;
                                break;

                            case "DATAPEDIDO":
                                if (leituraXml.Value != "")
                                {
                                    indispAdd.DataPedido = Convert.ToDateTime(leituraXml.Value).Date;
                                    indispAdd.HoraPedido = leituraXml.Value.Substring(11, 8);
                                    if (indispAdd.Cancelamento == "" || indispAdd.Cancelamento == null)
                                    {
                                        indispAdd.Cancelado = "N";
                                    }
                                }
                                break;

                            case "NUMERODOPROCESSO":
                                indispAdd.NumeroProcesso = leituraXml.Value;
                                break;

                            case "TELEFONE":
                                indispAdd.Telefone = leituraXml.Value;
                                break;

                            case "NOMEINSTITUICAO":
                                indispAdd.NomeInstituicao = leituraXml.Value;
                                break;

                            case "FORUMVARA":
                                indispAdd.ForumVara = leituraXml.Value;
                                break;

                            case "USUARIO":
                                indispAdd.Usuario = leituraXml.Value;
                                break;

                            case "EMAIL":
                                indispAdd.Email = leituraXml.Value;
                                break;

                            case "NOME":
                                indispAdd.NomeIndividuo = leituraXml.Value;
                                break;

                            case "CPFCNPJ":
                                indispAdd.CpfCnpj = leituraXml.Value;
                                break;
                        }

                        break;

                    case XmlNodeType.EndElement:
                        if (leituraXml.Name == "REGISTRO")
                        {

                            indispAdd = new Indisponibilidades();
                        }

                        if (leituraXml.Name == "CPFCNPJ")
                        {

                            FileInfo fi = new FileInfo(caminho);



                            indispAdd.Origem = string.Format("{0}_{1}", fi.Name, fi.LastWriteTime);

                            Indisponibilidades aux = new Indisponibilidades();
                            aux = indispAdd;


                            indisponibilidades.Add(indispAdd);
                            indispAdd = new Indisponibilidades();

                            indispAdd.Cancelamento = aux.Cancelamento;

                           
                            indispAdd.Cancelado = aux.Cancelado;

                            indispAdd.TipoCancelamento = aux.TipoCancelamento;

                            indispAdd.DataCancelamento = aux.DataCancelamento;

                            indispAdd.HoraCancelamento = aux.HoraCancelamento;

                            indispAdd.Protocolo = aux.Protocolo;
                            indispAdd.DataPedido = aux.DataPedido;
                            indispAdd.HoraPedido = aux.HoraPedido;
                            indispAdd.NumeroProcesso = aux.NumeroProcesso;
                            indispAdd.Telefone = aux.Telefone;
                            indispAdd.NomeInstituicao = aux.NomeInstituicao;
                            indispAdd.ForumVara = aux.ForumVara;
                            indispAdd.Usuario = aux.Usuario;
                            indispAdd.Email = aux.Email;
                        }

                        break;
                }
            }

            return indisponibilidades;
        }



        public IEnumerable<Indisponibilidades> ObterArquivosImportados(string arquivo)
        {
            return _repositorioIndisponibilidades.ObterArquivosImportados(arquivo);
        }


        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesPorNome(string nome)
        {
            return _repositorioIndisponibilidades.ObterIndisponibilidadesPorNome(nome);
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesCpfCnpj(string cpfCnpj)
        {
            return _repositorioIndisponibilidades.ObterIndisponibilidadesCpfCnpj(cpfCnpj);
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesProtocolo(string protocolo)
        {
            return _repositorioIndisponibilidades.ObterIndisponibilidadesProtocolo(protocolo);
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesNumeroProcesso(string numeroProcesso)
        {
            return _repositorioIndisponibilidades.ObterIndisponibilidadesNumeroProcesso(numeroProcesso);
        }


        public bool ValidarCpf(string validarCpf)
        {
            return _repositorioIndisponibilidades.ValidarCpf(validarCpf);
        }


        public bool ValidarCnpj(string validarCnpj)
        {
            return _repositorioIndisponibilidades.ValidarCnpj(validarCnpj);
        }


        public bool ValidarEmail(string validarEmail)
        {
            return _repositorioIndisponibilidades.ValidarEmail(validarEmail);
        }
    }
}
