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
    
    public partial class usuario
    {
        public short Id_usuario { get; set; }
        public short habilitado_id { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string correo_electronico { get; set; }
        public string contrasena { get; set; }
        public string direccion { get; set; }
        public string codigo_activacion { get; set; }
    
        public virtual estado_habilitado habilitado { get; set; }
    }
}