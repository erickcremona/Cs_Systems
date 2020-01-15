using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Dominio.Interfaces.Repositorios;
using Cs_IssPrefeitura.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cs_IssPrefeitura.Dominio.Servicos
{
    public class ServicoAtoIss: ServicoBase<AtoIss>, IServicoAtoIss
    {
        private readonly IRepositorioAtoIss _repositorioAtoIss;

        public ServicoAtoIss(IRepositorioAtoIss repositorioAtoIss)
            :base(repositorioAtoIss)
        {
            _repositorioAtoIss = repositorioAtoIss;
        }

        public AtoIss CalcularValoresAtoIss(AtoIss atoCalcular)
        {
            int index;
            string Siss = "0,00";
            decimal iss = 0;
            decimal aliquota = _repositorioAtoIss.AliquotaIss();

            try
            {
                if (atoCalcular.Emolumentos > 0)
                {

                    if (_repositorioAtoIss.TipoCalculoIss() == "Com Fórmula")
                    {
                        iss = atoCalcular.Emolumentos / ((100M - aliquota) / 100M);
                        iss = iss - atoCalcular.Emolumentos;
                    }
                    else
                    {
                        iss = (atoCalcular.Emolumentos * aliquota) / 100M;
                    }


                    Siss = Convert.ToString(iss);

                    index = Siss.IndexOf(',');
                    if (Siss.Length - index > 2)
                        Siss = Siss.Substring(0, index + 3);

                    atoCalcular.Iss = Convert.ToDecimal(Siss);



                    atoCalcular.Total = atoCalcular.Emolumentos + atoCalcular.Acoterj + atoCalcular.Distribuidor + atoCalcular.Fetj + atoCalcular.Funarpen + atoCalcular.Fundperj +
                        atoCalcular.Funperj + atoCalcular.Iss + atoCalcular.Mutua + atoCalcular.Ressag;
                }
                else
                {
                    atoCalcular.Iss = 0;
                    atoCalcular.Total = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return atoCalcular;
        }



        public List<AtoIss> LerArquivoXml(string caminho)
        {
            XmlTextReader leituraXml;
            var AtoAdd = new AtoIss();
            var AtosImpotados = new List<AtoIss>();

            string leituraAtual = string.Empty;

            leituraXml = new XmlTextReader(caminho);

            leituraXml.ReadToFollowing("Relatorio");
            string data = leituraXml.GetAttribute("DataPratica");

            while (leituraXml.Read())
            {
                switch (leituraXml.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (leituraXml.Name)
                        {

                            case "DESC_ATRIBUICAO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "CD_SELO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "CD_ALEATORIO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "DESC_TIPO_ATO":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "CD_TIPO_COBRANCA":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "VALOR_EMOLUMENTOS":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "FETJ":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "FUNDPERJ":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "FUNPERJ":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "FUNARPEN":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "RESSAG":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "MUTUA":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "ACOTERJ":
                                leituraAtual = leituraXml.Name;
                                break;

                            case "DISTRIBUIDOR":
                                leituraAtual = leituraXml.Name;
                                break;
                        }

                        break;

                    case XmlNodeType.Text:

                        switch (leituraAtual)
                        {
                            case "DESC_ATRIBUICAO":
                                AtoAdd.Atribuicao = leituraXml.Value;
                                break;

                            case "CD_SELO":
                                AtoAdd.Selo = leituraXml.Value;
                                break;

                            case "CD_ALEATORIO":
                                AtoAdd.Aleatorio = leituraXml.Value;
                                break;

                            case "DESC_TIPO_ATO":
                                AtoAdd.TipoAto = leituraXml.Value;
                                break;

                            case "CD_TIPO_COBRANCA":
                                AtoAdd.TipoCobranca = leituraXml.Value;
                                break;

                            case "VALOR_EMOLUMENTOS":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Emolumentos = Convert.ToDecimal(valor);
                                }
                                break;

                            case "FETJ":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Fetj = Convert.ToDecimal(valor);
                                }
                                break;

                            case "FUNDPERJ":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Fundperj = Convert.ToDecimal(valor);
                                }
                                break;

                            case "FUNPERJ":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Funperj = Convert.ToDecimal(valor);
                                }
                                break;

                            case "FUNARPEN":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Funarpen = Convert.ToDecimal(valor);
                                }
                                break;

                            case "RESSAG":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Ressag = Convert.ToDecimal(valor);
                                }
                                break;

                            case "MUTUA":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Mutua = Convert.ToDecimal(valor);
                                }
                                break;

                            case "ACOTERJ":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Acoterj = Convert.ToDecimal(valor);
                                }
                                break;

                            case "DISTRIBUIDOR":
                                if (leituraXml.Value != "" && leituraXml.Value != null)
                                {
                                    var valor = leituraXml.Value.Replace('.', ',');
                                    AtoAdd.Distribuidor = Convert.ToDecimal(valor);
                                }
                                break;
                        }

                        break;

                    case XmlNodeType.EndElement:
                        if (leituraXml.Name == "ItemRelatorio")
                        {
                            AtoAdd.Data = Convert.ToDateTime(data);
                            AtosImpotados.Add(AtoAdd);

                            AtoAdd = new AtoIss();

                        }


                        break;
                }
            }

            return AtosImpotados;
        }


        public List<string> CarregarListaAtribuicoes()
        {
            return _repositorioAtoIss.CarregarListaAtribuicoes();
        }


        public List<string> CarregarListaTipoAtos()
        {
            return _repositorioAtoIss.CarregarListaTipoAtos();
        }


        public List<AtoIss> ListarAtosPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _repositorioAtoIss.ListarAtosPorPeriodo(inicio, fim);
        }

        public List<AtoIss> VerificarRegistrosExistentesPorData(DateTime data)
        {
            return _repositorioAtoIss.VerificarRegistrosExistentesPorData(data);
        }


        public List<AtoIss> ConsultaDetalhada(string tipoConsulta, string dados)
        {
            return _repositorioAtoIss.ConsultaDetalhada(tipoConsulta, dados);
        }
    }
}
