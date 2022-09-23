using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiDeposu.Models;
using BilgiDeposu.Models.Entitiy;


namespace OgrenciNotMvc.Controllers
{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar

        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var sinavlar = db.TBLNOTLAR.ToList();
            return View(sinavlar);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            

            List<SelectListItem> deger1 = (from i in db.TBLKITAP.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in db.TBLOGRENCI.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD + " " + x.SOYAD,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR p)
        {
            var ktg = db.TBLKITAP.Where(k => k.ID == p.TBLKITAP.ID).FirstOrDefault();
            var ogr = db.TBLOGRENCI.Where(k => k.ID == p.TBLOGRENCI.ID).FirstOrDefault();
            p.TBLOGRENCI = ogr;
            p.TBLKITAP = ktg;
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SinavGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("SinavGetir", not);
        }
        [HttpPost]
        public ActionResult SinavGetir(TBLNOTLAR p, Class2 cls1, int Sinav1 = 0, int Sinav2 = 0, int Sinav3 = 0, int Proje = 0)
        {
            if (cls1.islem == "HESAPLA")
            {
                //işlem 1
                int ORTALAMA = (Sinav1 + Sinav2 + Sinav3 + Proje) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (cls1.islem == "NOTGUNCELLE")
            {
                //işlem 2
                var not = db.TBLNOTLAR.Find(p.NOTID);
                not.SINAV1 = p.SINAV1;
                not.SINAV2 = p.SINAV2;
                not.PROJE = p.PROJE;
                not.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLNOTLAR.Find(id);
            db.TBLNOTLAR.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}