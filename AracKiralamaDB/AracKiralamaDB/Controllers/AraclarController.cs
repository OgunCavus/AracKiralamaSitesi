using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralamaDB.Models;

namespace AracKiralamaDB.Controllers
{
    public class AraclarController : Controller
    {
        // GET: Araclar
        public ActionResult Index()
        {
            AracKiralamaDBEntities db = new AracKiralamaDBEntities();
            ModelToplama mt = new ModelToplama();
            mt.Arabalars = db.Arabalar.ToList();
            mt.ArabaModelleris = db.ArabaModelleri.ToList();
            mt.ArabaMarkalaris = db.ArabaMarkalari.ToList();
            mt.ArabaResimleris = db.ArabaResimleri.ToList();
            return View(mt);

        }
        public ActionResult MusteriIndex()
        {
            AracKiralamaDBEntities db = new AracKiralamaDBEntities();
            ModelToplama mt = new ModelToplama();
            mt.Arabalars = db.Arabalar.ToList();
            mt.ArabaModelleris = db.ArabaModelleri.ToList();
            mt.ArabaMarkalaris = db.ArabaMarkalari.ToList();
            mt.ArabaResimleris = db.ArabaResimleri.ToList();
            return View(mt);

        }
    }
}