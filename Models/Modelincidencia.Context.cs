﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelincidenciaContainer : DbContext
    {
        public ModelincidenciaContainer()
            : base("name=ModelincidenciaContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<estado_habilitado> habilitado { get; set; }
        public virtual DbSet<provincia> provincia { get; set; }
        public virtual DbSet<canton> canton { get; set; }
        public virtual DbSet<distrito> distrito { get; set; }
    }
}
