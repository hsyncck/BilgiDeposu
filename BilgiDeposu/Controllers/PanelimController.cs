using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BilgiDeposu.Models.Entitiy;

namespace BilgiDeposu.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            //var degerler = db.TBLOGRENCI.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = db.TBLDUYURULAR.ToList();
            var d1 = db.TBLOGRENCI.Where(x => x.MAIL == uyemail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.TBLOGRENCI.Where(x => x.MAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;
            var d3 = db.TBLOGRENCI.Where(x => x.MAIL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;
            var d4 = db.TBLOGRENCI.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d4 = d4;
            var d5 = db.TBLOGRENCI.Where(x => x.MAIL == uyemail).Select(y => y.TBLBOLUM.AD).FirstOrDefault();
            ViewBag.d5 = d5;
            var uyeid = db.TBLOGRENCI.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var d6 = db.TBLHAREKET.Where(x => x.UYE == uyeid).Count();
            ViewBag.d6 = d6;
            var d9 = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d9 = d9;

            var d10 = db.TBLDUYURULAR.Count();
            ViewBag.d10 = d10;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLOGRENCI p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLOGRENCI.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Derslerim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLOGRENCI.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "vitrin");
        } 
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLOGRENCI.Where(x => x.MAIL == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.TBLOGRENCI.Find(id);

            return PartialView("Partial2",uyebul);
        }
        public ActionResult Notlarim()
        {
            var duyurulistesi = db.TBLNOTLAR.ToList();
            return View(duyurulistesi);
        }
        public ActionResult Görün()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }
        public ActionResult DersSec()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }


    }
}