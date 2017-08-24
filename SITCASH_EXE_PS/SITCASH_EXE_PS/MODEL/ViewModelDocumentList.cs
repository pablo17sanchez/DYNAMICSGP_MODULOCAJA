using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SITCASH_EXE_PS.MODEL
{
    class ViewModelDocumentList
    {
        public DateTime? Date { get; set; }
        public String DocumentNumber { get; set; }
      
        public Decimal? DocumentAmout { get; set; }
       
        public Decimal? Payment { get; set; }
        public String Tipo { get; set; }
        public String NCF { get; set; }
        public String CodigodeCliente { get; set; }
        public Decimal MontoPago { get; set; }
        public Decimal? Descuento { get; set; }
        public Decimal? Impuesto { get; set; }
        public Decimal? MontoeEfectivo { get; set; }
        public Decimal? MontoCheque { get; set; }
        public String NumeroDeChecke { get; set; }
    }
}
