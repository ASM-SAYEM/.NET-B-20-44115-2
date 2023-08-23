using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    //public class NotificationRepo : Repo, IRepo<Notification, int, Notification>
    //{
    //    public Notification Add(Notification obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Notification> Get()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Notification Get(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Notification Update(Notification obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Notification SendNotification(string UserName, int serviceProviderId, string title, string content)
    //    {
    //        throw new NotImplementedException();
    //    }

    public class NotificationRepo : Repo, IRepo<Notification, int, Notification>
    {

        // Implement other methods for updating, deleting, and retrieving notifications
        public Notification Add(Notification obj)
        {
            db.Notifications.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Notifications.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Notification> Get()
        {
            return db.Notifications.ToList();
        }

        public Notification Get(int id)
        {
            return db.Notifications.Find(id);
        }

        public Notification Update(Notification obj)
        {
            throw new NotImplementedException();
        }
    }
}
