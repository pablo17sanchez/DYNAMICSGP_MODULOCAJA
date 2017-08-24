using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SITCASH_EXE_PS.MODEL
{
    class ViewModelCagraIntegracionTransacionVenta
    {
        public int IDCarga { get; set; }
        public int IDVenta { get; set; }
        public int Tipo { get; set; }
        public String IDTipo { get; set; }
        public String NoDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public String AlmacenDefault { get; set; }
        public String IDLote { get; set; }
        public String IDCliente { get; set; }
        public String NombreCliente { get; set; }
        public String NoOrden { get; set; }
        public String IDMoneda { get; set; }
        public Decimal DescuentoComercial { get; set; }
        public Decimal Flete { get; set; }
        public Decimal Miscelaneo { get; set; }
        public Decimal MontoRecibido { get; set; }
        public Decimal DescuentoRetornado { get; set; }
        public Decimal Impuestos { get; set; }
        public String NCF { get; set; }
        public String IDVendedor { get; set; }
        public String Status { get; set; }
        public String IDAyudante { get; set; }
        public String IDayudante2 { get; set; }
        public Decimal MontoEfectivo { get; set; }
        public String NumeroCheque { get; set; }
        public Decimal MontoCheque { get; set; }
         //(IDCarga, Tipo, IDTipo, NoDocumento, Fecha, AlmacenDefault, IDLote, IDCliente, NombreCliente, NoOrden, IDMoneda, DescuentoComercial, Flete, Miscelaneo, MontoRecibido, DescuentoRetornado, Impuestos, Status, IDVenta, IDVendedor, IDAyudante, IDAyudante2, NCF, MontoEfectivo, MontoCheque, NumeroCheque)
    }
}
