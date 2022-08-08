using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using staj_son.Models;

namespace staj_son.Controllers
{
    public class AracController : Controller
    {
        private car_rental_dbEntities db = new car_rental_dbEntities();

        // GET: Arac
        public ActionResult Index(string SortOrder)
        {
            //ASC-DESC YAPILAN KISIM
            ViewBag.plaka = SortOrder == "plaka" ? "plaka_desc" : "plaka";
            ViewBag.marka = String.IsNullOrEmpty(SortOrder) ? "marka" : "";
            ViewBag.model = SortOrder == "model" ? "model_desc" : "model";
            ViewBag.durum = SortOrder == "durum" ? "durum_desc" : "durum";
            ViewBag.yakit = SortOrder == "yakit" ? "yakit_desc" : "yakit";
            ViewBag.vites = SortOrder == "vites" ? "vites_desc" : "vites";
            ViewBag.ucret = SortOrder == "ucret" ? "ucret_desc" : "ucret";

            var araccc = from s in db.arac_kayits
                         select s;

            switch (SortOrder)
            {
                case "plaka_desc":
                    araccc = araccc.OrderByDescending(s => s.plaka);
                    break;
                case "plaka":
                    araccc = araccc.OrderBy(s => s.plaka);
                    break;
                case "marka" :
                    araccc = araccc.OrderByDescending(s => s.marka);
                    break;
                case "model_desc":
                    araccc = araccc.OrderByDescending(s => s.model);
                    break;
                case "model":
                    araccc = araccc.OrderBy(s => s.model);
                    break;
                case "durum_desc":
                    araccc = araccc.OrderByDescending(s => s.durum);
                    break;
                case "durum":
                    araccc = araccc.OrderBy(s => s.durum);
                    break;
                case "yakit_desc":
                    araccc = araccc.OrderByDescending(s => s.yakit);
                    break;
                case "yakit":
                    araccc = araccc.OrderBy(s => s.yakit);
                    break;
                case "vites_desc":
                    araccc = araccc.OrderByDescending(s => s.vites);
                    break;
                case "vites":
                    araccc = araccc.OrderBy(s => s.vites);
                    break;
                case "ucret_desc":
                    araccc = araccc.OrderByDescending(s => s.ucret);
                    break;
                case "ucret":
                    araccc = araccc.OrderBy(s => s.ucret);
                    break;
                default :
                    araccc = araccc.OrderBy(s => s.marka);
                    break;
            }
            return View(araccc.ToList());
        }

        // GET: Arac/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arac_kayit arac_kayit = db.arac_kayits.Find(id);
            if (arac_kayit == null)
            {
                return HttpNotFound();
            }
            return View(arac_kayit);
        }

        // GET: Arac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arac/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "plaka,marka,model,durum,yakit,vites,ucret")] arac_kayit arac_kayit)
        {
            if (ModelState.IsValid)
            {
                db.arac_kayits.Add(arac_kayit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arac_kayit);
        }

        // GET: Arac/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arac_kayit arac_kayit = db.arac_kayits.Find(id);
            if (arac_kayit == null)
            {
                return HttpNotFound();
            }
            return View(arac_kayit);
        }

        // POST: Arac/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "plaka,marka,model,durum,yakit,vites,ucret")] arac_kayit arac_kayit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arac_kayit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arac_kayit);
        }

        // GET: Arac/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arac_kayit arac_kayit = db.arac_kayits.Find(id);
            if (arac_kayit == null)
            {
                return HttpNotFound();
            }
            return View(arac_kayit);
        }

        // POST: Arac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            arac_kayit arac_kayit = db.arac_kayits.Find(id);
            db.arac_kayits.Remove(arac_kayit);
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
