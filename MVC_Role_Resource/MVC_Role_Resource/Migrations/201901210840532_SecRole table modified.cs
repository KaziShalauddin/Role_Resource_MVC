namespace MVC_Role_Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecRoletablemodified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SecRoles", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.SecRoles", "ModificationDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SecRoles", "ModificationDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SecRoles", "ModifiedBy", c => c.Int(nullable: false));
        }
    }
}
