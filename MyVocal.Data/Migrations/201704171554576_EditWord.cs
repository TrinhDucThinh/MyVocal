namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Synonym", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "Synonym");
        }
    }
}
