using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class deparmentSController : Controller
    {
        private sql_mangeEntities db = new sql_mangeEntities();
        // GET: deparmentS
        public ActionResult Index()
        {
            return View(db.departments.ToList());
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Add([Bind(Include = "departmentId,departmentName")]department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.departments.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
            return View(department);
        }
       
        // GET: deparmentS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: deparmentS/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

        // GET: deparmentS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: deparmentS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
