﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilgiDeposu.Models.Entitiy;
namespace BilgiDeposu.Controllers
{
    public class islemController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}