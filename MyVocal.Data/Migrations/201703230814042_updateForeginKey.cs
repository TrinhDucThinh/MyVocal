namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateForeginKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Questions", name: "QuestionCateroyId", newName: "QuestionCategoryId");
            RenameIndex(table: "dbo.Questions", name: "IX_QuestionCateroyId", newName: "IX_QuestionCategoryId");
            AddColumn("dbo.QuestionCategories", "QuestionCategoryName", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.QuestionCategories", "QuesionCategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionCategories", "QuesionCategoryName", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.QuestionCategories", "QuestionCategoryName");
            RenameIndex(table: "dbo.Questions", name: "IX_QuestionCategoryId", newName: "IX_QuestionCateroyId");
            RenameColumn(table: "dbo.Questions", name: "QuestionCategoryId", newName: "QuestionCateroyId");
        }
    }
}
