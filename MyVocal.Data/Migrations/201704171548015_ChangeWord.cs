namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Defination", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "Defination");
        }
    }
}
