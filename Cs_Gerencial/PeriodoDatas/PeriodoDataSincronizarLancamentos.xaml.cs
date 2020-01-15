using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Windows;
using Cs_Gerencial.WindowsAguarde;
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

namespace Cs_Gerencial.PeriodoDatas
{
    /// <summary>
    /// Interaction logic for PeriodoDataSincronizarLancamentos.xaml
    /// </summary>
    public partial class PeriodoDataSincronizarLancamentos : Window
    {
        Usuario _usuario;
        CadastroLancamentos _cadastroLancametos;

        private readonly IAppServicoContas _AppServicoContas = BootStrap.Container.GetInstance<IAppServicoContas>();


        public PeriodoDataSincronizarLancamentos(Usuario usuario, CadastroLancamentos cadastroLancametos)
        {
            _usuario = usuario;
            _cadastroLancametos = cadastroLancametos;
            InitializeComponent();
        }

        private void dpConsultaInicio_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpSincronizarInicio.SelectedDate > DateTime.Now.Date)
            {
                dpSincronizarInicio.SelectedDate = DateTime.Now.Date;
            }

            dpSincronizarFim.SelectedDate = dpSincronizarInicio.SelectedDate;

            if (dpSincronizarInicio.SelectedDate > dpSincronizarFim.SelectedDate)
            {
                dpSincronizarFim.SelectedDate = dpSincronizarInicio.SelectedDate;
            }
        }

        private void dpConsultaFim_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpSincronizarInicio.SelectedDate != null)
            {
                if (dpSincronizarInicio.SelectedDate > dpSincronizarFim.SelectedDate)
                {
                    dpSincronizarFim.SelectedDate = dpSincronizarInicio.SelectedDate;
                }
            }
            else
            {
                dpSincronizarInicio.SelectedDate = dpSincronizarFim.SelectedDate;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpSincronizarInicio.SelectedDate = DateTime.Now;
        }

        private void btnSincronizar_Click(object sender, RoutedEventArgs e)
        {
            Close();

            var sincronizar = new Sincronizando(dpSincronizarInicio.SelectedDate.Value, dpSincronizarFim.SelectedDate.Value, _usuario);
            sincronizar.Owner = _cadastroLancametos;
            sincronizar.ShowDialog();
           
            try
            {

                _cadastroLancametos.listaTodos = _AppServicoContas.ConsultaPorPeriodo(dpSincronizarInicio.SelectedDate.Value, dpSincronizarFim.SelectedDate.Value).ToList();

                _cadastroLancametos.CarregarDataGridDeposito();

                _cadastroLancametos.CarregarDataGridReceita();

                _cadastroLancametos.CarregarDataGridDespesas();

                _cadastroLancametos.dpConsultaInicio.SelectedDate = dpSincronizarInicio.SelectedDate.Value;

                _cadastroLancametos.dpConsultaFim.SelectedDate = dpSincronizarFim.SelectedDate.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado. " + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
