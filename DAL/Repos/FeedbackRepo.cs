using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class FeedbackRepo : Repo, IRepo<Feedback, int, Feedback>
    {
        public Feedback Add(Feedback obj)
        {

            db.Feedbacks.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Feedbacks.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Feedback> Get()
        {
            return db.Feedbacks.ToList();
        }

        public Feedback Get(int id)
        {
            return db.Feedbacks.Find(id);
        }

        public Feedback Update(Feedback obj)
        {
            var ex = Get(obj.Star);
            //ex =Get(obj.FeedbackDescription);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }

            return null;
        }
    }
}