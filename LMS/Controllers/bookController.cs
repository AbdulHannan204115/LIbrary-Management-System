using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using System.Data.Entity;

namespace LMS.Controllers
{

    public class bookController : Controller
    {
        // GET: book
        LMSEntities obj = new LMSEntities();



        public ActionResult Index()
        {


            if (Session["name"] == null)
            {

                return RedirectToAction("Index", "management");
            }
            else
            {

                var r = obj.boo.ToList();
                return View(r);
            }
        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            var data = obj.boo.Where(model => model.book_name.StartsWith(search)).ToList();
            return View(data);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(book bo)
        {
            var c = obj.boo.Add(bo);
            if (ModelState.IsValid)
            {
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);

        }
        public ActionResult edit(int id)
        {
            var row = obj.boo.Where(model => model.book_id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult edit(book bo)
        {
            obj.Entry(bo).State = EntityState.Modified;
            if (ModelState.IsValid)
            {
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult delete(int id)
        {
            var row = obj.boo.Where(model => model.book_id == id).FirstOrDefault();
            obj.Entry(row).State = EntityState.Deleted;
            obj.SaveChanges();
            return RedirectToAction("Index");

        }
        /*[HttpPost]
        public ActionResult delete(book bo)
        {
           
            return RedirectToAction("Index");
        }*/
        public ActionResult detail(int id)
        {
            var row = obj.boo.Where(model => model.book_id == id).FirstOrDefault();
            return View(row);
        }
        public ActionResult log()
        {
            return View();
        }
        public ActionResult logout()
        {
            if (Session["name"] != null)
            {
                Session.Abandon();
                return RedirectToAction("log","management");

            }
            else
            {
                return View();
            }

        }
    }
}