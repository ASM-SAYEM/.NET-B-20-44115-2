using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.EF
{
    public class TerraceGardenContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ServiceProviderPayment> ServiceProviderPayments { get; set; }
        //public DbSet<ServiceProviderPayments> ServiceProviderPayments { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}