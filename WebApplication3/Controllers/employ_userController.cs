using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class employ_userController : Controller
    {
        
        private sql_mangeEntities db = new sql_mangeEntities();

        // GET: employ_user
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.employ_user.ToList());
        }


   
      

        // GET: employ_user/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employ_user employ_user = db.employ_user.Find(id);
            if (employ_user == null)
            {
                return HttpNotFound();
            }
            return View(employ_user);
        }

        // GET: employ_user/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()

        {

            var departmentList = db.departments.ToList();
            var DesignationList = db.Designations.ToList();
            ViewBag.dplist = departmentList;
            ViewBag.dglist = DesignationList;
            //employ_user emp = new employ_user()
            //{
            //    departmentId = 1
            //};


            return View();
        }

        // POST: employ_user/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "id,name,Password,date,phone,email,departmentId,DesignationId")] employ_user employ_user )
        {
            

            try
            {
                if (ModelState.IsValid)
                {
                    db.employ_user.Add(employ_user);
                    db.SaveChanges();
                    TempData["userName"] = employ_user.name;
                    TempData["Action"] = "Save";
                    TempData["ErrMes"] = "user successfully";
                    
                    return RedirectToAction("Index");
                    


                }
            }
            catch (Exception e)
            {
                TempData["ErrMes"] = "2" + e.Message;
                return RedirectToAction("Index");

            }
           

            return View(employ_user);
        }

       



        // GET: employ_user/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employ_user employ_user = db.employ_user.Find(id);
            if (employ_user == null)
            {
                return HttpNotFound();
            }

            var departmentList = db.departments.ToList();
            var DesignationList = db.Designations.ToList();
            ViewBag.dplist = departmentList;
            ViewBag.dglist = DesignationList;
            employ_user emp = new employ_user()
            {
                departmentId = 1
            };
            return View(employ_user);
        }

        // POST: employ_user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "id,name,Password,date,phone,email,departmentId,DesignationId")] employ_user employ_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employ_user).State = EntityState.Modified;
                db.SaveChanges();
                TempData["userName"] = employ_user.name;
                TempData["ErrMes"] = "User successfully";
                TempData["Action"] = "Update";
                return RedirectToAction("Index");
            }
            return View(employ_user);
        }

        // GET: employ_user/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employ_user employ_user = db.employ_user.Find(id);
            if (employ_user == null)
            {
                return HttpNotFound();
            }
            return View(employ_user);
        }

        // POST: employ_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            employ_user employ_user = db.employ_user.Find(id);
            db.employ_user.Remove(employ_user);
            db.SaveChanges();
            TempData["userName"] = employ_user.name;
            TempData["ErrMes"] = "user successfully";
            TempData["Action"] = "Delete";
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
