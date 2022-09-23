using BilgiDeposu.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiDeposu.Controllers
{
    public class KayitOlController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLOGRENCI p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLOGRENCI.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}