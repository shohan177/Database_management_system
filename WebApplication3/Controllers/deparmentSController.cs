using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DeparmentSController : Controller
    {
        private sql_mangeEntities db = new sql_mangeEntities();
        // GET: deparmentS
        public ActionResult Index()
        {
            return View(db.departments.OrderByDescending(x=>x.departmentName).ToList());
        }

        

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public JsonResult Create(department department)
        {
          
                    db.departments.Add(department);
                    db.SaveChanges();
                     return Json(JsonRequestBehavior.AllowGet);


        }
       
  
       

        // GET: deparmentS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: deparmentS/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

     

  
        [HttpPost]
    
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            department department = db.departments.Find(id);
            db.departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
