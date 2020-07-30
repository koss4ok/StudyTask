using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Hard_disksController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: Hard_disks
        public ActionResult Index()
        {
            var hard_disks = db.Hard_disks.Include(h => h.Deliveries).Include(h => h.Makers).Include(h => h.Orders);
            return View(hard_disks.ToList());
        }
        public ActionResult Admin_index()
        {
            var hard_disks = db.Hard_disks.Include(h => h.Deliveries).Include(h => h.Makers).Include(h => h.Orders);
            return View(hard_disks.ToList());
        }

        // GET: Hard_disks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hard_disks hard_disks = db.Hard_disks.Find(id);
            if (hard_disks == null)
            {
                return HttpNotFound();
            }
            return View(hard_disks);
        }

        // GET: Hard_disks/Create
        public ActionResult Create()
        {
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date");
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name");
            ViewBag.Order = new SelectList(db.Orders, "Id", "date");
            return View();
        }

        // POST: Hard_disks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Hard_disks hard_disks)
        {
            if (ModelState.IsValid)
            {
                db.Hard_disks.Add(hard_disks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", hard_disks.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", hard_disks.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", hard_disks.Order);
            return View(hard_disks);
        }

        // GET: Hard_disks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hard_disks hard_disks = db.Hard_disks.Find(id);
            if (hard_disks == null)
            {
                return HttpNotFound();
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", hard_disks.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", hard_disks.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", hard_disks.Order);
            return View(hard_disks);
        }

        // POST: Hard_disks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Hard_disks hard_disks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hard_disks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", hard_disks.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", hard_disks.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", hard_disks.Order);
            return View(hard_disks);
        }

        // GET: Hard_disks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hard_disks hard_disks = db.Hard_disks.Find(id);
            if (hard_disks == null)
            {
                return HttpNotFound();
            }
            return View(hard_disks);
        }

        // POST: Hard_disks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hard_disks hard_disks = db.Hard_disks.Find(id);
            db.Hard_disks.Remove(hard_disks);
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
