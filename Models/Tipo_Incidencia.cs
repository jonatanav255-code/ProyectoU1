//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalRegistroIncidencias.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tipo_Incidencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Incidencia()
        {
            this.Incidencias = new HashSet<Incidencias>();
        }
    
        public short Id_Tipo_Incidencia { get; set; }
        public string Nombre_Problematica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incidencias> Incidencias { get; set; }
    }
}