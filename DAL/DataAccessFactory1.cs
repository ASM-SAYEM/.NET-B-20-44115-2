using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Payment, int, bool> PaymentData()
        {
            return new PaymentRepo();
        }
        public static IRepo<Client, int, bool> ClientData()
        {
            return new ClientRepo();
        }
        public static IRepo<Booking, int, bool> BookingData()
        {
            return new BookingRepo();
        }
        public static IRepo<Schedule, int, bool> ScheduleData()
        {
            return new ScheduleRepo();
        }
        public static IRepo<SrviceProvider, int, bool> SrviceProviderData()
        {
            return new SrviceProviderRepo();
        }
        public static IRepo<Issue, int, bool> IssueData()
        {
            return new IssueRepo();
        }
        public static IRepo<Manager, int, bool> ManagerData()
        {
            return new ManagerRepo();
        }
        public static IRepo<Token, int, bool> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<BookingNotification, int, bool> BookingNotificationData()
        {
            return new BookingNotificationRepo();
        }
        public static IRepo<IssueNotification, int, bool> IssueNotificationData()
        {
            return new IssueNotificationRepo();
        }
        public static IRepo<PaymentNotification, int, bool> PaymentNotificationData()
        {
            return new PaymentNotificationRepo();
        }

        public static IAuth AuthData()
        {
            return new ManagerRepo();
        }

    }
}
