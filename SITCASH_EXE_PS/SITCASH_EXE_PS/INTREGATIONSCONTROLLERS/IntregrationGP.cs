using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SITCASH_EXE_PS.MODEL;


namespace SITCASH_EXE_PS.INTREGATIONSCONTROLLERS
{
    public class IntregrationGP
    {

        private clsDataAcces cData;
        private WebServiceManager webSrvGP;
        private DataTable tblVenta;
        private DataTable tblItems;
        private DataTable tblCarga;
        private int IDCarga;
        private int CompanyID;
        private string Chequera;
        private string sConnGPDb;
        private string sConnIntDb;

        public DataTable RunImportProccess(ViewModelImportInfo viewmodelImport)
        {
            clsDataAcces controldata = new clsDataAcces();
           
            GPdataaccess data = new GPdataaccess();
            
            this.IDCarga = viewmodelImport.iIDCarga;
            this.CompanyID = viewmodelImport.iCompanyID;
            this.Chequera = viewmodelImport.sChequera;
            this.webSrvGP = new WebServiceManager(viewmodelImport.UserId,
                viewmodelImport.Password, viewmodelImport.Dominio,
                viewmodelImport.Url, data.GPHNCARGAR(), data.SITINTEGRATION());
            int ID = viewmodelImport.iIDCarga;
            try
            {

               
                //no problema
                //this.tblCarga = this.cData.GetTblCarga(ID);
                this.tblCarga = controldata.GetTblCarga(ID);
                return this.tblCarga;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetSalesList(int iIDCarga)
        {
            clsDataAcces controldata = new clsDataAcces();

        //    this.tblVenta = this.cData.GetVentasList(iIDCarga);
            this.tblVenta = controldata.GetVentasList(iIDCarga);
            return this.tblVenta;
        }


        public string SaleProcess(int iIDVenta, int xPos)
        {
            clsDataAcces controldata = new clsDataAcces();
            //El idventa vuelve a 0
            //int IdVenta=0;
            string docs;
            try
            {


                //Id Venta es asignado otra vez esta logica es del programa creado por SITCORP
                //IdVenta = iIDVenta;

                //Retorna un datatable con el select siguiente SELECT * FROM TransaccionVentaItem WHERE IDVenta = @IDVenta
                //El cual resive un parametro que es el id de venta
               //** this.tblItems = this.cData.GetVentaItemById(iIDVenta);
             //ppp   
                this.tblItems = controldata.GetVentaItemById(iIDVenta);
                //crear el documento para pasar a gp
                //pasa 6 paramaetros 
                // CompanyID=id de la compania
                //tblVenta=tabla TRANSACCIONVENTA HEADER
                //"eS-ES" PARAMETRO DE LENGUAJE
                //NUMERO DE FILAS
                //tblItems=TRANSACCIONVENTAEL DETAIL
                docs = this.webSrvGP.CreateDocs(this.CompanyID, this.tblVenta, "es-ES", xPos, this.tblItems, this.Chequera);
                if (docs != "")
                    controldata.UpdateVentaSetEstatus(iIDVenta, "P", docs);
                else
                    controldata.UpdateVentaSetEstatus(iIDVenta, "P", "");
            }
            catch (Exception ex)
            {
                controldata.UpdateVentaSetEstatus(iIDVenta, "E", ex.Message.ToString());
                docs = ex.Message.ToString();
            }
            return docs;
        }

        public void ProcessCarga(int iIDCarga)
        {
            this.cData.UpdateCargaSetEstatus(iIDCarga, "P");
        }
    }
}
