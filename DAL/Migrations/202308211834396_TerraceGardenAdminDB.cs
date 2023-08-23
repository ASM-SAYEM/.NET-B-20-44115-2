namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TerraceGardenAdminDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 20),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false, identity: true),
                        ClientUserName = c.String(nullable: false, maxLength: 128),
                        DiscountPercentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountId)
                .ForeignKey("dbo.Clients", t => t.ClientUserName, cascadeDelete: true)
                .Index(t => t.ClientUserName);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeedbackDescription = c.String(nullable: false, maxLength: 50),
                        Star = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FeedbackBy = c.String(maxLength: 128),
                        ServiceProviderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.FeedbackBy)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProviderId, cascadeDelete: true)
                .Index(t => t.FeedbackBy)
                .Index(t => t.ServiceProviderId);
            
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        shortDescriprtion = c.String(nullable: false, maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        AssignedBy = c.String(maxLength: 128),
                        FeedbackBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AssignedBy)
                .ForeignKey("dbo.Clients", t => t.FeedbackBy)
                .Index(t => t.AssignedBy)
                .Index(t => t.FeedbackBy);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        offerId = c.Int(nullable: false, identity: true),
                        offerName = c.String(nullable: false, maxLength: 100),
                        offerType = c.String(nullable: false, maxLength: 100),
                        offerDescription = c.String(nullable: false, maxLength: 100),
                        offerStarts = c.DateTime(nullable: false),
                        offerEnd = c.DateTime(nullable: false),
                        Assignby = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.offerId)
                .ForeignKey("dbo.Admins", t => t.Assignby)
                .Index(t => t.Assignby);
            
            CreateTable(
                "dbo.ServiceProviderPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceProviderId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceProviders", t => t.ServiceProviderId, cascadeDelete: true)
                .Index(t => t.ServiceProviderId);
            
            CreateTable(
                "dbo.Websites",
                c => new
                    {
                        WebFeedbackId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        FeedbackBy = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WebFeedbackId)
                .ForeignKey("dbo.Clients", t => t.FeedbackBy)
                .Index(t => t.FeedbackBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Websites", "FeedbackBy", "dbo.Clients");
            DropForeignKey("dbo.ServiceProviderPayments", "ServiceProviderId", "dbo.ServiceProviders");
            DropForeignKey("dbo.Offers", "Assignby", "dbo.Admins");
            DropForeignKey("dbo.Feedbacks", "ServiceProviderId", "dbo.ServiceProviders");
            DropForeignKey("dbo.ServiceProviders", "FeedbackBy", "dbo.Clients");
            DropForeignKey("dbo.ServiceProviders", "AssignedBy", "dbo.Admins");
            DropForeignKey("dbo.Feedbacks", "FeedbackBy", "dbo.Clients");
            DropForeignKey("dbo.Discounts", "ClientUserName", "dbo.Clients");
            DropIndex("dbo.Websites", new[] { "FeedbackBy" });
            DropIndex("dbo.ServiceProviderPayments", new[] { "ServiceProviderId" });
            DropIndex("dbo.Offers", new[] { "Assignby" });
            DropIndex("dbo.ServiceProviders", new[] { "FeedbackBy" });
            DropIndex("dbo.ServiceProviders", new[] { "AssignedBy" });
            DropIndex("dbo.Feedbacks", new[] { "ServiceProviderId" });
            DropIndex("dbo.Feedbacks", new[] { "FeedbackBy" });
            DropIndex("dbo.Discounts", new[] { "ClientUserName" });
            DropTable("dbo.Websites");
            DropTable("dbo.ServiceProviderPayments");
            DropTable("dbo.Offers");
            DropTable("dbo.ServiceProviders");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Discounts");
            DropTable("dbo.Clients");
            DropTable("dbo.Admins");
        }
    }
}
