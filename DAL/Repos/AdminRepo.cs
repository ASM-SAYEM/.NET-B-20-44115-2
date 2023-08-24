using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class AdminRepo : Repo, IRepo4<Admin, string, Admin>, IAuth , IRepo<Admin, string, Admin>
    {
        //public Admin Add(Admin obj)
        //{
        //    db.Admins.Add(obj);
        //    if (db.SaveChanges() > 0)
        //    {
        //        return obj;
        //    }
        //    return null;
        //}

        //public Admin Authenticate(string UserName, string Password)
        //{
        //    var admin = from t in db.Admins
        //               where t.UserName.Equals(UserName)
        //               && t.Password.Equals(Password)
        //               select t;
        //    if (admin != null) return admin.SingleOrDefault();
        //    return null;
        //}

        //public bool ChangePass(string UserName, string password, string newPassword)
        //{
        //    var admin = db.Admins.FirstOrDefault(a => a.UserName == UserName); 
        //    bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, admin.Password);
        //    if (isValidPassword)
        //    {
        //        admin.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        //        return db.SaveChanges() > 0;
        //    }
        //    return false;
        //}

        ////public bool ChangePass(int id, string password, string newPassword)
        ////{
        ////    var admin = db.Admins.Find(id);
        ////    bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, admin.Password);
        ////    if (isValidPassword)
        ////    {
        ////        admin.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        ////        return db.SaveChanges() > 0;
        ////    }
        ////    return false;
        ////}



        //public bool Delete(string UserName)
        //{
        //    var ex = Get(UserName);
        //    db.Admins.Remove(ex);
        //    return db.SaveChanges() > 0;
        //}

        //public Admin ForgetPass(string gmail)
        //{
        //    var admin = (from u in db.Admins
        //                 where u.Gmail.Equals(gmail)
        //                 select u).SingleOrDefault();
        //    Console.WriteLine(admin.Gmail);
        //    return admin;
        //}

        //public List<Admin> Get()
        //{
        //    return db.Admins.ToList();
        //}

        //public Admin Get(string id)
        //{
        //    return db.Admins.Find(id);
        //}

        //public Admin Get(string name, string password)
        //{

        //    var admin = (from u in db.Admins
        //                 where u.Name.Equals(name)
        //                 select u).SingleOrDefault();
        //    bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, admin.Password);
        //    if (isValidPassword) return admin;
        //    return null;
        //}

        //public bool ResetPass(int id, string password)
        //{
        //    var admin = db.Admins.Find(id);

        //    admin.Password = BCrypt.Net.BCrypt.HashPassword(password);
        //    return db.SaveChanges() > 0;
        //}

        //public Admin Update(Admin obj)
        //{
        //    var ex = Get(obj.UserName);
        //    db.Entry(ex).CurrentValues.SetValues(obj);
        //    if (db.SaveChanges() > 0)
        //    {
        //        return obj;
        //    }

        //    return null;
        //}


        ////
        ////public Admin Get(string name, string password)
        ////{

        ////    var admin = (from u in db.Admins
        ////                where u.Name.Equals(name)
        ////                select u).SingleOrDefault();
        ////    bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, admin.Password);
        ////    if (isValidPassword) return admin;
        ////    return null;
        ////}

        ////public bool ChangePass(int id, string password, string newPassword)
        ////{
        ////    var admin = db.Admins.Find(id);
        ////    bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, admin.Password);
        ////    if (isValidPassword)
        ////    {
        ////        admin.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        ////        return db.SaveChanges() > 0;
        ////    }
        ////    return false;
        ////}

        ////public bool ResetPass(int id, string password)
        ////{
        ////    var admin = db.Admins.Find(id);

        ////    admin.Password = BCrypt.Net.BCrypt.HashPassword(password);
        ////    return db.SaveChanges() > 0;
        ////}



        ////public Admin ForgetPass(string gmail)
        ////{
        ////    var admin = (from u in db.Admins
        ////                where u.Gmail.Equals(gmail)
        ////                select u).SingleOrDefault();
        ////    Console.WriteLine(admin.Gmail);
        ////    return admin;

        ////}
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

        public bool ChangePass(string UserName, string password, string newPassword)
        {
            var admin = db.Admins.FirstOrDefault(a => a.UserName == UserName);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, admin.Password);
            if (isValidPassword)
            {
                admin.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(string UserName)
        {
            var ex = Get(UserName);
            db.Admins.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Admin ForgetPass(string gmail)
        {
            var admin = (from u in db.Admins
                         where u.Gmail.Equals(gmail)
                         select u).SingleOrDefault();
            Console.WriteLine(admin.Gmail);
            return admin;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(string id)
        {
            return db.Admins.FirstOrDefault(a => a.UserName == id);
        }

        public Admin Get(string UserName, string password)
        {
            var admin = (from u in db.Admins
                         where u.Name.Equals(UserName)
                         select u).SingleOrDefault();
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, admin.Password);
            if (isValidPassword) return admin;
            return null;
        }

        public bool ResetPass(string UserName, string password)
        {
            var admin = db.Admins.FirstOrDefault(a => a.UserName == UserName);

            admin.Password = BCrypt.Net.BCrypt.HashPassword(password);
            return db.SaveChanges() > 0;
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