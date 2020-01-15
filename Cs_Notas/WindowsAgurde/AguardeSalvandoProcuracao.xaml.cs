using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows;
using Cs_Notas.Windows.Procuracao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Cs_Notas.WindowsAgurde
{
    /// <summary>
    /// Lógica interna para AgurardeSalvandoProcuracao.xaml
    /// </summary>
    public partial class AgurardeSalvandoProcuracao : Window
    {

        BackgroundWorker worker;
        DigitarProcuracao _digitarProcuracao;
        string janelaChamada;
        CadProcuracao _procuracao;
        Principal _principal;
        Cs_Notas.Dominio.Entities.Usuario _usuario;
        List<AtoConjuntos> _listaAtoConjuntos;
        List<Selos> _selos;


        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoCadProcuracao _AppServicoCadProcuracao = BootStrap.Container.GetInstance<IAppServicoCadProcuracao>();
        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();
        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();
        private readonly IAppServicoParteConjuntos _IAppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();



        public AgurardeSalvandoProcuracao(DigitarProcuracao digitarProcuracao)
        {
            _procuracao = digitarProcuracao._procuracao;
            _digitarProcuracao = digitarProcuracao;
            janelaChamada = "digitarProcuracao";
            InitializeComponent();
        }

        public AgurardeSalvandoProcuracao(CadProcuracao procuracao, List<AtoConjuntos> listaAtoConjuntos, Principal principal, Cs_Notas.Dominio.Entities.Usuario usuario, List<Selos> selos)
        {
            _procuracao = procuracao;
            _principal = principal;
            _usuario = usuario;
            _listaAtoConjuntos = listaAtoConjuntos;
            janelaChamada = "iniciarPrimeiraDigitacaoProcuracao";
            _selos = selos;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao tentar salvar a Escritua. Favor imformar ao Suporte.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                if (janelaChamada == "iniciarPrimeiraDigitacaoProcuracao")
                {

                    SalvarAddProcuracao();

                    SalvarAddAtoConjunto();

                    SalvaSeloReservado();

                }
                else
                {
                    SalvarUpdateProcuracao();

                    SalvarItensCustas();

                    SalvarSelo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorrreu um erro inesperado. " + ex.Message);
            }
        }

        private void SalvarSelo()
        {
            var selo = _AppServicoSelos.ConsultarPorSerieNumero(_procuracao.Selo.Substring(0, 4), Convert.ToInt32(_procuracao.Selo.Substring(4, 5)));

            selo.FormUtilizado = "Digitar Procuracão";
            selo.IdAto = _procuracao.ProcuracaoId;
            selo.DataPratica = _procuracao.DataLavratura;

            if (_procuracao.Recibo != null && _procuracao.Recibo != "")
                selo.Recibo = Convert.ToInt32(_procuracao.Recibo);

            selo.TipoCobranca = _procuracao.TipoCobranca;

            selo.Emolumentos = _procuracao.Emolumentos;
            selo.Fetj = _procuracao.Fetj;
            selo.Fundperj = _procuracao.Fundperj;
            selo.Funperj = _procuracao.Funprj;
            selo.Funarpen = _procuracao.Funarpen;
            selo.Pmcmv = _procuracao.Pmcmv;
            selo.Iss = _procuracao.Iss;
            selo.Mutua = _procuracao.Mutua;
            selo.Acoterj = _procuracao.Acoterj;
            selo.Distribuicao = _procuracao.Distribuicao;
            selo.Total = _procuracao.Total;

            selo.Conjunto = "N";
            selo.Escrevente = _procuracao.Login;
            selo.Natureza = "PROCURAÇÂO";
            _AppServicoSelos.SalvarSeloModificado(selo);


            for (int y = 0; y < _digitarProcuracao.listaAtoConjuntos.Count; y++)
            {

                var conjunto = _AppServicoSelos.ConsultarPorSerieNumero(_digitarProcuracao.listaAtoConjuntos[y].Selo.Substring(0, 4), Convert.ToInt32(_digitarProcuracao.listaAtoConjuntos[y].Selo.Substring(4, 5)));
                conjunto.Conjunto = "S";
                conjunto.Sistema = "NOTAS";
                conjunto.DataPratica = _procuracao.DataLavratura;
                if (_procuracao.Recibo != "" && _procuracao.Recibo != null)
                    conjunto.Recibo = Convert.ToInt32(_procuracao.Recibo);
                conjunto.Escrevente = _procuracao.Login;
                conjunto.Natureza = _digitarProcuracao.listaAtoConjuntos[y].TipoAto;
                _AppServicoSelos.SalvarSeloModificado(selo);
            }

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (janelaChamada == "iniciarPrimeiraDigitacaoProcuracao")
            {
                var digitarEscritura = new DigitarProcuracao(_procuracao, _usuario, true);
                digitarEscritura.Owner = _principal;
                this.Close();
                digitarEscritura.ShowDialog();
            }
            this.Close();
        }

        private void SalvarAddProcuracao()
        {
            _AppServicoCadProcuracao.Add(_procuracao);
        }
        private void SalvarUpdateProcuracao()
        {
            _AppServicoCadProcuracao.Update(_procuracao);
        }

        private void SalvarItensCustas()
        {
            var custasExcluir = _AppServicoItensCustas.ObterItensCustasPorIdAto(_procuracao.ProcuracaoId);

            for (int i = 0; i < custasExcluir.Count; i++)
            {
                var excluirBanco = _AppServicoItensCustas.GetById(custasExcluir[i].ItensCustasId);
                _AppServicoItensCustas.Remove(excluirBanco);
            }


            for (int i = 0; i < _digitarProcuracao.listaItensCustas.Count; i++)
            {
                var adicionarBanco = new ItensCustas();

                adicionarBanco = _digitarProcuracao.listaItensCustas[i];

                adicionarBanco.IdProcuracao = _procuracao.ProcuracaoId;

                _AppServicoItensCustas.Add(adicionarBanco);
            }
        }

        private void SalvarAddAtoConjunto()
        {

            for (int i = 0; i < _listaAtoConjuntos.Count; i++)
            {

                _listaAtoConjuntos[i].IdProcuracao = _procuracao.ProcuracaoId;

                _AppServicoAtoConjuntos.Add(_listaAtoConjuntos[i]);

            }

        }


        private void SalvaSeloReservado()
        {
            for (int i = 0; i < _selos.Count; i++)
            {

                if (i == 0)
                {
                    var selo = _AppServicoSelos.GetById(_selos[i].SeloId);
                    selo.Status = "UTILIZADO";
                    selo.FormUtilizado = "Digitar Procuração";
                    selo.IdAto = _procuracao.ProcuracaoId;
                    selo.DataPratica = _procuracao.DataLavratura;

                    if (_procuracao.Recibo != null && _procuracao.Recibo != "")
                        selo.Recibo = Convert.ToInt32(_procuracao.Recibo);
                    selo.TipoCobranca = _procuracao.TipoCobranca;

                    selo.Emolumentos = _procuracao.Emolumentos;
                    selo.Fetj = _procuracao.Fetj;
                    selo.Fundperj = _procuracao.Fundperj;
                    selo.Funperj = _procuracao.Funprj;
                    selo.Funarpen = _procuracao.Funarpen;
                    selo.Pmcmv = _procuracao.Pmcmv;
                    selo.Iss = _procuracao.Iss;
                    selo.Mutua = _procuracao.Mutua;
                    selo.Acoterj = _procuracao.Acoterj;
                    selo.Distribuicao = _procuracao.Distribuicao;
                    selo.Total = _procuracao.Total;

                    selo.Conjunto = "N";
                    selo.Escrevente = _procuracao.Login;
                    selo.Natureza = "PROCURAÇÃO";
                    _AppServicoSelos.SalvarSeloModificado(selo);
                }

            }

            for (int y = 0; y < _listaAtoConjuntos.Count; y++)
            {

                var selo = _AppServicoSelos.GetById(_selos[y + 1].SeloId);
                selo.Status = "UTILIZADO";
                selo.FormUtilizado = "Digitar Escrituras";
                selo.Conjunto = "S";
                selo.IdAto = _listaAtoConjuntos[y].ConjuntoId;
                selo.DataPratica = _procuracao.DataLavratura;

                selo.Escrevente = _procuracao.Login;
                selo.Natureza = _listaAtoConjuntos[y].TipoAto;
                _AppServicoSelos.SalvarSeloModificado(selo);
            }
        }
    }
}

