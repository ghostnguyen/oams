﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAMS_10.Models;

namespace OAMS_10.Controllers
{
    public class FindSiteController : Controller
    {
        //
        // GET: /FindSite/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find(int campaignID)
        {
            FindSite e = new FindSite();
            e.From = DateTime.Now.Date;
            e.CampaignID = campaignID;
            return View(e);
        }

        //[HttpPost]
        //public ActionResult Find(FindSite e)
        //{
        //    e.Results = SiteRepository.Repo.GetAll().ToList();

        //    return View(e);
        //}

        [HttpPost]
        public JsonResult FindJson(FindSite e)
        {
            List<Site> l = SiteRepository.Repo.GetAll().Where(r => r.Style == e.Style).ToList();

            
            return Json(l.Select(r => new { r.ID, r.Latitude, r.Longitude, r.Code, r.Material, r.Style, ContractDetailID = r.ContractDetails.LastOrDefault().ID }));
            //return Json(e.Results.Select(r => new { r.ID, r.Latitude, r.Longitude, r.Code, r.Material, r.Style, ContractDetailID = 100 }));
        }
    }
}

