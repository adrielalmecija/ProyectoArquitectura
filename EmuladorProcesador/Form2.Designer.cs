namespace EmuladorProcesador
{
    partial class FormGrafica
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
            this.dataGridGrafica = new System.Windows.Forms.DataGridView();
            this.ColSO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNuevo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColListo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBloqueado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEjecutando = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTerminado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGrafica)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridGrafica
            // 
            this.dataGridGrafica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridGrafica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridGrafica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGrafica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSO,
            this.ColNuevo,
            this.ColListo,
            this.ColBloqueado,
            this.ColEjecutando,
            this.ColTerminado});
            this.dataGridGrafica.Location = new System.Drawing.Point(22, 70);
            this.dataGridGrafica.MultiSelect = false;
            this.dataGridGrafica.Name = "dataGridGrafica";
            this.dataGridGrafica.ReadOnly = true;
            this.dataGridGrafica.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridGrafica.RowTemplate.Height = 24;
            this.dataGridGrafica.Size = new System.Drawing.Size(646, 366);
            this.dataGridGrafica.TabIndex = 0;
            // 
            // ColSO
            // 
            this.ColSO.HeaderText = "S.O.";
            this.ColSO.Name = "ColSO";
            this.ColSO.ReadOnly = true;
            // 
            // ColNuevo
            // 
            this.ColNuevo.HeaderText = "Nuevo";
            this.ColNuevo.Name = "ColNuevo";
            this.ColNuevo.ReadOnly = true;
            // 
            // ColListo
            // 
            this.ColListo.HeaderText = "Listo";
            this.ColListo.Name = "ColListo";
            this.ColListo.ReadOnly = true;
            // 
            // ColBloqueado
            // 
            this.ColBloqueado.HeaderText = "Bloqueado";
            this.ColBloqueado.Name = "ColBloqueado";
            this.ColBloqueado.ReadOnly = true;
            // 
            // ColEjecutando
            // 
            this.ColEjecutando.HeaderText = "Ejecutando";
            this.ColEjecutando.Name = "ColEjecutando";
            this.ColEjecutando.ReadOnly = true;
            // 
            // ColTerminado
            // 
            this.ColTerminado.HeaderText = "Terminado";
            this.ColTerminado.Name = "ColTerminado";
            this.ColTerminado.ReadOnly = true;
            // 
            // FormGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 477);
            this.Controls.Add(this.dataGridGrafica);
            this.Name = "FormGrafica";
            this.Text = "Grafica de Procesado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGrafica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridGrafica;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColListo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBloqueado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEjecutando;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTerminado;
    }
}