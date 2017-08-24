using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Data;

namespace SITCASH_EXE_PS.INTREGATIONSCONTROLLERS
{
    class clsDataAcces
    {
        private SqlConnection sqlConn;
        private SqlConnection sqlConnGpDB;
        private string sConnGpDb;
        private clsLogic cLogic;
        GPdataaccess dataacces = new GPdataaccess();


        public DataTable GetTblCarga(int iIDCarga)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = new SqlConnection(dataacces.SITINTEGRATION()))
            {

                using (SqlCommand comando = new SqlCommand("sp_SelectCargaGP",con))
                {
                    con.Open();
             
                    comando.CommandType = CommandType.StoredProcedure;
                

                    comando.Parameters.Add("@IDCarga", SqlDbType.Int).Value = iIDCarga;

                    using (SqlDataAdapter ada=  new SqlDataAdapter(comando))
                    {
                        ada.Fill(tabla);
                    }


                    
                }
                
            }



            return tabla;

        //    return this.ExQuery("EXEC sp_SelectCargaGp " + iIDCarga.ToString());
        }

        //  public clsDataAcces(string sConn, string sConn2)
        public clsDataAcces()
        {
            GPdataaccess dataaccess = new GPdataaccess();


            this.sqlConn = new SqlConnection(dataaccess.SITINTEGRATION());
            this.sqlConnGpDB = new SqlConnection(dataaccess.GPHNCARGAR());
            this.sConnGpDb = dataaccess.GPHNCARGAR();
           // this.cLogic = new clsLogic();
        }
        //bien 
        public DataTable GetSopPayment(int IdVentas, string sChequera)
        {
            return this.ExQuery("EXEC PS_sp_taCreateSopPaymentInsertRecord " + IdVentas.ToString() + ", '" + sChequera + "'");
        }

        //bien 
        private DataTable ExQuery(string sProcedureName)
        {
            DataSet dataSet = new DataSet();
            if (this.sqlConn.State != ConnectionState.Open)
                this.sqlConn.Open();
            SqlCommand selectCommand = new SqlCommand(sProcedureName, this.sqlConn);
            selectCommand.ExecuteReader();
            this.sqlConn.Close();
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            return dataSet.Tables[0];
        }

        //bien 
        public DataTable GetVentasList(int IdCarga)
        {
            return this.ExQuery("EXEC sp_SelectVentaList " + IdCarga.ToString());
        }
        //bien
        public DataTable GetVentaItemById(int IdVenta)
        {
            return this.ExQuery("EXEC sp_SelectTransaccionVentaItem " + IdVenta.ToString());
        }
        public DataTable GetSopLine(int IdVentas)
        {
            return this.ExQuery("EXEC PS_sp_taSopLineIvcInsert " + IdVentas.ToString());
        }
        //BIEN 
        public DataTable GetSopUserDef(int IdVentas)
        {
            return this.ExQuery("EXEC sp_taSopUserDefined " + IdVentas.ToString());
        }

        //BIEN
        public DataTable GetSopMultiBin(int IdVentas)
        {
            return this.ExQuery("EXEC sp_taSopMultiBin " + IdVentas.ToString());
        }
        //bien 
        public DataTable GetSopHdr(int IdVentas)
        {
            return this.ExQuery("EXEC PS_sp_taSopHdrIvcInsert " + IdVentas.ToString());
        }


        //bien
        public void UpdateVentaSetEstatus(int IdVenta, string status, string ErrorDetail)
        {
            int length = ErrorDetail.Length;
            if (length > 799)
                length = 799;
            this.ExNoQuery("sp_UpdateVentasSetEstatus " + IdVenta.ToString() + ", '" + status + "', '" + ErrorDetail.Substring(0, length) + "'");
        }
        //BIEN 
        private void ExNoQuery(string sProcedureName)
        {
            sProcedureName = "EXEC " + sProcedureName;
            DataSet dataSet = new DataSet();
            if (this.sqlConn.State != ConnectionState.Open)
                this.sqlConn.Open();
            new SqlCommand(sProcedureName, this.sqlConn).ExecuteNonQuery();
            this.sqlConn.Close();
        }


        //bien
        public void UpdateCargaSetEstatus(int Idcarga, string status)
        {
            this.ExNoQuery("sp_UpdateCargaSetEstatus " + Idcarga.ToString() + ", '" + status + "'");
        }
    }
}
