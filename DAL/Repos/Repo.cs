using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class Repo
    {
        protected TerraceGardenContext db;
        internal Repo()
        {
            db = new TerraceGardenContext();
        }
    }
}