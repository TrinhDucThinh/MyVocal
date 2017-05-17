namespace MyVocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.ApplicationUserLogin", newName: "IdentityUserLogins");
            RenameTable(name: "dbo.ApplicationUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.ApplicationRoles", newName: "IdentityRoles");
            DropPrimaryKey("dbo.IdentityUserClaims");
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.IdentityUserClaims", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.IdentityUserClaims");
            AlterColumn("dbo.IdentityUserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.IdentityUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.IdentityUserClaims", "UserId");
            RenameTable(name: "dbo.IdentityRoles", newName: "ApplicationRoles");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "ApplicationUserRoles");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "ApplicationUserLogin");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "ApplicationUserClaims");
        }
    }
}
