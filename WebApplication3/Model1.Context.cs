﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class sql_mangeEntities : DbContext
    {
        public sql_mangeEntities()
            : base("name=sql_mangeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<employ_user> employ_user { get; set; }
        public virtual DbSet<userRole> userRoles { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
    
        public virtual ObjectResult<string> GetAllDatabaseList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetAllDatabaseList");
        }

        public System.Data.Entity.DbSet<WebApplication3.Models.ViewAllDatabase> viewAllDatabases { get; set; }
    }
}
