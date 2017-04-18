namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributeForWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Example", c => c.String());
            AddColumn("dbo.Words", "ExampleTranslation", c => c.String());
            AddColumn("dbo.Words", "SoundExample", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "SoundExample");
            DropColumn("dbo.Words", "ExampleTranslation");
            DropColumn("dbo.Words", "Example");
        }
    }
}
