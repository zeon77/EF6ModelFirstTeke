//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF6DbFirstTeke
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TekeDbEntities : DbContext
    {
        public TekeDbEntities()
            : base("name=TekeDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Egyesuletek> Egyesuleteks { get; set; }
        public virtual DbSet<Eredmenyek> Eredmenyeks { get; set; }
        public virtual DbSet<Versenyzok> Versenyzoks { get; set; }
    }
}
