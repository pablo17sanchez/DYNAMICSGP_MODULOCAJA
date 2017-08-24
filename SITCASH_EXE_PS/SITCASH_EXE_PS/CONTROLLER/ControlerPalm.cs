using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SITCASH_EXE_PS.MODEL;
using System.Data.Objects.SqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace SITCASH_EXE_PS.CONTROLLER
{
    class ControlerPalm
    {

        GPdataaccess CONE = new GPdataaccess();

        MODEL.PalmComSyncEntities1 PALMDATAENTITIES = new MODEL.PalmComSyncEntities1();


        public List<ViewModelPalmID> GetpalmID(string idvendedorparmetro)
        {

            var PALMIDVALUE = (from PAML in PALMDATAENTITIES.OUT_CONFIG
                               where PAML.IDVENDEDOR == idvendedorparmetro
                               select new ViewModelPalmID
                               {

                                   PamlID = PAML.PALMID.Trim()
                               }).ToList();


            int result = PALMIDVALUE.SelectMany(list => list.PamlID).Distinct().Count();

            if (result > 0)
            {
                return PALMIDVALUE;
            }
            else
            {
                return null;
            }



        }



        public List<ViewModelDocumentList> GetDocumenList(ModelPalmVendors palmvendor)
        {


            var DOCUMENTLISTVARIABLE = (from DOCUMENTLIST in PALMDATAENTITIES.IN_FACTURA
                                        where
                                            DOCUMENTLIST.PALMID == palmvendor.PalmID
                                            && DOCUMENTLIST.FECHAFAC >= palmvendor.FechaDesde
                                            && DOCUMENTLIST.FECHAFAC <= palmvendor.FechaHasta
                                        group DOCUMENTLIST by new
                                        {
                                            DOCUMENTLIST.FECHAFAC,
                                            DOCUMENTLIST.FACNUM,
                                            DOCUMENTLIST.NCF,
                                            DOCUMENTLIST.CODCLIE
                                            ,
                                            DOCUMENTLIST.MONPAGEFEC
                                            ,
                                            DOCUMENTLIST.MONTOCHK
                                            ,
                                            DOCUMENTLIST.NUMCHK,
                                            DOCUMENTLIST.DESCUENTO
                                            ,
                                            DOCUMENTLIST.MONPAGO
                                        } into GROUPINGFACTURAS

                                        select new ViewModelDocumentList
                                        {
                                            DocumentNumber = GROUPINGFACTURAS.Key.FACNUM
                                            ,
                                            Date = GROUPINGFACTURAS.Key.FECHAFAC
                                            ,
                                            DocumentAmout = GROUPINGFACTURAS.Sum(c => c.MONTOFAC)
                                            ,
                                            Payment = GROUPINGFACTURAS.Sum(c => c.MONPAGO)
                                            ,
                                            Tipo = "FACTURA"
                                            ,
                                            NCF = GROUPINGFACTURAS.Key.NCF
                                            ,
                                            CodigodeCliente = GROUPINGFACTURAS.Key.CODCLIE
                                            ,
                                            MontoeEfectivo = GROUPINGFACTURAS.Key.MONPAGEFEC
                                            ,
                                            MontoCheque = GROUPINGFACTURAS.Key.MONTOCHK
                                            ,
                                            NumeroDeChecke = GROUPINGFACTURAS.Key.NUMCHK
                                            ,
                                            Descuento = GROUPINGFACTURAS.Key.DESCUENTO
                                            ,
                                            MontoPago = GROUPINGFACTURAS.Key.MONPAGO ?? 0



                                        }).Union(//******SEPARATOR 



                                       from DOCUMENTLIST in PALMDATAENTITIES.IN_PEDIDOS
                                       where
                                           DOCUMENTLIST.PALMID == palmvendor.PalmID
                                           && DOCUMENTLIST.FECHAPED >= palmvendor.FechaDesde
                                           && DOCUMENTLIST.FECHAPED <= palmvendor.FechaHasta
                                       group DOCUMENTLIST by new
                                       {
                                           DOCUMENTLIST.FECHAPED,
                                           DOCUMENTLIST.PEDNUM,

                                           DOCUMENTLIST.CODCLIE,
                                           DOCUMENTLIST.MONTOPED
                                           ,
                                           DOCUMENTLIST.MONPAGO
                                          ,
                                           DOCUMENTLIST.IMPUESTO


                                       } into GROUPINGPEDIDOS

                                       select new ViewModelDocumentList
                                       {
                                           DocumentNumber = GROUPINGPEDIDOS.Key.PEDNUM
                                           ,
                                           Date = GROUPINGPEDIDOS.Key.FECHAPED
                                           ,
                                           DocumentAmout = GROUPINGPEDIDOS.Key.MONTOPED
                                           ,
                                           Payment = GROUPINGPEDIDOS.Key.MONPAGO
                                           ,
                                           Tipo = "PEDIDOS",
                                           NCF = ""
                                           ,
                                           CodigodeCliente = GROUPINGPEDIDOS.Key.CODCLIE
                                           ,
                                           MontoeEfectivo = 0
                                           ,
                                           MontoCheque = 0
                                           ,
                                           NumeroDeChecke = ""
                                           ,
                                           Descuento = 0
                                           ,
                                           MontoPago = GROUPINGPEDIDOS.Key.MONPAGO ?? 0


                                       }).Union(//***SEPARATOR asd
                                                                                  from DOCUMENTLIST in PALMDATAENTITIES.in_conduce
                                                                                  where
                                                                                      DOCUMENTLIST.PALMID == palmvendor.PalmID
                                                                                      && DOCUMENTLIST.FECHACOND >= palmvendor.FechaDesde
                                                                                      && DOCUMENTLIST.FECHACOND <= palmvendor.FechaHasta
                                                                                  group DOCUMENTLIST by new
                                                                                  {
                                                                                      DOCUMENTLIST.FECHACOND,
                                                                                      DOCUMENTLIST.CNDNUM,
                                                                                      DOCUMENTLIST.MONTOCND,
                                                                                      DOCUMENTLIST.MONPAGO
                                                                                      ,
                                                                                      DOCUMENTLIST.CODCLIE
                                                                                      ,
                                                                                      DOCUMENTLIST.DESCUENTO

                                                                                  } into GROUPINGCONDUCE

                                                                                  select new ViewModelDocumentList
                                                                                  {
                                                                                      DocumentNumber = GROUPINGCONDUCE.Key.CNDNUM
                                                                                      ,
                                                                                      Date = GROUPINGCONDUCE.Key.FECHACOND
                                                                                      ,
                                                                                      // DocumentAmout = GROUPINGCONDUCE.Sum(c => c.MONTOCND)
                                                                                      DocumentAmout = GROUPINGCONDUCE.Key.MONTOCND
                                                                                      ,
                                                                                      // Payment = GROUPINGCONDUCE.Sum(c => c.MONPAGO)
                                                                                      Payment = GROUPINGCONDUCE.Key.MONPAGO
                                                                                      ,
                                                                                      Tipo = "CONDUCE",
                                                                                      NCF = ""
                                                                                      ,
                                                                                      CodigodeCliente = GROUPINGCONDUCE.Key.CODCLIE
                                                                                      ,
                                                                                      MontoeEfectivo = 0
                                                                                      ,
                                                                                      MontoCheque = 0
                                                                                        ,
                                                                                      NumeroDeChecke = ""
                                                                                      ,
                                                                                      Descuento = GROUPINGCONDUCE.Key.DESCUENTO
                                                                                      ,
                                                                                      MontoPago = GROUPINGCONDUCE.Key.MONPAGO ?? 0


                                                                                  }).ToList();



            return DOCUMENTLISTVARIABLE;

        }

        public ViewModelDocumentsAmountsTotals llenartotales(List<ViewModelDocumentList> listado)
        {


            ViewModelDocumentsAmountsTotals totales = new ViewModelDocumentsAmountsTotals();

            foreach (var item in listado)
            {
                totales.DocumentAmountTotals += item.DocumentAmout;
                totales.PaymentAmounts += item.Payment;
            }

            return totales;
        }


        //       public String GetMaxDateDocument(String palmID, DateTime fechadesde, DateTime fechahasta)
        //       {

        //            DateTime fechasiesnullo = new DateTime(1991, 07, 14);
        //           var MaxDate = (from d in PALMDATAENTITIES.IN_FACTURA
        //                          where d.FECHAFAC >= fechadesde &&
        //                          d.FECHAFAC >= fechahasta && d.PALMID == palmID
        //                          select new ViewModelMaxFecha{  FechaMax = d.FECHAFAC }).Union(from e in PALMDATAENTITIES.in_conduce
        //                                                                   where e.FECHACOND >= fechadesde &&
        //                                       e.FECHACOND >= fechahasta && e.PALMID == palmID
        //                                                                                        select new ViewModelMaxFecha { FechaMax = e.FECHACOND }).Union(from f in PALMDATAENTITIES.IN_PEDIDOS
        //                                                                                                             where f.FECHAPED >= fechadesde &&
        //                                                                                                             f.FECHAPED >= fechahasta && f.PALMID == palmID
        //                                                                                                                                                       select new ViewModelMaxFecha {  FechaMax = f.FECHAPED }).ToList();

        //           var result = MaxDate.Max();



        //var COUNT = (from d in PALMDATAENTITIES.IN_FACTURA
        //                          where d.FECHAFAC >= fechadesde &&
        //                          d.FECHAFAC >= fechahasta && d.PALMID == palmID
        //                          select new { fecha = d.FECHAFAC }).Union(from e in PALMDATAENTITIES.in_conduce
        //                                                                   where e.FECHACOND >= fechadesde &&
        //                                       e.FECHACOND >= fechahasta && e.PALMID == palmID
        //                                                                   select new { fecha = e.FECHACOND }).Union(from f in PALMDATAENTITIES.IN_PEDIDOS
        //                                                                                                             where f.FECHAPED >= fechadesde &&
        //                                                                                                             f.FECHAPED >= fechahasta && f.PALMID == palmID
        //                                                                                                             select new { fecha = f.FECHAPED }).Count();

        //DateTime outs = result.FechaMax ?? fechasiesnullo;

        //String SFECHAMAX = outs.Year +""+ outs.Month +""+ outs.Day;



        //           String resultado = "";

        //           if (COUNT > 0)
        //           {
        //               if (COUNT>1)
        //               {
        //                   resultado = "";

        //               }

        //               resultado = result.FechaMax.ToString("yyyyMMdd");
        //           }






        //           return resultado;

        //       }







        public int CountDocumentList(ModelPalmVendors palmvendors)
        {
            int resultado = GetDocumenList(palmvendors).Count;
            return resultado;
        }




        public List<ViewModelInvoiceDetail> GetDocumentDetail(String palmID, DateTime fecha, String documentNumber)
        {
            DateTime fechasiesnullo = new DateTime(1991, 07, 14);


            var resultado = (from facdetail in PALMDATAENTITIES.IN_DETAFAC
                             join facmaster in PALMDATAENTITIES.IN_FACTURA on facdetail.FACNUM
                             equals facmaster.FACNUM
                             where
                                 facmaster.PALMID == palmID &&
                                 facmaster.FECHAFAC == fecha
                                 && facmaster.FACNUM == documentNumber
                             select new ViewModelInvoiceDetail
                             {
                                 FechaDocumento = facmaster.FECHAFAC ?? fechasiesnullo,
                                 Cantidad = facdetail.CANTIDAD,
                                 CodigoProducto = facdetail.CODPROD,
                                 NumeroDocumento = facdetail.FACNUM,
                                 Importe = SqlFunctions.Log10(facdetail.IMPORTE) ?? 0,
                                 Impuesto = facdetail.IMPUESTO,
                                 PalmID = facdetail.PALMID,
                                 Precio = facdetail.PRECIO,
                                 Tipo = "FACTURA",
                                 Codigotipo = 3

                             }).Union(from peddital in PALMDATAENTITIES.IN_DETAPED
                                      join pedmaster in PALMDATAENTITIES.IN_PEDIDOS on peddital.PEDNUM
                                                     equals pedmaster.PEDNUM
                                      where
                                          pedmaster.PALMID == palmID
                                          && pedmaster.FECHAPED == fecha
                                          && pedmaster.PEDNUM == documentNumber
                                      select new ViewModelInvoiceDetail
                                      {
                                          FechaDocumento = pedmaster.FECHAPED ?? fechasiesnullo,
                                          Cantidad = peddital.CANTIDAD,
                                          CodigoProducto = peddital.CODPROD,
                                          NumeroDocumento = peddital.PEDNUM,
                                          Importe = SqlFunctions.Log10(peddital.IMPORTE) ?? 0,
                                          Impuesto = SqlFunctions.Log10(peddital.IMPUESTO),
                                          PalmID = peddital.PALMID,
                                          Precio = peddital.PRECIO ?? 0,
                                          Tipo = "PEDIDO",
                                          Codigotipo = 2



                                      }).Union(from conddetail in PALMDATAENTITIES.in_detacond
                                               join condmaster in PALMDATAENTITIES.in_conduce on conddetail.CNDNUM
                                                              equals condmaster.CNDNUM
                                               where
                                                   condmaster.PALMID == palmID
                                                   && condmaster.FECHACOND == fecha
                                                   && condmaster.CNDNUM == documentNumber
                                               select new ViewModelInvoiceDetail
                                               {
                                                   FechaDocumento = condmaster.FECHACOND ?? fechasiesnullo,
                                                   Cantidad = conddetail.CANTIDAD,
                                                   CodigoProducto = conddetail.CODPROD,
                                                   NumeroDocumento = conddetail.CNDNUM,
                                                   Importe = SqlFunctions.Log10(conddetail.IMPORTE) ?? 0,
                                                   Impuesto = SqlFunctions.Log10(conddetail.IMPUESTO),
                                                   PalmID = conddetail.PALMID,
                                                   Precio = conddetail.PRECIO ?? 0,
                                                   Tipo = "CONDUCE",
                                                   Codigotipo = 2




                                               }).ToList();



            return resultado;



        }

        int afectrows = 0;
        public int DeleteDocumentDetail(String NumeroDocumento, String SPalmID, String tipo)
        {

                using (SqlConnection con = new SqlConnection(CONE.PAMLCONECTIONS()))
                {
                    con.Open();
                 
                    using (SqlCommand comando = new SqlCommand())
                    {
                        if (tipo == "PALMFACTURA")
                        {

                            comando.CommandText = "delete in_detafac from in_factura f join in_detafac d on (f.facnum=d.facnum) where f.NoDocumento=@NoDocumento and f.PALMID=@PALMID";
                            comando.Parameters.AddWithValue("@NoDocumento", NumeroDocumento);

                            comando.Parameters.AddWithValue("@PALMID", SPalmID);

                             afectrows = comando.ExecuteNonQuery();


                        }
                        else if (tipo == "PALMCONDUCE")
                        {
                            
                            comando.CommandText = "delete in_detacond from in_conduce f join in_detacond d on (f.CNDNUM=d.CNDNUM) where f.NoDocumento=@NoDocumento and f.PALMID=@PALMID";
                            comando.Parameters.AddWithValue("@NoDocumento", NumeroDocumento);

                            comando.Parameters.AddWithValue("@PALMID", SPalmID);

                             afectrows = comando.ExecuteNonQuery();

                        }
                        else if (tipo == "PALMPEDIDOS")
                        {
                       


                            comando.CommandText = "delete IN_DETAPED from IN_PEDIDOS f join IN_DETAPED d on (f.PEDNUM=d.PEDNUM)  where f.NoDocumento=@NoDocumento and f.PALMID=@PALMID";
                            comando.Parameters.AddWithValue("@NoDocumento", NumeroDocumento);

                            comando.Parameters.AddWithValue("@PALMID", SPalmID);

                             afectrows = comando.ExecuteNonQuery();

                        }

                    }








                };







                return afectrows;
          
        }




        public int DeleteDocumntHeader(String NumeroDocumento, String SPalmID, String tipo)
        {
            int afectrows = 0;
            using (SqlConnection con = new SqlConnection(CONE.PAMLCONECTIONS()))
            {
                con.Open();

                using (SqlCommand comando = new SqlCommand())
                {
                    if (tipo == "PALMFACTURA")
                    {

                        comando.CommandText = "delete in_factura where NoDocumento=@NoDocumento and PALMID=@PALMID";
                        comando.Parameters.AddWithValue("@NoDocumento", NumeroDocumento);

                        comando.Parameters.AddWithValue("@PALMID", SPalmID);

                        afectrows = comando.ExecuteNonQuery();


                    }
                    else if (tipo == "PALMCONDUCE")
                    {

                        comando.CommandText = "delete in_conduce  where NoDocumento=@NoDocumento and PALMID=@PALMID";
                        comando.Parameters.AddWithValue("@NoDocumento", NumeroDocumento);

                        comando.Parameters.AddWithValue("@PALMID", SPalmID);

                        afectrows = comando.ExecuteNonQuery();

                    }
                    else if (tipo == "PALMPEDIDOS")
                    {

                        comando.CommandText = "delete IN_PEDIDOS where NoDocumento=@NoDocumento and PALMID=@PALMID";
                        comando.Parameters.AddWithValue("@NoDocumento", NumeroDocumento);

                        comando.Parameters.AddWithValue("@PALMID", SPalmID);

                        afectrows = comando.ExecuteNonQuery();

                    }

                }




            };








            return afectrows;
        }



    }
}