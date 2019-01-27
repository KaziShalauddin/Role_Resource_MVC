namespace MVC_Role_Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecResourcePermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecRoleId = c.Int(nullable: false),
                        SecResourceId = c.Int(nullable: false),
                        FileName = c.String(),
                        MenuName = c.String(),
                        DisplayName = c.String(),
                        ModuleId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        ActionUrl = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecResources", t => t.SecResourceId, cascadeDelete: true)
                .ForeignKey("dbo.SecRoles", t => t.SecRoleId, cascadeDelete: true)
                .Index(t => t.SecRoleId)
                .Index(t => t.SecResourceId);
            
            CreateTable(
                "dbo.SecResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        MenuName = c.String(),
                        DisplayName = c.String(),
                        ModuleId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        ActionUrl = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(),
                        ModificationDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecRolePermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecResourcePermissionId = c.Int(nullable: false),
                        Add = c.Boolean(nullable: false),
                        Edit = c.Boolean(nullable: false),
                        Delete = c.Boolean(nullable: false),
                        Read = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecResourcePermissions", t => t.SecResourcePermissionId, cascadeDelete: true)
                .Index(t => t.SecResourcePermissionId);
            
            CreateTable(
                "dbo.SecUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecUserId = c.Int(nullable: false),
                        SecRoleId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(),
                        ModificationDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecRoles", t => t.SecRoleId, cascadeDelete: true)
                .ForeignKey("dbo.SecUsers", t => t.SecUserId, cascadeDelete: true)
                .Index(t => t.SecUserId)
                .Index(t => t.SecRoleId);
            
            CreateTable(
                "dbo.SecUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogInName = c.String(),
                        Password = c.String(),
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(),
                        ModificationDateTime = c.DateTime(),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SecRoles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentRollNo = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecUserRoles", "SecUserId", "dbo.SecUsers");
            DropForeignKey("dbo.SecUsers", "RoleId", "dbo.SecRoles");
            DropForeignKey("dbo.SecUserRoles", "SecRoleId", "dbo.SecRoles");
            DropForeignKey("dbo.SecRolePermissions", "SecResourcePermissionId", "dbo.SecResourcePermissions");
            DropForeignKey("dbo.SecResourcePermissions", "SecRoleId", "dbo.SecRoles");
            DropForeignKey("dbo.SecResourcePermissions", "SecResourceId", "dbo.SecResources");
            DropIndex("dbo.SecUsers", new[] { "RoleId" });
            DropIndex("dbo.SecUserRoles", new[] { "SecRoleId" });
            DropIndex("dbo.SecUserRoles", new[] { "SecUserId" });
            DropIndex("dbo.SecRolePermissions", new[] { "SecResourcePermissionId" });
            DropIndex("dbo.SecResourcePermissions", new[] { "SecResourceId" });
            DropIndex("dbo.SecResourcePermissions", new[] { "SecRoleId" });
            DropTable("dbo.Students");
            DropTable("dbo.SecUsers");
            DropTable("dbo.SecUserRoles");
            DropTable("dbo.SecRolePermissions");
            DropTable("dbo.SecRoles");
            DropTable("dbo.SecResources");
            DropTable("dbo.SecResourcePermissions");
        }
    }
}
