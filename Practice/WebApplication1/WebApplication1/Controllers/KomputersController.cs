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
    public class KomputersController : Controller
    {
        private databaseEntities db = new databaseEntities();

        // GET: Komputers
        public ActionResult Index(string sortOrder, string searchString)
        {
            
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.DeliveriesSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                var komputers = from s in db.Komputers
                                select s;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    komputers = komputers.Where(s => s.Name.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        komputers = komputers.OrderByDescending(s => s.Name);
                        break;
                    case "Date":
                        komputers = komputers.OrderBy(s => s.Delivery);
                        break;
                    case "date_desc":
                        komputers = komputers.OrderByDescending(s => s.Delivery);
                        break;
                    default:
                        komputers = komputers.OrderBy(s => s.Name);
                        break;
                }
            }
            catch (Exception) { }
            return View(komputers.ToList());
        }

        public ActionResult Admin_index(string sortOrder, string searchString)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DeliveriesSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var komputers = from s in db.Komputers
                            select s;
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    komputers = komputers.Where(s => s.Name.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        komputers = komputers.OrderByDescending(s => s.Name);
                        break;
                    case "Date":
                        komputers = komputers.OrderBy(s => s.Deliveries);
                        break;
                    case "date_desc":
                        komputers = komputers.OrderByDescending(s => s.Deliveries);
                        break;
                    default:
                        komputers = komputers.OrderBy(s => s.Name);
                        break;
                }
            }
            catch (Exception) { }
            return View(komputers.ToList());
        }


        // GET: Komputers/Create
        public ActionResult Create()
        {
            ViewBag.Delivery = new SelectList(db.Deliveries, "id", "date");
            ViewBag.Hard_drive = new SelectList(db.Hard_disks, "Id", "Name");
            ViewBag.Motherboard = new SelectList(db.Motherboards, "Id", "Name");
            ViewBag.Order = new SelectList(db.Orders, "id", "date");
            ViewBag.Processor = new SelectList(db.Processors, "Id", "Name");
            ViewBag.Ram = new SelectList(db.Rams, "Id", "Name");
            return View();
        }

        // POST: Komputers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Processor,Motherboard,Ram,Hard_drive,Delivery,Order,image")] Komputers komputers, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        komputers.image= reader.ReadBytes(upload.ContentLength);
                    }
                }

                db.Komputers.Add(komputers);
                db.SaveChanges();
                return RedirectToAction("admin_index");
            }

            ViewBag.Delivery = new SelectList(db.Deliveries, "id", "date", komputers.Delivery);
            ViewBag.Hard_drive = new SelectList(db.Hard_disks, "Id", "Name", komputers.Hard_drive);
            ViewBag.Motherboard = new SelectList(db.Motherboards, "Id", "Name", komputers.Motherboard);
            ViewBag.Order = new SelectList(db.Orders, "id", "date", komputers.Order);
            ViewBag.Processor = new SelectList(db.Processors, "Id", "Name", komputers.Processor);
            ViewBag.Ram = new SelectList(db.Rams, "Id", "Name", komputers.Ram);
            return View(komputers);
        }

        // GET: Komputers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komputers komputers = db.Komputers.Find(id);
            if (komputers == null)
            {
                return HttpNotFound();
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "id", "date", komputers.Delivery);
            ViewBag.Hard_drive = new SelectList(db.Hard_disks, "Id", "Name", komputers.Hard_drive);
            ViewBag.Motherboard = new SelectList(db.Motherboards, "Id", "Name", komputers.Motherboard);
            ViewBag.Order = new SelectList(db.Orders, "id", "date", komputers.Order);
            ViewBag.Processor = new SelectList(db.Processors, "Id", "Name", komputers.Processor);
            ViewBag.Ram = new SelectList(db.Rams, "Id", "Name", komputers.Ram);
            return View(komputers);
        }

        // POST: Komputers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Processor,Motherboard,Ram,Hard_drive,Delivery,Order,image")] Komputers komputers, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komputers).State = EntityState.Modified;
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        komputers.image= reader.ReadBytes(upload.ContentLength);
                    }
                    db.SaveChanges();
                }

                else
                {
                    db.Entry(komputers).Property(m => m.image).IsModified = false;
                    db.SaveChanges();
                }

                db.SaveChanges();
                return RedirectToAction("admin_index");
            }
            ViewBag.Delivery = new SelectList(db.Deliveries, "id", "date", komputers.Delivery);
            ViewBag.Hard_drive = new SelectList(db.Hard_disks, "Id", "Name", komputers.Hard_drive);
            ViewBag.Motherboard = new SelectList(db.Motherboards, "Id", "Name", komputers.Motherboard);
            ViewBag.Order = new SelectList(db.Orders, "id", "date", komputers.Order);
            ViewBag.Processor = new SelectList(db.Processors, "Id", "Name", komputers.Processor);
            ViewBag.Ram = new SelectList(db.Rams, "Id", "Name", komputers.Ram);
            return View(komputers);
        }

        // GET: Komputers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komputers komputers = db.Komputers.Find(id);
            if (komputers == null)
            {
                return HttpNotFound();
            }
            return View(komputers);
        }

        // POST: Komputers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Komputers komputers = db.Komputers.Find(id);
            db.Komputers.Remove(komputers);
            db.SaveChanges();
            return RedirectToAction("admin_index");
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
