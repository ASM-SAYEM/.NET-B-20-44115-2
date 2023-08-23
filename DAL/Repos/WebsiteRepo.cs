using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class WebsiteRepo : Repo, IRepo<Website, int, Website>
    {
        public Website Add(Website obj)
        {
            db.Websites.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Websites.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Website> Get()
        {
            return db.Websites.ToList();
        }

        public Website Get(int id)
        {
            return db.Websites.Find(id);
        }

        public Website Update(Website obj)
        {
            throw new NotImplementedException();
        }
    }
}