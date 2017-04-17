namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "WordName", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "WordName");
        }
    }
}
