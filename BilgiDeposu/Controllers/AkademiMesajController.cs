using BilgiDeposu.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgiDeposu.Controllers
{
    public class AkademiMesajController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Kullanici"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }

        public ActionResult Giden()
        {
            var uyemail = (string)Session["Kullanici"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemail = (string)Session["Kullanici"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden", "AkademiMesaj");
        }
        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Kullanici"].ToString();
            var gelensayisi = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.d2 = gidensayisi;
            return PartialView();
        }
        public ActionResult Görün()
        {
            var uyemail = (string)Session["Kullanici"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }

    }
}