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
    /// Lógica interna para AguardeExcluirProcuracao.xaml
    /// </summary>
    public partial class AguardeExcluirProcuracao : Window
    {
        BackgroundWorker worker;
        CadProcuracao _procuracao;
        bool _liberarSelo;
        bool sucesso = false;


        List<AtoConjuntos> atosConjuntos = new List<AtoConjuntos>();
        List<Complementos> complementos = new List<Complementos>();
        List<ItensCustas> itensCustas = new List<ItensCustas>();
        List<Nomes> nomes = new List<Nomes>();
        List<ParteConjuntos> parteConjuntos = new List<ParteConjuntos>();


        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoCadProcuracao _AppServicoCadProcuracao = BootStrap.Container.GetInstance<IAppServicoCadProcuracao>();
        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();
        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();
        private readonly IAppServicoParteConjuntos _IAppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();
        private readonly IAppServicoProcuracaoEscritura _AppServicoProcuracaoEscritura = BootStrap.Container.GetInstance<IAppServicoProcuracaoEscritura>();
        private readonly IAppServicoComplementos _AppServicoComplementos = BootStrap.Container.GetInstance<IAppServicoComplementos>();




        public AguardeExcluirProcuracao(CadProcuracao procuracao, bool liberarSelo)
        {
            _procuracao = procuracao;
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
            atosConjuntos = _AppServicoAtoConjuntos.ObterAtosConjuntosPorIdProcuracao(_procuracao.ProcuracaoId);
            
            itensCustas = _AppServicoItensCustas.ObterItensCustasPorIdProcuracao(_procuracao.ProcuracaoId);

            nomes = _AppServicoNomes.ObterNomesPorIdAto(_procuracao.ProcuracaoId);

            parteConjuntos = _IAppServicoParteConjuntos.ListarPorIdAto(_procuracao.ProcuracaoId);
            
            complementos = _AppServicoComplementos.ObterComplementosPorIdAto(_procuracao.ProcuracaoId);

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
                selo = _AppServicoSelos.ConsultarPorSerieNumero(_procuracao.Selo.Substring(0, 4), Convert.ToInt32(_procuracao.Selo.Substring(4, 5)));
                _AppServicoSelos.LiberarSelos(selo);
                _AppServicoSelos.SalvarSeloModificado(selo);
            }

            _AppServicoCadProcuracao.Remove(_procuracao);

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
