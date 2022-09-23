using BilgiDeposu.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiDeposu.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        
        public ActionResult Index()
        {
            var kullanicilar = db.ADMIN.ToList();
            return View(kullanicilar);
        }
        public ActionResult Index2()
        {
            var kullanicilar = db.ADMIN.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(ADMIN t)
        {
            db.ADMIN.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.ADMIN.Find(id);
            db.ADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.ADMIN.Find(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(ADMIN p)
        {
            var admin = db.ADMIN.Find(p.ID);
            admin.Kullanici = p.Kullanici;
            admin.Sifre = p.Sifre;
            admin.Yetki = p.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

    }
}