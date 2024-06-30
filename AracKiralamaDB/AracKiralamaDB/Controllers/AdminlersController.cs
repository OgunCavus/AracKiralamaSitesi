using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AracKiralamaDB.Models;


namespace AracKiralamaDB.Controllers
{
    public class AdminlersController : Controller
    {
        private AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        // GET: Adminlers
        public ActionResult Index()
        {
            var adminler = db.Adminler.Include(a => a.Cinsiyetler);
            return View(adminler.ToList());
        }

        // GET: Adminlers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminler adminler = db.Adminler.Find(id);
            if (adminler == null)
            {
                return HttpNotFound();
            }
            return View(adminler);
        }

        // GET: Adminlers/Create
        public ActionResult Create()
        {
            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi");
            return View();
        }

        // POST: Adminlers/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,KullaniciAdi,Sifre,Kullanıcı_Tipi,Ad,Soyad,CinsiyetID,Email,TelefonNo,İl,İlce,Adres")] Adminler adminler)
        {
            if (ModelState.IsValid)
            {
                db.Adminler.Add(adminler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi", adminler.CinsiyetID);
            return View(adminler);
        }

        // GET: Adminlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminler adminler = db.Adminler.Find(id);
            if (adminler == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi", adminler.CinsiyetID);
            return View(adminler);
        }

        // POST: Adminlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminID,KullaniciAdi,Sifre,Kullanıcı_Tipi,Ad,Soyad,CinsiyetID,Email,TelefonNo,İl,İlce,Adres")] Adminler adminler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinsiyetID = new SelectList(db.Cinsiyetler, "CinsiyetID", "CinsiyetAdi", adminler.CinsiyetID);
            return View(adminler);
        }

        // GET: Adminlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adminler adminler = db.Adminler.Find(id);
            if (adminler == null)
            {
                return HttpNotFound();
            }
            return View(adminler);
        }

        // POST: Adminlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adminler adminler = db.Adminler.Find(id);
            db.Adminler.Remove(adminler);
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
