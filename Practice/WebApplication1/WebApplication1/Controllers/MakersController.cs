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
    public class MakersController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: Makers
        public ActionResult Index()
        {
            return View(db.Makers.ToList());
        }

        public ActionResult Admin_Index()
        {
            return View(db.Makers.ToList());
        }

        // GET: Makers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makers makers = db.Makers.Find(id);
            if (makers == null)
            {
                return HttpNotFound();
            }
            return View(makers);
        }

        // GET: Makers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Makers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Makers makers)
        {
            if (ModelState.IsValid)
            {
                db.Makers.Add(makers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(makers);
        }

        // GET: Makers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makers makers = db.Makers.Find(id);
            if (makers == null)
            {
                return HttpNotFound();
            }
            return View(makers);
        }

        // POST: Makers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Makers makers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(makers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(makers);
        }

        // GET: Makers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makers makers = db.Makers.Find(id);
            if (makers == null)
            {
                return HttpNotFound();
            }
            return View(makers);
        }

        // POST: Makers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Makers makers = db.Makers.Find(id);
            db.Makers.Remove(makers);
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
