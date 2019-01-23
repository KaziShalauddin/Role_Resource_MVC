namespace MVC_Role_Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecResourceandSecResourcePermissiontablesmodified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SecResourcePermissions", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.SecResourcePermissions", "ModificationDateTime", c => c.DateTime());
            AlterColumn("dbo.SecResources", "Status", c => c.Boolean(nullable: false));
            CreateIndex("dbo.SecResourcePermissions", "SecRoleId");
            CreateIndex("dbo.SecResourcePermissions", "SecResourceId");
            AddForeignKey("dbo.SecResourcePermissions", "SecResourceId", "dbo.SecResources", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SecResourcePermissions", "SecRoleId", "dbo.SecRoles", "Id", cascadeDelete: true);
            DropColumn("dbo.SecResources", "SecResourceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SecResources", "SecResourceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SecResourcePermissions", "SecRoleId", "dbo.SecRoles");
            DropForeignKey("dbo.SecResourcePermissions", "SecResourceId", "dbo.SecResources");
            DropIndex("dbo.SecResourcePermissions", new[] { "SecResourceId" });
            DropIndex("dbo.SecResourcePermissions", new[] { "SecRoleId" });
            AlterColumn("dbo.SecResources", "Status", c => c.String());
            AlterColumn("dbo.SecResourcePermissions", "ModificationDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SecResourcePermissions", "ModifiedBy", c => c.Int(nullable: false));
        }
    }
}
