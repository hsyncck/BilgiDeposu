using BilgiDeposu.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BilgiDeposu.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ADMIN p)
        {
            var bilgiler = db.ADMIN.FirstOrDefault(x => x.Kullanici == p.Kullanici
            && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Bolum");
            }
            else
            {


                return View();
            }
        }
    }
}