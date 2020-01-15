using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Windows;
using Cs_Notas.Windows.Testamento;
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
    /// Lógica interna para AguardeSalvandoTestamento.xaml
    /// </summary>
    public partial class AguardeSalvandoTestamento : Window
    {

        BackgroundWorker worker;
        DigitarTestamento _digitarTestamento;
        CadTestamento _testamento;



        private readonly IAppServicoPessoas _AppServicoPessoas = BootStrap.Container.GetInstance<IAppServicoPessoas>();
        private readonly IAppServicoNomes _AppServicoNomes = BootStrap.Container.GetInstance<IAppServicoNomes>();
        private readonly IAppServicoTestamento _AppServicoTestamento = BootStrap.Container.GetInstance<IAppServicoTestamento>();
        private readonly IAppServicoAtoConjuntos _AppServicoAtoConjuntos = BootStrap.Container.GetInstance<IAppServicoAtoConjuntos>();
        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();
        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();
        private readonly IAppServicoParteConjuntos _IAppServicoParteConjuntos = BootStrap.Container.GetInstance<IAppServicoParteConjuntos>();
        private readonly IAppServicoSelos _AppServicoSelos = BootStrap.Container.GetInstance<IAppServicoSelos>();
        private readonly IAppServicoItensCustas _AppServicoItensCustas = BootStrap.Container.GetInstance<IAppServicoItensCustas>();
        private readonly IAppServicoRevogados _AppServicoRevogados = BootStrap.Container.GetInstance<IAppServicoRevogados>();


        public AguardeSalvandoTestamento(DigitarTestamento digitarTestamento)
        {
            _testamento = digitarTestamento._testamento;
            _digitarTestamento = digitarTestamento;
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
                if(_testamento.TestamentoId > 0)
                {
                    SalvarUpdateTestamento();

                    SalvarItensCustas();

                    SalvarSelo();
                }
                else
                {
                    SalvarAddTestamento();

                    SalvarItensCustas();

                    SalvaSeloReservado();
                }

                SalvarTestemunhas();

                SalvarRevogados();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorrreu um erro inesperado. " + ex.Message);
                _digitarTestamento.estado = "erro";
            }
        }
       

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            
            this.Close();
        }


        private void SalvarTestemunhas()
        {

            var nomes = _AppServicoNomes.ObterNomesPorIdTestamento(_testamento.TestamentoId);

           
            foreach (var item in nomes)
            {
                var pessoa = _AppServicoPessoas.GetById(item.IdPessoa);

                _AppServicoPessoas.Remove(pessoa);

                _AppServicoNomes.Remove(item);
            }
            

            for (int i = 0; i < _digitarTestamento.participantes.Count; i++)
            {
                var pessoa = _digitarTestamento.listaPessoas[i];
                
                if (pessoa != null)
                    _AppServicoPessoas.Add(pessoa);

                var nome = _digitarTestamento.listaNomes[i];

                nome.IdPessoa = pessoa.PessoasId;

                nome.IdTestamento = _testamento.TestamentoId;

                if (nome != null)
                    _AppServicoNomes.Add(nome);

            }
        }

        private void SalvarRevogados()
        {

            var revogados = _AppServicoRevogados.ObterRevogadosPorIdTestamento(_testamento.TestamentoId);

            for (int i = 0; i < revogados.Count; i++)
            {
                _AppServicoRevogados.Remove(revogados[i]);
            }


            for (int i = 0; i < _digitarTestamento.listaRevogados.Count; i++)
            {
                var revogado = _digitarTestamento.listaRevogados[i];

                revogado.IdTestamento = _testamento.TestamentoId;

                _AppServicoRevogados.Add(revogado);
            }
        }

        private void SalvarAddTestamento()
        {
            _AppServicoTestamento.Add(_testamento);
        }
        private void SalvarUpdateTestamento()
        {
            _AppServicoTestamento.Update(_testamento);
        }

        private void SalvarItensCustas()
        {
            var custasExcluir = _AppServicoItensCustas.ObterItensCustasPorIdTestamento(_testamento.TestamentoId);

            for (int i = 0; i < custasExcluir.Count; i++)
            {
                var excluirBanco = _AppServicoItensCustas.GetById(custasExcluir[i].ItensCustasId);
                _AppServicoItensCustas.Remove(excluirBanco);
            }


            for (int i = 0; i < _digitarTestamento.listaItensCustas.Count; i++)
            {
                var adicionarBanco = new ItensCustas();

                adicionarBanco = _digitarTestamento.listaItensCustas[i];

                adicionarBanco.IdTestamento = _testamento.TestamentoId;

                _AppServicoItensCustas.Add(adicionarBanco);
            }
        }

        private void SalvarSelo()
        {
            var selo = _AppServicoSelos.ConsultarPorSerieNumero(_testamento.Selo.Substring(0, 4), Convert.ToInt32(_testamento.Selo.Substring(4, 5)));

            selo.FormUtilizado = "Digitar Testamento";
            selo.IdAto = _testamento.TestamentoId;
            selo.DataPratica = _testamento.DataAto;

            if (_testamento.Recibo != null && _testamento.Recibo != "")
                selo.Recibo = Convert.ToInt32(_testamento.Recibo);

            selo.TipoCobranca = _testamento.TipoCobranca;

            selo.Emolumentos = _testamento.Emolumentos;
            selo.Fetj = _testamento.Fetj;
            selo.Fundperj = _testamento.Fundperj;
            selo.Funperj = _testamento.Funprj;
            selo.Funarpen = _testamento.Funarpen;
            selo.Pmcmv = _testamento.Pmcmv;
            selo.Iss = _testamento.Iss;
            selo.Mutua = _testamento.Mutua;
            selo.Acoterj = _testamento.Acoterj;
            selo.Distribuicao = _testamento.Distribuicao;
            selo.Total = _testamento.Total;

            selo.Conjunto = "N";
            selo.Escrevente = _testamento.Login;
            selo.Natureza = "TESTAMENTO";
            _AppServicoSelos.SalvarSeloModificado(selo);



        }


        private void SalvaSeloReservado()
        {
            
                    var selo = _AppServicoSelos.GetById(_digitarTestamento._selo.SeloId);
                    selo.Status = "UTILIZADO";
                    selo.FormUtilizado = "Digitar Testamento";
                    selo.IdAto = _testamento.TestamentoId;
                    selo.DataPratica = _testamento.DataAto;

                    if (_testamento.Recibo != null && _testamento.Recibo != "")
                        selo.Recibo = Convert.ToInt32(_testamento.Recibo);
                    selo.TipoCobranca = _testamento.TipoCobranca;

                    selo.Emolumentos = _testamento.Emolumentos;
                    selo.Fetj = _testamento.Fetj;
                    selo.Fundperj = _testamento.Fundperj;
                    selo.Funperj = _testamento.Funprj;
                    selo.Funarpen = _testamento.Funarpen;
                    selo.Pmcmv = _testamento.Pmcmv;
                    selo.Iss = _testamento.Iss;
                    selo.Mutua = _testamento.Mutua;
                    selo.Acoterj = _testamento.Acoterj;
                    selo.Distribuicao = _testamento.Distribuicao;
                    selo.Total = _testamento.Total;

                    selo.Conjunto = "N";
                    selo.Escrevente = _testamento.Login;
                    selo.Natureza = "TESTAMENTO";
                    _AppServicoSelos.SalvarSeloModificado(selo);
        

            
        }
    }
}

