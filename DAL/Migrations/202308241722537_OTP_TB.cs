namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OTP_TB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OTPresets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OTP = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        DeleteTime = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.UserName, cascadeDelete: true)
                .Index(t => t.UserName);
            
            AddColumn("dbo.Admins", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Gmail", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Clients", "Gmail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OTPresets", "UserName", "dbo.Admins");
            DropIndex("dbo.OTPresets", new[] { "UserName" });
            DropColumn("dbo.Clients", "Gmail");
            DropColumn("dbo.Clients", "Phone");
            DropColumn("dbo.Admins", "Gmail");
            DropColumn("dbo.Admins", "Phone");
            DropTable("dbo.OTPresets");
        }
    }
}
