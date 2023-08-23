namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.TerraceGardenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.TerraceGardenContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Random random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    var discount = new EF.Models.Discount
            //    {
            //        DiscountId = i,
            //        ClientUserName = "Client_" + i,
            //        //DiscountPercentage = i+10,
            //    };

            //    // Set the DiscountPercentage based on the client's type
            //    //var clientType = GetType(); // get the client's type based on your business logic
            //    //discount.GetPercentage(clientType, i);

            //    //context.Discounts.AddOrUpdate(discount);

            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    context.ServiceProviders.AddOrUpdate(new EF.Models.ServiceProvider
            //    {
            //        Id=i,
            //        Name="Provider_"+i,
            //        shortDescriprtion= Guid.NewGuid().ToString(),
            //        Date=DateTime.Now,
            //        AssignedBy="Admin_"+i,
            //        FeedbackBy="Client_"+i
            //        //ServiceProviderId = random.Next(1, 11),



            //    }
            //   ); ;
            //}


        }
    }
    
}