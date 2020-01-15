namespace Cs_IssPrefeitura.Relatorios.Forms
{
    partial class FrmVisualizadorFechamentoMes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.atoissBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cs_issprefeituraDataSet = new Cs_IssPrefeitura.cs_issprefeituraDataSet();
            this.atoissBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.csissprefeituraDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atoissTableAdapter = new Cs_IssPrefeitura.cs_issprefeituraDataSetTableAdapters.atoissTableAdapter();
            this.usuarioTableAdapter1 = new Cs_IssPrefeitura.cs_issprefeituraDataSetTableAdapters.usuarioTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.atoissBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cs_issprefeituraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atoissBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csissprefeituraDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // atoissBindingSource
            // 
            this.atoissBindingSource.DataMember = "atoiss";
            this.atoissBindingSource.DataSource = this.cs_issprefeituraDataSet;
            // 
            // cs_issprefeituraDataSet
            // 
            this.cs_issprefeituraDataSet.DataSetName = "cs_issprefeituraDataSet";
            this.cs_issprefeituraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // atoissBindingSource1
            // 
            this.atoissBindingSource1.DataMember = "atoiss";
            this.atoissBindingSource1.DataSource = this.csissprefeituraDataSetBindingSource;
            // 
            // csissprefeituraDataSetBindingSource
            // 
            this.csissprefeituraDataSetBindingSource.DataSource = this.cs_issprefeituraDataSet;
            this.csissprefeituraDataSetBindingSource.Position = 0;
            // 
            // atoissTableAdapter
            // 
            this.atoissTableAdapter.ClearBeforeFill = true;
            // 
            // usuarioTableAdapter1
            // 
            this.usuarioTableAdapter1.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.atoissBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Cs_IssPrefeitura.Relatorios.ReportViewer.FechametoMes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(729, 628);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmVisualizadorFechamentoMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 628);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmVisualizadorFechamentoMes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APURAÇÃO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVisualizadorFechamentoMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.atoissBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cs_issprefeituraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atoissBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csissprefeituraDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource atoissBindingSource;
        private cs_issprefeituraDataSet cs_issprefeituraDataSet;
        private System.Windows.Forms.BindingSource csissprefeituraDataSetBindingSource;
        private System.Windows.Forms.BindingSource atoissBindingSource1;
        private cs_issprefeituraDataSetTableAdapters.atoissTableAdapter atoissTableAdapter;
        private cs_issprefeituraDataSetTableAdapters.usuarioTableAdapter usuarioTableAdapter1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}