using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Dynamics.GP.eConnect;
using GPIntegrationAssembly.DynamicsGPService;
using System.Data;
using System.Web.Services;

namespace SITCASH_EXE_PS.INTREGATIONSCONTROLLERS
{
    class WebServiceManager
    {
        GPdataaccess dataaccess = new GPdataaccess();

        private string sConn = "";
        private string sReturnData = "";
        private string sChequeraId = "";
        private const string sXmlHeaderOpen = "<eConnect xmlns:dt=\"urn:schemas-microsoft-com:datatypes\"><SOPTransactionType>";
        private const string sXmlHeaderClose = "</SOPTransactionType></eConnect>";
        private DynamicsGP wsDynamicsGP;
        private Context context;
        private CompanyKey companyKey;
        private clsDataAcces cData;
        private bool eConnResult;
        private eConnectMethods eConnObject;
        private XmlDocument xmlDoc;

        public WebServiceManager(string ParamConnGP, string ParamConnIntDB)
        {
            this.sConn = ParamConnGP;
          //  this.cData = new clsDataAcces(ParamConnIntDB, ParamConnGP);
            this.cData = new clsDataAcces();
        }


        public WebServiceManager(string sUserId, string sPassword, string sDomainName, string sUrl, string ParamConnGP, string ParamConnIntDB)
        {
            try
            {
               // this.cData = new clsDataAcces(ParamConnIntDB, ParamConnGP);
                this.cData = new clsDataAcces();
                this.sConn = ParamConnGP;
            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder("No fue posible establecer conexion con el servicio web.  ");
                stringBuilder.AppendLine(ex.Message);
                throw new Exception(stringBuilder.ToString());
            }
        }




        #region CREATEDOCUMENTO
        public string CreateDocs(int KeyCompany, DataTable tblVenta, string sCultureName, int RecordPos, DataTable tblItems, string sChequera)
        {
            int int32 = Convert.ToInt32(tblVenta.Rows[RecordPos]["Tipo"]);
            int num = 0;
            string str = "";
            Convert.ToDateTime(tblVenta.Rows[RecordPos]["Fecha"].ToString());
            num = tblVenta.Rows.Count;
            this.sChequeraId = sChequera;
            switch (int32)
            {
                case 0:
                    this.CreateReceivablesInvoice(KeyCompany, tblVenta, sCultureName, RecordPos, sChequera);
                    break;
                case 3:
                    this.CreateSalesInv_eConnect(tblVenta, RecordPos);
                    break;

                case 2:
                    this.CreateSalesInv_eConnect(tblVenta, RecordPos);
                    break;

                case 6:
                    this.CreateReceivablesCreditMemo(KeyCompany, tblVenta, sCultureName, RecordPos, sChequera);
                    break;
            }
            return str;
        }

        private void CreateReceivablesInvoice(int KeyCompany, DataTable tblVenta, string sCultureName, int RecordPos, string sChequera)
        {
            Context Context = new Context();
            Context.OrganizationKey = (OrganizationKey)new CompanyKey()
            {
                Id = KeyCompany
            };
            Context.CultureName = sCultureName;
            ReceivablesDocumentKey receivablesDocumentKey = new ReceivablesDocumentKey();
            CustomerKey customerKey = new CustomerKey();
            customerKey.Id = Convert.ToString(tblVenta.Rows[RecordPos]["idCliente"]);
            BatchKey batchKey = new BatchKey();
            batchKey.Id = tblVenta.Rows[RecordPos]["IDLote"].ToString();
            MoneyAmount moneyAmount1 = new MoneyAmount();
            MoneyAmount moneyAmount2 = new MoneyAmount();
            moneyAmount2.Currency = Convert.ToString(tblVenta.Rows[RecordPos]["IDMoneda"]);
            moneyAmount2.Value = Convert.ToDecimal(tblVenta.Rows[RecordPos]["MontoXCobrar"]);
            MoneyAmount moneyAmount3 = new MoneyAmount();
            moneyAmount3.Currency = Convert.ToString(tblVenta.Rows[RecordPos]["IDMoneda"]);
            if (tblVenta.Rows[RecordPos]["CostoCobrar"].ToString() != "")
                moneyAmount3.Value = Convert.ToDecimal(tblVenta.Rows[RecordPos]["CostoCobrar"]);
            MoneyAmount moneyAmount4 = new MoneyAmount();
            moneyAmount4.Currency = Convert.ToString(tblVenta.Rows[RecordPos]["IDMoneda"].ToString());
            if (tblVenta.Rows[RecordPos]["Impuestos"].ToString() != "")
                moneyAmount4.Value = Convert.ToDecimal(tblVenta.Rows[RecordPos]["Impuestos"]);
            ReceivablesInvoice receivablesInvoice = new ReceivablesInvoice();
            string str = tblVenta.Rows[RecordPos]["NoDocumento"].ToString();
            receivablesDocumentKey.Id = str;
            receivablesInvoice.Key = receivablesDocumentKey;
            if (tblVenta.Rows[RecordPos]["Fecha"].ToString() != "")
                receivablesInvoice.Date = new DateTime?(Convert.ToDateTime(tblVenta.Rows[RecordPos]["Fecha"]));
            receivablesInvoice.BatchKey = batchKey;
            receivablesInvoice.CustomerKey = customerKey;
            receivablesInvoice.PaymentTermsKey = new PaymentTermsKey()
            {
                Id = "NETO 30"
            };
            if (Convert.ToString(tblVenta.Rows[RecordPos]["NoOrden"]) != "")
                receivablesInvoice.CustomerPONumber = Convert.ToString(tblVenta.Rows[RecordPos]["NoOrden"]);
            receivablesInvoice.CostAmount = moneyAmount3;
            receivablesInvoice.TaxAmount = moneyAmount4;
            receivablesInvoice.SalesAmount = moneyAmount2;
            if (Convert.ToString(tblVenta.Rows[RecordPos]["MontoRecibido"]) != "" && Convert.ToDecimal(tblVenta.Rows[RecordPos]["MontoRecibido"]) != new Decimal(0))
            {
                moneyAmount1.Currency = Convert.ToString(tblVenta.Rows[RecordPos]["IDMoneda"]);
                moneyAmount1.Value = Convert.ToDecimal(tblVenta.Rows[RecordPos]["MontoRecibido"]);
                receivablesInvoice.Payment = new ReceivablesPayment();
                receivablesInvoice.Payment.Cash = new CashDetail();
                receivablesInvoice.Payment.Cash.Amount = moneyAmount1;
                receivablesInvoice.Payment.Cash.BankAccountKey = new BankAccountKey();
                receivablesInvoice.Payment.Cash.BankAccountKey.Id = sChequera;
                receivablesInvoice.Payment.Cash.Date = new DateTime?(Convert.ToDateTime(tblVenta.Rows[RecordPos]["Fecha"]));
                receivablesInvoice.Payment.Cash.Number = str;
            }
            Policy policyByOperation = this.wsDynamicsGP.GetPolicyByOperation("CreateReceivablesInvoice", Context);
            this.wsDynamicsGP.CreateReceivablesInvoice(receivablesInvoice, Context, policyByOperation);
        }


        private void CreateReceivablesCreditMemo(int KeyCompany, DataTable tblVenta, string sCultureName, int RecordPos, string sChequera)
        {
            Context Context = new Context();
            Context.OrganizationKey = (OrganizationKey)new CompanyKey()
            {
                Id = KeyCompany
            };
            Context.CultureName = sCultureName;
            ReceivablesDocumentKey receivablesDocumentKey = new ReceivablesDocumentKey();
            CustomerKey customerKey = new CustomerKey();
            customerKey.Id = Convert.ToString(tblVenta.Rows[RecordPos]["idCliente"]);
            BatchKey batchKey = new BatchKey();
            batchKey.Id = tblVenta.Rows[RecordPos]["IDLote"].ToString();
            MoneyAmount moneyAmount = new MoneyAmount();
            moneyAmount.Currency = Convert.ToString(tblVenta.Rows[RecordPos]["IDMoneda"]);
            moneyAmount.Value = Convert.ToDecimal(tblVenta.Rows[RecordPos]["MontoXCobrar"]);
            ReceivablesCreditMemo receivablesCreditMemo = new ReceivablesCreditMemo();
            string str = tblVenta.Rows[RecordPos]["NoDocumento"].ToString();
            receivablesDocumentKey.Id = str;
            receivablesCreditMemo.Key = receivablesDocumentKey;
            if (tblVenta.Rows[RecordPos]["Fecha"].ToString() != "")
                receivablesCreditMemo.Date = new DateTime?(Convert.ToDateTime(tblVenta.Rows[RecordPos]["Fecha"]));
            receivablesCreditMemo.BatchKey = batchKey;
            receivablesCreditMemo.CustomerKey = customerKey;
            receivablesCreditMemo.SalesAmount = moneyAmount;
            Policy policyByOperation = this.wsDynamicsGP.GetPolicyByOperation("CreateReceivablesCreditMemo", Context);
            this.wsDynamicsGP.CreateReceivablesCreditMemo(receivablesCreditMemo, Context, policyByOperation);
        }

        private DataColumn CreateColumn(string sColumnName, string sType)
        {
            return new DataColumn()
            {
                DataType = Type.GetType(sType),
                ColumnName = sColumnName
            };
        }


        private void CreateSalesInv_eConnect(DataTable tbl, int xPos)
        {
            this.eConnObject = new eConnectMethods();
            this.xmlDoc = new XmlDocument();
            DataTable sopLine = this.cData.GetSopLine(Convert.ToInt32(tbl.Rows[xPos]["idventa"]));
            sopLine.TableName = "taSopLineIvcInsert";
            sopLine.DataSet.DataSetName = "taSopLineIvcInsert_Items";
            string str1 = "<eConnect><SOPTransactionType>" + sopLine.DataSet.GetXml();
            DataTable sopPayment = this.cData.GetSopPayment(Convert.ToInt32(tbl.Rows[xPos]["idventa"]), this.sChequeraId);
            sopPayment.TableName = "taCreateSopPaymentInsertRecord";
            sopPayment.DataSet.DataSetName = "taCreateSopPaymentInsertRecord_Items";
            string xml1 = sopPayment.DataSet.GetXml();
            string str2 = str1 + xml1;
            DataTable sopUserDef = this.cData.GetSopUserDef(Convert.ToInt32(tbl.Rows[xPos]["idventa"]));
            sopUserDef.TableName = "taSopUserDefined";
            sopUserDef.DataSet.DataSetName = "dataset";
            string str3 = sopUserDef.DataSet.GetXml().Replace("<dataset>", "").Trim().Replace("</dataset>", "").Trim();
            string str4 = str2 + str3;
            DataTable sopMultiBin = this.cData.GetSopMultiBin(Convert.ToInt32(tbl.Rows[xPos]["idventa"]));
            sopMultiBin.TableName = "taSopMultiBin";
            sopMultiBin.DataSet.DataSetName = "taSopMultiBin_Items";
            string xml2 = sopMultiBin.DataSet.GetXml();
            string str5 = str4 + xml2;
            DataTable sopHdr = this.cData.GetSopHdr(Convert.ToInt32(tbl.Rows[xPos]["idventa"]));
            sopHdr.TableName = "taSopHdrIvcInsert";
            sopHdr.DataSet.DataSetName = "dataset";
            string str6 = sopHdr.DataSet.GetXml().Replace("<dataset>", "").Trim().Replace("</dataset>", "").Trim();
            this.xmlDoc.LoadXml(str5 + str6 + "</SOPTransactionType></eConnect>");
            this.eConnResult = this.eConnObject.eConnect_EntryPoint(this.sConn, EnumTypes.ConnectionStringType.SqlClient, this.xmlDoc.OuterXml, EnumTypes.SchemaValidationType.None, "");
        }

        #endregion







    }
}
