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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Albarán = new HashSet<Albarán>();
        }
    
        public Nullable<short> CodigoEmpresa { get; set; }
        public string IdDelegacion { get; set; }
        public string CodigoCliente { get; set; }
        public string SiglaNacion { get; set; }
        public string CifDni { get; set; }
        public string CifEuropeo { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string CodigoProveedor { get; set; }
        public string CodigoContable { get; set; }
        public string RazonSocial { get; set; }
        public string RazonSocial2 { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Domicilio2 { get; set; }
        public string Nombre1 { get; set; }
        public string FormadePago { get; set; }
        public string CodigoBanco { get; set; }
        public string CodigoAgencia { get; set; }
        public string DC { get; set; }
        public string CCC { get; set; }
        public string IBAN { get; set; }
        public Nullable<int> CodigoZona { get; set; }
        public string CodigoRuta_ { get; set; }
        public Nullable<int> CodigoTransportista { get; set; }
        public string TipoPortes { get; set; }
        public string ObservacionesCliente { get; set; }
        public string Comentarios { get; set; }
        public string CodigoSigla { get; set; }
        public string ViaPublica { get; set; }
        public string Numero1 { get; set; }
        public string Numero2 { get; set; }
        public string Escalera { get; set; }
        public string Piso { get; set; }
        public string Puerta { get; set; }
        public string Letra { get; set; }
        public string CodigoPostal { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string ColaMunicipio { get; set; }
        public string CodigoProvincia { get; set; }
        public string Provincia { get; set; }
        public Nullable<short> CodigoNacion { get; set; }
        public string Nacion { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string HorarioDomicilioLc { get; set; }
        public int id { get; set; }
    
        public virtual ICollection<Albarán> Albarán { get; set; }
    }
}
