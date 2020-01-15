using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
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
    /// Lógica interna para AguardeExcluirEscritura.xaml
    /// </summary>
    public partial class AguardeExcluirEscritura : Window
    {

        BackgroundWorker worker;
        Escrituras _escritura;
        bool _liberarSelo;
        bool sucesso = false;


        List<AtoConjuntos> atosConjuntos = new List<AtoConjuntos>();
        List<BensAtosConjuntos> bensAtosConjuntos = new List<BensAtosConjuntos>();
        List<Complementos> complementos = new List<Complementos>();
        List<Imovel> imovel = new List<Imovel>();
        List<ItensCustas> itensCustas = new List<ItensCustas>();
        List<Nomes> nomes = new List<Nomes>();
        List<ParteConjuntos> parteConjuntos = new List<ParteConjuntos>();
        List<ProcuracaoEscritura> procuracaoEscritura = new List<ProcuracaoEscritura>();


        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoEscrituras _AppServicoEscrituras = BootStrap.Container.GetInstance<IAppServicoEscrituras>();
        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();
        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();
        private readonly IAppServicoParteConjuntos _IAppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();
        private readonly IAppServicoProcuracaoEscritura _AppServicoProcuracaoEscritura = BootStrap.Container.GetInstance<IAppServicoProcuracaoEscritura>();
        private readonly IAppServicoComplementos _AppServicoComplementos = BootStrap.Container.GetInstance<IAppServicoComplementos>();


        public AguardeExcluirEscritura(Escrituras escritura, bool liberarSelo)
        {
            _escritura = escritura;
            _liberarSelo = liberarSelo;
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
            atosConjuntos = _AppServicoAtoConjuntos.ObterAtosConjuntosPorIdAto(_escritura.EscriturasId);

            bensAtosConjuntos = _AppServicoBensAtosConjuntos.ObterBensAtoConjuntosPorIdAto(_escritura.EscriturasId);

            imovel = _AppServicoImovel.ObterImoveisPorIdAto(_escritura.EscriturasId);

            itensCustas = _AppServicoItensCustas.ObterItensCustasPorIdAto(_escritura.EscriturasId);

            nomes = _AppServicoNomes.ObterNomesPorIdAto(_escritura.EscriturasId);

            parteConjuntos = _IAppServicoParteConjuntos.ListarPorIdAto(_escritura.EscriturasId);

            procuracaoEscritura = _AppServicoProcuracaoEscritura.ObterProcuracoesPorIdAto(_escritura.EscriturasId);

            complementos = _AppServicoComplementos.ObterComplementosPorIdAto(_escritura.EscriturasId);

            Selos selo;

            for (int i = 0; i < atosConjuntos.Count; i++)
            {
                _AppServicoAtoConjuntos.Remove(atosConjuntos[i]);

                if (_liberarSelo == true)
                {
                    selo = _AppServicoSelos.ConsultarPorSerieNumero(atosConjuntos[i].Selo.Substring(0, 4), Convert.ToInt32(atosConjuntos[i].Selo.Substring(4, 5)));
                    _AppServicoSelos.LiberarSelos(selo);
                    _AppServicoSelos.SalvarSeloModificado(selo);
                }
            }



            for (int i = 0; i < bensAtosConjuntos.Count; i++)
            {
                _AppServicoBensAtosConjuntos.Remove(bensAtosConjuntos[i]);
            }


            for (int i = 0; i < imovel.Count; i++)
            {
                _AppServicoImovel.Remove(imovel[i]);
            }


            for (int i = 0; i < itensCustas.Count; i++)
            {
                _AppServicoItensCustas.Remove(itensCustas[i]);
            }


            for (int i = 0; i < parteConjuntos.Count; i++)
            {
                _IAppServicoParteConjuntos.Remove(parteConjuntos[i]);
            }

            for (int i = 0; i < nomes.Count; i++)
            {
                _AppServicoNomes.Remove(nomes[i]);
            }

            for (int i = 0; i < procuracaoEscritura.Count; i++)
            {
                _AppServicoProcuracaoEscritura.Remove(procuracaoEscritura[i]);
            }

            for (int i = 0; i < complementos.Count; i++)
            {
                _AppServicoComplementos.Remove(complementos[i]);

                if (_liberarSelo == true)
                {
                    selo = _AppServicoSelos.ConsultarPorSerieNumero(complementos[i].Cct.Substring(0, 4), Convert.ToInt32(complementos[i].Cct.Substring(4, 5)));
                    _AppServicoSelos.LiberarSelos(selo);
                    _AppServicoSelos.SalvarSeloModificado(selo);
                }
            }

            if (_liberarSelo == true)
            {
                selo = _AppServicoSelos.ConsultarPorSerieNumero(_escritura.SeloEscritura.Substring(0, 4), Convert.ToInt32(_escritura.SeloEscritura.Substring(4, 5)));
                _AppServicoSelos.LiberarSelos(selo);
                _AppServicoSelos.SalvarSeloModificado(selo);
            }

            _AppServicoEscrituras.Remove(_escritura);

            sucesso = true;
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }


        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sucesso == true)
            {
                this.Visibility = Visibility.Hidden;
                MessageBox.Show("Ato excluído com sucesso!", "Sucesso na exclusão", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }

            this.Close();
        }
    }
}
