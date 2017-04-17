namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationship_subject_applicationUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUser_Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        WordRememebered = c.Int(nullable: false),
                        NotWordRemembered = c.Int(nullable: false),
                        LearnDate = c.DateTime(nullable: false),
                        ListWordIdRememebered = c.String(),
                        ListNotWordIdRememebered = c.String(),
                    })
                .PrimaryKey(t => new { t.SubjectId, t.ApplicationUserId })
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser_Subject", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUser_Subject", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.ApplicationUser_Subject", new[] { "ApplicationUserId" });
            DropIndex("dbo.ApplicationUser_Subject", new[] { "SubjectId" });
            DropTable("dbo.ApplicationUser_Subject");
        }
    }
}
