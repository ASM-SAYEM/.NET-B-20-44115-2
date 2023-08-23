using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class OfferRepo : Repo, IRepo<Offer, int, Offer>
    {
        public Offer Add(Offer obj)
        {
            db.Offers.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Offers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Offer> Get()
        {
            return db.Offers.ToList();
        }

        public Offer Get(int id)
        {
            return db.Offers.Find(id);
        }

        public Offer Update(Offer obj)
        {
            //var ex = Get(obj.offerName);
            ////var ex =Get(obj.FeedbackDescription);
            //db.Entry(ex).CurrentValues.SetValues(obj);
            //if (db.SaveChanges() > 0)
            //{
            //    return obj;
            //}

            return null;
        }
    }
}