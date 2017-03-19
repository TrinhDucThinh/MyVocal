namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        QuestionCategoryId = c.Int(nullable: false, identity: true),
                        QuesionCategoryName = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.QuestionCategoryId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionName = c.String(),
                        QuestionCateroyId = c.Int(nullable: false),
                        AnswerA = c.String(),
                        AnswerB = c.String(),
                        AnswerC = c.String(),
                        AnswerD = c.String(),
                        Solution = c.String(),
                        Image = c.String(),
                        Status = c.Boolean(nullable: false),
                        WordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionCategories", t => t.QuestionCateroyId, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.WordId, cascadeDelete: true)
                .Index(t => t.QuestionCateroyId)
                .Index(t => t.WordId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        WordId = c.Int(nullable: false, identity: true),
                        Transcription = c.String(maxLength: 40),
                        WordCategoryId = c.Int(nullable: false),
                        Sound = c.String(maxLength: 300),
                        Image = c.String(maxLength: 300),
                        Status = c.Boolean(),
                        SubjectId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.WordId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.WordCategories", t => t.WordCategoryId, cascadeDelete: true)
                .Index(t => t.WordCategoryId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 600),
                        Identify = c.String(maxLength: 100),
                        Image = c.String(maxLength: 500),
                        SubjectGroupId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        WordTotal = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.SubjectGroups", t => t.SubjectGroupId, cascadeDelete: true)
                .Index(t => t.SubjectGroupId);
            
            CreateTable(
                "dbo.SubjectGroups",
                c => new
                    {
                        SubjectGroupId = c.Int(nullable: false, identity: true),
                        SubjecGroupName = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 600),
                        Identify = c.String(maxLength: 100),
                        Image = c.String(maxLength: 500),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectGroupId);
            
            CreateTable(
                "dbo.WordCategories",
                c => new
                    {
                        WordCategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 15),
                        Description = c.String(maxLength: 200),
                        Identify = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.WordCategoryId);
            
            CreateTable(
                "dbo.Semantics",
                c => new
                    {
                        Semantic_Id = c.Int(nullable: false, identity: true),
                        WordId = c.Int(nullable: false),
                        WordFollow = c.String(maxLength: 100),
                        Example = c.String(maxLength: 300),
                        ExampleSound = c.String(maxLength: 400),
                        Image = c.String(maxLength: 400),
                        SemamticTime = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Semantic_Id)
                .ForeignKey("dbo.Words", t => t.WordId, cascadeDelete: true)
                .Index(t => t.WordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Semantics", "WordId", "dbo.Words");
            DropForeignKey("dbo.Question", "WordId", "dbo.Words");
            DropForeignKey("dbo.Words", "WordCategoryId", "dbo.WordCategories");
            DropForeignKey("dbo.Words", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "SubjectGroupId", "dbo.SubjectGroups");
            DropForeignKey("dbo.Question", "QuestionCateroyId", "dbo.QuestionCategories");
            DropIndex("dbo.Semantics", new[] { "WordId" });
            DropIndex("dbo.Subjects", new[] { "SubjectGroupId" });
            DropIndex("dbo.Words", new[] { "SubjectId" });
            DropIndex("dbo.Words", new[] { "WordCategoryId" });
            DropIndex("dbo.Question", new[] { "WordId" });
            DropIndex("dbo.Question", new[] { "QuestionCateroyId" });
            DropTable("dbo.Semantics");
            DropTable("dbo.WordCategories");
            DropTable("dbo.SubjectGroups");
            DropTable("dbo.Subjects");
            DropTable("dbo.Words");
            DropTable("dbo.Question");
            DropTable("dbo.QuestionCategories");
        }
    }
}
