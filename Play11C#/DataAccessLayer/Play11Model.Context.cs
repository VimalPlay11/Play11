﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Play11DatabaseEntities : DbContext
    {
        public Play11DatabaseEntities()
            : base("name=Play11DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ref_PlayerRole> ref_PlayerRole { get; set; }
        public DbSet<ref_UserRole> ref_UserRole { get; set; }
        public DbSet<trn_ScoreCardDetails> trn_ScoreCardDetails { get; set; }
        public DbSet<ref_UserDetails> ref_UserDetails { get; set; }
        public DbSet<ref_PlayerDetails> ref_PlayerDetails { get; set; }
        public DbSet<ref_TeamDetails> ref_TeamDetails { get; set; }
        public DbSet<trn_UserTeamDetails> trn_UserTeamDetails { get; set; }
        public DbSet<ref_MatchDetails> ref_MatchDetails { get; set; }
        public DbSet<ExecptionLog> ExecptionLogs { get; set; }
    }
}