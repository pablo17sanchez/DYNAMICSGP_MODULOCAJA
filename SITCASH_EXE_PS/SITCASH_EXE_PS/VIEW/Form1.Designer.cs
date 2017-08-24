namespace SITCASH_EXE_PS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbvendedor = new System.Windows.Forms.ComboBox();
            this.lvendedor = new System.Windows.Forms.Label();
            this.cbayudante = new System.Windows.Forms.ComboBox();
            this.layudante1 = new System.Windows.Forms.Label();
            this.lbayudante2 = new System.Windows.Forms.Label();
            this.cbayudante2 = new System.Windows.Forms.ComboBox();
            this.cbpalm = new System.Windows.Forms.ComboBox();
            this.lblpalmID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dbgridInvoice = new System.Windows.Forms.DataGridView();
            this.btgenerar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnGenerar = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarLoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reprocesarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reprocesarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.btnayudante2 = new System.Windows.Forms.Button();
            this.btnbuscarayudante = new System.Windows.Forms.Button();
            this.dtmpickerDesde = new System.Windows.Forms.TextBox();
            this.dtmpickerHasta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMontoDocumento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbgridInvoice)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbvendedor
            // 
            this.cbvendedor.FormattingEnabled = true;
            this.cbvendedor.Location = new System.Drawing.Point(87, 30);
            this.cbvendedor.Name = "cbvendedor";
            this.cbvendedor.Size = new System.Drawing.Size(212, 21);
            this.cbvendedor.TabIndex = 0;
            this.cbvendedor.SelectedIndexChanged += new System.EventHandler(this.cbvendedor_SelectedIndexChanged);
            // 
            // lvendedor
            // 
            this.lvendedor.AutoSize = true;
            this.lvendedor.Location = new System.Drawing.Point(12, 30);
            this.lvendedor.Name = "lvendedor";
            this.lvendedor.Size = new System.Drawing.Size(53, 13);
            this.lvendedor.TabIndex = 1;
            this.lvendedor.Text = "Vendedor";
            // 
            // cbayudante
            // 
            this.cbayudante.Enabled = false;
            this.cbayudante.FormattingEnabled = true;
            this.cbayudante.Location = new System.Drawing.Point(87, 57);
            this.cbayudante.Name = "cbayudante";
            this.cbayudante.Size = new System.Drawing.Size(212, 21);
            this.cbayudante.TabIndex = 2;
            // 
            // layudante1
            // 
            this.layudante1.AutoSize = true;
            this.layudante1.Location = new System.Drawing.Point(12, 57);
            this.layudante1.Name = "layudante1";
            this.layudante1.Size = new System.Drawing.Size(52, 13);
            this.layudante1.TabIndex = 3;
            this.layudante1.Text = "Ayudante";
            // 
            // lbayudante2
            // 
            this.lbayudante2.AutoSize = true;
            this.lbayudante2.Location = new System.Drawing.Point(12, 84);
            this.lbayudante2.Name = "lbayudante2";
            this.lbayudante2.Size = new System.Drawing.Size(61, 13);
            this.lbayudante2.TabIndex = 5;
            this.lbayudante2.Text = "Ayudante 2";
            // 
            // cbayudante2
            // 
            this.cbayudante2.Enabled = false;
            this.cbayudante2.FormattingEnabled = true;
            this.cbayudante2.Location = new System.Drawing.Point(87, 84);
            this.cbayudante2.Name = "cbayudante2";
            this.cbayudante2.Size = new System.Drawing.Size(212, 21);
            this.cbayudante2.TabIndex = 4;
            // 
            // cbpalm
            // 
            this.cbpalm.Enabled = false;
            this.cbpalm.FormattingEnabled = true;
            this.cbpalm.Location = new System.Drawing.Point(384, 30);
            this.cbpalm.Name = "cbpalm";
            this.cbpalm.Size = new System.Drawing.Size(212, 21);
            this.cbpalm.TabIndex = 6;
            // 
            // lblpalmID
            // 
            this.lblpalmID.AutoSize = true;
            this.lblpalmID.Location = new System.Drawing.Point(329, 30);
            this.lblpalmID.Name = "lblpalmID";
            this.lblpalmID.Size = new System.Drawing.Size(41, 13);
            this.lblpalmID.TabIndex = 7;
            this.lblpalmID.Text = "PalmID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hasta";
            // 
            // dbgridInvoice
            // 
            this.dbgridInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbgridInvoice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dbgridInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgridInvoice.Location = new System.Drawing.Point(12, 159);
            this.dbgridInvoice.Name = "dbgridInvoice";
            this.dbgridInvoice.Size = new System.Drawing.Size(584, 150);
            this.dbgridInvoice.TabIndex = 13;
            this.dbgridInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgridInvoice_CellContentClick);
            // 
            // btgenerar
            // 
            this.btgenerar.Location = new System.Drawing.Point(521, 332);
            this.btgenerar.Name = "btgenerar";
            this.btgenerar.Size = new System.Drawing.Size(75, 23);
            this.btgenerar.TabIndex = 14;
            this.btgenerar.Text = "Ingresar";
            this.btgenerar.UseVisualStyleBackColor = true;
            this.btgenerar.Click += new System.EventHandler(this.btgenerar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGenerar,
            this.ventaToolStripMenuItem,
            this.ventaManualToolStripMenuItem,
            this.actualizarLoteToolStripMenuItem,
            this.reprocesarToolStripMenuItem,
            this.reprocesarToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::SITCASH_EXE_PS.Properties.Resources._1483551469_checkin_key;
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(85, 20);
            this.btnGenerar.Text = "Vefirificar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // ventaToolStripMenuItem
            // 
            this.ventaToolStripMenuItem.Image = global::SITCASH_EXE_PS.Properties.Resources._1483551674_Sales_by_Payment_Method_rep;
            this.ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            this.ventaToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ventaToolStripMenuItem.Text = "Venta";
            // 
            // ventaManualToolStripMenuItem
            // 
            this.ventaManualToolStripMenuItem.Image = global::SITCASH_EXE_PS.Properties.Resources._1483551688_product_sales_report;
            this.ventaManualToolStripMenuItem.Name = "ventaManualToolStripMenuItem";
            this.ventaManualToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.ventaManualToolStripMenuItem.Text = "Venta Manual";
            // 
            // actualizarLoteToolStripMenuItem
            // 
            this.actualizarLoteToolStripMenuItem.Image = global::SITCASH_EXE_PS.Properties.Resources._1483551914_shop_23;
            this.actualizarLoteToolStripMenuItem.Name = "actualizarLoteToolStripMenuItem";
            this.actualizarLoteToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.actualizarLoteToolStripMenuItem.Text = "Manual";
            // 
            // reprocesarToolStripMenuItem
            // 
            this.reprocesarToolStripMenuItem.Image = global::SITCASH_EXE_PS.Properties.Resources._1483551967_Button_Open_01;
            this.reprocesarToolStripMenuItem.Name = "reprocesarToolStripMenuItem";
            this.reprocesarToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.reprocesarToolStripMenuItem.Text = "Actualizar lote";
            // 
            // reprocesarToolStripMenuItem1
            // 
            this.reprocesarToolStripMenuItem1.Image = global::SITCASH_EXE_PS.Properties.Resources._1483552127_our_process_2;
            this.reprocesarToolStripMenuItem1.Name = "reprocesarToolStripMenuItem1";
            this.reprocesarToolStripMenuItem1.Size = new System.Drawing.Size(93, 20);
            this.reprocesarToolStripMenuItem1.Text = "Reprocesar";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(302, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 21);
            this.button1.TabIndex = 19;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnayudante2
            // 
            this.btnayudante2.Enabled = false;
            this.btnayudante2.Image = global::SITCASH_EXE_PS.Properties.Resources.BUSCAR4_0;
            this.btnayudante2.Location = new System.Drawing.Point(302, 84);
            this.btnayudante2.Name = "btnayudante2";
            this.btnayudante2.Size = new System.Drawing.Size(27, 21);
            this.btnayudante2.TabIndex = 18;
            this.btnayudante2.UseVisualStyleBackColor = true;
            // 
            // btnbuscarayudante
            // 
            this.btnbuscarayudante.Enabled = false;
            this.btnbuscarayudante.Image = global::SITCASH_EXE_PS.Properties.Resources.BUSCAR4_0;
            this.btnbuscarayudante.Location = new System.Drawing.Point(302, 57);
            this.btnbuscarayudante.Name = "btnbuscarayudante";
            this.btnbuscarayudante.Size = new System.Drawing.Size(27, 21);
            this.btnbuscarayudante.TabIndex = 17;
            this.btnbuscarayudante.UseVisualStyleBackColor = true;
            this.btnbuscarayudante.Click += new System.EventHandler(this.btnbuscarayudante_Click);
            // 
            // dtmpickerDesde
            // 
            this.dtmpickerDesde.Location = new System.Drawing.Point(384, 57);
            this.dtmpickerDesde.Name = "dtmpickerDesde";
            this.dtmpickerDesde.Size = new System.Drawing.Size(212, 20);
            this.dtmpickerDesde.TabIndex = 20;
            // 
            // dtmpickerHasta
            // 
            this.dtmpickerHasta.Location = new System.Drawing.Point(384, 84);
            this.dtmpickerHasta.Name = "dtmpickerHasta";
            this.dtmpickerHasta.Size = new System.Drawing.Size(212, 20);
            this.dtmpickerHasta.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblMontoDocumento);
            this.panel1.Location = new System.Drawing.Point(12, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 17);
            this.panel1.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "00.0$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Totales";
            // 
            // lblMontoDocumento
            // 
            this.lblMontoDocumento.AutoSize = true;
            this.lblMontoDocumento.Location = new System.Drawing.Point(256, 2);
            this.lblMontoDocumento.Name = "lblMontoDocumento";
            this.lblMontoDocumento.Size = new System.Drawing.Size(34, 13);
            this.lblMontoDocumento.TabIndex = 23;
            this.lblMontoDocumento.Text = "0.00$";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(601, 367);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtmpickerHasta);
            this.Controls.Add(this.dtmpickerDesde);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnayudante2);
            this.Controls.Add(this.btnbuscarayudante);
            this.Controls.Add(this.btgenerar);
            this.Controls.Add(this.dbgridInvoice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblpalmID);
            this.Controls.Add(this.cbpalm);
            this.Controls.Add(this.lbayudante2);
            this.Controls.Add(this.cbayudante2);
            this.Controls.Add(this.layudante1);
            this.Controls.Add(this.cbayudante);
            this.Controls.Add(this.lvendedor);
            this.Controls.Add(this.cbvendedor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Cuadre y Caja -Microsoft Dynamics GP ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbgridInvoice)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbvendedor;
        private System.Windows.Forms.Label lvendedor;
        public System.Windows.Forms.ComboBox cbayudante;
        private System.Windows.Forms.Label layudante1;
        private System.Windows.Forms.Label lbayudante2;
        private System.Windows.Forms.ComboBox cbayudante2;
        private System.Windows.Forms.ComboBox cbpalm;
        private System.Windows.Forms.Label lblpalmID;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dbgridInvoice;
        private System.Windows.Forms.Button btgenerar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnGenerar;
        private System.Windows.Forms.ToolStripMenuItem ventaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventaManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarLoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reprocesarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reprocesarToolStripMenuItem1;
        private System.Windows.Forms.Button btnbuscarayudante;
        private System.Windows.Forms.Button btnayudante2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox dtmpickerDesde;
        private System.Windows.Forms.TextBox dtmpickerHasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMontoDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

