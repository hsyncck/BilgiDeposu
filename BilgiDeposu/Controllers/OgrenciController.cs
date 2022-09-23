using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiDeposu.Models.Entitiy;
using PagedList;
using PagedList.Mvc;

namespace BilgiDeposu.Controllers
{
    public class OgrenciController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBLTBLOGRENCI.ToList();
            var degerler = db.TBLOGRENCI.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> deger3 = (from i in db.TBLBOLUM.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(TBLOGRENCI p)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("OgrenciEkle");
            //}
            var ktg = db.TBLBOLUM.Where(k => k.ID == p.TBLBOLUM.ID).FirstOrDefault();
            p.TBLBOLUM = ktg;
            db.TBLOGRENCI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciSil(int id)
        {
            var uye = db.TBLOGRENCI.Find(id);
            db.TBLOGRENCI.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            //var ktp = db.TBLBOLUM.Find(id);
            List<SelectListItem> deger4 = (from i in db.TBLBOLUM.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr4 = deger4;
            var uye = db.TBLOGRENCI.Find(id);
            return View("OgrenciGetir", uye);
        }
        public ActionResult OgrenciGuncelle(TBLOGRENCI p)
        {
            var uye = db.TBLOGRENCI.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            var ktg = db.TBLBOLUM.Where(k => k.ID == p.TBLBOLUM.ID).FirstOrDefault();
            uye.OKUL = ktg.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciDersGecmis(int id)
        {
            var ktpgcms = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBLOGRENCI.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgcms);
        }
    }
}