namespace MVC_Role_Resource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecUsertablemodifiedagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SecUsers", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.SecUsers", "ModificationDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SecUsers", "ModificationDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SecUsers", "ModifiedBy", c => c.Int(nullable: false));
        }
    }
}
