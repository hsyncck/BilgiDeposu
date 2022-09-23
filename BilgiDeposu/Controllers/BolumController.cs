using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiDeposu.Models.Entitiy;

namespace BilgiDeposu.Controllers
{
    public class BolumController : Controller
    {
        // GET: Katagori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        
        public ActionResult Index()
        {
            var degerler = db.TBLBOLUM.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult BolumEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BolumEkle(TBLBOLUM p)
        {
            db.TBLBOLUM.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult BolumSil(int id)
        {
            var kategori = db.TBLBOLUM.Find(id);
            db.TBLBOLUM.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BolumGetir(int id)
        {
            var ktg = db.TBLBOLUM.Find(id);

            return View("BolumGetir", ktg);
        }
        public ActionResult BolumGuncelle(TBLBOLUM p)
        {
            var ktg = db.TBLBOLUM.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}