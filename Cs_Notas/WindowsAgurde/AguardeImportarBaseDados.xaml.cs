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
    /// Interaction logic for AguardeExpotarBaseDados.xaml
    /// </summary>
    public partial class AguardeImpotarBaseDados : Window
    {
        BackgroundWorker worker;

        public AguardeImpotarBaseDados()
        {
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
                MessageBox.Show("Não foi possível mover o arquivo para a pasta de Importados. Por favor verifique se os diretórios estão configurados e tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        //    try
        //    {
        //        if (abortado == false)
        //        {

        //            if (sucesso == false)
        //            {
        //                MessageBox.Show("Ocorreu um erro inesperado na importação. Favor verifique os dados importados.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
        //                arquivo.MoveTo(_estoqueSelos.parametros.PathSelosNaoImportados + @"\" + arquivo.Name);
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    this.Close();

        }
    }
}
