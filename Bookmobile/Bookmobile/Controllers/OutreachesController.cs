using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bookmobile.Models;

namespace Bookmobile.Controllers
{
    public class OutreachesController : Controller
    {
        private BookmobileEntities db = new BookmobileEntities();

        // GET: Outreaches
        public ActionResult Index()
        {
            var outreaches = db.Outreaches.Include(o => o.LibraryStaff).Include(o => o.School);
            return View(outreaches.ToList());
        }

        // GET: Outreaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outreach outreach = db.Outreaches.Find(id);
            if (outreach == null)
            {
                return HttpNotFound();
            }
            return View(outreach);
        }

        // GET: Outreaches/Create
        public ActionResult Create()
        {
            ViewBag.StaffIdPrimary = new SelectList(db.LibraryStaffs, "StaffId", "LastName");
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName");
            return View();
        }

        // POST: Outreaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutreachId,Date,SchoolId,StartTime,EndTime,StaffIdPrimary,StaffIdSecondary,Notes")] Outreach outreach)
        {
            if (ModelState.IsValid)
            {
                db.Outreaches.Add(outreach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffIdPrimary = new SelectList(db.LibraryStaffs, "StaffId", "LastName", outreach.StaffIdPrimary);
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName", outreach.SchoolId);
            return View(outreach);
        }

        // GET: Outreaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outreach outreach = db.Outreaches.Find(id);
            if (outreach == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffIdPrimary = new SelectList(db.LibraryStaffs, "StaffId", "LastName", outreach.StaffIdPrimary);
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName", outreach.SchoolId);
            return View(outreach);
        }

        // POST: Outreaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutreachId,Date,SchoolId,StartTime,EndTime,StaffIdPrimary,StaffIdSecondary,Notes")] Outreach outreach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outreach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffIdPrimary = new SelectList(db.LibraryStaffs, "StaffId", "LastName", outreach.StaffIdPrimary);
            ViewBag.SchoolId = new SelectList(db.Schools, "SchoolId", "SchoolName", outreach.SchoolId);
            return View(outreach);
        }

        // GET: Outreaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outreach outreach = db.Outreaches.Find(id);
            if (outreach == null)
            {
                return HttpNotFound();
            }
            return View(outreach);
        }

        // POST: Outreaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outreach outreach = db.Outreaches.Find(id);
            db.Outreaches.Remove(outreach);
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
