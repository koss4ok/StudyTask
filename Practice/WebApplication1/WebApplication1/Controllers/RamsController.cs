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
    public class RamsController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: Rams
        public ActionResult Index()
        {
            var rams = db.Rams.Include(r => r.Deliveries).Include(r => r.Makers).Include(r => r.Orders);
            return View(rams.ToList());
        }

        public ActionResult Admin_index()
        {
            var rams = db.Rams.Include(r => r.Deliveries).Include(r => r.Makers).Include(r => r.Orders);
            return View(rams.ToList());
        }

        // GET: Rams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rams rams = db.Rams.Find(id);
            if (rams == null)
            {
                return HttpNotFound();
            }
            return View(rams);
        }

        // GET: Rams/Create
        public ActionResult Create()
        {
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date");
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name");
            ViewBag.Order = new SelectList(db.Orders, "Id", "date");
            return View();
        }

        // POST: Rams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Rams rams)
        {
            if (ModelState.IsValid)
            {
                db.Rams.Add(rams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", rams.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", rams.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", rams.Order);
            return View(rams);
        }

        // GET: Rams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rams rams = db.Rams.Find(id);
            if (rams == null)
            {
                return HttpNotFound();
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", rams.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", rams.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", rams.Order);
            return View(rams);
        }

        // POST: Rams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Rams rams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", rams.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", rams.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", rams.Order);
            return View(rams);
        }

        // GET: Rams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rams rams = db.Rams.Find(id);
            if (rams == null)
            {
                return HttpNotFound();
            }
            return View(rams);
        }

        // POST: Rams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rams rams = db.Rams.Find(id);
            db.Rams.Remove(rams);
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
