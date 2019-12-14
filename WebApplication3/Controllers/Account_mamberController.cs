using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Web.Security;

namespace WebApplication3.Controllers
{
    [AllowAnonymous]
    public class Account_mamberController : Controller
    {
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
                        return RedirectToAction("About", "Home");

                    }
                    ModelState.AddModelError("", "Invalide user and password");
                    return View();
                }

            }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("About", "Home");
        }
    }
}