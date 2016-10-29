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
    public class LibraryStaffsController : Controller
    {
        private BookmobileEntities db = new BookmobileEntities();

        // GET: LibraryStaffs
        public ActionResult Index()
        {
            return View(db.LibraryStaffs.ToList());
        }

        // GET: LibraryStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryStaff libraryStaff = db.LibraryStaffs.Find(id);
            if (libraryStaff == null)
            {
                return HttpNotFound();
            }
            return View(libraryStaff);
        }

        // GET: LibraryStaffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryStaffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffId,LastName,FirstName,Email,Phone")] LibraryStaff libraryStaff)
        {
            if (ModelState.IsValid)
            {
                db.LibraryStaffs.Add(libraryStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libraryStaff);
        }

        // GET: LibraryStaffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryStaff libraryStaff = db.LibraryStaffs.Find(id);
            if (libraryStaff == null)
            {
                return HttpNotFound();
            }
            return View(libraryStaff);
        }

        // POST: LibraryStaffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffId,LastName,FirstName,Email,Phone")] LibraryStaff libraryStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libraryStaff);
        }

        // GET: LibraryStaffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryStaff libraryStaff = db.LibraryStaffs.Find(id);
            if (libraryStaff == null)
            {
                return HttpNotFound();
            }
            return View(libraryStaff);
        }

        // POST: LibraryStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibraryStaff libraryStaff = db.LibraryStaffs.Find(id);
            db.LibraryStaffs.Remove(libraryStaff);
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
