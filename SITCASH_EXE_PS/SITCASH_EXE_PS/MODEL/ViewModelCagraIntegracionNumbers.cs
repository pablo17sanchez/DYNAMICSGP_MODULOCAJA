using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SITCASH_EXE_PS.MODEL
{
    class ViewModelCagraIntegracionTransacionVenta_Item
    {
        public int _CantidadFacturadas { get; set; }
        public int IDventa { get; set; }
        public String NoProducto { get; set; }
        public String UnidadDeMedida { get; set; }
        public Double Cantidad { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public String DescripcionDeProducto { get; set; }
        public Decimal PrecioExtendido { get; set; }
        public Double CantidadFacturada { get; set; }
        public Double CantidadCompletada { get; set; }
        public Double CantidadCancelada { get; set; }
        public Double CantidadBO { get; set; }
        public Double CantidadOrdenada { get; set; }
        public int CostoUnitario { get; set; }
        public bool EntregaDirecta { get; set; }
        public String ListaPrecio { get; set; }
        public String Almacen { get; set; }
      




    }
}
