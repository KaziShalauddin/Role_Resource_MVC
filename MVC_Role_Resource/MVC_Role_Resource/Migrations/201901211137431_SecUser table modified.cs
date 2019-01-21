namespace MVC_Role_Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecUsertablemodified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecUsers", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.SecUsers", "RoleId");
            AddForeignKey("dbo.SecUsers", "RoleId", "dbo.SecRoles", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecUsers", "RoleId", "dbo.SecRoles");
            DropIndex("dbo.SecUsers", new[] { "RoleId" });
            DropColumn("dbo.SecUsers", "RoleId");
        }
    }
}
