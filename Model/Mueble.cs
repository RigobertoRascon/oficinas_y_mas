//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mueble
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mueble()
        {
            this.Entregas = new HashSet<Entrega>();
            this.Pedidoes = new HashSet<Pedido>();
        }
    
        public int idMueble { get; set; }
        public int idAlmacen { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public Nullable<int> precio { get; set; }
        public string image { get; set; }
        public int cantidad_stock { get; set; }
        public string categoria { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entregas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
