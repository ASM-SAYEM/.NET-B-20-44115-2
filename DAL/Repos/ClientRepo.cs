using DAL.EF.Models;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class ClientRepo : Repo, IRepo<Client, string, Client>
    {
        public Client Add(Client obj)
        {
            db.Clients.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Client> Get()
        {
            return db.Clients.ToList();
        }

        public Client Get(string id)
        {
            throw new NotImplementedException();
        }

        public Client Update(Client obj)
        {
            throw new NotImplementedException();
        }
    }
}