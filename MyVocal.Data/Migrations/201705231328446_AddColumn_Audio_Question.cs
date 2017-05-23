namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn_Audio_Question : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Audio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Audio");
        }
    }
}
