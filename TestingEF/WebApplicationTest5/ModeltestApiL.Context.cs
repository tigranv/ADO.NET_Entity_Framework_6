﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationTest5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BetC_CRM_DatabaseEntitiesAPITest5 : DbContext
    {
        public BetC_CRM_DatabaseEntitiesAPITest5()
            : base("name=BetC_CRM_DatabaseEntitiesAPITest5")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmailList> EmailLists { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
    }
}