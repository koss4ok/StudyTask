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
    public class DeliveriesController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: Deliveries
        public ActionResult Index()
        {
            return View(db.Deliveries.ToList());
        }
        public ActionResult Admin_index()
        {
            return View(db.Deliveries.ToList());
        }

        // GET: Deliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveries deliveries = db.Deliveries.Find(id);
            if (deliveries == null)
            {
                return HttpNotFound();
            }
            return View(deliveries);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Num_Delivery")] Deliveries deliveries)
        {
            if (ModelState.IsValid)
            {
                db.Deliveries.Add(deliveries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveries);
        }

        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveries deliveries = db.Deliveries.Find(id);
            if (deliveries == null)
            {
                return HttpNotFound();
            }
            return View(deliveries);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Num_Delivery")] Deliveries deliveries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveries);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deliveries deliveries = db.Deliveries.Find(id);
            if (deliveries == null)
            {
                return HttpNotFound();
            }
            return View(deliveries);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deliveries deliveries = db.Deliveries.Find(id);
            db.Deliveries.Remove(deliveries);
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
