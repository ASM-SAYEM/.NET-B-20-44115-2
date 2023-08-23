using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class ServiceProviderRepo : Repo, IRepo<ServiceProvider, int, ServiceProvider>
    {
        public ServiceProvider Add(ServiceProvider obj)
        {
            db.ServiceProviders.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.ServiceProviders.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<ServiceProvider> Get()
        {
            return db.ServiceProviders.ToList();
        }

        public ServiceProvider Get(int id)
        {
            return db.ServiceProviders.Find(id);
        }

        public ServiceProvider Update(ServiceProvider obj)
        {
            var ex = Get(obj.Id);
            //var ex =Get(obj.FeedbackDescription);
            ex.shortDescriprtion = obj.shortDescriprtion;
            //ex.Star=
            // db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
            //throw new NotImplementedException();
        }
    }
}