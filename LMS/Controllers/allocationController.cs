using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Controllers
{
    public class allocationController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: allocation
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {

                return RedirectToAction("Index", "management");
            }
            /*var ab = DateTime.Now.ToString("dd / MM / yyyy");
             var bb =DateTime.Now.ToString("07/00/0000");
           // var bb = 7;
            var sum = ab + bb;
            ViewBag.ab = ab;
            ViewBag.sum = sum;*/
            var allocations = db.allo.Include(a => a.book).Include(a => a.management).Include(a => a.student);
            return View(allocations.ToList());
        }


        // GET: allocation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            allocation allocation = db.allo.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        // GET: allocation/Create
        public ActionResult Create()
        {
            
            
            ViewBag.book_id = new SelectList(db.boo, "book_id", "book_name");
            ViewBag.management_id = new SelectList(db.mana, "management_id", "name");
            ViewBag.student_id = new SelectList(db.std, "student_id", "name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "allocation_id,management_id,student_id,book_id,allocation_date")] allocation allocation)
        {
            if (ModelState.IsValid)
            {
                db.allo.Add(allocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.book_id = new SelectList(db.boo, "book_id", "book_name", allocation.book_id);
            ViewBag.management_id = new SelectList(db.mana, "management_id", "name", allocation.management_id);
            ViewBag.student_id = new SelectList(db.std, "student_id", "name", allocation.student_id);
            return View(allocation);
        }

        // GET: allocation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            allocation allocation = db.allo.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.book_id = new SelectList(db.boo, "book_id", "book_name", allocation.book_id);
            ViewBag.management_id = new SelectList(db.mana, "management_id", "name", allocation.management_id);
            ViewBag.student_id = new SelectList(db.std, "student_id", "name", allocation.student_id);
            return View(allocation);
        }

        // POST: allocation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "allocation_id,management_id,student_id,book_id,allocation_date")] allocation allocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.book_id = new SelectList(db.boo, "book_id", "book_name", allocation.book_id);
            ViewBag.management_id = new SelectList(db.mana, "management_id", "name", allocation.management_id);
            ViewBag.student_id = new SelectList(db.std, "student_id", "name", allocation.student_id);
            return View(allocation);
        }

        // GET: allocation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            allocation allocation = db.allo.Find(id);
            if (allocation == null)
            {
                return HttpNotFound();
            }
            return View(allocation);
        }

        // POST: allocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            allocation allocation = db.allo.Find(id);
            db.allo.Remove(allocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult logout()
        {
            if (Session["name"] != null)
            {
                Session.Abandon();
                return RedirectToAction("log","management");

            }

            return View();

        }
        public ActionResult daate()
        {
            var a = DateTime.Now.ToString("M");
            
            return View();
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
