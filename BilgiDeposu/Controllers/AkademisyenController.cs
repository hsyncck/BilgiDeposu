using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiDeposu.Models.Entitiy;

namespace BilgiDeposu.Controllers
{
    public class AkademisyenController : Controller
    {
        // GET: AKADEM
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        
        public ActionResult Index()
        {
            var degerler = db.TBLAKADEMISYEN.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AkademisyenEkle()
        {
            return View();
        }
        public ActionResult AkademisyenEkle(TBLAKADEMISYEN p)
        {
            if (!ModelState.IsValid)
            {
                return View("AkademisyenEkle");
            }
            db.TBLAKADEMISYEN.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult AkademisyenSil(int id)
        {
            var akadem = db.TBLAKADEMISYEN.Find(id);
            db.TBLAKADEMISYEN.Remove(akadem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AkademisyenGetir(int id)
        {
            var akdm = db.TBLAKADEMISYEN.Find(id);
            return View("AkademisyenGetir", akdm);
        }
        public ActionResult AkademisyenGuncelle(TBLAKADEMISYEN p)
        {
            var yzr = db.TBLAKADEMISYEN.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }










































        public ActionResult AkademisyenDersler(int id)
        {
            var AKADEM = db.TBLKITAP.Where(x => x.AKADEM == id).ToList();
            var yzrad = db.TBLAKADEMISYEN.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(AKADEM);
        }
    }
}