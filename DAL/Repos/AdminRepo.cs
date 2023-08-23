using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class AdminRepo : Repo, IRepo<Admin, string, Admin>, IAuth
    {
        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public Admin Authenticate(string UserName, string Password)
        {
            var admin = from t in db.Admins
                       where t.UserName.Equals(UserName)
                       && t.Password.Equals(Password)
                       select t;
            if (admin != null) return admin.SingleOrDefault();
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Get(id);
            db.Admins.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(string id)
        {
            return db.Admins.Find(id);
        }

        public Admin Update(Admin obj)
        {
            var ex = Get(obj.UserName);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        } 
    }
}