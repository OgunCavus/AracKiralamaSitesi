using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AracKiralamaDB.Models;

namespace AracKiralamaDB.Controllers
{
    public class ArabaResimlerisController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: ArabaResimleris
        public ActionResult Index()
        {
            return View(db.ArabaResimleri.ToList());
        }

        // GET: ArabaResimleris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaResimleri arabaResimleri = db.ArabaResimleri.Find(id);
            if (arabaResimleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaResimleri);
        }

        // GET: ArabaResimleris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArabaResimleris/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaResimID,Resim")] ArabaResimleri arabaResimleri, HttpPostedFileBase Resim)
        {
            if (ModelState.IsValid)
            {
                if (Resim.ContentLength > 0)
                {
                    var image = Path.GetFileName(Resim.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img"), image);
                    Resim.SaveAs(path);

                    arabaResimleri.Resim = "/Content/img/" + image;
                    db.ArabaResimleri.Add(arabaResimleri);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound();

            }
            return HttpNotFound();
            return View(arabaResimleri);
        }
        

        // GET: ArabaResimleris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaResimleri arabaResimleri = db.ArabaResimleri.Find(id);
            if (arabaResimleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaResimleri);
        }

        // POST: ArabaResimleris/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArabaResimID,Resim")] ArabaResimleri arabaResimleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arabaResimleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arabaResimleri);
        }

        // GET: ArabaResimleris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArabaResimleri arabaResimleri = db.ArabaResimleri.Find(id);
            if (arabaResimleri == null)
            {
                return HttpNotFound();
            }
            return View(arabaResimleri);
        }

        // POST: ArabaResimleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArabaResimleri arabaResimleri = db.ArabaResimleri.Find(id);
            db.ArabaResimleri.Remove(arabaResimleri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

