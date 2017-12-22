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
    public class AssetCountersController : Controller
    {
        private GlobalAssetRestServiceModel db = new GlobalAssetRestServiceModel();

        // GET: AssetCounters
        public ActionResult Index()
        {
            return View(db.AssetCounters.ToList());
        }

        // GET: AssetCounters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetCounter assetCounter = db.AssetCounters.Find(id);
            if (assetCounter == null)
            {
                return HttpNotFound();
            }
            return View(assetCounter);
        }

        // GET: AssetCounters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetCounters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssetCounterID,AssetType,AssetSubType,Count")] AssetCounter assetCounter)
        {
            if (ModelState.IsValid)
            {
                db.AssetCounters.Add(assetCounter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assetCounter);
        }

        // GET: AssetCounters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetCounter assetCounter = db.AssetCounters.Find(id);
            if (assetCounter == null)
            {
                return HttpNotFound();
            }
            return View(assetCounter);
        }

        // POST: AssetCounters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssetCounterID,AssetType,AssetSubType,Count")] AssetCounter assetCounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetCounter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assetCounter);
        }

        // GET: AssetCounters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetCounter assetCounter = db.AssetCounters.Find(id);
            if (assetCounter == null)
            {
                return HttpNotFound();
            }
            return View(assetCounter);
        }

        // POST: AssetCounters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetCounter assetCounter = db.AssetCounters.Find(id);
            db.AssetCounters.Remove(assetCounter);
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
