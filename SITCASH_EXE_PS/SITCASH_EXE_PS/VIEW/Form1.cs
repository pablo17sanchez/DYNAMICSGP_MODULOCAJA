using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SITCASH_EXE_PS.VIEW;
using SITCASH_EXE_PS.CONTROLLER;
using SITCASH_EXE_PS.MODEL;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using GPIntegrationAssembly;
using System.Runtime.CompilerServices;
using SITCASH_EXE_PS.INTREGATIONSCONTROLLERS;
using System.Data.Sql;
using System.Data.SqlClient;
using  GPIntegrationAssembly;
namespace SITCASH_EXE_PS
{
    public partial class Form1 : Form
    {
       // GPIntegrationAssembly.GPIntegration LIBRARYINTEGRATION;
        ModelPalmVendors vendor = new ModelPalmVendors();
        ControlerPalm palmresponse = new ControlerPalm();
        ControllerSitIntegration sitint = new ControllerSitIntegration();
        ControllerDynamicsConfig dynamicsconfig = new ControllerDynamicsConfig();

        String gpInterCompanyId = "GPHN";
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            cargarcombovendedor();
            cargarcomboayudante();
            cargarayudante2();
            cargarcombodtmpickes();
        }

        private void cbvendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbvendedor.DataSource == null || !(this.cbvendedor.SelectedValue is string))
            { return; }

            if (Microsoft.VisualBasic.CompilerServices.Operators.
                ConditionalCompareObjectNotEqual
                (this.cbvendedor.SelectedValue, (object)"0", false))
            {
                llenarcbpalm();

            }
        }

        private void btnbuscarayudante_Click(object sender, EventArgs e)
        {
            frmBuscarAyudante FormularioSingleton = new frmBuscarAyudante();
            FormularioSingleton.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmbuscarcliente FormularioSingleton = new frmbuscarcliente();
            FormularioSingleton.ShowDialog();
        }



        private void btgenerar_Click(object sender, EventArgs e)
        {
            string CodigoDelVendorMasLaFecha = "R";
            DateTime FECHAACTUAL = DateTime.Now;
            if (Convert.ToDateTime(dtmpickerHasta.Text).Subtract(Convert.ToDateTime(dtmpickerDesde.Text)).TotalDays >= 0)
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.cbvendedor.SelectedValue, (object)"-1", false))
                {
                    if (!(cbpalm.SelectedValue == null))
                    {


                        if (cbvendedor.SelectedValue.ToString() != "0" && cbpalm.SelectedValue.ToString() != "0")
                        {




                            vendor.FechaDesde = Convert.ToDateTime(dtmpickerDesde.Text);
                            vendor.FechaHasta = Convert.ToDateTime(dtmpickerHasta.Text);
                            vendor.PalmID = Convert.ToString(cbpalm.Text.Trim());


                            if (palmresponse.CountDocumentList(vendor) > 0)
                            {

                                DateTime fechah = Convert.ToDateTime(dtmpickerHasta.Text);
                                //CAMBIAR ESTE CODIGO POR EL VERDADERO
                                CodigoDelVendorMasLaFecha =
                             Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject
                              (Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.cbvendedor.SelectedValue,
                              (object)"-"), fechah.ToString("yyyyMMdd")));





                                ViewModelCagraIntegracionTransacionVenta transactventa = new ViewModelCagraIntegracionTransacionVenta();
                                ViewModelCagraIntegracionTransacionVenta_Item itemsdeventa = new ViewModelCagraIntegracionTransacionVenta_Item();
                                ControllerCuadredeCaja gpdb = new ControllerCuadredeCaja();
                                ControlerPalm PALMDB = new ControlerPalm();
                                ViewModelCargaIntegration VALORESDECARGA = new ViewModelCargaIntegration();
                                ControllerSitIntegration SITINTEGRATION = new ControllerSitIntegration();

                                VALORESDECARGA.IDCarga = 0;
                                VALORESDECARGA.Descripcion = CodigoDelVendorMasLaFecha;
                                VALORESDECARGA.Estado = "S";
                                //REVIZAR IDCARGA
                                int IDcargas = SITINTEGRATION.InsertCargaGP(VALORESDECARGA);

                                foreach (var result in palmresponse.GetDocumenList(vendor))
                                {


                                    string tipos = "";
                                    int IDTIPO = 0;


                                    switch (result.Tipo)
                                    {
                                        case "FACTURA":
                                            tipos = "PALMFACTURA";
                                            IDTIPO = 3;

                                            break;
                                        case "CONDUCE":
                                            tipos = "PALMCONDUCE";
                                            IDTIPO = 2;
                                            break;

                                        case "PEDIDOS":
                                            tipos = "PALMPEDIDOS";
                                            IDTIPO = 2;
                                            break;
                                        default:
                                            tipos = "PALMSINTIPO";
                                            IDTIPO = 0;
                                            break;
                                    }

                                    //Bien
                                    transactventa.IDCarga = IDcargas;
                                    //REVIZAR QUE HACER CUANDO HAY VALORES REPETIDOS
                                    transactventa.IDVenta = 0;
                                    //Bien
                                    transactventa.IDTipo = tipos;
                                    //Bien
                                    transactventa.Tipo = IDTIPO;
                                    //Bien
                                    transactventa.NoDocumento = result.DocumentNumber.Trim();
                                    //BIen
                                    transactventa.Fecha = result.Date ?? FECHAACTUAL;
                                    //bien
                                    transactventa.AlmacenDefault = dynamicsconfig.GetuserLocation("sa");
                                    //bien
                                    transactventa.IDLote = CodigoDelVendorMasLaFecha;
                                    //bien
                                    transactventa.IDCliente = result.CodigodeCliente.Trim();
                                    //bien
                                    transactventa.NombreCliente = "";
                                    //bien
                                    transactventa.NoOrden = "";
                                    //bien
                                    transactventa.IDMoneda = "DOP";
                                    //BIEN
                                    transactventa.DescuentoComercial = result.Descuento ?? 0;
                                    //BIEN
                                    transactventa.DescuentoRetornado = 0;
                                    //BIEN 
                                    transactventa.Flete = 0;
                                    //BIEN
                                    transactventa.Miscelaneo = 0;
                                    //BIEN
                                    transactventa.MontoRecibido = result.MontoPago;

                                    transactventa.Impuestos = result.Impuesto ?? 0;
                                    //BIEN
                                    transactventa.Status = "N";
                                    //BIEN
                                    transactventa.IDVendedor = cbvendedor.SelectedValue.ToString().Trim();
                                    //BIEN
                                    transactventa.IDAyudante = cbayudante.SelectedValue.ToString().Trim() == "BLANK" ? "" : cbayudante.SelectedValue.ToString().Trim();
                                    //BIEN
                                    transactventa.IDayudante2 = cbayudante2.SelectedValue.ToString().Trim() == "BLANK" ? "" : cbayudante2.SelectedValue.ToString().Trim();
                                    //BIEN
                                    transactventa.NCF = result.NCF;
                                    //BIEN
                                    transactventa.MontoEfectivo = result.MontoeEfectivo ?? 0;
                                    //BIEN
                                    transactventa.MontoCheque = result.MontoCheque ?? 0;
                                    //BIEN
                                    transactventa.NumeroCheque = result.NumeroDeChecke;
                                    //BIEN
                                    SITINTEGRATION.insertarventaconsqlconexion(transactventa);

                                    foreach (var resultitem in palmresponse.GetDocumentDetail(vendor.PalmID, transactventa.Fecha, transactventa.NoDocumento))
                                    {




                                        //REVIZAR QUE HACER CUANDO HAY VALORES REPETIDOS
                                        itemsdeventa.IDventa = IDcargas;
                                        //BIEN
                                        itemsdeventa.NoProducto = resultitem.CodigoProducto;
                                        //BIEN
                                        itemsdeventa.UnidadDeMedida = gpdb.GetUnitmeasurementItem(resultitem.CodigoProducto);
                                        //BIEN
                                        itemsdeventa.Cantidad = Convert.ToDouble(resultitem.Cantidad);
                                        //BIEN
                                        itemsdeventa.PrecioUnitario = resultitem.Precio;
                                        //BIEN
                                        itemsdeventa.Cantidad = Convert.ToDouble(resultitem.Cantidad);
                                        //BIEN DE MOMENTO
                                        itemsdeventa.DescripcionDeProducto = "N";

                                        //BIEN
                                        itemsdeventa.PrecioExtendido = Convert.ToDecimal(resultitem.Cantidad * resultitem.Precio);
                                        //BIEN
                                        itemsdeventa.CantidadFacturada = IDTIPO == 2 ? 0 : Convert.ToDouble(resultitem.Cantidad ?? 0);
                                        //BIEN
                                        itemsdeventa.CantidadCompletada = IDTIPO == 2 ? 0 : Convert.ToDouble(resultitem.Cantidad ?? 0);


                                        //BIEN
                                        itemsdeventa.CantidadBO = 0;
                                        //BIEN
                                        itemsdeventa.CantidadOrdenada = 0;
                                        //BIEN
                                        itemsdeventa.CantidadCancelada = 0;
                                        //BIEN
                                        itemsdeventa.CostoUnitario = 0;
                                        //BIEN
                                        itemsdeventa.EntregaDirecta = false;
                                        //BIEN
                                        itemsdeventa.ListaPrecio = gpdb.GetPriceLevel(resultitem.CodigoProducto);
                                        //BIEN
                                        itemsdeventa.Almacen = cbpalm.Text;


                                        //REVIZAR
                                        SITINTEGRATION.InsertarTransacsion_Venta_Itemsqlconexion(itemsdeventa);

                                        //TOMAR ENCUENTA


                                         /* PALMDB.DeleteDocumentDetail(transactventa.NoDocumento, cbpalm.Text, tipos);
                                            PALMDB.DeleteDocumntHeader(transactventa.NoDocumento, cbpalm.Text, tipos);*/
                                       IntregrationGP gpintegration = new IntregrationGP();


                                       ControllerSitIntegration sitint = new ControllerSitIntegration();
                                       sitint.UpdateIdCarga(IDcargas);

                                       this.ExportToGP(gpintegration, Conversions.ToInteger( SITINTEGRATION.GETCOMPANYID("GPHN")), IDcargas, GetRMDefaultCheckBookID());

                                    }



                                }
                            }
                            else
                            {

                                MessageBox.Show("La palm no tiene documentos  para ingresar en el sistema", "Microsoft Dynamics GP",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);

                            }

                        }
                        else
                        {
                            MessageBox.Show("Debe seleccionar un vendedor que tenga una palm asignada", "Microsoft Dynamics GP",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation);
                        }



                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un vendedor que tenga una palm asignada", "Microsoft Dynamics GP",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    MessageBox.Show("El vendedor tiene que tener una palm asignada", "Microsoft Dynamics GP",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("La fecha de inicio no puede sobrepasar a la fecha final", "Microsoft Dynamics GP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

        }




        private void btnGenerar_Click(object sender, EventArgs e)
        {

            if (Convert.ToDateTime(dtmpickerHasta.Text).Subtract(Convert.ToDateTime(dtmpickerDesde.Text)).TotalDays >= 0)
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.cbpalm.SelectedValue, (object)"-1", false))
                {
                    if (!String.IsNullOrEmpty(cbpalm.Text))
                    {

                        vendor.FechaDesde = Convert.ToDateTime(dtmpickerDesde.Text);
                        vendor.FechaHasta = Convert.ToDateTime(dtmpickerHasta.Text);
                        vendor.PalmID = Convert.ToString(cbpalm.Text);
                        dbgridInvoice.DataSource = palmresponse.GetDocumenList(vendor);
                        var resultado = palmresponse.llenartotales(palmresponse.GetDocumenList(vendor));



                    }
                    else
                    {
                        MessageBox.Show("El vendedor tiene que tener una palm asignada", "Microsoft Dynamics GP",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Debe seleccionar un vendedor", "Microsoft Dynamics GP",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("La fecha desde debe ser menor o igual que la fecha hasta. Cámbiela e intente nuevamente. ", "Microsoft Dynamics GP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }



        #region LLEVAR A GP

        /// <summary>
        /// /E MOTODO QUE EXPORTA A GP TODOS LOS DOCUMENTOS CONTENIDOS  EN  LA BASE DE DATOS SITINTEGRATOIN EN LAS TABLAS TRANSACCIONVENTA COMO EL HEADER Y TRANSACCIONVENTAITEM COMO EL DETAIL  DATATABLE 
        /// </summary>
        /// <param name="GSI"> LLAMAR A LA CALSE DE INTREGACION PARA PASARA TODOS LOS METODOS DE DICHA CLASE</param>
        /// <param name="SiCompanyID"></param>
        /// <param name="SiIDCarga"></param>
        /// <param name="Chequera"></param>
        public void ExportToGP(IntregrationGP GSI, int SiCompanyID, int SiIDCarga, string Chequera)
        {
            GPdataaccess gpdataaccess =   new GPdataaccess();
            int CONTADOR = 0;


            DataTable dataTable = null;
            try
            {
                ViewModelImportInfo importinfo = new ViewModelImportInfo();
                importinfo.UserId = "Administrator";
                importinfo.Password = "taramaca01$";
                importinfo.Dominio = "ITARAMACA";
                importinfo.Url = "http://GEA-SRVDATA /dynamicsgpwebservices/dynamicsgpservice.asmx";
                importinfo.iCompanyID = SiCompanyID;
                importinfo.iIDCarga = SiIDCarga;
                importinfo.sChequera = Chequera;
                dataTable = GSI.RunImportProccess(importinfo);
                
               // dataTable = LIBRARYINTEGRATION.RunImportProccess(importinfo.UserId, importinfo.Password, importinfo.Dominio, importinfo.Url, importinfo.iCompanyID, importinfo.iIDCarga, importinfo.sChequera);
                CONTADOR = dataTable.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un errro " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

              
            }





            int num3 = 0;
            int num4 = checked(CONTADOR - 1);
            int index = num3;



            while (index <= num4)
            {
                try
                {

                    //El METODO LLENA EL DATATABLE CON EL SIGUIENTE SELECT: SELECT * FROM TransaccionVenta WHERE idcarga = @IdCarga AND status <> 'P' 
                    //PASA UN PARAMETRO QUE ES EL ID DE CARGA 
                    DataTable salesList = GSI.GetSalesList(Convert.ToInt32(RuntimeHelpers.GetObjectValue(dataTable.Rows[index]["IdCarga"])));

                   // DataTable salesList = GSI.GetSalesList(Convert.ToInt32(RuntimeHelpers.GetObjectValue(dataTable.Rows[index]["IdCarga"])));
                    int count = salesList.Rows.Count;
                    int num2 = 0;

                    //ASIGNAR EL NUMERO DE FILAS AL LA VARIABLE NUM5
                    int num5 = checked(count - 1);
                    //CONTADOR QUE SE INCREMENTE EN 1 CADA CICLO Y EMPIEZA EL 0
                    int xPos = num2;
                    while (xPos <= num5)
                    {
                        try
                        {

                            //PASA DOS PARAMETROS QUE ES EL ID DE VENTA Y EL NUMERO DE  FILA
                            GSI.SaleProcess(Convert.ToInt32(RuntimeHelpers.GetObjectValue(salesList.Rows[xPos]["IdVenta"])), xPos);
                        }
                        catch (Exception ex)
                        {
                            ProjectData.SetProjectError(ex);
                            ProjectData.ClearProjectError();
                        }

                        checked { ++xPos; }
                    }
                    //LE COLOCA LA P A TODOS LOS ITEM DE VENTAS QUE SE MANDARON 
                    GSI.ProcessCarga(Convert.ToInt32(RuntimeHelpers.GetObjectValue(dataTable.Rows[index]["IdCarga"])));
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                        int num2 = (int)Interaction.MsgBox((object)(ex.Message + " -- Connection String: " + gpdataaccess.GPHNCARGAR()), MsgBoxStyle.Critical, (object)null);
                    ProjectData.ClearProjectError();
                }
                checked { ++index; }
            }

        }

        #endregion

        #region [METODOS DE LLENADO]


        private static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {

                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }



        private void Habilitarayudantes()
        {

            cbayudante.Enabled = true;
            cbayudante2.Enabled = true;
            btnayudante2.Enabled = true;
            btnbuscarayudante.Enabled = true;




        }



        private void cargarcombodtmpickes()
        {

            dtmpickerDesde.Text = DateAndTime.Now.ToString();
            dtmpickerHasta.Text = DateAndTime.Now.ToString();


        }

        private void cargarcombovendedor()
        {
            CONTROLLER.ControllerCuadredeCaja controlador = new CONTROLLER.ControllerCuadredeCaja();
            cbvendedor.DataSource = controlador.GetSalespersonList();
            cbvendedor.DisplayMember = "NOMBRE";
            cbvendedor.ValueMember = "CODIGO";
        }

        private void cargarcomboayudante()
        {
            CONTROLLER.ControllerCuadredeCaja controlador = new CONTROLLER.ControllerCuadredeCaja();
            cbayudante.DataSource = controlador.GetSalespersonList();
            cbayudante.DisplayMember = "NOMBRE";
            cbayudante.ValueMember = "CODIGO";
        }


        private void cargarayudante2()
        {
            CONTROLLER.ControllerCuadredeCaja controlador = new CONTROLLER.ControllerCuadredeCaja();
            cbayudante2.DataSource = controlador.GetSalespersonList();
            cbayudante2.DisplayMember = "NOMBRE";
            cbayudante2.ValueMember = "CODIGO";

        }



        private void llenarcbpalm()
        {

            CONTROLLER.ControlerPalm controlador = new CONTROLLER.ControlerPalm();
            cbpalm.DataSource = controlador.GetpalmID(Convert.ToString(this.cbvendedor.SelectedValue));
            cbpalm.DisplayMember = "PamlID";
            cbpalm.ValueMember = "PamlID";
            Habilitarayudantes();
        }
        #endregion


        public string GetRMDefaultCheckBookID()
        {
            DataTable rmConfig = this.GetRMConfig();
            if (rmConfig.Rows.Count > 0)
                return rmConfig.Rows[0]["chekbkid"].ToString();
            return "";
        }


        public DataTable GetRMConfig()
        {
            GPdataaccess data = new GPdataaccess();
               DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(data.GPCONECTIONS()))
            {
                 con.Open();

                 using (SqlDataAdapter dataa = new SqlDataAdapter("select chekbkid, prclevel from rm40101",con))
                 {
                  
                     dataa.Fill(table);
                 }

                
            }

            return table;

          
        }

        private void dbgridInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
