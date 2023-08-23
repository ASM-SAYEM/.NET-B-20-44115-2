using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class ServiceProviderPaymentRepo : Repo, IRepo<ServiceProviderPayment, int, ServiceProviderPayment>
    {
        public ServiceProviderPayment Add(ServiceProviderPayment obj)
        {
            db.ServiceProviderPayments.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.ServiceProviderPayments.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ServiceProviderPayment> Get()
        {
            return db.ServiceProviderPayments.ToList();
        }

        public ServiceProviderPayment Get(int id)
        {
            return db.ServiceProviderPayments.Find(id);
        }

        public ServiceProviderPayment Update(ServiceProviderPayment obj)
        {
            var ex = Get(obj.Amount);
            //var ex =Get(obj.FeedbackDescription);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }
    }
}