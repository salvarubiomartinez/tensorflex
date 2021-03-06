//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tensorflex.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Articulo
    {
        public Articulo()
        {
            this.LineaAlbarans = new HashSet<LineaAlbaran>();
        }
    
        public Nullable<short> CodigoEmpresa { get; set; }
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }
        public string Descripcion2Articulo { get; set; }
        public string CodigoAlternativo { get; set; }
        public string CodigoAlternativo2 { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string CodigoFamilia { get; set; }
        public string CodigoSubfamilia { get; set; }
        public Nullable<decimal> StockMinimo { get; set; }
        public Nullable<decimal> StockMaximo { get; set; }
        public Nullable<decimal> PuntoPedido { get; set; }
        public Nullable<decimal> PrecioCompra { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public Nullable<decimal> C_Margen { get; set; }
        public int id { get; set; }
    
        public virtual ICollection<LineaAlbaran> LineaAlbarans { get; set; }
    }
}
