﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAMS.Models
{
    public class SiteRepository : BaseRepository<SiteRepository>
    {
        private OAMSEntities db = new OAMSEntities();

        public IQueryable<Site> GetAll()
        {
            return db.Sites;
        }

        public Site Get(int id)
        {
            return db.Sites.Where(r => r.ID == id).SingleOrDefault();

        }

        public Site Add(Site e, int? contractID)
        {
            db.Sites.AddObject(e);

            if (contractID != null && contractID == 0)
            {
                new ContractDetail() { Site = e, ContractID = contractID };
            }

            return e;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}