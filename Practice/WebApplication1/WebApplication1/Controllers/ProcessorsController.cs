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
    public class ProcessorsController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: Processors
        public ActionResult Index()
        {
            var processors = db.Processors.Include(p => p.Deliveries).Include(p => p.Makers).Include(p => p.Orders);
            return View(processors.ToList());
        }
        public ActionResult Admin_index()
        {
            var processors = db.Processors.Include(p => p.Deliveries).Include(p => p.Makers).Include(p => p.Orders);
            return View(processors.ToList());
        }


        // GET: Processors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processors processors = db.Processors.Find(id);
            if (processors == null)
            {
                return HttpNotFound();
            }
            return View(processors);
        }

        // GET: Processors/Create
        public ActionResult Create()
        {
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date");
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name");
            ViewBag.Order = new SelectList(db.Orders, "Id", "date");
            return View();
        }

        // POST: Processors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Processors processors)
        {
            if (ModelState.IsValid)
            {
                db.Processors.Add(processors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", processors.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", processors.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", processors.Order);
            return View(processors);
        }

        // GET: Processors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processors processors = db.Processors.Find(id);
            if (processors == null)
            {
                return HttpNotFound();
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", processors.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", processors.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", processors.Order);
            return View(processors);
        }

        // POST: Processors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Delivery,Order,Maker")] Processors processors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "Id", "date", processors.Delivery);
            ViewBag.Maker = new SelectList(db.Makers, "Id", "Name", processors.Maker);
            ViewBag.Order = new SelectList(db.Orders, "Id", "date", processors.Order);
            return View(processors);
        }

        // GET: Processors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processors processors = db.Processors.Find(id);
            if (processors == null)
            {
                return HttpNotFound();
            }
            return View(processors);
        }

        // POST: Processors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Processors processors = db.Processors.Find(id);
            db.Processors.Remove(processors);
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
