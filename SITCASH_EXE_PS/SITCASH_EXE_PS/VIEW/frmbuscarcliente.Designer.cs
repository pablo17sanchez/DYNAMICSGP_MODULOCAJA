namespace SITCASH_EXE_PS.VIEW
{
    partial class frmbuscarcliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbuscarcliente));
            this.txtnombrea = new System.Windows.Forms.TextBox();
            this.cbcriterio = new System.Windows.Forms.ComboBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dbgClintes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dbgClintes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtnombrea
            // 
            this.txtnombrea.Location = new System.Drawing.Point(66, 19);
            this.txtnombrea.Name = "txtnombrea";
            this.txtnombrea.Size = new System.Drawing.Size(248, 20);
            this.txtnombrea.TabIndex = 0;
            // 
            // cbcriterio
            // 
            this.cbcriterio.FormattingEnabled = true;
            this.cbcriterio.Items.AddRange(new object[] {
            "POR NOMBRE",
            "POR ID. VENDEDOR",
            "POR ZONA DE VENTA"});
            this.cbcriterio.Location = new System.Drawing.Point(321, 19);
            this.cbcriterio.Name = "cbcriterio";
            this.cbcriterio.Size = new System.Drawing.Size(158, 21);
            this.cbcriterio.TabIndex = 1;
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(485, 19);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(75, 23);
            this.btnbuscar.TabIndex = 2;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "BUSCAR";
            // 
            // dbgClintes
            // 
            this.dbgClintes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dbgClintes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgClintes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgClintes.Location = new System.Drawing.Point(12, 77);
            this.dbgClintes.Name = "dbgClintes";
            this.dbgClintes.Size = new System.Drawing.Size(548, 258);
            this.dbgClintes.TabIndex = 4;
            this.dbgClintes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgClintes_CellClick);
            // 
            // frmbuscarcliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(580, 345);
            this.Controls.Add(this.dbgClintes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.cbcriterio);
            this.Controls.Add(this.txtnombrea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmbuscarcliente";
            this.Text = "BUSCAR- Microsoft Dynamics GP";
            ((System.ComponentModel.ISupportInitialize)(this.dbgClintes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtnombrea;
        private System.Windows.Forms.ComboBox cbcriterio;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dbgClintes;
    }
}