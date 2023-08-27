namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GmailAddedToServiceProvider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProviders", "Gmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceProviders", "Gmail");
        }
    }
}
