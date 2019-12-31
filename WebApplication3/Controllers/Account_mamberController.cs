using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Web.Security;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    [AllowAnonymous]
    public class Account_mamberController : Controller
    {
        sql_mangeEntities db = new sql_mangeEntities();


        // GET: Account_mamber
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(member_login model)
        {
            
                using (var context = new sql_mangeEntities())
                {
                    bool isValid = context.employ_user.Any(x => x.name == model.name && x.Password == model.Password);
                    
                

                    if (isValid )
                    {
                        FormsAuthentication.SetAuthCookie(model.name, false);
                    var logerIn = new LoginHistroy
                    {
                    
                        username = model.name,
                        Action = Request.ServerVariables["REMOTE_ADDR"],
                         LoginTime = DateTime.UtcNow


                    };
                    db.LoginHistroy.Add(logerIn);
                    db.SaveChanges();

                    return RedirectToAction("About", "Home");
                   
                    

                    }
                    ModelState.AddModelError("", "Invalide user and password");
                    return View();
                }

            }
        
        public ActionResult Logout(member_login model)
        {
           
            var logerOut = new LoginHistroy
            {

                username = model.name,
                                       Action = Request.ServerVariables["REMOTE_ADDR"],
                LogoutTime = DateTime.UtcNow


            };
            db.LoginHistroy.Add(logerOut);
            db.SaveChanges();
            FormsAuthentication.SignOut();


            return RedirectToAction("Login", "Account_mamber");
            
        }
       
    }
}