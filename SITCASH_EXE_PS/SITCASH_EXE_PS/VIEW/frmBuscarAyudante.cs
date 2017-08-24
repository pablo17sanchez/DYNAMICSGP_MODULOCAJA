using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SITCASH_EXE_PS.CONTROLLER;


namespace SITCASH_EXE_PS.VIEW
{
    public partial class frmBuscarAyudante : Form
    {

        ControllerCuadredeCaja CONTROLLER = new ControllerCuadredeCaja();

        public frmBuscarAyudante()
        {
            InitializeComponent();
        }


       

        private void dbgridAyudantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dbgridAyudantes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dbgridAyudantes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dbgridAyudantes.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["IDVendedor"].Value).Trim();
                this.Hide();
                Form1 f2 = Application.OpenForms["Form1"] as Form1;
                if (f2 != null)
                    f2.cbayudante.SelectedValue = a;
                this.Close();
            }
        }

        private void btnbuscarAyudante_Click(object sender, EventArgs e)
        {
            llenargrid();
        }


        #region [METODOS DE LLENADO]


        private void llenargrid()
        {

            if (cbcriterioayudante.SelectedIndex == 0)
            {
                FillDBgridclientesPornombre();
            }
            else if (cbcriterioayudante.SelectedIndex == 1)
            {
                FillDBgridclientesPorIDvendedor();


            }
            else if (cbcriterioayudante.SelectedIndex == 2)
            {
                FillDBgridclientesPorIDzona();
            }
            else if (cbcriterioayudante.SelectedIndex == -1)
            {
                MessageBox.Show("Inserte el texto que desea buscar", "Microsoft Dynamics GP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void FillDBgridclientesPornombre()
        {

            dbgridAyudantes.DataSource = CONTROLLER.Getsalespersoncompletepornombre(txtbuscarayudante.Text);





        }


        private void FillDBgridclientesPorIDvendedor()
        {

            dbgridAyudantes.DataSource = CONTROLLER.GetsalespersoncompleteIDvendedor(txtbuscarayudante.Text);

        }


        private void FillDBgridclientesPorIDzona()
        {

            dbgridAyudantes.DataSource = CONTROLLER.GetsalespersoncompleteIDdezona(txtbuscarayudante.Text);

        }

        #endregion



    }
}
