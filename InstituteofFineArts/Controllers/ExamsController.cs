using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteofFineArts.Models;

namespace InstituteofFineArts.Controllers
{
    public class ExamsController : Controller
    {
        private sem3Entities db = new sem3Entities();

        // GET: Exams
        public async Task<ActionResult> Index()
        {
            var exams = db.Exams.Include(e => e.Manager).Include(e => e.Student).Include(e => e.Topic);
            return View(await exams.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "name");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "name");
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "title");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudentId,ManagerId,TopicId,Point")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "name", exam.ManagerId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "name", exam.StudentId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "title", exam.TopicId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "name", exam.ManagerId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "name", exam.StudentId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "title", exam.TopicId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudentId,ManagerId,TopicId,Point")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.Managers, "Id", "name", exam.ManagerId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "name", exam.StudentId);
            ViewBag.TopicId = new SelectList(db.Topics, "Id", "title", exam.TopicId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Exam exam = await db.Exams.FindAsync(id);
            db.Exams.Remove(exam);
            await db.SaveChangesAsync();
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
