namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateQuestions : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Question", newName: "Questions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Questions", newName: "Question");
        }
    }
}
