using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class OTPresetRepo : Repo, IRepo3<OTPreset, string, bool>
    {
        public bool Add(OTPreset obj)
        {
            var resetotp = db.OTPresets.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            var data = db.OTPresets.Find(id);
            db.OTPresets.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<OTPreset> Get()
        {
            var data = db.OTPresets.ToList();
            return data;
        }

        public OTPreset Get(string id)
        {
            var ret = (from u in db.OTPresets
                       where u.OTP.Equals(id)
                       select u).SingleOrDefault();
            return ret;
        }

        public OTPreset SetOTP(string UserName, string otp)
        {
            var ret = (from u in db.OTPresets
                       where u.OTP.Equals(otp) && u.UserName == UserName
                       select u).SingleOrDefault();
            return ret;
        }

        public OTPreset SetOTP(int id, string otp)
        {
            throw new NotImplementedException();
        }

        public bool Update(OTPreset obj)
        {
            var data = db.OTPresets.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}