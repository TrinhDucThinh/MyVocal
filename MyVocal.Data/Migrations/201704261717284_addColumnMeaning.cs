namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnMeaning : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Meaning", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "Meaning");
        }
    }
}
