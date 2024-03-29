﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HalloEF_DbFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PROGRAMMINGEFDB1Entities : DbContext
    {
        public PROGRAMMINGEFDB1Entities()
            : base("name=PROGRAMMINGEFDB1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<vOfficeAddress> vOfficeAddresses { get; set; }
    
        public virtual ObjectResult<Contact> GetContactsByState(string statecode)
        {
            var statecodeParameter = statecode != null ?
                new ObjectParameter("statecode", statecode) :
                new ObjectParameter("statecode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Contact>("GetContactsByState", statecodeParameter);
        }
    
        public virtual ObjectResult<Contact> GetContactsByState(string statecode, MergeOption mergeOption)
        {
            var statecodeParameter = statecode != null ?
                new ObjectParameter("statecode", statecode) :
                new ObjectParameter("statecode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Contact>("GetContactsByState", mergeOption, statecodeParameter);
        }
    }
}
