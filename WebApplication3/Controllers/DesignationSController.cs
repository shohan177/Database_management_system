using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DesignationSController : Controller
    {
        private sql_mangeEntities db = new sql_mangeEntities();
       

        public object SqlCommandText { get; private set; }

        // GET: DesignationS
        public ActionResult Index()
        
        {
           
            return View(db.Designations.OrderByDescending(x=>x.DesignationName).ToList());
        }
        public void Save(string Dgname)
        {
          
       

        }
        // GET: DesignationS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        // POST: DesignationS/Create
        [HttpPost]
        public JsonResult Create(Designation Designation)
        {
           
                    db.Designations.Add(Designation);
                    db.SaveChanges();
                     return Json(JsonRequestBehavior.AllowGet);
                  
               
        }

        // GET: DesignationS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DesignationS/Edit/5
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



        [Authorize(Roles = "Admin")]
        [HttpPost]

        public ActionResult Delete(int id)
        {
            Designation Designation = db.Designations.Find(id);
            db.Designations.Remove(Designation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
