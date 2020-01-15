using CrossCutting;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Entities_Fracas;
using Cs_Gerencial.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cs_Gerencial.WindowsAguarde
{
    /// <summary>
    /// Interaction logic for AguardeImportarSelos.xaml
    /// </summary>
    public partial class AguardeImportarSelos : Window
    {
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();

        private readonly IAppServicoCompraSelo _AppServicoCompraSelo = BootStrap.Container.GetInstance<IAppServicoCompraSelo>();

        private readonly IAppServicoSeries _AppServicoSeries = BootStrap.Container.GetInstance<IAppServicoSeries>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();

        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();

        Usuario _usuario;
        
        LogSistema logSistema;

        BackgroundWorker worker;
        
        bool abortado = false;

        bool sucesso = false;

        string acao = string.Empty;

        List<Selos> removerSelos;

        EstoqueSelos _estoqueSelos;

        FileInfo arquivo;

        public AguardeImportarSelos(Usuario usuario, EstoqueSelos estoqueSelos)
        {
            _usuario = usuario;         
            _estoqueSelos = estoqueSelos;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            progressBar1.Maximum = _estoqueSelos.leituraDoArquivoXml.Quantidade;

            try
            {
                 arquivo = new FileInfo(_estoqueSelos.arquivoSelecionado.FullName);
               
                _estoqueSelos.arquivoSelecionado = null;


                if (arquivo.Exists)
                    arquivo.MoveTo(_estoqueSelos.parametros.PathSelosImportados + @"\" + arquivo.Name);


                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();                     
            
            
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível mover o arquivo para a pasta de Importados. Por favor verifique se os diretórios estão configurados e tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);  
                Close();
            }


            
        }


        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            int cont = 0;
            try
            {

                List<CompraSelo> verificarSeJaFoiImportado = _AppServicoCompraSelo.ConsultaPorIdPedido(_estoqueSelos.leituraDoArquivoXml.Id).ToList();

                if (verificarSeJaFoiImportado.Count() > 0)
                {
                    if (MessageBox.Show("Esta série de selo já foi importada. \n\nSe clicar em 'Sim' todos os selos importados anteriormente serão removidos e importados novamente.\n\n\n Deseja importar novamente?", "Ateção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        acao = "Removendo registro";

                        int idCompraSelo = verificarSeJaFoiImportado.Select(p => p.CompraSeloId).FirstOrDefault();
                        List<Series> removerSeries = _AppServicoSeries.ConsultarPorIdCompraSelo(idCompraSelo).ToList();

                        removerSelos = _AppServicoSelos.ConsultarPorIdCompraSelo(verificarSeJaFoiImportado.Select(p => p.CompraSeloId).FirstOrDefault()).ToList();

                        for (int i = 0; i < removerSelos.Count(); i++)
                        {
                            _AppServicoSelos.Remove(removerSelos[i]);

                            Thread.Sleep(1);
                            worker.ReportProgress(i);
                        }

                        for (int i = 0; i < verificarSeJaFoiImportado.Count(); i++)
                        {
                            _AppServicoCompraSelo.Remove(verificarSeJaFoiImportado[i]);
                        }

                        for (int i = 0; i < removerSeries.Count(); i++)
                        {
                            _AppServicoSeries.Remove(removerSeries[i]);
                        }
                    }
                    else
                    {
                        abortado = true;
                        return;
                    }
                }

                var compraSelo = SalvarCompraSelos();

                var series = SalvarSerie(compraSelo.CompraSeloId);

                List<Selos> listSelosImportar = _AppServicoSelos.AdicionarListaSelosImportar(_estoqueSelos.leituraDoArquivoXml, compraSelo, series).ToList();

                _estoqueSelos.serieDisponiveisSelecionada = series;

                acao = "Importando registro";

                Selos selo;

                for (int i = 0; i < listSelosImportar.Count; i++)
                {
                    cont++;

                    selo = listSelosImportar[i];
                    selo.Aleatorio = ClassGerarAleatorio.LetrasAleatorias(3);
                    _AppServicoSelos.Add(selo);

                    Thread.Sleep(1);
                    worker.ReportProgress(cont);

                }

                SalvarLogSistema("Importou o Arquivo: " + _estoqueSelos.leituraDoArquivoXml.Arquivo);

                sucesso = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;


            if (acao == "Importando registro")
            {
                progressBar1.Maximum = _estoqueSelos.leituraDoArquivoXml.Quantidade;
                lblContagem.Content = string.Format(acao + " {0} de {1}", e.ProgressPercentage, _estoqueSelos.leituraDoArquivoXml.Quantidade);
            }
            else
            {
                progressBar1.Maximum = removerSelos.Count;
                lblContagem.Content = string.Format(acao + " {0} de {1}", e.ProgressPercentage, removerSelos.Count);
            }

        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (abortado == false)
                {

                    if (sucesso == false)
                    {
                        MessageBox.Show("Ocorreu um erro inesperado na importação. Favor verifique os dados importados.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                        arquivo.MoveTo(_estoqueSelos.parametros.PathSelosNaoImportados + @"\" + arquivo.Name);
                    }
                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }

      
        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "AguardeImportarSelos";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }


        private CompraSelo SalvarCompraSelos()
        {
            var compraSelo = new CompraSelo();

            compraSelo.Arquivo = _estoqueSelos.leituraDoArquivoXml.Arquivo;

            compraSelo.CpfSolicitante = _estoqueSelos.leituraDoArquivoXml.SolicitanteCpf;

            compraSelo.DataGeracao = _estoqueSelos.leituraDoArquivoXml.DataGeracao.Date;

            compraSelo.HoraGeracao = _estoqueSelos.leituraDoArquivoXml.DataGeracao.ToShortTimeString();

            compraSelo.DataPagamento = _estoqueSelos.leituraDoArquivoXml.DataPagamento.Date;

            compraSelo.HoraPagamento = _estoqueSelos.leituraDoArquivoXml.DataPagamento.ToShortTimeString();

            compraSelo.DataPedido = _estoqueSelos.leituraDoArquivoXml.DataPedido.Date;

            compraSelo.HoraPedido = _estoqueSelos.leituraDoArquivoXml.DataPedido.ToShortTimeString();

            compraSelo.Grerj = _estoqueSelos.leituraDoArquivoXml.Grerj;

            compraSelo.NomeSolicitante = _estoqueSelos.leituraDoArquivoXml.SolicitanteNome;

            compraSelo.PedidoId = _estoqueSelos.leituraDoArquivoXml.Id;

            compraSelo.Quantidade = _estoqueSelos.leituraDoArquivoXml.Quantidade;

            _AppServicoCompraSelo.Add(compraSelo);


            return compraSelo;
        }

        private Series SalvarSerie(int compraSeloId)
        {
            var series = new Series();

            series.IdCompra = compraSeloId;

            series.Inicial = _estoqueSelos.leituraDoArquivoXml.SequenciaInicio;

            series.Final = _estoqueSelos.leituraDoArquivoXml.SequenciaFim;

            series.Letra = _estoqueSelos.leituraDoArquivoXml.Serie;

            series.Quantidade = _estoqueSelos.leituraDoArquivoXml.Quantidade;

            _AppServicoSeries.Add(series);

            return series;
        }

       

    }
}
