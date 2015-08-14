using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Repository.Pattern.Ef6;
using System.Diagnostics;
using Serilog;
using ConfOrganizer.Entities;

namespace ConfOrganizer.Data
{

    public partial class ConfOrganizerDataContext : DataContext
    {

        public ConfOrganizerDataContext()
            : base("name=CoreData")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<ConfOrganizerDataContext>(null);
            //Database.Log = msg => log.Debug(msg);
            Database.Log = msg => Trace.WriteLine(msg);
        }

        public virtual DbSet<Attendee> AttendeeSet { get; set; }
        public virtual DbSet<Organizer> OrganizerSet { get; set; }
        public virtual DbSet<Speaker> SpeakerSet { get; set; }
        public virtual DbSet<Talk> TalkSet { get; set; }
        public virtual DbSet<TalkProposal> TalkProposalSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }

}