namespace MVC_Role_Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecUserRoletablemodified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SecUserRoles", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.SecUserRoles", "ModificationDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SecUserRoles", "ModificationDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SecUserRoles", "ModifiedBy", c => c.Int(nullable: false));
        }
    }
}
