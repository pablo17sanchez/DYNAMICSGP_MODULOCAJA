using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using SITCASH_EXE_PS.MODEL;


namespace SITCASH_EXE_PS.CONTROLLER
{
    class ControllerCuadredeCaja
    {

        GPHNEntitiesDB gpDataentities = new GPHNEntitiesDB();


        public List<ViewModelClientes> GetSalespersonList()
        {

            var CLIENTES = (from customers in gpDataentities.RM00301
                            orderby customers.SLPRSNFN
                            select new ViewModelClientes
                                            {

                                                CODIGO = customers.SLPRSNID.Trim(),
                                                NOMBRE = customers.SLPRSNFN.Trim() + " " + customers.SPRSNSLN.Trim()

                                            }).ToList();


            CLIENTES.Insert(0, new ViewModelClientes { NOMBRE = "BLANK", CODIGO = "0" });

            return CLIENTES;
        }


        public List<ViewModelClientesCompletos> Getsalespersoncompletepornombre(String nombre)
        {

            var CLIENTES = (from customers in gpDataentities.RM00301
                            orderby customers.SLPRSNFN
                            where customers.SLPRSNFN.Contains(nombre)
                            select new ViewModelClientesCompletos
                            {

                                IDVendedor = customers.SLPRSNID,
                                Nombre = customers.SLPRSNFN.Trim() + "," + customers.SPRSNSLN,
                                IDzona = customers.SALSTERR,
                                Estado =
        (
            customers.INACTIVE == 1 ? "INACTIVO" :
            customers.INACTIVE == 0 ? "ACTIVO" : "Unknown"
        )

                            }).ToList();


            return CLIENTES;
        }

        public List<ViewModelClientesCompletos> GetsalespersoncompleteIDvendedor(String idvendedor)
        {

            var CLIENTES = (from customers in gpDataentities.RM00301
                            orderby customers.SLPRSNFN
                            where customers.SLPRSNID.Contains(idvendedor)
                            select new ViewModelClientesCompletos
                            {

                                IDVendedor = customers.SLPRSNID,
                                Nombre = customers.SLPRSNFN.Trim() + "," + customers.SPRSNSLN,
                                IDzona = customers.SALSTERR,
                                Estado =
                          (
            customers.INACTIVE == 1 ? "INACTIVO" :
            customers.INACTIVE == 0 ? "ACTIVO" : "Unknown"
                            )

                            }).ToList();


            return CLIENTES;
        }

        public List<ViewModelClientesCompletos> GetsalespersoncompleteIDdezona(String idzona)
        {

            var CLIENTES = (from customers in gpDataentities.RM00301
                            orderby customers.SLPRSNFN
                            where customers.SALSTERR.Contains(idzona)
                            select new ViewModelClientesCompletos
                            {

                                IDVendedor = customers.SLPRSNID,
                                Nombre = customers.SLPRSNFN.Trim() + "," + customers.SPRSNSLN,
                                IDzona = customers.SALSTERR,
                                Estado =
                          (
            customers.INACTIVE == 1 ? "INACTIVO" :
            customers.INACTIVE == 0 ? "ACTIVO" : "Unknown"
                            )

                            }).ToList();





            return CLIENTES;
        }


        public String GetUnitmeasurementItem(String itemnumber)
        {
            var result = (from itemmeasuremnt in gpDataentities.IV00101
                          where itemmeasuremnt.ITEMNMBR == itemnumber

                          select new { itemmeasuremnt.SELNGUOM }).Single();

            String RESLTADOSTRING = Convert.ToString(result.SELNGUOM);

            return RESLTADOSTRING;


        }

        public String GetPriceLevel(String itemnumber)
        {
            var result = (from itemmeasuremnt in gpDataentities.IV00101
                          where itemmeasuremnt.ITEMNMBR == itemnumber

                          select new { itemmeasuremnt.PRCLEVEL }).Single();

            String RESULTADOSTRING = Convert.ToString(result.PRCLEVEL);

            return RESULTADOSTRING;


        }
    }
}
