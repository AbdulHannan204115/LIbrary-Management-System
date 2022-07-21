using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using System.Data.Entity;

namespace LMS.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        LMSEntities obj = new LMSEntities();
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {

                return RedirectToAction("Index", "management");
            }

            var c = obj.std.ToList();
            return View(c);
        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            var data = obj.std.Where(model => model.name.Contains(search)).ToList();
            return View(data);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(student st)
        {
            var a = obj.std.Add(st);
            if (ModelState.IsValid)
            {
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
            
        }
        public ActionResult edit(int id )
        {
            var row = obj.std.Where(model => model.student_id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult edit(student st)
        {
            obj.Entry(st).State = EntityState.Modified;
            if (ModelState.IsValid)
            {
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult delete(int id)
        {
            var row = obj.std.Where(model => model.student_id == id).FirstOrDefault();

            return View();
        }
        [HttpPost]
        public ActionResult delete(student st)
        {
            obj.Entry(st).State = EntityState.Deleted;
            if (ModelState.IsValid)
            {
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult detail(int id)
        {
            var row = obj.std.Where(model => model.student_id == id).FirstOrDefault();
            obj.SaveChanges();
            return View(row);
        }
        public ActionResult logout()
        {
            if (Session["name"] != null)
            {
                Session.Abandon();
                return RedirectToAction("log", "management");

            }

            return View();

        }
    }
    
}