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
using System.IO;
using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;

namespace Cs_Gerencial.Windows
{
    /// <summary>
    /// Interaction logic for ParametrosConfigDiretorios.xaml
    /// </summary>
    public partial class ParametrosConfigDiretorios : Window
    {
        private readonly IAppServicoParametros _AppServicoParametros = BootStrap.Container.GetInstance<IAppServicoParametros>();

        private readonly IAppServicoLogSistema _AppServicoLogSistema = BootStrap.Container.GetInstance<IAppServicoLogSistema>();
        
        Parametros parametros;

        LogSistema logSistema;

        Usuario _usuario;


        public ParametrosConfigDiretorios(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            parametros = new Parametros();

            parametros = _AppServicoParametros.GetAll().FirstOrDefault();

            
            txtDiretorioSelosNaoImportados.Text = parametros.PathSelosNaoImportados;
            txtDiretorioSelosImportados.Text = parametros.PathSelosImportados;
            txtDiretorioCenib.Text = parametros.PathSelosCenib;

        }

        private void btnLocalizarDiretorioNaoImportados_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = txtDiretorioSelosNaoImportados.Text;            

            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtDiretorioSelosNaoImportados.Text = folderBrowserDialog.SelectedPath;
            }

            folderBrowserDialog.Dispose();
        }

        private void btnLocalizarSelosImportados_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = txtDiretorioSelosImportados.Text;

            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtDiretorioSelosImportados.Text = folderBrowserDialog.SelectedPath;
            }
            folderBrowserDialog.Dispose();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtDiretorioSelosImportados.Text != parametros.PathSelosImportados || txtDiretorioSelosNaoImportados.Text
                    != parametros.PathSelosNaoImportados || txtDiretorioCenib.Text != parametros.PathSelosCenib)
                {
                    parametros.PathSelosNaoImportados = txtDiretorioSelosNaoImportados.Text;
                    parametros.PathSelosImportados = txtDiretorioSelosImportados.Text;
                    parametros.PathSelosCenib = txtDiretorioCenib.Text;

                    _AppServicoParametros.Update(parametros);

                    SalvarLogSistema("Alterou Diretórios");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        private void SalvarLogSistema(string descricao)
        {
            logSistema = new LogSistema();

            logSistema.Data = DateTime.Now.Date;

            logSistema.Descricao = descricao;

            logSistema.Hora = DateTime.Now.ToLongTimeString();

            logSistema.Tela = "Configurações de Diretórios";

            logSistema.IdUsuario = _usuario.UsuarioId;

            logSistema.Usuario = _usuario.NomeUsuario;

            logSistema.Maquina = Environment.MachineName.ToString();

            _AppServicoLogSistema.Add(logSistema);
        }

        private void btnLocalizarCenib_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = txtDiretorioCenib.Text;

            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtDiretorioCenib.Text = folderBrowserDialog.SelectedPath;
            }

            folderBrowserDialog.Dispose();
        }

    }
}
