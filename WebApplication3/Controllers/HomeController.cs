using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        sql_mangeEntities db = new sql_mangeEntities();
        public ActionResult Index1()
        {
     
            List<ViewAllDatabase> dl = new List<ViewAllDatabase>();
            dl.Add(new ViewAllDatabase() { Id = 1, Name = "master" });
            dl.Add(new ViewAllDatabase() { Id = 2, Name = "tempdb"});
            dl.Add(new ViewAllDatabase() { Id = 3, Name = "model"});
            dl.Add(new ViewAllDatabase() { Id = 4, Name = "msdb"});
            dl.Add(new ViewAllDatabase() { Id = 5, Name = "ReportServer"});
            dl.Add(new ViewAllDatabase() { Id = 6, Name = "ReportServerTempDB"});
            dl.Add(new ViewAllDatabase() { Id = 7, Name = "sql_mange"});
            dl.Add(new ViewAllDatabase() { Id = 8, Name = "EmployeDatabase"});
           
            ViewDatabaseList dataModel = new ViewDatabaseList();
            dataModel.DatabaseList = dl;

            

            return View(dataModel);
         
        }
        [HttpPost]
        public JsonResult CreatBackup(string dl)
        {
            string[] arr = dl.Split(',');
            foreach(var Name in arr)
            {
               var currentID = Name;
                var dataTime = DateTime.Now.ToString("h;mm;ss");
               
                string dbPath = Server.MapPath("~/App_Data/"+ currentID + "_"+dataTime + ".bak");
                using(var db = new sql_mangeEntities())
                {
                    try
                    {
                        var cmd = String.Format("BACKUP DATABASE {0} TO DISK='{1}' WITH FORMAT, MEDIANAME='DbBackups', MEDIADESCRIPTION='Media set for {0} database';"
                , currentID, dbPath);
                        db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                    }
                    catch (Exception )
                    {

                      
                    }
                    
                }
                  
              
             
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDatabaseList()
        {


            var data = db.GetAllDatabaseList();
            return View(data);
        }
       
    private List<string> Getfiles()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/App_Data"));
            System.IO.FileInfo[] filename = dir.GetFiles("*.*");
            
            

            List<string> items = new List<string>();
            foreach (var file in filename)
            {
                items.Add(file.Name);
               
                
            }
          
            return items;
        }
        public ActionResult Index()
        {
            List<ViewAllDatabase> dl = new List<ViewAllDatabase>();
            dl.Add(new ViewAllDatabase() { Id = 1, Name = "master" });
            dl.Add(new ViewAllDatabase() { Id = 2, Name = "tempdb" });
            dl.Add(new ViewAllDatabase() { Id = 3, Name = "model" });
            dl.Add(new ViewAllDatabase() { Id = 4, Name = "msdb" });
            dl.Add(new ViewAllDatabase() { Id = 5, Name = "ReportServer" });
            dl.Add(new ViewAllDatabase() { Id = 6, Name = "ReportServerTempDB" });
            dl.Add(new ViewAllDatabase() { Id = 7, Name = "sql_mange" });
            dl.Add(new ViewAllDatabase() { Id = 8, Name = "EmployeDatabase" });
            ViewBag.dl = dl;

            var items = Getfiles();
            return View(items);
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() 
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}