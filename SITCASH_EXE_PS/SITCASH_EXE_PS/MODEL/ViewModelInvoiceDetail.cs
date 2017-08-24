using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SITCASH_EXE_PS.MODEL
{
    class ViewModelInvoiceDetail
    {

        public Decimal? Cantidad { get; set; }
        public DateTime FechaDocumento { get; set; }
        public String CodigoProducto { get; set; }
        public String NumeroDocumento { get; set; }
        public Double Importe { get; set; }
        public Double? Impuesto { get; set; }
        public String PalmID { get; set; }
        public Decimal Precio { get; set; }
        public String Tipo { get; set; }
        public int Codigotipo { get; set; }

    }
}
