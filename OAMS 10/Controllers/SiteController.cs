﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OAMS.Models;
using Google.GData.Photos;

namespace OAMS.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        SiteRepository repo = new SiteRepository();

        public ActionResult Index()
        {
            PicasaRepository picasaRepository = new PicasaRepository();
            picasaRepository.GetAlbumInfo();

            return View(repo.GetAll());
        }

        //
        // GET: /Site/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Site/Create

        public ActionResult Create(int? contractID)
        {
            Site e = repo.InitWithDefaultValue();
            return View(e);
        }

        //
        // POST: /Site/Create



        [HttpPost]
        //public ActionResult Create(IEnumerable<HttpPostedFileBase> files)
        public ActionResult Create(int? contractID, IEnumerable<HttpPostedFileBase> files)
        {
            var e = new Site();

            UpdateModel(e);

            repo.Add(e, files);

            return RedirectToAction("Index");
        }

        //
        // GET: /Site/Edit/5

        public ActionResult Edit(int id)
        {
            Site e = repo.Get(id);
            e.NewGeoFullName = e.GeoFullName;
            return View(e);
        }

        //
        // POST: /Site/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, IEnumerable<HttpPostedFileBase> files, List<int> DeletePhotoList)
        {
            // TODO: Add update logic here
            Site e = repo.Get(id);

            UpdateModel(e);

            repo.UpdateGeo(e);
            if (!e.FrontlitNumerOfLamps.HasValue
                || e.FrontlitNumerOfLamps <= 0)
            {
                e.FontLightArmsStraight = null;
                e.FontlitArmsPlacement = null;
                e.FontlitIlluminationDistribution = null;
                e.FrontlitSideLighting = null;
                e.FrontlitTopBottom = null;
            }
            else
            {
                e.BacklitFormat = null;
                e.BacklitIlluninationSpread = null;
                e.BacklitLightBoxLeakage = null;
                e.BacklitLightingBlocks = null;
                e.BacklitVisualLegibility = null;
            }
            repo.Save();

            //repo.AddPhoto(e, files);

            repo.DeletePhoto(DeletePhotoList);

            //return View(e);
            return RedirectToAction("Index");
        }

        //
        // GET: /Site/Delete/5

        public ActionResult Delete(int id)
        {
            repo.DeletePhoto(id);
            repo.Delete(id);
            return RedirectToAction("Index");

            //return View();
        }

        //
        // POST: /Site/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            repo.DeletePhoto(id);
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult JsonList()
        {
            OAMSEntities db = new OAMSEntities();
            var result = db.Sites.Where(r => r.Lng > 0 && r.Lat > 0)
                .Select(r => new { r.Lat, r.Lng, r.Code, Note = r.Code })
                .ToList();

            return Json(result);
        }



    }
}
