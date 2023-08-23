using DAL.EF.Models;
using DAL.Interface;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Client, string, Client> ClientData()
        {
            return new ClientRepo();
        }

        public static IRepo<Admin, string, Admin> AdminData()
        {
            return new AdminRepo();
        }

        public static IRepo<ServiceProvider, int, ServiceProvider> ServiceProviderData()
        {
            return new ServiceProviderRepo();
        }

        public static IRepo<Feedback, int, Feedback> FeedbackData()
        {
            return new FeedbackRepo();
        }

        public static IRepo<Website, int, Website> WebsiteData()
        {
            return new WebsiteRepo();
        }

        public static IRepo<ServiceProviderPayment, int, ServiceProviderPayment> ServiceProviderPaymentData()
        {
            return new ServiceProviderPaymentRepo();
        }

        public static IRepo<Offer, int, Offer> OfferData()
        {
            return new OfferRepo();
        }

        public static IRepo2<Discount, int, Discount> DiscountData()
        {
            return new DiscountRepo();
        }

        public static IRepo<Notification, int, Notification> NotificationData()
        {
            return new NotificationRepo();
        }

        public static IRepo<Token, int, Token> TokensData()
        {
            return new TokenRepo();
        }

        public static IAuth AuthData()
        {
            return new AdminRepo();
        }

    }
}