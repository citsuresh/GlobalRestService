using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalRestService.Models;

namespace GlobalRestService.Controllers
{
    public class GlobalAssetsController : Controller
    {
        private GlobalAssetRestServiceDBEntities db = new GlobalAssetRestServiceDBEntities();

        // GET: GlobalAssets
        public ActionResult Index()
        {
            return View(db.GlobalAssets.ToList());
        }

        // GET: GlobalAssets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalAsset globalAsset = db.GlobalAssets.Find(id);
            if (globalAsset == null)
            {
                return HttpNotFound();
            }
            return View(globalAsset);
        }

        // GET: GlobalAssets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GlobalAssets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetID,AssetType,AssetSubType,SerialNumber,ClientIdentifier,Status,LastServiceDate,NextServiceDate")] GlobalAsset globalAsset)
        {
            if (ModelState.IsValid)
            {
                db.GlobalAssets.Add(globalAsset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(globalAsset);
        }

        // GET: GlobalAssets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalAsset globalAsset = db.GlobalAssets.Find(id);
            if (globalAsset == null)
            {
                return HttpNotFound();
            }
            return View(globalAsset);
        }

        // POST: GlobalAssets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetID,AssetType,AssetSubType,SerialNumber,ClientIdentifier,Status,LastServiceDate,NextServiceDate")] GlobalAsset globalAsset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(globalAsset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(globalAsset);
        }

        // GET: GlobalAssets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalAsset globalAsset = db.GlobalAssets.Find(id);
            if (globalAsset == null)
            {
                return HttpNotFound();
            }
            return View(globalAsset);
        }

        // POST: GlobalAssets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlobalAsset globalAsset = db.GlobalAssets.Find(id);
            db.GlobalAssets.Remove(globalAsset);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
