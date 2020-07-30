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
    public class MotherboardsController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: Motherboards
        public ActionResult Index()
        {
            var motherboards = db.Motherboards.Include(m => m.Deliveries).Include(m => m.Makers).Include(m => m.Orders);
            return View(motherboards.ToList());
        }

        public ActionResult Admin_index()
        {
            var motherboards = db.Motherboards.Include(m => m.Deliveries).Include(m => m.Makers).Include(m => m.Orders);
            return View(motherboards.ToList());
        }

        // GET: Motherboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboards motherboards = db.Motherboards.Find(id);
            if (motherboards == null)
            {
                return HttpNotFound();
            }
            return View(motherboards);
        }

        // GET: Motherboards/Create
        public ActionResult Create()
        {
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date");
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name");
            ViewBag.Order = new SelectList(db.Orders, "Id", "date");
            return View();
        }

        // POST: Motherboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Motherboards motherboards)
        {
            if (ModelState.IsValid)
            {
                db.Motherboards.Add(motherboards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", motherboards.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", motherboards.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", motherboards.Order);
            return View(motherboards);
        }

        // GET: Motherboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboards motherboards = db.Motherboards.Find(id);
            if (motherboards == null)
            {
                return HttpNotFound();
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", motherboards.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", motherboards.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", motherboards.Order);
            return View(motherboards);
        }

        // POST: Motherboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Motherboards motherboards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motherboards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", motherboards.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", motherboards.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", motherboards.Order);
            return View(motherboards);
        }

        // GET: Motherboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboards motherboards = db.Motherboards.Find(id);
            if (motherboards == null)
            {
                return HttpNotFound();
            }
            return View(motherboards);
        }

        // POST: Motherboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motherboards motherboards = db.Motherboards.Find(id);
            db.Motherboards.Remove(motherboards);
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
