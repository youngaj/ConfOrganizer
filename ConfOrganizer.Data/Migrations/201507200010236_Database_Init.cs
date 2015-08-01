namespace ConfOrganizer.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Database_Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        Code = c.String(),
                        JobTitle = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TalkProposals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Abstract = c.String(),
                        Discipline = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        AttendeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendees", t => t.AttendeeId, cascadeDelete: true)
                .Index(t => t.AttendeeId);

            CreateTable(
                "dbo.Talks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Abstract = c.String(),
                        Discipline = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        SpeakerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attendees", t => t.SpeakerId, cascadeDelete: true)
                .Index(t => t.SpeakerId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Talks", "SpeakerId", "dbo.Attendees");
            DropForeignKey("dbo.TalkProposals", "AttendeeId", "dbo.Attendees");
            DropIndex("dbo.Talks", new[] { "SpeakerId" });
            DropIndex("dbo.TalkProposals", new[] { "AttendeeId" });
            DropTable("dbo.Talks");
            DropTable("dbo.TalkProposals");
            DropTable("dbo.Attendees");
        }
    }
}