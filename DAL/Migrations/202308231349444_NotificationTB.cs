namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationTB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceProviderName = c.String(nullable: false),
                        Message = c.String(nullable: false, maxLength: 255),
                        DateSent = c.DateTime(nullable: false),
                        SentByAdminUserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.SentByAdminUserName)
                .Index(t => t.SentByAdminUserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "SentByAdminUserName", "dbo.Admins");
            DropIndex("dbo.Notifications", new[] { "SentByAdminUserName" });
            DropTable("dbo.Notifications");
        }
    }
}
