﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Projekat_Entities : DbContext
    {
        public Projekat_Entities()
            : base("name=Projekat_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brod> Brod { get; set; }
        public virtual DbSet<Brodogradiliste> Brodogradiliste { get; set; }
        public virtual DbSet<Brodska_Linija> Brodska_Linija { get; set; }
        public virtual DbSet<Kapetan> Kapetan { get; set; }
        public virtual DbSet<Kormilar> Kormilar { get; set; }
        public virtual DbSet<Kruzer> Kruzer { get; set; }
        public virtual DbSet<Mornar> Mornar { get; set; }
        public virtual DbSet<Posada> Posada { get; set; }
        public virtual DbSet<Poseduje> Poseduje { get; set; }
        public virtual DbSet<Tanker> Tanker { get; set; }
        public virtual DbSet<Teretni_Brod> Teretni_Brod { get; set; }
    }
}
