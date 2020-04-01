using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PortalRegistroIncidencias.Models
{
    public class Incidencias
    {
        
        public int Id_Incidencia { get; set; }
        [Required]
        public string Latitud { get; set; }
        [Required]
        public string Longitud { get; set; }
        public string Detalle { get; set; }
        public int Tipo_Incidencia_Id { get; set; }
        public int Empresa_Id { get; set; }
        public int Estado_Incidencia_Id { get; set; }
        public int Fotografia_Id { get; set; }
        public int Provincia_Id { get; set; }
        public int Canton_Id { get; set; }
        public int Distrito_Id { get; set; }
        public int Usuario_Id { get; set; }

    }
}