using System;
using System.Collections.Generic;
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