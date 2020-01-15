
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.ValuesObject;
using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cs_Notas.Windows.Escritura
{
    /// <summary>
    /// Lógica interna para Minuta.xaml
    /// </summary>
    public partial class Minuta : Window
    {
        Escrituras _escritura;
        Serventia serventia = new Serventia();
        Pessoas pessoa = new Pessoas();
        Cs_Notas.Dominio.Entities.Usuario escrevente = new Cs_Notas.Dominio.Entities.Usuario();
        List<Nomes> listaNomes = new List<Nomes>();
        private readonly IAppServicoServentia _IAppServicoServentia = BootStrap.Container.GetInstance<IAppServicoServentia>();
        private readonly IAppServicoPessoas _IAppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario _IAppServicoUsuario = BootStrap.Container.GetInstance<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario>();
        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        private readonly IAppServicoNomes _IAppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();

        Configuracoes configuracoes = new Configuracoes();
        List<FileInfo> listaArquivos = new List<FileInfo>();
        public Minuta(Escrituras escritura)
        {
            serventia = _IAppServicoServentia.GetById(0);            
            _escritura = escritura;
            escrevente = _IAppServicoUsuario.GetAll().Where(p => p.Nome == _escritura.EscreventeAtoRegistro).FirstOrDefault();
            configuracoes = _AppServicoConfiguracoes.GetById(1);
            listaNomes = _IAppServicoNomes.ObterNomesPorIdAto(escritura.EscriturasId).ToList();
            InitializeComponent();
        }

        private void BuscaArquivos(DirectoryInfo dir)
        {
            // lista arquivos do diretorio corrente
            foreach (FileInfo file in dir.GetFiles())
            {
                // aqui no caso estou guardando o nome completo do arquivo em em controle ListBox
                // voce faz como quiser
                listaArquivos.Add(file);
            }

            // busca arquivos do proximo sub-diretorio
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                BuscaArquivos(subDir);
            }
        }


        private void btnINovo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                

                listaArquivos = new List<FileInfo>();

                // manipular de diretorios
                DirectoryInfo dirInfo = new DirectoryInfo(@configuracoes.PathEscritura);

                // procurar arquivos
                BuscaArquivos(dirInfo);

                var arquivo = listaArquivos.Where(p => (p.Name == _escritura.EscriturasId.ToString() + ".doc") || (p.Name == _escritura.EscriturasId.ToString() + ".docx")).FirstOrDefault();

                if (arquivo != null)
                {
                    System.Diagnostics.Process.Start(arquivo.FullName);
                }
                else
                {


                    if (_escritura.Descricao != "" && _escritura.Descricao != null)
                    {
                        FileInfo modelo = new FileInfo(configuracoes.PathEscritura + @"\Modelos\" + _escritura.Descricao + ".doc");

                        if (modelo.Exists)
                        {
                            bool retorno = false;

                            System.IO.File.Copy(configuracoes.PathEscritura + @"\Modelos\" + _escritura.Descricao + ".doc", configuracoes.PathEscritura + @"\" + _escritura.EscriturasId + ".doc");


                            if (modelo.Name == "COMPRA E VENDA.doc")
                                retorno = PreencherCompraVenda(configuracoes.PathEscritura + @"\" + _escritura.EscriturasId + ".doc");


                            if (retorno == true)
                                System.Diagnostics.Process.Start(configuracoes.PathEscritura + @"\" + _escritura.EscriturasId + ".doc");
                            else
                                System.IO.File.Delete(configuracoes.PathEscritura + @"\" + _escritura.EscriturasId + ".doc");
                        }
                        else
                        {
                            MessageBox.Show("Não existe um modelo de minuta para " + _escritura.Descricao + ", Favor entrar em contato com a CS_Sistemas.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha o campo Natureza.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }



                }


            }
            catch (Exception) { }

            this.Close();
        }




        private bool PreencherCompraVenda(string caminhoArquivo)
        {
            bool retorno = false;

            object missing = System.Reflection.Missing.Value;

            Microsoft.Office.Interop.Word.Application oApp = new Microsoft.Office.Interop.Word.Application();

            object template = caminhoArquivo;

            Microsoft.Office.Interop.Word.Document oDoc = oApp.Documents.Add(ref template, ref missing, ref missing, ref missing);

            try
            {
                //--------------LIVRO---------------------------
                Microsoft.Office.Interop.Word.Range oRng = oDoc.Range(ref missing, ref missing);
                object FindText = "[livro]";
                object ReplaceWith = string.Format("{0:000}", _escritura.LivroEscritura);
                object MatchWholeWord = true;
                object Forward = false;

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                //----------------FOLHAS INCIO---------------------------
                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[flsIni]";
                ReplaceWith = string.Format("{0:000}", _escritura.FolhasInicio);

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                //-----------------FOLHAS FIM--------------------------
                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[flsFim]";
                ReplaceWith = string.Format("{0:000}", _escritura.FolhasFim);

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                //-----------------NÚMERO ATO--------------------------
                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[ato]";
                ReplaceWith = string.Format("{0:000}", _escritura.NumeroAto);

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                //-----------------DATA POR EXTENSO--------------------------

                CultureInfo culture = new CultureInfo("pt-BR");
                DateTimeFormatInfo dtfi = culture.DateTimeFormat;

                int dia = _escritura.DataAtoRegistro.Date.Day;
                int anoabr = Convert.ToInt16(_escritura.DataAtoRegistro.Date.Year.ToString().Substring(2, 2));
                int ano = _escritura.DataAtoRegistro.Date.Year;
                string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(_escritura.DataAtoRegistro.Date.Month));



                if (dia > 1)
                {

                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[aos]";
                    ReplaceWith = "aos";

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);



                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[diaExtenso]";
                    ReplaceWith = string.Format("{0}", busqueExtenso(dia, " e ")).ToLower();

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[diaNumero]";
                    ReplaceWith = string.Format("{0}", dia);

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[dias]";
                    ReplaceWith = "dias";

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                }
                else
                {
                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[aos]";
                    ReplaceWith = string.Format("ao");

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);



                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[diaExtenso]";
                    ReplaceWith = string.Format("primeiro");

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[diaNumero]";
                    ReplaceWith = string.Format("{0}", dia);

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                    oRng = oDoc.Range(ref missing, ref missing);
                    FindText = "[dias]";
                    ReplaceWith = "dia";

                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                }

                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[mesExtenso]";
                ReplaceWith = string.Format("{0}", mes.ToLower());

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[anoExtenso]";
                ReplaceWith = string.Format("{0}", busqueExtenso(anoabr, " e ")).ToLower();

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[ano]";
                ReplaceWith = string.Format("{0}", ano).ToLower();

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                //----------------------------NOME ESCREVENTE--------------------------------


                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[nomeEscrevente]";
                ReplaceWith = string.Format("{0}", escrevente.Nome);

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[cargo]";
                ReplaceWith = string.Format("{0}", FirstCharToUpper(escrevente.Qualificacao));

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                //----------------------------CARTORIO NOME E ENDEREÇO--------------------------------


                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[nomeCartorio]";
                ReplaceWith = string.Format("{0}", serventia.Descricao);

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                oRng = oDoc.Range(ref missing, ref missing);
                FindText = "[enderecoCartorio]";
                ReplaceWith = string.Format("{0}", serventia.Endereco);

                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);



                //----------------------------OUTORGANTES------------------------------------------------

                
                var listaOutorgantes = listaNomes.Where(p => p.Descricao == "OUTORGANTE").ToList();

                int qtdOutorgantes = listaOutorgantes.Count();

                switch (qtdOutorgantes)
                {
                    case 1:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante10], [nacOutorante10], [estadoCivilOutorgante10], [profissaoOuntorgante10], portadora da carteira de identidade nº [rgOutorgante10], expedida por [orgaoRgOutorgante10], em [emissaoRgOutorgante10], CPF n° [cpfOutorgante10], residente e domiciliado na [enderecoOutorgante10], [bairroOutorgante10], [cidadeOutorgante10]/[ufOutorgante10]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante9], [nacOutorante9], [estadoCivilOutorgante9], [profissaoOuntorgante9], portadora da carteira de identidade nº [rgOutorgante9], expedida por [orgaoRgOutorgante9], em [emissaoRgOutorgante9], CPF n° [cpfOutorgante9], residente e domiciliado na [enderecoOutorgante9], [bairroOutorgante9], [cidadeOutorgante1]/[ufOutorgante9]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante8], [nacOutorante8], [estadoCivilOutorgante8], [profissaoOuntorgante8], portadora da carteira de identidade nº [rgOutorgante8], expedida por [orgaoRgOutorgante8], em [emissaoRgOutorgante8], CPF n° [cpfOutorgante8], residente e domiciliado na [enderecoOutorgante8], [bairroOutorgante8], [cidadeOutorgante1]/[ufOutorgante8]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante7], [nacOutorante7], [estadoCivilOutorgante7], [profissaoOuntorgante7], portadora da carteira de identidade nº [rgOutorgante7], expedida por [orgaoRgOutorgante7], em [emissaoRgOutorgante7], CPF n° [cpfOutorgante7], residente e domiciliado na [enderecoOutorgante7], [bairroOutorgante7], [cidadeOutorgante7]/[ufOutorgante7]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante6], [nacOutorante6], [estadoCivilOutorgante6], [profissaoOuntorgante6], portadora da carteira de identidade nº [rgOutorgante6], expedida por [orgaoRgOutorgante6], em [emissaoRgOutorgante6], CPF n° [cpfOutorgante6], residente e domiciliado na [enderecoOutorgante6], [bairroOutorgante6], [cidadeOutorgante6]/[ufOutorgante6]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante5], [nacOutorante5], [estadoCivilOutorgante5], [profissaoOuntorgante5], portadora da carteira de identidade nº [rgOutorgante5], expedida por [orgaoRgOutorgante5], em [emissaoRgOutorgante5], CPF n° [cpfOutorgante5], residente e domiciliado na [enderecoOutorgante5], [bairroOutorgante5], [cidadeOutorgante5]/[ufOutorgante5]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante1], [nacOutorante1], [estadoCivilOutorgante4], [profissaoOuntorgante4], portadora da carteira de identidade nº [rgOutorgante4], expedida por [orgaoRgOutorgante4], em [emissaoRgOutorgante4], CPF n° [cpfOutorgante4], residente e domiciliado na [enderecoOutorgante4], [bairroOutorgante4], [cidadeOutorgante4]/[ufOutorgante4]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante3], [nacOutorante3], [estadoCivilOutorgante3], [profissaoOuntorgante3], portadora da carteira de identidade nº [rgOutorgante3], expedida por [orgaoRgOutorgante3], em [emissaoRgOutorgante3], CPF n° [cpfOutorgante3], residente e domiciliado na [enderecoOutorgante3], [bairroOutorgante3], [cidadeOutorgante3]/[ufOutorgante3]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante2], [nacOutorante2], [estadoCivilOutorgante2], [profissaoOuntorgante2], portadora da carteira de identidade nº [rgOutorgante2], expedida por [orgaoRgOutorgante2], em [emissaoRgOutorgante2], CPF n° [cpfOutorgante2], residente e domiciliado na [enderecoOutorgante2], [bairroOutorgante2], [cidadeOutorgante2]/[ufOutorgante2]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "[nomeOutorgante1], [nacOutorante1], [estadoCivilOutorgante1], [profissaoOuntorgante1], portadora da carteira de identidade nº [rgOutorgante1], expedida por [orgaoRgOutorgante1], em [emissaoRgOutorgante1], CPF n° [cpfOutorgante1], residente e domiciliado na [enderecoOutorgante1], [bairroOutorgante1], [cidadeOutorgante1]/[ufOutorgante1]; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "[nomeOutorgante" + i + "]";
                            ReplaceWith = string.Format("{0}", listaOutorgantes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaOutorgantes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaOutorgantes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "[qualificacaoOutorgante" + i + "]";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaOutorgantes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaOutorgantes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaOutorgantes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;
                    case 2:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante7>, <qualificacaoOutorgante7>, <enderecoOutorgante7>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante6>, <qualificacaoOutorgante6>, <enderecoOutorgante6>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante5>, <qualificacaoOutorgante5>, <enderecoOutorgante5>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante4>, <qualificacaoOutorgante4>, <enderecoOutorgante4>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante3>, <qualificacaoOutorgante3>, <enderecoOutorgante3>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante2>, <qualificacaoOutorgante2>, <enderecoOutorgante2>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaOutorgantes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaOutorgantes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaOutorgantes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaOutorgantes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaOutorgantes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaOutorgantes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 3:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante7>, <qualificacaoOutorgante7>, <enderecoOutorgante7>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante6>, <qualificacaoOutorgante6>, <enderecoOutorgante6>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante5>, <qualificacaoOutorgante5>, <enderecoOutorgante5>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante4>, <qualificacaoOutorgante4>, <enderecoOutorgante4>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante3>, <qualificacaoOutorgante3>, <enderecoOutorgante3>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);



                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 4:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante7>, <qualificacaoOutorgante7>, <enderecoOutorgante7>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante6>, <qualificacaoOutorgante6>, <enderecoOutorgante6>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante5>, <qualificacaoOutorgante5>, <enderecoOutorgante5>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante4>, <qualificacaoOutorgante4>, <enderecoOutorgante4>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);




                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 5:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante7>, <qualificacaoOutorgante7>, <enderecoOutorgante7>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante6>, <qualificacaoOutorgante6>, <enderecoOutorgante6>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante5>, <qualificacaoOutorgante5>, <enderecoOutorgante5>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);



                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;


                    case 6:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante7>, <qualificacaoOutorgante7>, <enderecoOutorgante7>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante6>, <qualificacaoOutorgante6>, <enderecoOutorgante6>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);




                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 7:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante7>, <qualificacaoOutorgante7>, <enderecoOutorgante7>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);




                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 8:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);



                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 9:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 10:
                        oRng = oDoc.Range(ref missing, ref missing);
                        FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                        ReplaceWith = "";
                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;

                    case 11:

                        for (int i = 0; i < qtdOutorgantes; i++)
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante" + i + ">";
                            ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            if (listaNomes[i].TipoPessoa == "F")
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cpf = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                {
                                    if (pessoa.EsctadoCivil == 2)
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {
                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }
                                else
                                {


                                    EstadoCivil estadoCivil = new EstadoCivil();


                                    if (pessoa.Sexo == "M")
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                    else
                                        estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                }


                            }
                            else
                            {
                                pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                string Cnpj = string.Empty;

                                if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                    Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<qualificacaoOutorgante" + i + ">";
                                ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<enderecoOutorgante" + i + ">";
                                ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            }

                        }


                        break;


                    default:
                        if (qtdOutorgantes > 11)
                        {
                            for (int i = 0; i < 11; i++)
                            {
                                oRng = oDoc.Range(ref missing, ref missing);
                                FindText = "<nomeOutorgante" + i + ">";
                                ReplaceWith = string.Format("{0}", listaNomes[i].Nome);
                                oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                                if (listaNomes[i].TipoPessoa == "F")
                                {
                                    pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                    string Cpf = string.Empty;

                                    if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                        Cpf = string.Format("{0}.{1}.{2}-{3}", pessoa.CpfCgc.Substring(0, 3), pessoa.CpfCgc.Substring(3, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(6, 2));



                                    if (pessoa.EsctadoCivil == 2 || pessoa.EsctadoCivil == 8)
                                    {
                                        if (pessoa.EsctadoCivil == 2)
                                        {
                                            oRng = oDoc.Range(ref missing, ref missing);
                                            FindText = "<qualificacaoOutorgante" + i + ">";

                                            if (pessoa.RegimeBens.ToLower() == "comunhão parcial de bens")
                                            {
                                                ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6}, na vigência da Lei 6.515/77 com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());

                                            }
                                            else
                                            {
                                                ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}, casado pelo regime da {6} com {7}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf, pessoa.RegimeBens.ToLower(), pessoa.Conjuge.ToUpper());

                                            }


                                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                        }
                                        else
                                        {
                                            oRng = oDoc.Range(ref missing, ref missing);
                                            FindText = "<qualificacaoOutorgante" + i + ">";
                                            ReplaceWith = string.Format("{0}, {1}, portador da carteira de identidade nº{2}, expedida pelo(a) {3}, em {4}, inscrito no CPF nº{5}", listaNomes[i].Nacionalidade.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                        }

                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<enderecoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }
                                    else
                                    {


                                        EstadoCivil estadoCivil = new EstadoCivil();


                                        if (pessoa.Sexo == "M")
                                            estadoCivil = estadoCivil.ObterListaEstadoCivil(true).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();
                                        else
                                            estadoCivil = estadoCivil.ObterListaEstadoCivil(false).Where(p => p.Codigo == pessoa.EsctadoCivil).FirstOrDefault();

                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<qualificacaoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("{0}, {1}, {2}, portador da carteira de identidade nº{3}, expedida pelo(a) {4}, em {5}, inscrito no CPF nº{6}", listaNomes[i].Nacionalidade.ToLower(), estadoCivil.Descricao.ToLower(), pessoa.Profissao.ToLower(), pessoa.Rg, pessoa.OrgaoRG, pessoa.DataEmissaoRG.ToShortDateString(), Cpf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                        oRng = oDoc.Range(ref missing, ref missing);
                                        FindText = "<enderecoOutorgante" + i + ">";
                                        ReplaceWith = string.Format("residente e domiciliado(a) na {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                        oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                                    }


                                }
                                else
                                {
                                    pessoa = _IAppServicoPessoas.GetById(listaNomes[i].IdPessoa);
                                    string Cnpj = string.Empty;

                                    if (pessoa.CpfCgc != null && pessoa.CpfCgc != "")
                                        Cnpj = string.Format("{0}.{1}.{2}/{3}-{4}", pessoa.CpfCgc.Substring(0, 2), pessoa.CpfCgc.Substring(2, 3), pessoa.CpfCgc.Substring(5, 3), pessoa.CpfCgc.Substring(8, 4), pessoa.CpfCgc.Substring(12, 2));

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<qualificacaoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("inscrita no CNPJ/MF. Sob o nº{0}", Cnpj);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                    oRng = oDoc.Range(ref missing, ref missing);
                                    FindText = "<enderecoOutorgante" + i + ">";
                                    ReplaceWith = string.Format("com sede à {0}, {1}, {2}-{3}", pessoa.Endereco, pessoa.Bairro, pessoa.Cidade, pessoa.Uf);
                                    oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                                }

                            }
                        }
                        else
                        {
                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante10>, <qualificacaoOutorgante10>, <enderecoOutorgante10>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante9>, <qualificacaoOutorgante9>, <enderecoOutorgante9>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante8>, <qualificacaoOutorgante8>, <enderecoOutorgante8>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante7>, <qualificacaoOutorgante7>, <enderecoOutorgante7>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante6>, <qualificacaoOutorgante6>, <enderecoOutorgante6>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante5>, <qualificacaoOutorgante5>, <enderecoOutorgante5>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante4>, <qualificacaoOutorgante4>, <enderecoOutorgante4>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante3>, <qualificacaoOutorgante3>, <enderecoOutorgante3>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);


                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante2>, <qualificacaoOutorgante2>, <enderecoOutorgante2>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante1>, <qualificacaoOutorgante1>, <enderecoOutorgante1>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);

                            oRng = oDoc.Range(ref missing, ref missing);
                            FindText = "<nomeOutorgante0>, <qualificacaoOutorgante0>, <enderecoOutorgante0>; ";
                            ReplaceWith = "";
                            oRng.Find.Execute(ref FindText, ref missing, ref MatchWholeWord, ref missing, ref missing, ref missing, ref Forward, ref missing, ref missing, ref ReplaceWith, ref missing, ref missing, ref missing, ref missing, ref missing);
                        }
                        break;



                }


                int qtdOutorgados = listaNomes.Where(p => p.Descricao == "OUTORGADO").Count();


                //---------------SALVAR MINUTA---------------------
                object fileName = caminhoArquivo;
                oApp.ActiveDocument.SaveAs(ref fileName,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing);

                retorno = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir a Minuta. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return retorno;
            }
            return retorno;
        }





        private void btnAnexarMinuta_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Create OpenFileDialog

                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



                // Set filter for file extension and default file extension

                dlg.DefaultExt = ".doc";

                dlg.Filter = "Word files (*.doc, *.docx) | *.doc; *.docx";



                // Display OpenFileDialog by calling ShowDialog method

                Nullable<bool> result = dlg.ShowDialog();



                // Get the selected file name and display in a TextBox

                if (result == true)
                {

                    // Open document

                    string filename = dlg.FileName;


                    string path = configuracoes.PathEscritura + @"\" + _escritura.EscriturasId + ".doc";

                    FileInfo alterar = new FileInfo(path);
                    
                    if (alterar.Exists)
                        alterar.Delete();


                    System.IO.File.Copy(filename, path);

                    System.Diagnostics.Process.Start(path);


                }
            }
            catch (Exception) { }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

            if (serventia == null)
            {
                MessageBox.Show("Configure no Gerencial o Cadastro da Serventia Corretamente.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                this.Close();
            }


            FileInfo arquivo = new FileInfo(configuracoes.PathEscritura + @"\" + _escritura.EscriturasId + ".doc");

            if (arquivo.Exists)
                btnExcluirMinuta.IsEnabled = true;
            else
                btnExcluirMinuta.IsEnabled = false;


        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("Insira uma palavra diferente de nula ou vazia");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        public static string busqueExtenso(int valor, string separador)
        {

            if (valor < 20)
            {
                return (RetorneValorString(valor));
            }


            if (valor > 19)
            {
                int len = valor.ToString().Length;

                if (len == 2)
                {
                    int ValorPrimario = int.Parse(valor.ToString().Substring(0, 1));
                    int ValorSecundario = int.Parse(valor.ToString().Substring(1, 1));
                    ValorPrimario = ValorPrimario * 10;
                    return (RetorneValorString(ValorPrimario) + (ValorSecundario > 0 ? separador + RetorneValorString(ValorSecundario) : ""));
                }
                else if (len == 3)
                {
                    int ValorPrimario = int.Parse(valor.ToString().Substring(0, 1));
                    int ValorSecundario = int.Parse(valor.ToString().Substring(1, 1));
                    int ValorTerciario = int.Parse(valor.ToString().Substring(2, 1));

                    ValorPrimario = ValorPrimario * 100;
                    ValorSecundario = ValorSecundario * 10;


                    return (RetorneValorString(ValorPrimario)
                                      + (ValorSecundario > 0 ? separador + RetorneValorString(ValorSecundario) : "")
                                      + (ValorTerciario > 0 ? separador + RetorneValorString(ValorTerciario) : ""));
                }
            }

            return "";

        }


        public static string RetorneValorString(int identificador)
        {
            switch (identificador)
            {
                case 1: return "Um";
                case 2: return "Dois";
                case 3: return "Tres";
                case 4: return "Quatro";
                case 5: return "Cinco";
                case 6: return "Seis";
                case 7: return "Sete";
                case 8: return "Oito";
                case 9: return "Nove";

                case 10: return "Dez";
                case 11: return "Onze";
                case 12: return "Doze";
                case 13: return "Treze";
                case 14: return "Quatorze";
                case 15: return "Quinze";
                case 16: return "Dezesseis";
                case 17: return "Dezessete";
                case 18: return "Dezoito";
                case 19: return "Dezenove";

                case 20: return "Vinte";
                case 30: return "Trinta";
                case 40: return "Quarenta";
                case 50: return "Cinquenta";
                case 60: return "Sessenta";
                case 70: return "Setenta";
                case 80: return "Oitenta";
                case 90: return "Noventa";

                case 100: return "Cem";
                case 200: return "Duzentos";
                case 300: return "Trezentos";
                case 400: return "Quatrocentos";
                case 500: return "Quinhentos";
                case 600: return "Seicentos";
                case 700: return "Setecentos";
                case 800: return "Oitocentos";
                case 900: return "Novecentos";


                default: return "Valor inválido";
            }

        }

        private void btnExcluirMinuta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileInfo excluir = new FileInfo(configuracoes.PathEscritura + @"\" + _escritura.EscriturasId + ".doc");

                if (MessageBox.Show("Deseja realmente excluir esta minuta?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (excluir.Exists)
                    {
                        excluir.Delete();
                        btnExcluirMinuta.IsEnabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Minuta não existe.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                        btnExcluirMinuta.IsEnabled = false;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível excluir a minuta. Verifique se encontra-se aberta nesta ou em outra máquina.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
