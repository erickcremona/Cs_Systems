using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
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

namespace Cs_Notas.Windows.Escritura
{
    /// <summary>
    /// Interaction logic for ImovelEscritura.xaml
    /// </summary>
    public partial class ImovelEscritura : Window
    {
        DigitarEscritura _digitarEscritura;
        public Imovel imovel;
        List<string> Ufs = new List<string>();
        string _tipoBem;
        public List<ServentiasOutras> serventiasOutras;
        int ordemImovel;
        public ServentiasOutras serventiasOutrasSelecionada;

        private readonly IAppServicoMunicipios _AppServicoMunicipios = BootStrap.Container.GetInstance<IAppServicoMunicipios>();

        private readonly IAppServicoServentia _AppServicoServentia = BootStrap.Container.GetInstance<IAppServicoServentia>();

        private readonly IAppServicoServentiasOutras _AppServicoServentiasOutras = BootStrap.Container.GetInstance<IAppServicoServentiasOutras>();

        private readonly IAppServicoImovel _AppServicoImovel = BootStrap.Container.GetInstance<IAppServicoImovel>();

        private readonly IAppServicoBensAtosConjuntos _AppServicoBensAtosConjuntos = BootStrap.Container.GetInstance<IAppServicoBensAtosConjuntos>();

        public string estado;

        public ImovelEscritura(DigitarEscritura digitarEscritura, string tipoBem)
        {
            _digitarEscritura = digitarEscritura;
            _tipoBem = tipoBem;
            estado = _digitarEscritura.estado;
            InitializeComponent();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            CarregarUF();
            serventiasOutras = _AppServicoServentiasOutras.GetAll().ToList();
            cmbZonaImovel.SelectedIndex = 0;
            cmbZonaImovel.Focus();


            if (_digitarEscritura.estado == "adicionando imovel")
            {

                if (_digitarEscritura.listaImoveis.Count > 0)
                    ordemImovel = _digitarEscritura.listaImoveis.Max(p => p.Ordem) + 1;
                else
                    ordemImovel = 1;
            }
            else
            {
                ordemImovel = _digitarEscritura.listaImoveis[_digitarEscritura.dataGridImovel.SelectedIndex].Ordem;
                imovel = _digitarEscritura.listaImoveis.Where(p => p.ImovelId == ((Imovel)_digitarEscritura.dataGridImovel.SelectedItem).ImovelId).FirstOrDefault();
            }

            if (imovel != null)
                CarregarImovel();
            else
                imovel = new Imovel();

            if (_digitarEscritura.estado == "adicionando imovel")
            {
                lblTexto.Content = string.Format("Incluindo novo imóvel Nº {0}", ordemImovel);
            }
            else
            {
                lblTexto.Content = string.Format("Alterando imóvel Nº {0}", ordemImovel);
            }

            dataGridAtoConjunto.ItemsSource = _digitarEscritura.listaAtos;


            CarregarBensConjuntosNaLista();
        }

        private void CarregarImovel()
        {
            switch (imovel.TipoRecolhimento)
            {
                case "N":
                    cmbRecolhimentoImovel.SelectedIndex = 0;
                    break;

                case "I":
                    cmbRecolhimentoImovel.SelectedIndex = 1;
                    break;

                case "F":
                    cmbRecolhimentoImovel.SelectedIndex = 2;
                    break;

                default:

                    break;
            }

            if (imovel.SubTipo == "1")
                cmbTipoImovel.SelectedIndex = 0;
            if (imovel.SubTipo == "2")
                cmbTipoImovel.SelectedIndex = 1;

            if (imovel.TipoImovel == "U")
            {
                cmbZonaImovel.SelectedIndex = 0;
            }
            if (imovel.TipoImovel == "R")
            {
                cmbZonaImovel.SelectedIndex = 1;
            }

            txtCepImovel.Text = imovel.Cep;

            txtNumeroImovel.Text = imovel.Numero.ToString();

            txtInscricaoImobiliaria.Text = imovel.InscricaoImobiliaria;

            txtInscricaoIncraImovel.Text = imovel.Incra;

            txtAreaImovel.Text = imovel.Area;

            txtValorAlienadoImovel.Text = string.Format("{0:n2}", imovel.ValorAlienacao);

            txtDenominacaoImovel.Text = imovel.Denominacao;

            txtInscricaoSRFImovel.Text = imovel.SRF;

            txtEnderecoImovel.Text = imovel.Endereco;

            txtBairro.Text = imovel.Bairro;

            cmbMunicipio.Text = imovel.Municipio;

            cmbUfImovel.Text = imovel.Uf;

            txtGuiaImpostoImovel.Text = imovel.Guia;

            txtCpfCnpjAdquirente.Text = imovel.Adquirente;

            txtCpfCnpjCedente.Text = imovel.Cedente;

            txtMaiorPorcaoImovel.Text = imovel.MaiorPorcao;

            txtValorBemImovel.Text = string.Format("{0:N2}", imovel.Valor);

            txtParteTransferidaImovel.Text = imovel.ParteTranferida;

            txtMatriculaImovel.Text = imovel.Matricula;

            txtComplementoImovel.Text = imovel.Complemento;

            txtServentia.Text = imovel.Rgi;

            txtLocalImovel.Text = imovel.LocalTerreno;

            txtValorGuiaImpostoImovel.Text = string.Format("{0:N2}", imovel.ValorGuia);

            cmbMunicipio.SelectedValue = imovel.CodigoMunicipio;

            txtCodigo.Text = imovel.Serventia.ToString();

            cmbTipoImpostoImovel.Text = imovel.TipoImposto;

            if (txtAreaImovel.Text != "")
                ckbNaoConstaAreaImovel.IsChecked = false;
            else
                ckbNaoConstaAreaImovel.IsChecked = true;

            _tipoBem = imovel.TipoBem;

            cmbZonaImovel.Focus();

        }

        private void CarregarBensConjuntosNaLista()
        {
            var bensConjuntos = _digitarEscritura.listaBensAtosConjuntos.Where(p => p.IdImovel == imovel.ImovelId).ToList();


            foreach (var item in _digitarEscritura.listaAtos)
            {
                item.IsChecked = false;

                if (imovel.Principal == "S")
                    _digitarEscritura.listaAtos[0].IsChecked = true;

                if (_digitarEscritura.estado == "alterando imovel")
                    for (int i = 0; i < bensConjuntos.Count; i++)
                    {
                        if (item.ConjuntoId == bensConjuntos[i].IdAtoConjunto)
                            item.IsChecked = true;
                    }
                else
                    item.IsChecked = true;
            }
        }

        private void CarregarUF()
        {

            Ufs = _AppServicoMunicipios.ObterUfsDosMunicipios();

            cmbUfImovel.ItemsSource = Ufs;

        }

        private void cmbZona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AbilitarDesabilitarUrbano(cmbZonaImovel.SelectedIndex);
            AbilitarDesabilitarRural(cmbZonaImovel.SelectedIndex);
        }

        private void AbilitarDesabilitarUrbano(int indice)
        {
            if (indice == 0)
            {
                GridZonaUrbana.IsEnabled = true;
            }
            else
            {
                txtCepImovel.Text = "";
                txtEnderecoImovel.Text = "";
                txtNumeroImovel.Text = "";
                txtComplementoImovel.Text = "";
                txtBairro.Text = "";
                GridZonaUrbana.IsEnabled = false;
            }

        }

        private void AbilitarDesabilitarRural(int indice)
        {
            if (indice == 1)
            {
                GridZonaRural.IsEnabled = true;
            }
            else
            {
                txtLocalImovel.Text = "";
                txtDenominacaoImovel.Text = "";
                txtInscricaoIncraImovel.Text = "";
                txtInscricaoSRFImovel.Text = "";
                txtAreaImovel.Text = "";
                ckbNaoConstaAreaImovel.IsChecked = true;
                GridZonaRural.IsEnabled = false;
            }
        }

        private void cmbZona_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void btnConsultarServentia_Click(object sender, RoutedEventArgs e)
        {
            var consultarServentia = new ConsultaServentias(this);
            consultarServentia.Owner = this;
            consultarServentia.ShowDialog();

            if (serventiasOutrasSelecionada != null)
            {
                txtCodigo.Text = serventiasOutrasSelecionada.Codigo.ToString();
                txtServentia.Text = serventiasOutrasSelecionada.Descricao;
            }
        }

        private void txtCodigo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
                PesquisarServentia();
            else
                txtServentia.Text = "";
        }

        private void PesquisarServentia()
        {
            var codigo = Convert.ToInt32(txtCodigo.Text);

            serventiasOutrasSelecionada = serventiasOutras.Where(p => p.Codigo == codigo).FirstOrDefault();

            if (serventiasOutrasSelecionada != null)
                txtServentia.Text = serventiasOutrasSelecionada.Descricao;
            else
                txtServentia.Text = "";
        }

        private void cmbMunicipio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void cmbMunicipio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }



        private void DigitarSomenteNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }

        private void DigitarSemNumeros(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32);
        }


        private void DigitarSomenteNumerosEmReaisComVirgual(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 || key >= 74 && key <= 83 || key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key == 142 || key == 88);
        }

        private void DigitarSomenteLetras(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key == 2 || key == 3 || key == 23 || key == 25 || key == 32 || key >= 44 && key <= 69);
        }


        private void dataGridAtoConjunto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var quant = 0;
            foreach (var item in _digitarEscritura.listaAtos)
            {
                if (item.IsChecked == true)
                {
                    quant++;
                }
            }

            if (((AtoConjuntos)dataGridAtoConjunto.SelectedItem).IsChecked == true && quant > 1)
            {
                _digitarEscritura.listaAtos[dataGridAtoConjunto.SelectedIndex].IsChecked = false;
            }
            else
            {
                _digitarEscritura.listaAtos[dataGridAtoConjunto.SelectedIndex].IsChecked = true;
            }

            dataGridAtoConjunto.Items.Refresh();
        }

        private void MenuItemMarcarTodos_Click(object sender, RoutedEventArgs e)
        {
            MarcarTodosCheckes();
        }

        private void MenuItemDesmarcarTodos_Click(object sender, RoutedEventArgs e)
        {
            DesmarcarTodosCheckes();
        }

        private void DesmarcarTodosCheckes()
        {
            try
            {

                foreach (var item in _digitarEscritura.listaAtos)
                {
                    item.IsChecked = false;

                }

                _digitarEscritura.listaAtos[0].IsChecked = true;
                dataGridAtoConjunto.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MarcarTodosCheckes()
        {
            try
            {
                foreach (var item in _digitarEscritura.listaAtos)
                {
                    item.IsChecked = true;
                    dataGridAtoConjunto.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnSalvarImovel_Click(object sender, RoutedEventArgs e)
        {
            SalvarImovel();

            SalvarBensConjuntosNaLista();

            _digitarEscritura.dataGridImovel.Items.Refresh();

            if (imovel != null)
            {
                _digitarEscritura.dataGridImovel.ItemsSource = null;
                _digitarEscritura.dataGridImovel.ItemsSource = _digitarEscritura.listaImoveis;

                _digitarEscritura.dataGridImovel.SelectedItem = imovel;
                _digitarEscritura.dataGridImovel.ScrollIntoView(imovel);
                _digitarEscritura.dataGridImovel.Items.Refresh();
            }

            this.Close();
        }

        private void SalvarBensConjuntosNaLista()
        {
            var bensConjuntos = new BensAtosConjuntos();

            if (_digitarEscritura.estado == "alterando imovel")
            {
                var listaBensConjuntos = _digitarEscritura.listaBensAtosConjuntos.Where(p => p.IdImovel == imovel.ImovelId).ToList();

                foreach (var item in listaBensConjuntos)
                {
                    if (item.IdAtoConjunto != 0)
                    {                        
                        var excluirBanco = _AppServicoBensAtosConjuntos.GetById(item.BensAtosConjuntosID);
                        _AppServicoBensAtosConjuntos.Remove(excluirBanco);
                    }
                    _digitarEscritura.listaBensAtosConjuntos.Remove(item);
                }
            }


            for (int i = 0; i < _digitarEscritura.listaAtos.Count; i++)
            {

                if (_digitarEscritura.listaAtos[i].IsChecked == true)
                {
                    bensConjuntos = new BensAtosConjuntos();

                    bensConjuntos.IdEscritura = _digitarEscritura.listaAtos[i].IdEscritura;
                    bensConjuntos.IdImovel = imovel.ImovelId;
                    bensConjuntos.IdAtoConjunto = _digitarEscritura.listaAtos[i].ConjuntoId;
                    if (i > 0)
                    _AppServicoBensAtosConjuntos.Add(bensConjuntos);
                    _digitarEscritura.listaBensAtosConjuntos.Add(bensConjuntos);

                }
            }
        }


        private void SalvarImovel()
        {



            imovel.IdEscritura = _digitarEscritura._escrituras.EscriturasId;

            imovel.Ordem = ordemImovel;

            switch (cmbRecolhimentoImovel.SelectedIndex)
            {
                case 0:
                    imovel.TipoRecolhimento = "N";
                    break;

                case 1:
                    imovel.TipoRecolhimento = "I";
                    break;

                case 2:
                    imovel.TipoRecolhimento = "F";
                    break;

                default:
                    imovel.TipoRecolhimento = null;
                    break;


            }

            if (_digitarEscritura.listaAtos[0].IsChecked == true)
                imovel.Principal = "S";
            else
                imovel.Principal = "N";


            if (cmbZonaImovel.SelectedIndex == 0)
            {
                imovel.TipoImovel = "U";
            }
            else
            {
                imovel.TipoImovel = "R";
            }

            if (cmbTipoImovel.SelectedIndex == 0)
                imovel.SubTipo = "1";
            if (cmbTipoImovel.SelectedIndex == 1)
                imovel.SubTipo = "2";

            imovel.InscricaoImobiliaria = txtInscricaoImobiliaria.Text.Trim();

            imovel.Incra = txtInscricaoIncraImovel.Text.Trim();

            imovel.Area = txtAreaImovel.Text;

            imovel.Denominacao = txtDenominacaoImovel.Text.Trim();

            imovel.SRF = txtInscricaoSRFImovel.Text.Trim();

            imovel.Endereco = txtEnderecoImovel.Text.Trim();

            imovel.Bairro = txtBairro.Text.Trim();

            imovel.Municipio = cmbMunicipio.Text;

            imovel.Uf = cmbUfImovel.Text;

            imovel.Guia = txtGuiaImpostoImovel.Text.Trim();

            imovel.Adquirente = txtCpfCnpjAdquirente.Text;

            imovel.Cedente = txtCpfCnpjCedente.Text;

            imovel.MaiorPorcao = txtMaiorPorcaoImovel.Text;

            if (txtValorBemImovel.Text.Length > 0)
                imovel.Valor = Convert.ToDecimal(txtValorBemImovel.Text);

            imovel.ParteTranferida = txtParteTransferidaImovel.Text;

            if (txtValorAlienadoImovel.Text != "")
                imovel.ValorAlienacao = Convert.ToDecimal(txtValorAlienadoImovel.Text);

            imovel.Matricula = txtMatriculaImovel.Text.Trim();

            imovel.Complemento = txtComplementoImovel.Text.Trim();

            imovel.Rgi = txtServentia.Text.Trim();

            imovel.LocalTerreno = txtLocalImovel.Text;

            if (txtValorGuiaImpostoImovel.Text.Length > 0)
                imovel.ValorGuia = Convert.ToDecimal(txtValorGuiaImpostoImovel.Text);

            imovel.CodigoMunicipio = Convert.ToInt32(cmbMunicipio.SelectedValue);

            if (txtCodigo.Text.Length > 0)
                imovel.Serventia = Convert.ToInt32(txtCodigo.Text);

            if (cmbTipoImpostoImovel.SelectedIndex > -1)
                imovel.TipoImposto = cmbTipoImpostoImovel.Text;

            if (txtNumeroImovel.Text != "")
                imovel.Numero = Convert.ToInt32(txtNumeroImovel.Text);

            imovel.Cep = txtCepImovel.Text;

            imovel.TipoBem = _tipoBem;


            if (_digitarEscritura.estado == "adicionando imovel")
            {
                _AppServicoImovel.Add(imovel);

                _digitarEscritura.listaImoveis.Add(imovel);
            }
            else
            {
                var imovelAlterar = (Imovel)_digitarEscritura.dataGridImovel.SelectedItem;
                imovelAlterar = imovel;
                
                _AppServicoImovel.Update(imovel);
            }
        }



        private void txtNumeroImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            DigitarSomenteNumeros(sender, e);
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtMatriculaImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtInscricaoImobiliaria_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbUfImovel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUfImovel.SelectedIndex > -1)
            {
                cmbMunicipio.ItemsSource = _AppServicoMunicipios.ObterMunicipiosPorUF(Ufs[cmbUfImovel.SelectedIndex]).OrderBy(p => p.Nome);

                cmbMunicipio.DisplayMemberPath = "Nome";

                cmbMunicipio.SelectedValuePath = "Codigo";

            }
        }

        private void cmbUfImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCepImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void txtComplementoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtBairro_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtLocalImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtDenominacaoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtInscricaoIncraImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtInscricaoSRFImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtAreaImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (!txtAreaImovel.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtAreaImovel.Text.IndexOf(",");

                if (indexVirgula + 3 == txtAreaImovel.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void cmbRecolhimentoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void cmbTipoImpostoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtGuiaImpostoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtValorGuiaImpostoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (txtValorGuiaImpostoImovel.SelectionLength == txtValorGuiaImpostoImovel.Text.Length)
            {
                txtValorGuiaImpostoImovel.Text = "";
            }

            if (!txtValorGuiaImpostoImovel.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorGuiaImpostoImovel.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorGuiaImpostoImovel.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtValorBemImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (txtValorBemImovel.SelectionLength == txtValorBemImovel.Text.Length)
            {
                txtValorBemImovel.Text = "";
            }

            if (!txtValorBemImovel.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorBemImovel.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorBemImovel.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtValorAlienadoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);

            if (txtValorAlienadoImovel.SelectionLength == txtValorAlienadoImovel.Text.Length)
            {
                txtValorAlienadoImovel.Text = "";
            }

            if (!txtValorAlienadoImovel.Text.Contains(","))
                DigitarSomenteNumerosEmReaisComVirgual(sender, e);
            else
            {
                int indexVirgula = txtValorAlienadoImovel.Text.IndexOf(",");

                if (indexVirgula + 3 == txtValorAlienadoImovel.Text.Length)
                    DigitarSemNumeros(sender, e);
                else
                    DigitarSomenteNumeros(sender, e);
            }
        }

        private void txtMaiorPorcaoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtParteTransferidaImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtCpfCnpjAdquirente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void txtCpfCnpjCedente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
            DigitarSomenteNumeros(sender, e);
        }

        private void ckbNaoConstaAreaImovel_Checked(object sender, RoutedEventArgs e)
        {
            txtAreaImovel.Text = "";
        }

        private void ckbNaoConstaAreaImovel_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAreaImovel.Focus();
        }

        private void txtAreaImovel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtAreaImovel.Text != "" && txtAreaImovel.Text != ",")
                txtAreaImovel.Text = string.Format("{0:n2}", Convert.ToDecimal(txtAreaImovel.Text));
            else
                txtAreaImovel.Text = "";

            imovel.Area = txtAreaImovel.Text;
        }

        private void txtValorGuiaImpostoImovel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorGuiaImpostoImovel.Text != "" && txtValorGuiaImpostoImovel.Text != ",")
                txtValorGuiaImpostoImovel.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorGuiaImpostoImovel.Text));
            else
                txtValorGuiaImpostoImovel.Text = "0,00";

            if (txtValorGuiaImpostoImovel.Text.Length > 0)
                imovel.ValorGuia = Convert.ToDecimal(txtValorGuiaImpostoImovel.Text);
        }


        private void txtValorBemImovel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorBemImovel.Text != "" && txtValorBemImovel.Text != ",")
                txtValorBemImovel.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorBemImovel.Text));
            else
                txtValorBemImovel.Text = "0,00";

            if (txtValorBemImovel.Text.Length > 0)
                imovel.Valor = Convert.ToDecimal(txtValorBemImovel.Text);
        }

        private void txtValorAlienadoImovel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorAlienadoImovel.Text != "" && txtValorAlienadoImovel.Text != ",")
                txtValorAlienadoImovel.Text = string.Format("{0:n2}", Convert.ToDecimal(txtValorAlienadoImovel.Text));
            else
                txtValorAlienadoImovel.Text = "0,00";

            if (txtValorAlienadoImovel.Text != "")
                imovel.ValorAlienacao = Convert.ToDecimal(txtValorAlienadoImovel.Text);


        }

        private void btnImporarImovel_Click(object sender, RoutedEventArgs e)
        {
            if (_digitarEscritura.listaNomes.Count > 0)
            {
                var alienante = _digitarEscritura.listaNomes.Where(p => p.Tipo == "AL").FirstOrDefault();

                var adiquirente = _digitarEscritura.listaNomes.Where(p => p.Tipo == "AD").FirstOrDefault();

                if (adiquirente != null)
                    txtCpfCnpjAdquirente.Text = adiquirente.Documento;
                if (alienante != null)
                    txtCpfCnpjCedente.Text = alienante.Documento;
            }
        }

        private void PassarDeUmCoponenteParaOutro(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void cmbTipoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtServentia_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void txtEnderecoImovel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PassarDeUmCoponenteParaOutro(sender, e);
        }

        private void btnDoi_Click(object sender, RoutedEventArgs e)
        {
            var doi = new ImovelDoi(this, _digitarEscritura.dtDataAto.SelectedDate.Value, estado);
            doi.Owner = this;
            doi.ShowDialog();

        }

        private void txtAreaImovel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAreaImovel.Text.Length > 0)
            {
                ckbNaoConstaAreaImovel.IsChecked = false;
            }
            else
                ckbNaoConstaAreaImovel.IsChecked = true;
        }

        private void txtNumeroImovel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNumeroImovel.Text == "0")
                txtNumeroImovel.Text = "";
        }

        private void txtValorGuiaImpostoImovel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorGuiaImpostoImovel.Text == "0,00")
                txtValorGuiaImpostoImovel.Text = "";
        }

        private void txtValorBemImovel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorBemImovel.Text == "0,00")
                txtValorBemImovel.Text = "";
        }

        private void txtValorAlienadoImovel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtValorAlienadoImovel.Text == "0,00")
                txtValorAlienadoImovel.Text = "";
        }
    }
}
