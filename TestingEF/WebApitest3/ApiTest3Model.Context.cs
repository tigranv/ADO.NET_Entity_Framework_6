﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApitest3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BetC_CRM_DatabaseEntitiesTest3 : DbContext
    {
        public BetC_CRM_DatabaseEntitiesTest3()
            : base("name=BetC_CRM_DatabaseEntitiesTest3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmailList> EmailLists { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
    
        public virtual ObjectResult<GetByPage_Result> GetByPage(Nullable<int> startFrom, Nullable<int> numberOfRows, Nullable<bool> flag)
        {
            var startFromParameter = startFrom.HasValue ?
                new ObjectParameter("startFrom", startFrom) :
                new ObjectParameter("startFrom", typeof(int));
    
            var numberOfRowsParameter = numberOfRows.HasValue ?
                new ObjectParameter("numberOfRows", numberOfRows) :
                new ObjectParameter("numberOfRows", typeof(int));
    
            var flagParameter = flag.HasValue ?
                new ObjectParameter("flag", flag) :
                new ObjectParameter("flag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetByPage_Result>("GetByPage", startFromParameter, numberOfRowsParameter, flagParameter);
        }
    }
}