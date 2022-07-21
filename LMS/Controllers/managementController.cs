using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;
using System.Web.Security;
using System.Data.Entity;
//using System.Web.Security;

namespace LMS.Controllers
{
    //[Authorize]
    public class managementController : Controller
    {
        
        LMSEntities obj = new LMSEntities();
     
        public ActionResult log()
        {
            return View();
        }
        [HttpPost]
        public ActionResult log(string name, string pass)
        {


            Session["name"] = name;
            Session["pass"] = pass;
            if (name.Equals("") == true)
            {
                ModelState.AddModelError("name", "Enter the Name");
                if (pass.Equals("") == true)
                {
                    ModelState.AddModelError("pass", "Enter the password");
                }

            }
            else
            {
                bool isvalid = obj.mana.Any(model => model.user_name == name);

                if (isvalid)
                {
                    if (pass.Equals("") == true)
                    {
                        ModelState.AddModelError("pass", "Enter the password");
                    }
                    else
                    {

                        bool isValid = obj.mana.Any(model => model.password == pass);
                        if (isValid)
                        {

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("pass", "Incorrect Password!!");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("name", "Incorrect User-Name");
                }

            }

            return View();
        }
        /*<authentication mode = "Forms" >                  (in web config after system.web)

        < forms > loginUrl = "management/log" </ forms >

    </ authentication >*/
        public ActionResult logout()
        {
            if (Session["name"] != null)
            {
                Session.Abandon();
                return RedirectToAction("log");
            }

            return View();

        }
        public ActionResult Index()
        {
            if (Session["name"]==null)
            {
                return RedirectToAction("log");
            }
            var a = obj.mana.ToList();
            return View(a);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(management man)
        {
            obj.mana.Add(man);
            if (ModelState.IsValid)
            {
                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult edit(int id)
        {
            var row = obj.mana.Where(model => model.management_id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult edit(management man)
        {
            obj.Entry(man).State = EntityState.Modified;
            if (ModelState.IsValid)
            {
                obj.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }
       public ActionResult delete(int id)
        {
            var row = obj.mana.Where(model => model.management_id == id).FirstOrDefault();
            obj.Entry(row).State = EntityState.Deleted;
            obj.SaveChanges();
            return RedirectToAction("Index");
            
        }
      /*  [HttpPost]
        public ActionResult delete(management man)
        {


            obj.Entry(man).State = EntityState.Deleted;
            obj.SaveChanges();
            return RedirectToAction("Index");

        }*/
        public ActionResult detail(int id)
        {
            var row = obj.mana.Where(model => model.management_id == id).FirstOrDefault();
            return View(row);
        }
       
       /* public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }*/
    }
}