namespace SITCASH_EXE_PS.VIEW
{
    partial class frmBuscarAyudante
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
            this.dbgridAyudantes = new System.Windows.Forms.DataGridView();
            this.txtbuscarayudante = new System.Windows.Forms.TextBox();
            this.cbcriterioayudante = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbuscarAyudante = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridAyudantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dbgridAyudantes
            // 
            this.dbgridAyudantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgridAyudantes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridAyudantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgridAyudantes.Location = new System.Drawing.Point(12, 77);
            this.dbgridAyudantes.Name = "dbgridAyudantes";
            this.dbgridAyudantes.Size = new System.Drawing.Size(548, 258);
            this.dbgridAyudantes.TabIndex = 0;
            this.dbgridAyudantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridAyudantes_CellClick);
            // 
            // txtbuscarayudante
            // 
            this.txtbuscarayudante.Location = new System.Drawing.Point(66, 19);
            this.txtbuscarayudante.Name = "txtbuscarayudante";
            this.txtbuscarayudante.Size = new System.Drawing.Size(248, 20);
            this.txtbuscarayudante.TabIndex = 1;
            // 
            // cbcriterioayudante
            // 
            this.cbcriterioayudante.FormattingEnabled = true;
            this.cbcriterioayudante.Items.AddRange(new object[] {
            "POR NOMBRE",
            "POR ID. VENDEDOR",
            "POR ZONA DE VENTA"});
            this.cbcriterioayudante.Location = new System.Drawing.Point(321, 19);
            this.cbcriterioayudante.Name = "cbcriterioayudante";
            this.cbcriterioayudante.Size = new System.Drawing.Size(158, 21);
            this.cbcriterioayudante.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "BUSCAR";
            // 
            // btnbuscarAyudante
            // 
            this.btnbuscarAyudante.Location = new System.Drawing.Point(485, 19);
            this.btnbuscarAyudante.Name = "btnbuscarAyudante";
            this.btnbuscarAyudante.Size = new System.Drawing.Size(75, 23);
            this.btnbuscarAyudante.TabIndex = 4;
            this.btnbuscarAyudante.Text = "Buscar";
            this.btnbuscarAyudante.UseVisualStyleBackColor = true;
            this.btnbuscarAyudante.Click += new System.EventHandler(this.btnbuscarAyudante_Click);
            // 
            // frmBuscarAyudante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 345);
            this.Controls.Add(this.btnbuscarAyudante);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbcriterioayudante);
            this.Controls.Add(this.txtbuscarayudante);
            this.Controls.Add(this.dbgridAyudantes);
            this.Name = "frmBuscarAyudante";
            this.Text = "BUSCAR- Microsoft Dynamics GP";
            ((System.ComponentModel.ISupportInitialize)(this.dbgridAyudantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbgridAyudantes;
        private System.Windows.Forms.TextBox txtbuscarayudante;
        private System.Windows.Forms.ComboBox cbcriterioayudante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbuscarAyudante;
    }
}