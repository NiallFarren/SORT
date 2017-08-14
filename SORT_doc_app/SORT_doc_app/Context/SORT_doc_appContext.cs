using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SORT_doc_app.Models;

namespace SORT_doc_app.Context
{
    public class SORT_doc_appContext : DbContext
    {
        public SORT_doc_appContext()
            : base("SORT_doc_appContext")
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<AppsSupportReqs> AppsSupportReqs { get; set; }
        public DbSet<ChangeManagementReqs> ChangeManagementReqs { get; set; }
        public DbSet<DBAReqs> DBAReqs { get; set; }
        public DbSet<EOCReqs> EOCReqs { get; set; }
        public DbSet<GISReqs> GISReqs { get; set; }
        public DbSet<IAMReqs> IAMReqs { get; set; }
        public DbSet<ITCS> ITCS { get; set; }
        public DbSet<NEReqs> NEReqs { get; set; }
        public DbSet<PBX> PBX { get; set; }
        public DbSet<QAReqs> QAReqs { get; set; }
        public DbSet<Risks> Risks { get; set; }
        public DbSet<SCVReqs> SCVReqs { get; set; }
        public DbSet<ServiceSpecifics> ServiceSpecifics { get; set; }
        public DbSet<SignOff> SignOffs { get; set; }
        public DbSet<SMOReqs> SMOReqs { get; set; }
        public DbSet<SREReqs> SREReqs { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }

}