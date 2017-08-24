using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SITCASH_EXE_PS.CONTROLLER;
using SITCASH_EXE_PS.VIEW;



namespace SITCASH_EXE_PS.VIEW
{
    public partial class frmbuscarcliente : Form
    {



        ControllerCuadredeCaja CONTROLLER = new ControllerCuadredeCaja();
        private static frmbuscarcliente Instancia_de_frmbuscarcliente = null;
        public frmbuscarcliente()
        {
            InitializeComponent();
        }

        public static frmbuscarcliente Instance()
        {

            if (Instancia_de_frmbuscarcliente == null)
            {
                Instancia_de_frmbuscarcliente = new frmbuscarcliente();
            }
            return Instancia_de_frmbuscarcliente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            llenargrid();

        }


        private void dbgClintes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dbgClintes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dbgClintes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dbgClintes.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["IDVendedor"].Value).Trim();
                this.Hide();
                Form1 f2 = Application.OpenForms["Form1"] as Form1;
                if (f2 != null)
                    f2.cbvendedor.SelectedValue = a;
                this.Close();

            }




        }


        #region [METODOS DE LLENADO]


        private void llenargrid()
        {

            if (cbcriterio.SelectedIndex == 0)
            {
                FillDBgridclientesPornombre();
            }
            else if (cbcriterio.SelectedIndex == 1)
            {
                FillDBgridclientesPorIDvendedor();


            }
            else if (cbcriterio.SelectedIndex == 2)
            {
                FillDBgridclientesPorIDzona();
            }
            else if (cbcriterio.SelectedIndex == -1)
            {
                MessageBox.Show("Inserte el texto que desea buscar", "Microsoft Dynamics GP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void FillDBgridclientesPornombre()
        {

            dbgClintes.DataSource = CONTROLLER.Getsalespersoncompletepornombre(txtnombrea.Text);





        }


        private void FillDBgridclientesPorIDvendedor()
        {

            dbgClintes.DataSource = CONTROLLER.GetsalespersoncompleteIDvendedor(txtnombrea.Text);

        }


        private void FillDBgridclientesPorIDzona()
        {

            dbgClintes.DataSource = CONTROLLER.GetsalespersoncompleteIDdezona(txtnombrea.Text);

        }

        #endregion




    }
}
