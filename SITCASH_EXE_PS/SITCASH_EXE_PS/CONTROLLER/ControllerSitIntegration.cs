using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;

using SITCASH_EXE_PS.MODEL;
using System.Data.Objects.SqlClient;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace SITCASH_EXE_PS.CONTROLLER
{
    class ControllerSitIntegration
    {
        SITGPIntegrationEntities integrationgp = new SITGPIntegrationEntities();


        GPdataaccess CONE = new GPdataaccess();


        private int GetNextIdCarga()
        {

            var maxValue = integrationgp.CargaGP.Max(x => x.IDCarga);

            var result = integrationgp.CargaGP.Single(x => x.IDCarga == maxValue);


            int resultadoconvertido = Convert.ToInt32(result.IDCarga) + 1;
            return resultadoconvertido;
        }


        private int GetNextIDVenta()
        {

            var maxValue = integrationgp.TransaccionVentaItem.Max(x => x.IDVenta);




            var result = integrationgp.TransaccionVentaItem.Single(x => x.IDVenta == maxValue);


            int resultadoconvertido = Convert.ToInt32(result.IDVenta) + 1;
            return resultadoconvertido;
        }

        //public IEnumerable<string> CheckIfExist(ModelPalmVendors vendormodel)
        //{

        //     var ast = (from masterventa in integrationgp.TransaccionVenta
        //                              join detailventa in integrationgp.TransaccionVentaItem
        //                              on masterventa.IDVenta equals detailventa.IDVenta
        //                              where detailventa.Almacen.Trim() == vendormodel.PalmID &&
        //                           masterventa.Fecha >= vendormodel.FechaDesde &&
        //                           masterventa.Fecha <= vendormodel.FechaHasta
        //                              select new { masterventa.NoDocumento }).AsEnumerable();




        //     return ast;





        //}


        public int InsertCargaGP(ViewModelCargaIntegration integracion)
        {

            DateTime fechaactual = DateTime.Now;
            int resultado = GetNextIdCarga();

            CargaGP carga = new CargaGP
            {
                IDCarga = resultado
          ,
                FechaCreacion = fechaactual,
                Descripcion = integracion.Descripcion
          ,
                Estatus = integracion.Estado
            };

            integrationgp.AddToCargaGP(carga);
            integrationgp.SaveChanges();
            return resultado;

        }

        public void InsertarTransacsion_Venta(ViewModelCagraIntegracionTransacionVenta valorestrasactionventa)
        {





            TransaccionVenta venta = new TransaccionVenta
            {
                IDVendedor = valorestrasactionventa.IDVendedor,
                IDVenta = valorestrasactionventa.IDVenta,
                Impuestos = valorestrasactionventa.Impuestos,
                Miscelaneo = valorestrasactionventa.Miscelaneo,
                MontoCheque = valorestrasactionventa.MontoCheque,
                Tipo = valorestrasactionventa.Tipo,
                IDTipo = valorestrasactionventa.IDTipo,
                NoDocumento = valorestrasactionventa.NoDocumento,
                Fecha = valorestrasactionventa.Fecha,
                AlmacenDefault = valorestrasactionventa.AlmacenDefault,
                IDLote = valorestrasactionventa.IDLote,
                IDCliente = valorestrasactionventa.IDCliente,
                NombreCliente = valorestrasactionventa.NombreCliente,
                NoOrden = valorestrasactionventa.NoOrden,
                IDMoneda = valorestrasactionventa.IDMoneda,
                DescuentoComercial = valorestrasactionventa.DescuentoComercial,
                Flete = valorestrasactionventa.Flete,
                MontoRecibido = valorestrasactionventa.MontoRecibido,
                DescuentoRetornado = valorestrasactionventa.DescuentoRetornado,
                NCF = valorestrasactionventa.NCF,
                Status = valorestrasactionventa.Status,
                IDAyudante = valorestrasactionventa.IDAyudante,
                IDAyudante2 = valorestrasactionventa.IDayudante2,
                MontoEfectivo = valorestrasactionventa.MontoEfectivo,
                Conduce = "",
                ErrorDetail = "",
                CostoCobrar = 0
                ,
                IDComentario = ""



            };


            integrationgp.AddToTransaccionVenta(venta);
            integrationgp.SaveChanges();








        }



        public void insertarventaconsqlconexion(ViewModelCagraIntegracionTransacionVenta valorestrasactionventa)
        {
            try
            {



                using (SqlConnection con = new SqlConnection(CONE.SITINTEGRATION()))
                {
                    con.Open();

                    using (SqlCommand fCommand = new SqlCommand())
                    {

                        fCommand.Connection = con;

                        fCommand.CommandText = "insert into TransaccionVenta (IDCarga, Tipo, IDTipo, NoDocumento, Fecha, AlmacenDefault, IDLote, IDCliente, NombreCliente, NoOrden, IDMoneda, DescuentoComercial, Flete, Miscelaneo, MontoRecibido, DescuentoRetornado, Impuestos, Status, IDVenta, IDVendedor, IDAyudante, IDAyudante2, NCF, MontoEfectivo, MontoCheque, NumeroCheque) Values (@IDCarga, @Tipo, @IDTipo, @NoDocumento,@Fecha, @AlmacenDefault, @IDLote, @IDCliente, @NombreCliente, @NoOrden, @IDMoneda, @DescuentoComercial, @Flete, @Miscelaneo, @MontoRecibido, @DescuentoRetornado, @Impuestos, @Status, @IDVenta, @IDVendedor, @IDAyudante, @IDAyudante2, @NCF, @MontoEfectivo, @MontoCheque, @NumeroCheque)";

                        if (valorestrasactionventa.IDCarga != -1)
                        {

                            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(valorestrasactionventa.IDAyudante, "-1", false) == 0 | valorestrasactionventa.IDAyudante == null)
                                valorestrasactionventa.IDAyudante = "";
                            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(valorestrasactionventa.IDayudante2, "-1", false) == 0 | valorestrasactionventa.IDayudante2 == null)
                                valorestrasactionventa.IDayudante2 = "";

                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDCarga", valorestrasactionventa.IDCarga);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@Tipo", valorestrasactionventa.Tipo);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDTipo", valorestrasactionventa.IDTipo);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@NoDocumento", valorestrasactionventa.NoDocumento);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@Fecha", valorestrasactionventa.Fecha);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@AlmacenDefault", valorestrasactionventa.AlmacenDefault);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDLote", valorestrasactionventa.IDLote);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDCliente", valorestrasactionventa.IDCliente);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@NombreCliente", valorestrasactionventa.NombreCliente);
                            //bien
                            fCommand.Parameters.AddWithValue("@NoOrden", valorestrasactionventa.NoOrden);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDMoneda", valorestrasactionventa.IDMoneda);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@DescuentoComercial", valorestrasactionventa.DescuentoComercial);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@Flete", valorestrasactionventa.Flete);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@Miscelaneo", valorestrasactionventa.Miscelaneo);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@MontoRecibido", valorestrasactionventa.MontoRecibido);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@DescuentoRetornado", valorestrasactionventa.DescuentoRetornado);
                            //BIEN 
                            fCommand.Parameters.AddWithValue("@Impuestos", valorestrasactionventa.Impuestos);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@Status", valorestrasactionventa.Status);
                            //REVIZAR
                            fCommand.Parameters.AddWithValue("@IDVenta", GetNextIDVenta());
                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDVendedor", valorestrasactionventa.IDVendedor);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDAyudante", valorestrasactionventa.IDAyudante);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@IDAyudante2", valorestrasactionventa.IDayudante2);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@NCF", valorestrasactionventa.NCF);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@MontoEfectivo", valorestrasactionventa.MontoEfectivo);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@MontoCheque", valorestrasactionventa.MontoCheque);
                            //BIEN
                            fCommand.Parameters.AddWithValue("@NumeroCheque", valorestrasactionventa.NumeroCheque);
                            fCommand.ExecuteNonQuery();

                            con.Close();

                        }
                    }




                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error" + ex.ToString(), "Error al agregar Conduce o  Facturas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }



        public void InsertarTransacsion_Venta_Itemsqlconexion(ViewModelCagraIntegracionTransacionVenta_Item valaorestrasactionventa)
        {




            using (SqlConnection con = new SqlConnection(CONE.SITINTEGRATION()))
            {
                con.Open();





                using (SqlCommand fCommand = new SqlCommand())
                {

                    fCommand.Connection = con;
                    fCommand.CommandText = "insert into TransaccionVentaItem (IDVenta, NoProducto, UnidadMedida, Cantidad, PrecioUnitario, DescripcionProducto, PrecioExtendido, CantidadFacturada, CantidadCompletada, CantidadCancelada, CantidadBO, CantidadOrdenada, CostoUnitario, EntregaDirecta, ListaPrecio, Almacen)values (@IDVenta, @NoProducto, @UnidadMedida, @Cantidad, @PrecioUnitario, @DescripcionProducto, @PrecioExtendido, @CantidadFacturada, @CantidadCompletada, @CantidadCancelada, @CantidadBO, @CantidadOrdenada, @CostoUnitario, @EntregaDirecta, @ListaPrecio, @Almacen)";

                    //BIEN ENTRE COMILLAS
                    fCommand.Parameters.AddWithValue("@IDVenta", GetNextIDVenta());

                    //BIEN
                    fCommand.Parameters.AddWithValue("@NoProducto", valaorestrasactionventa.NoProducto);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@UnidadMedida", valaorestrasactionventa.UnidadDeMedida);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@Cantidad", valaorestrasactionventa.Cantidad);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@PrecioUnitario", valaorestrasactionventa.PrecioUnitario);
                    //ARREGLAR
                    fCommand.Parameters.AddWithValue("@DescripcionProducto", valaorestrasactionventa.DescripcionDeProducto);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@PrecioExtendido", valaorestrasactionventa.PrecioExtendido);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@CantidadFacturada", valaorestrasactionventa.CantidadFacturada);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@CantidadCompletada", valaorestrasactionventa.CantidadCompletada);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@CantidadCancelada", valaorestrasactionventa.CantidadCancelada);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@CantidadBO", valaorestrasactionventa.CantidadBO);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@CantidadOrdenada", valaorestrasactionventa.CantidadOrdenada);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@CostoUnitario", valaorestrasactionventa.CostoUnitario);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@EntregaDirecta", valaorestrasactionventa.EntregaDirecta);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@ListaPrecio", valaorestrasactionventa.ListaPrecio);
                    //BIEN
                    fCommand.Parameters.AddWithValue("@Almacen", valaorestrasactionventa.Almacen);
                    //BIEN
                    fCommand.ExecuteNonQuery();
                    con.Close();

                }

            }




        }





        public int InsertarTransacsion_Venta_Item(ViewModelCagraIntegracionTransacionVenta_Item valaorestrasactionventa)
        {

            TransaccionVentaItem T_VENTA = new TransaccionVentaItem
            {
                IDVenta = valaorestrasactionventa.IDventa,
                NoProducto = valaorestrasactionventa.NoProducto,
                UnidadMedida = valaorestrasactionventa.UnidadDeMedida,
                Cantidad = valaorestrasactionventa.Cantidad,
                PrecioUnitario = valaorestrasactionventa.PrecioUnitario,
                PrecioExtendido = valaorestrasactionventa.PrecioExtendido,
                CantidadFacturada = valaorestrasactionventa.CantidadFacturada,
                CantidadCompletada = valaorestrasactionventa.CantidadCompletada,
                CantidadCancelada = valaorestrasactionventa.CantidadCancelada,
                CantidadBO = valaorestrasactionventa.CantidadBO,
                CantidadOrdenada = valaorestrasactionventa.CantidadBO,
                CostoUnitario = valaorestrasactionventa.CostoUnitario,
                EntregaDirecta = valaorestrasactionventa.EntregaDirecta,
                Almacen = valaorestrasactionventa.Almacen


            };


            integrationgp.AddToTransaccionVentaItem(T_VENTA);
            int numerodetrasaciones_procesadas = integrationgp.SaveChanges();

            return numerodetrasaciones_procesadas;



        }



        public int GETCOMPANYID(string intercompanyid)
        {




            DYNAMICSEntities entidaddynamics = new DYNAMICSEntities();

            var RESULTADO = (from variable in entidaddynamics.SY01500
                             where variable.INTERID == intercompanyid

                             select new
                             {

                                 COMPANYID = variable.CMPANYID
                             }).Single();



            int resultados = Convert.ToInt32(RESULTADO.COMPANYID);

            return resultados;

        }


        public void UpdateIdCarga(int idcarga) {

            var cargagp = integrationgp.CargaGP.Single(p => p.Estatus=="S");

            cargagp.IDCarga = idcarga;


          

           


            try
            {
                integrationgp.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
        
        
        }



    }



}

