using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataFirstWebApplication.Models;

namespace DataFirstWebApplication.Controllers
{
    public class CoursersController : Controller
    {
        private testEntities db = new testEntities();

        // GET: Coursers
        public ActionResult Index()
        {
            return View(db.Coursers.ToList());
        }

        // GET: Coursers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courser courser = db.Coursers.Find(id);
            if (courser == null)
            {
                return HttpNotFound();
            }
            return View(courser);
        }

        // GET: Coursers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coursers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourserId,Title,Credits")] Courser courser)
        {
            if (ModelState.IsValid)
            {
                db.Coursers.Add(courser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courser);
        }

        // GET: Coursers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courser courser = db.Coursers.Find(id);
            if (courser == null)
            {
                return HttpNotFound();
            }
            return View(courser);
        }

        // POST: Coursers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourserId,Title,Credits")] Courser courser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courser);
        }

        // GET: Coursers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courser courser = db.Coursers.Find(id);
            if (courser == null)
            {
                return HttpNotFound();
            }
            return View(courser);
        }

        // POST: Coursers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courser courser = db.Coursers.Find(id);
            db.Coursers.Remove(courser);
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
