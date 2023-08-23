using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class DiscountRepo : Repo, IRepo<Discount, int, Discount>, IRepo2<Discount, int, Discount>
    {
        public Discount Add(Discount obj)
        {
            db.Discounts.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Discounts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Discount> Get()
        {
            return db.Discounts.ToList();
        }

        public Discount Get(int id)
        {
            return db.Discounts.Find(id);
        }

        public Discount GetPercentage(double percentage)
        {
            return db.Discounts.Where(r => r.DiscountPercentage == percentage).FirstOrDefault();
        }

        //public Discount GetPercentage(Discount discount, double percentage)
        //{
        //    return db.Discounts.Where(r => r.DiscountPercentage == percentage).FirstOrDefault();
        //}

        public Discount Update(Discount obj)
        {
            var ex = Get(Convert.ToInt32(obj.DiscountPercentage));
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }

    }
}