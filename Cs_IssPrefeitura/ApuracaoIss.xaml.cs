using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Relatorios.Forms;
using System;
using System.Collections.Generic;
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

namespace Cs_IssPrefeitura
{
    /// <summary>
    /// Interaction logic for ApuracaoIss.xaml
    /// </summary>
    public partial class ApuracaoIss : Window
    {

        List<string> tipoConsulta = new List<string>();
        List<string> mesesDoAno = new List<string>();
        List<string> Anos = new List<string>();

        private readonly IAppServicoApuracaoIss _appServicoApuracaoIss = BootStrap.Container.GetInstance<IAppServicoApuracaoIss>();
        private readonly IAppServicoAtoIss _appServicoAtoIss = BootStrap.Container.GetInstance < IAppServicoAtoIss>();
        private readonly IAppServicoConfiguracoes _appServicoConfiguracoes = BootStrap.Container.GetInstance<IAppServicoConfiguracoes>();

        DateTime primeiroDia = new DateTime();
        DateTime ultimoDia = new DateTime();

        Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss apuracaoSelecionada;

        Usuario _usuario;

        public ApuracaoIss(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListasConsulta();

            cmbTipoConsulta.ItemsSource = tipoConsulta;
            cmbTipoConsulta.SelectedIndex = 0;

            cmbMesFechamento.ItemsSource = mesesDoAno;
            cmbAnoFechamento.ItemsSource = Anos;

            ConsultarApuracao();


        }

        private void CarregarListasConsulta()
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                    tipoConsulta.Add("POR ANO");
                if(i == 1)
                    tipoConsulta.Add("POR MÊS");
            }

            for (int i = 1; i < 13; i++)
            {
                mesesDoAno.Add(string.Format("{0:00} - {1}", i, getMesPorExtenso(i)));
            }

            for (int i = DateTime.Now.Year; i >= 2011; i--)
            {
                Anos.Add(string.Format("{0}", i));
            }
        }

        private void cmbTipoConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoConsulta.SelectedIndex == 0)
            {
                cmbDadoConsulta.ItemsSource = Anos;
                lblInformacao.Content = "Ano";
            }
            else
            {
                cmbDadoConsulta.ItemsSource = mesesDoAno;
                lblInformacao.Content = "Mês";
            }

            cmbDadoConsulta.SelectedIndex = 0;
        }

        private void cmbAtribuicao_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ConsultarApuracao();
        }


        private void ConsultarApuracao()
        {
            try
            {
                if (cmbTipoConsulta.Text == "POR ANO")
                {
                    dataGridMesesfechados.ItemsSource = _appServicoApuracaoIss.ObterListaApuracaoPorAno(Convert.ToInt16(cmbDadoConsulta.Text));
                }
                if (cmbTipoConsulta.Text == "POR MÊS")
                {
                    string dadoConsulta = cmbDadoConsulta.Text.Substring(0, 2);


                    dataGridMesesfechados.ItemsSource = _appServicoApuracaoIss.ObterListaApuracaoPorMes(Convert.ToInt16(dadoConsulta));
                }

                if (dataGridMesesfechados.Items.Count > 0)
                {
                    dataGridMesesfechados.SelectedIndex = 0;
                    btnImprimirFechamento.IsEnabled = true;
                }
                else
                {
                    btnImprimirFechamento.IsEnabled = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridMesesfechados_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private string getMesPorExtenso(int mes)
        {
            // Obtém o nome do mês por extenso
            string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(mes).ToLower();
            // retorna o nome do mês com a primeira letra em maiúscula
            return char.ToUpper(mesExtenso[0]) + mesExtenso.Substring(1);
        }

        private void cmbMesFechamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMesFechamento.SelectedIndex > -1)
            {
                cmbAnoFechamento.IsEnabled = true;
                ObterPrimeiroUltimoDiaMes();
            }
        }

        private void cmbAnoFechamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAnoFechamento.SelectedIndex > -1)
            {
                btnFecharMes.IsEnabled = true;
                dpConsultaInicio.IsEnabled = true;
                dpConsultaFim.IsEnabled = true;
                ObterPrimeiroUltimoDiaMes();
            }
        }

        private void ObterPrimeiroUltimoDiaMes()
        {
            if(cmbMesFechamento.SelectedIndex > -1 && cmbAnoFechamento.SelectedIndex >-1)
            {
                var data = Convert.ToDateTime(string.Format("{00}/{01}/{0002}", 15, cmbMesFechamento.SelectedIndex +1, cmbAnoFechamento.SelectedItem)); //pega a data que está no controle
                primeiroDia = new DateTime(data.Year, data.Month, 1);
                ultimoDia = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));

                dpConsultaInicio.SelectedDate = primeiroDia;
                dpConsultaFim.SelectedDate = ultimoDia;

            }
        }

        private void btnFecharMes_Click(object sender, RoutedEventArgs e)
        {

            if (_usuario.FechamentoMes == false)
            {
                MessageBox.Show("Usuário logado não tem permissão para Fechar Mês.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            if(cmbMesFechamento.SelectedIndex > -1 && cmbAnoFechamento.SelectedIndex > -1)
            {
                if (dpConsultaInicio.SelectedDate != null && dpConsultaFim.SelectedDate != null)
                {

                    var verificarApuracaoExistente = _appServicoApuracaoIss.ObterListaApuracaoPorMesAno(cmbMesFechamento.SelectedIndex + 1, Convert.ToInt16(cmbAnoFechamento.SelectedItem));

                    if (verificarApuracaoExistente.Count > 0)
                    {
                        MessageBox.Show("A Apuração referente ao mês e ano que foi selecionada já está fechada.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                    List<AtoIss> _listaAtos = _appServicoAtoIss.ListarAtosPorPeriodo(dpConsultaInicio.SelectedDate.Value, dpConsultaFim.SelectedDate.Value);

                    if (_listaAtos.Count == 0)
                    {
                        MessageBox.Show("Não existe atos a serem vinculados neste período.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }


                    if (MessageBox.Show("Confirma o Fechamento do Mês de " + cmbMesFechamento.Text.Substring(5,cmbMesFechamento.Text.Length - 5).ToUpper()  + " do Ano " + cmbAnoFechamento.Text + "?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var aguarde = new AguardeApuracaoIss(cmbMesFechamento.SelectedIndex + 1, Convert.ToInt16(cmbAnoFechamento.SelectedItem), dpConsultaInicio.SelectedDate.Value, dpConsultaFim.SelectedDate.Value);
                        aguarde.Owner = this;
                        aguarde.ShowDialog();

                        ConsultarApuracao();
                    }
                }
                else
                {
                    MessageBox.Show("É necessário informar Data Inicial e Data Final.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("É necessário informar Mês e Ano de Fechamento.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }

        private void cmbDadoConsulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnConsultar.IsEnabled = true;
        }

        private void btnCancelarApuracao_Click(object sender, RoutedEventArgs e)
        {

            if (_usuario.FechamentoMes == false)
            {
                MessageBox.Show("Usuário logado não tem permissão para Cancelar Atpuração.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            if (dataGridMesesfechados.SelectedItem != null)
            {

                apuracaoSelecionada = _appServicoApuracaoIss.GetById(((Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss)dataGridMesesfechados.SelectedItem).ApuracaoIssId);

                if (apuracaoSelecionada.Cancelado == "SIM")
                {
                    MessageBox.Show("O Fechamento selecionado foi cancelado por outro usuário.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    ConsultarApuracao();
                    return;

                }


                if (MessageBox.Show("Confirmar Cancelamento da Apuração?", "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var dataInicio = Convert.ToDateTime(apuracaoSelecionada.Periodo.Substring(0, 10));

                    var dataFim = Convert.ToDateTime(apuracaoSelecionada.Periodo.Substring(13, 10));

                    var atosIss = _appServicoAtoIss.ListarAtosPorPeriodo(dataInicio, dataFim);



                    var aguarde = new AguardeApuracaoIss(apuracaoSelecionada, atosIss.Where(p => p.IdApuracaoIss == apuracaoSelecionada.ApuracaoIssId).ToList());
                    aguarde.Owner = this;
                    aguarde.ShowDialog();

                    ConsultarApuracao();
                }

            }
        }

        private void dpConsultaInicio_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpConsultaInicio.SelectedDate < primeiroDia)
            {
                dpConsultaInicio.SelectedDate = primeiroDia;
            }
            if (dpConsultaInicio.SelectedDate > ultimoDia)
            {
                dpConsultaInicio.SelectedDate = ultimoDia;
            }
            if (dpConsultaInicio.SelectedDate > dpConsultaFim.SelectedDate)
            {
                dpConsultaFim.SelectedDate = dpConsultaInicio.SelectedDate;
            }
        }

        private void dpConsultaFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpConsultaFim.SelectedDate > ultimoDia)
            {
                dpConsultaFim.SelectedDate = ultimoDia;
            }
            if (dpConsultaFim.SelectedDate < primeiroDia)
            {
                dpConsultaFim.SelectedDate = primeiroDia;
            }

            if (dpConsultaFim.SelectedDate < dpConsultaInicio.SelectedDate)
            {
                dpConsultaFim.SelectedDate = dpConsultaInicio.SelectedDate;
            }
        }

        private void dataGridMesesfechados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridMesesfechados.SelectedItem != null)
            {
                btnCancelarApuracao.IsEnabled = true;
                apuracaoSelecionada = (Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss)dataGridMesesfechados.SelectedItem;

                if (apuracaoSelecionada.Cancelado == "SIM")
                {
                    MessageBox.Show("O Fechamento selecionado já foi cancelado por outro usuário.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Stop);
                    ConsultarApuracao();
                }
            }
            else
                btnCancelarApuracao.IsEnabled = false;

        }

        private void btnImprimirFechamento_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMesesfechados.SelectedIndex > -1)
            {
                var visualizar = new FrmVisualizadorFechamentoMes(_appServicoConfiguracoes.GetById(1), (Cs_IssPrefeitura.Dominio.Entities.ApuracaoIss)dataGridMesesfechados.SelectedItem);
                visualizar.ShowDialog();
                visualizar.Close();
            }
        }
    }
}
