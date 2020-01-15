using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows.Escritura;
using Cs_Notas.WindowsAgurde;
using System;
using System.Collections.Generic;
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

namespace Cs_Notas.Windows.Procuracao
{
    /// <summary>
    /// Lógica interna para ConsultaAtosProcuracao.xaml
    /// </summary>
    public partial class ConsultaAtosProcuracao : Window
    {

        List<CadProcuracao> listaCadProcuracao = new List<CadProcuracao>();
        Usuario _usuario;

        List<FileInfo> listaArquivos = new List<FileInfo>();
        Configuracoes configuracoes = new Configuracoes();

        private readonly IAppServicoCadProcuracao _IAppServicoCadProcuracao = BootStrap.Container.GetInstance<IAppServicoCadProcuracao>();
        private readonly IAppServicoAtoConjuntos _IAppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoNomes _IAppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoSelos _IAppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoConfiguracoes _AppServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        public ConsultaAtosProcuracao(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbTipoConsulta.SelectedIndex = 0;
            dpInicio.SelectedDate = DateTime.Now.AddDays(-30).Date;
            dpFim.SelectedDate = DateTime.Now.Date;

            Consultar();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }


        private void btnConsultarAto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Consultar()
        {

            switch (cmbTipoConsulta.SelectedIndex)
            {
                case 0:
                    ConsultarPorPeriodo();
                    break;

                case 1:
                    ConsultarPorLivro();
                    break;

                case 2:
                    ConsultarPorAto();
                    break;

                case 3:
                    ConsultarPorSelo();
                    break;

                case 4:
                    ConsultarPorParticipante();
                    break;

                default:

                    break;
            }

            dataGridConsultarAtos.ItemsSource = listaCadProcuracao;
            dataGridConsultarAtos.SelectedIndex = 0;
        }


        private void ConsultarPorParticipante()
        {
            var Nomes = _IAppServicoNomes.ObterNomesPorNome(txtConsultar.Text.Trim());
            var idsAto = Nomes.Select(p => p.IdEscritura).ToList();


            if (txtConsultar.Text != "")
            {
                listaCadProcuracao = new List<CadProcuracao>();

                for (int i = 0; i < idsAto.Count; i++)
                {
                    var procuracao = _IAppServicoCadProcuracao.GetById(idsAto[i]);

                    if (procuracao != null)
                        listaCadProcuracao.Add(procuracao);

                }

            }
        }

        private void ConsultarPorSelo()
        {
            if (txtConsultar.Text != "")
                listaCadProcuracao = _IAppServicoCadProcuracao.ObterProcuracaoPorSelo(txtConsultar.Text);
        }



        private void ConsultarPorAto()
        {
            if (txtConsultar.Text != "")
                listaCadProcuracao = _IAppServicoCadProcuracao.ObterProcuracaoPorAto(Convert.ToInt16(txtConsultar.Text));
        }

        private void ConsultarPorLivro()
        {
            listaCadProcuracao = _IAppServicoCadProcuracao.ObterProcuracaoPorLivro(txtConsultar.Text);
        }



        private void ConsultarPorPeriodo()
        {
            if (dpInicio.SelectedDate == null)
            {
                MessageBox.Show("Informe a Data Início Válida.", "Data Início", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (dpFim.SelectedDate == null)
                dpFim.SelectedDate = dpInicio.SelectedDate;


            if (dpInicio.SelectedDate > dpFim.SelectedDate)
                dpFim.SelectedDate = dpInicio.SelectedDate;

            listaCadProcuracao = _IAppServicoCadProcuracao.ObterProcuracaoPorPeriodo(dpInicio.SelectedDate.Value, dpFim.SelectedDate.Value);
        }

        private void cmbTipoConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoConsulta.SelectedIndex == 0)
            {
                dpInicio.Visibility = Visibility.Visible;
                lblInicio.Visibility = Visibility.Visible;
                dpFim.Visibility = Visibility.Visible;
                lblFim.Visibility = Visibility.Visible;


                txtConsultar.Visibility = Visibility.Hidden;
            }
            else
            {


                switch (cmbTipoConsulta.SelectedIndex)
                {

                    case 1:
                        txtConsultar.MaxLength = 6;
                        break;

                    case 2:
                        txtConsultar.MaxLength = 4;
                        break;

                    case 3:
                        txtConsultar.MaxLength = 9;
                        break;

                    case 4:
                        txtConsultar.MaxLength = 100;
                        break;

                    default:
                        txtConsultar.MaxLength = 100;
                        break;
                }



                dpInicio.Visibility = Visibility.Hidden;
                lblInicio.Visibility = Visibility.Hidden;
                dpFim.Visibility = Visibility.Hidden;
                lblFim.Visibility = Visibility.Hidden;

                txtConsultar.Visibility = Visibility.Visible;
                txtConsultar.Text = "";
                txtConsultar.Focus();
            }
        }

        private void cmbTipoConsulta_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridConsultarAtos_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridConsultarAtos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregarGridParticipante();
        }

        private void CarregarGridParticipante()
        {
            try
            {
                var procuracao = (CadProcuracao)dataGridConsultarAtos.SelectedItem;

                if (procuracao == null)
                {
                    dataGridParticipantes.ItemsSource = null;

                }
                else
                {
                    var nomes = _IAppServicoNomes.ObterNomesPorIdProcuracao(procuracao.ProcuracaoId).ToList();
                    dataGridParticipantes.ItemsSource = nomes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridConsultarAtos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ConsultarAto();
        }


        private void ConsultarAto()
        {
            var procuracao = (CadProcuracao)dataGridConsultarAtos.SelectedItem;

            var digitarEscritura = new DigitarProcuracao(procuracao, _usuario, false);
            digitarEscritura.Owner = this;
            digitarEscritura.ShowDialog();

            dataGridConsultarAtos.SelectedItem = procuracao;
            dataGridConsultarAtos.Items.Refresh();

            CarregarGridParticipante();
        }

        private void dataGridParticipantes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }



        private void btnMinuta_Click_1(object sender, RoutedEventArgs e)
        {

            //var _procuracao = (CadProcuracao)dataGridConsultarAtos.SelectedItem;

            //configuracoes = _AppServicoConfiguracoes.GetById(1);

            //listaArquivos = new List<FileInfo>();

            //// manipular de diretorios
            //DirectoryInfo dirInfo = new DirectoryInfo(@configuracoes.PathEscritura);

            //// procurar arquivos
            //BuscaArquivos(dirInfo);

            //var arquivo = listaArquivos.Where(p => (p.Name == _procuracao.ProcuracaoId.ToString() + ".doc") || (p.Name == _procuracao.ProcuracaoId.ToString() + ".docx")).FirstOrDefault();


            //var minuta = new Minuta(_procuracao);
            //minuta.Owner = this;
            //minuta.ShowDialog();

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

        private void btnAlterarAto_Click(object sender, RoutedEventArgs e)
        {
            ConsultarAto();
        }

        private void txtConsultar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (cmbTipoConsulta.SelectedIndex == 2)
                DigitarSomenteNumeros(sender, e);

            if (e.Key == Key.Enter)
                btnConsultarAto.Focus();
        }

        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void btnExcluirAto_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir este ato?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;


            bool liberarSelo = false;

            if (MessageBox.Show("Deseja liberar o selo no Gerencial?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                liberarSelo = true;




            if (MessageBox.Show("Confirma a exclusão deste ato?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;


            var procuracao = (CadProcuracao)dataGridConsultarAtos.SelectedItem;

            if (procuracao != null)
            {
                var aguarde = new AguardeExcluirProcuracao(procuracao, liberarSelo);
                aguarde.Owner = this;
                aguarde.ShowDialog();

            }


            try
            {
                Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnComplemento_Click(object sender, RoutedEventArgs e)
        {

            var procuracao = (CadProcuracao)dataGridConsultarAtos.SelectedItem;

            if (procuracao != null)
            {
                var complemento = new Complemento(procuracao, _usuario);
                complemento.Owner = this;
                complemento.ShowDialog();

            }


        }

        private void btnSelarAto_Click(object sender, RoutedEventArgs e)
        {
            SelarAtoSelecionado();
        }

        private void MenuItemRemoverSelo_Click(object sender, RoutedEventArgs e)
        {
            RemoverSeloDoAto();
        }


        private void SelarAtoSelecionado()
        {
            try
            {
                configuracoes = _AppServicoConfiguracoes.GetById(1);

                var procuracao = (CadProcuracao)dataGridConsultarAtos.SelectedItem;

                if (procuracao != null)
                {

                    if (procuracao.Selo == null || procuracao.Selo == "")
                    {

                        var atoConjunto = _IAppServicoAtoConjuntos.ObterAtosConjuntosPorIdProcuracao(procuracao.ProcuracaoId).ToList();

                        DateTime data = DateTime.Now.Date;

                        var seloPrincipal = _IAppServicoSelos.ReservarSelos(configuracoes.SerieAtual, 1, "PROCURAÇÃO", _usuario.UsuarioId, _usuario.Nome, data, 2, procuracao.Livro, procuracao.FolhaInicio, procuracao.FolhaFim, procuracao.NumeroAto);

                        for (int i = 0; i < seloPrincipal.Count; i++)
                        {

                            seloPrincipal[i].DataReservado = data;
                            seloPrincipal[i].FormReservado = "Consulta Atos";
                            seloPrincipal[i].Reservado = "N";
                            seloPrincipal[i].Atribuicao = 2;
                            seloPrincipal[i].Sistema = "NOTAS";
                            seloPrincipal[i].Livro = procuracao.Livro;
                            seloPrincipal[i].FolhaInicial = procuracao.FolhaInicio;
                            seloPrincipal[i].FolhaFinal = procuracao.FolhaFim;
                            seloPrincipal[i].NumeroAto = procuracao.NumeroAto;
                            seloPrincipal[i].Natureza = "PROCURAÇÃO";
                            seloPrincipal[i].IdUsuarioReservado = _usuario.UsuarioId;
                            seloPrincipal[i].UsuarioReservado = _usuario.Nome;

                            _IAppServicoSelos.Update(seloPrincipal[i]);

                        }



                        List<Cs_Gerencial.Dominio.Entities.Selos> selosAtoConjunto = new List<Cs_Gerencial.Dominio.Entities.Selos>();


                        for (int i = 0; i < atoConjunto.Count; i++)
                        {
                            var selo = _IAppServicoSelos.ReservarSelos(configuracoes.SerieAtual, 1, atoConjunto[i].TipoAto, _usuario.UsuarioId, _usuario.Nome, data, 2, procuracao.Livro, procuracao.FolhaInicio, procuracao.FolhaFim, procuracao.NumeroAto).FirstOrDefault();

                            selo.DataReservado = data;
                            selo.FormReservado = "Consulta Atos";
                            selo.Reservado = "N";
                            selo.Atribuicao = 2;
                            selo.Sistema = "NOTAS";
                            selo.Livro = procuracao.Livro;
                            selo.FolhaInicial = procuracao.FolhaInicio;
                            selo.FolhaFinal = procuracao.FolhaFim;
                            selo.NumeroAto = procuracao.NumeroAto;
                            selo.Natureza = atoConjunto[i].TipoAto;
                            selo.IdUsuarioReservado = _usuario.UsuarioId;
                            selo.UsuarioReservado = _usuario.Nome;

                            selosAtoConjunto.Add(selo);

                            _IAppServicoSelos.Update(selo);
                        }

                        List<string> selosReservados = new List<string>();

                        selosReservados.Add(string.Format("{0}{1} {2}", seloPrincipal[0].Letra, seloPrincipal[0].Numero, seloPrincipal[0].Aleatorio));

                        for (int i = 0; i < atoConjunto.Count; i++)
                        {
                            selosReservados.Add(string.Format("{0}{1} {2}", selosAtoConjunto[i].Letra, selosAtoConjunto[i].Numero, selosAtoConjunto[i].Aleatorio));
                        }

                        string mensagem = "";

                        for (int i = 0; i < selosReservados.Count; i++)
                        {
                            mensagem = mensagem += selosReservados[i] + "\n";
                        }


                        if (selosReservados.Count > 1)
                        {
                            if (MessageBox.Show("Os seguintes selos foram reservados:\n\n" + mensagem + "\nDeseja continuar?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                            {
                                var seloLiberar = seloPrincipal[0];

                                seloLiberar = _IAppServicoSelos.LiberarSelos(seloLiberar);

                                _IAppServicoSelos.SalvarSeloModificado(seloLiberar);

                                for (int i = 0; i < selosAtoConjunto.Count; i++)
                                {
                                    var seloConjuntoLiberar = selosAtoConjunto[i];

                                    seloConjuntoLiberar = _IAppServicoSelos.LiberarSelos(seloConjuntoLiberar);

                                    _IAppServicoSelos.SalvarSeloModificado(seloConjuntoLiberar);
                                }

                                return;
                            }


                        }
                        else
                        {
                            if (selosReservados.Count == 1)
                            {
                                if (MessageBox.Show("O seguinte selo foi reservado:\n\n" + mensagem + "\nDeseja continuar?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                                {
                                    var seloLiberar = seloPrincipal[0];

                                    seloLiberar = _IAppServicoSelos.LiberarSelos(seloLiberar);

                                    _IAppServicoSelos.SalvarSeloModificado(seloLiberar);

                                    for (int i = 0; i < selosAtoConjunto.Count; i++)
                                    {
                                        var seloConjuntoLiberar = selosAtoConjunto[i];

                                        seloConjuntoLiberar = _IAppServicoSelos.LiberarSelos(seloConjuntoLiberar);

                                        _IAppServicoSelos.SalvarSeloModificado(seloConjuntoLiberar);
                                    }
                                    return;
                                }


                            }
                            else
                            {

                                return;
                            }
                        }


                        for (int i = 0; i < seloPrincipal.Count; i++)
                        {

                            if (i == 0)
                            {
                                var selo = _IAppServicoSelos.GetById(seloPrincipal[i].SeloId);
                                selo.Status = "UTILIZADO";
                                selo.FormUtilizado = "Consultar Atos";
                                selo.IdAto = procuracao.ProcuracaoId;
                                selo.DataPratica = procuracao.DataLavratura;

                                if (procuracao.Recibo != null && procuracao.Recibo != "")
                                    selo.Recibo = Convert.ToInt32(procuracao.Recibo);
                                selo.TipoCobranca = procuracao.TipoCobranca;

                                selo.Emolumentos = procuracao.Emolumentos;
                                selo.Fetj = procuracao.Fetj;
                                selo.Fundperj = procuracao.Fundperj;
                                selo.Funperj = procuracao.Funprj;
                                selo.Funarpen = procuracao.Funarpen;
                                selo.Pmcmv = procuracao.Pmcmv;
                                selo.Iss = procuracao.Iss;
                                selo.Mutua = procuracao.Mutua;
                                selo.Acoterj = procuracao.Acoterj;
                                selo.Distribuicao = procuracao.Distribuicao;
                                selo.Total = procuracao.Total;

                                selo.Conjunto = "N";
                                selo.Escrevente = procuracao.Login;
                                selo.Natureza = "PROCURAÇÃO";
                                _IAppServicoSelos.SalvarSeloModificado(selo);
                            }

                        }

                        for (int y = 0; y < selosAtoConjunto.Count; y++)
                        {

                            var selo = selosAtoConjunto[y];
                            selo.Status = "UTILIZADO";
                            selo.FormUtilizado = "Consultar Atos";
                            selo.Conjunto = "S";
                            selo.IdAto = atoConjunto[y].ConjuntoId;
                            selo.DataPratica = procuracao.DataLavratura;

                            selo.Escrevente = procuracao.Login;
                            selo.Natureza = atoConjunto[y].TipoAto;
                            _IAppServicoSelos.SalvarSeloModificado(selo);
                        }




                        procuracao.Selo = seloPrincipal[0].Letra + seloPrincipal[0].Numero;
                        procuracao.Aleatorio = seloPrincipal[0].Aleatorio;
                        _IAppServicoCadProcuracao.Update(procuracao);

                        dataGridConsultarAtos.SelectedItem = procuracao;
                        dataGridConsultarAtos.Items.Refresh();


                        for (int i = 0; i < atoConjunto.Count; i++)
                        {
                            var atocon = atoConjunto[i];

                            atocon.Selo = selosAtoConjunto[i].Letra + selosAtoConjunto[i].Numero;
                            atocon.Aleatorio = selosAtoConjunto[i].Aleatorio;

                            _IAppServicoAtoConjuntos.Update(atocon);

                        }

                        MessageBox.Show("Ato selado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void RemoverSeloDoAto()
        {
            try
            {

                bool liberar = false;


                var procuracao = (CadProcuracao)dataGridConsultarAtos.SelectedItem;

                if (procuracao != null)
                {
                    var atoConjunto = _IAppServicoAtoConjuntos.ObterAtosConjuntosPorIdProcuracao(procuracao.ProcuracaoId).ToList();

                    List<string> selosRemover = new List<string>();

                    if (procuracao.Selo != "" && procuracao.Selo != null)
                        selosRemover.Add(string.Format("{0} {1}", procuracao.Selo, procuracao.Aleatorio));

                    for (int i = 0; i < atoConjunto.Count; i++)
                    {
                        if (atoConjunto[i].Selo != "" && atoConjunto[i].Selo != null)
                            selosRemover.Add(string.Format("{0} {1}", atoConjunto[i].Selo, atoConjunto[i].Aleatorio));
                    }

                    string mensagem = "";

                    for (int i = 0; i < selosRemover.Count; i++)
                    {
                        mensagem = mensagem += selosRemover[i] + "\n";
                    }

                    if (selosRemover.Count > 1)
                    {
                        if (MessageBox.Show("Os seguintes selos serão removidos:\n\n" + mensagem + "\nConfirmar a remoção dos selos informados?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        {
                            return;
                        }

                        if (MessageBox.Show("Deseja liberar os selos no Gerencial?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            liberar = true;
                        }
                    }
                    else
                    {
                        if (selosRemover.Count == 1)
                        {
                            if (MessageBox.Show("O seguinte selo será removido:\n\n" + mensagem + "\nConfirma a remoção do selo informado?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                            {
                                return;
                            }

                            if (MessageBox.Show("Deseja liberar o selo no Gerencial?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                liberar = true;
                            }
                        }
                        else
                        {

                            return;
                        }
                    }


                    for (int i = 0; i < atoConjunto.Count; i++)
                    {
                        var atocon = atoConjunto[i];

                        atocon.Selo = "";
                        atocon.Aleatorio = "";

                        _IAppServicoAtoConjuntos.Update(atocon);

                    }

                    procuracao.Selo = "";
                    procuracao.Aleatorio = "";

                    _IAppServicoCadProcuracao.Update(procuracao);

                    dataGridConsultarAtos.SelectedItem = procuracao;
                    dataGridConsultarAtos.Items.Refresh();


                    if (liberar == true)
                    {
                        for (int i = 0; i < selosRemover.Count; i++)
                        {
                            var selo = _IAppServicoSelos.ConsultarPorSerieNumero(selosRemover[i].Substring(0, 4), Convert.ToInt32(selosRemover[i].Substring(4, 5)));

                            _IAppServicoSelos.LiberarSelos(selo);
                            _IAppServicoSelos.SalvarSeloModificado(selo);
                        }

                    }

                    if (selosRemover.Count > 1)
                        MessageBox.Show("Selos removidos com sucesso!", "Remonvidos", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Selo removido com sucesso!", "Remonvido", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}