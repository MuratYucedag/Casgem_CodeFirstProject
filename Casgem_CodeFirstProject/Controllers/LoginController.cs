using Casgem_CodeFirstProject.DAL.Context;
using Casgem_CodeFirstProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_CodeFirstProject.Controllers
{
    public class LoginController : Controller
    {
        TravelContext travelContext = new TravelContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = travelContext.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["usertravel"] = values.Username.ToString();
                return RedirectToAction("Index", "AdminGuide");
            }
            else
            {
                return View();
            }
        }
    }
}