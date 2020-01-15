using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows;
using Cs_Notas.Windows.Escritura;
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
    /// Interaction logic for AguardeSalvandoEscritura.xaml
    /// </summary>
    public partial class AguardeSalvandoEscritura : Window
    {
        BackgroundWorker worker;
        DigitarEscritura _digitarEscritura;
        string janelaChamada;
        Escrituras _escritura;
        Principal _principal;
        Cs_Notas.Dominio.Entities.Usuario _usuario;
        List<AtoConjuntos> _listaAtoConjuntos;
        List<Selos> _selos;


        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoEscrituras _AppServicoEscrituras = BootStrap.Container.GetInstance<IAppServicoEscrituras>();
        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();
        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();
        private readonly IAppServicoParteConjuntos _IAppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();


        public AguardeSalvandoEscritura(DigitarEscritura digitarEscritura)
        {
            _escritura = digitarEscritura._escrituras;
            _digitarEscritura = digitarEscritura;
            janelaChamada = "digitarEscritura";
            InitializeComponent();
        }

        public AguardeSalvandoEscritura(Escrituras escritura, List<AtoConjuntos> listaAtoConjuntos, Principal principal, Cs_Notas.Dominio.Entities.Usuario usuario, List<Selos> selos)
        {
            _escritura = escritura;
            _principal = principal;
            _usuario = usuario;
            _listaAtoConjuntos = listaAtoConjuntos;
            janelaChamada = "iniciarPrimeiraDigitacaoEscritura";
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

                if (janelaChamada == "iniciarPrimeiraDigitacaoEscritura")
                {

                    SalvarAddEscritura();

                    SalvarAddAtoConjunto();

                    SalvaSeloReservado();

                }
                else
                {
                    SalvarUpdateEscritura();

                    SalvarItensCustas();

                    SalvarSelo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorrreu um erro inesperado. " + ex.Message);

                _digitarEscritura.estado = "erro";
            }
        }

        private void SalvarSelo()
        {
            var selo = _AppServicoSelos.ConsultarPorSerieNumero(_escritura.SeloEscritura.Substring(0, 4), Convert.ToInt32(_escritura.SeloEscritura.Substring(4, 5)));
            
            selo.FormUtilizado = "Digitar Escrituras";
            selo.IdAto = _escritura.EscriturasId;
            selo.DataPratica = _escritura.DataAtoRegistro;

            if (_escritura.Recibo != null && _escritura.Recibo != "")
                selo.Recibo = Convert.ToInt32(_escritura.Recibo);
            selo.TipoCobranca = _escritura.TipoCobranca;

            selo.Emolumentos = _escritura.Emolumentos;
            selo.Fetj = _escritura.Fetj;
            selo.Fundperj = _escritura.Fundperj;
            selo.Funperj = _escritura.Funprj;
            selo.Funarpen = _escritura.Funarpen;
            selo.Pmcmv = _escritura.Pmcmv;
            selo.Iss = _escritura.Iss;
            selo.Mutua = _escritura.Mutua;
            selo.Acoterj = _escritura.Acoterj;
            selo.Distribuicao = _escritura.Distribuicao;
            selo.Total = _escritura.Total;

            selo.Conjunto = "N";
            selo.Escrevente = _escritura.EscreventeAtoRegistro;
            selo.Natureza = _escritura.Descricao;
            _AppServicoSelos.SalvarSeloModificado(selo);


            for (int y = 0; y < _digitarEscritura.listaAtoConjuntos.Count; y++)
            {

                var conjunto = _AppServicoSelos.ConsultarPorSerieNumero(_digitarEscritura.listaAtoConjuntos[y].Selo.Substring(0,4), Convert.ToInt32(_digitarEscritura.listaAtoConjuntos[y].Selo.Substring(4,5)));
                conjunto.Conjunto = "S";
                conjunto.Sistema = "NOTAS";
                conjunto.DataPratica = _escritura.DataAtoRegistro;
                if(_escritura.Recibo != "" && _escritura.Recibo != null)
                conjunto.Recibo = Convert.ToInt32(_escritura.Recibo);
                conjunto.Escrevente = _escritura.EscreventeAtoRegistro;
                conjunto.Natureza = _digitarEscritura.listaAtoConjuntos[y].TipoAto;
                _AppServicoSelos.SalvarSeloModificado(selo);
            }

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (janelaChamada == "iniciarPrimeiraDigitacaoEscritura")
            {
                var digitarEscritura = new DigitarEscritura(_escritura, _usuario, true);
                digitarEscritura.Owner = _principal;
                this.Close();
                digitarEscritura.ShowDialog();
            }
            this.Close();
        }

        private void SalvarAddEscritura()
        {



            _AppServicoEscrituras.Add(_escritura);
        }
        private void SalvarUpdateEscritura()
        {



            _AppServicoEscrituras.Update(_escritura);
        }

        private void SalvarItensCustas()
        {
            var custasExcluir = _AppServicoItensCustas.ObterItensCustasPorIdAto(_escritura.EscriturasId);

            for (int i = 0; i < custasExcluir.Count; i++)
            {
                var excluirBanco = _AppServicoItensCustas.GetById(custasExcluir[i].ItensCustasId);
                _AppServicoItensCustas.Remove(excluirBanco);
            }


            for (int i = 0; i < _digitarEscritura.listaItensCustas.Count; i++)
            {
                var adicionarBanco = new ItensCustas();

                adicionarBanco = _digitarEscritura.listaItensCustas[i];

                adicionarBanco.IdEscritura = _escritura.EscriturasId;

                _AppServicoItensCustas.Add(adicionarBanco);
            }
        }
       
        private void SalvarAddAtoConjunto()
        {

            for (int i = 0; i < _listaAtoConjuntos.Count; i++)
            {

                _listaAtoConjuntos[i].IdEscritura = _escritura.EscriturasId;

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
                    selo.FormUtilizado = "Digitar Escrituras";      
                    selo.IdAto = _escritura.EscriturasId;
                    selo.DataPratica = _escritura.DataAtoRegistro;

                    if(_escritura.Recibo != null && _escritura.Recibo != "")
                    selo.Recibo = Convert.ToInt32(_escritura.Recibo);
                    selo.TipoCobranca = _escritura.TipoCobranca;

                    selo.Emolumentos = _escritura.Emolumentos;
                    selo.Fetj = _escritura.Fetj;
                    selo.Fundperj = _escritura.Fundperj;
                    selo.Funperj = _escritura.Funprj;
                    selo.Funarpen = _escritura.Funarpen;
                    selo.Pmcmv = _escritura.Pmcmv;
                    selo.Iss = _escritura.Iss;
                    selo.Mutua = _escritura.Mutua;
                    selo.Acoterj = _escritura.Acoterj;
                    selo.Distribuicao = _escritura.Distribuicao;
                    selo.Total = _escritura.Total;

                    selo.Conjunto = "N";
                    selo.Escrevente = _escritura.EscreventeAtoRegistro;
                    selo.Natureza = _escritura.Descricao;
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
                selo.DataPratica = _escritura.DataAtoRegistro;        

                selo.Escrevente = _escritura.EscreventeAtoRegistro;
                selo.Natureza = _listaAtoConjuntos[y].TipoAto;
                _AppServicoSelos.SalvarSeloModificado(selo);
            }
        }
    }
}

