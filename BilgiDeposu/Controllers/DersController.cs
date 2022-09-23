using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiDeposu.Models.Entitiy;

namespace BilgiDeposu.Controllers
{
    public class DersController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        
        public ActionResult Index(string p)
        {
            var dersler = from k in db.TBLKITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                dersler = dersler.Where(m => m.AD.Contains(p));
            }
            // var kitaplar = db.TBLKITAP.ToList();
            return View(dersler.ToList());
        }
        [HttpGet]
        public ActionResult DersEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLBOLUM.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLAKADEMISYEN.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(TBLKITAP p)
        {
           
            var ktg = db.TBLBOLUM.Where(k => k.ID == p.TBLBOLUM.ID).FirstOrDefault();
            var yzr = db.TBLAKADEMISYEN.Where(y => y.ID == p.TBLAKADEMISYEN.ID).FirstOrDefault();
            p.TBLBOLUM = ktg;
            p.TBLAKADEMISYEN = yzr; 
           
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Ders");
        }
        public ActionResult DersSil(int id)
        {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ktp = db.TBLKITAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLBOLUM.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLAKADEMISYEN.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;


            return View("DersGetir", ktp);
        }
        public ActionResult DersGuncelle(TBLKITAP p)
        {
            var kitap = db.TBLKITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.AKTS = p.AKTS;
            kitap.SAYFA = p.SAYFA;
            kitap.DURUM = true;
            var ktg = db.TBLBOLUM.Where(k => k.ID == p.TBLBOLUM.ID).FirstOrDefault();
            var akdm = db.TBLAKADEMISYEN.Where(y => y.ID == p.TBLAKADEMISYEN.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.AKADEM = akdm.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}