using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using staj_son.Models;

namespace staj_son.Controllers
{
    public class MusteriController : Controller
    {
        private car_rental_dbEntities db = new car_rental_dbEntities();

        // GET: Musteri
        public ActionResult Index(string SortOrder)
        {
            //ASC-DESC YAPILAN KISIM
            ViewBag.tc = SortOrder == "tc" ? "tc_desc" : "tc";
            ViewBag.ad_soyad = String.IsNullOrEmpty(SortOrder) ? "ad_soyad" : "";
            ViewBag.adres = SortOrder == "adres" ? "adres_desc" : "adres";
            ViewBag.telefon = SortOrder == "telefon" ? "telefon_desc" : "telefon";

            var mstr = from x in db.musteris
                       select x;

            switch (SortOrder)
            {
                case "tc_desc":
                    mstr = mstr.OrderByDescending(x => x.tc);
                    break;
                case "tc":
                    mstr = mstr.OrderBy(x => x.tc);
                    break;
                case "ad_soyad":
                    mstr = mstr.OrderByDescending(x => x.ad_soyad);
                    break;
                case "adres_desc":
                    mstr = mstr.OrderByDescending(x => x.adres);
                    break;
                case "adres":
                    mstr = mstr.OrderBy(x => x.adres);
                    break;
                case "telefon_desc":
                    mstr = mstr.OrderByDescending(x => x.telefon);
                    break;
                case "telefon":
                    mstr = mstr.OrderBy(x => x.telefon);
                    break;
                default:
                    mstr = mstr.OrderBy(x => x.ad_soyad);
                    break;
            }
            return View(mstr.ToList());
        }
        // GET: Musteri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            musteri musteri = db.musteris.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: Musteri/Create
        public ActionResult Create()
        {
            return View();
        }
        //---------------------------------ESKİ CREATE CONTROLLER--------------------------------------
        // POST: Musteri/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "tc,ad_soyad,adres,telefon,ehliyet")] musteri musteri){
        //    if (ModelState.IsValid)   {      
        //        db.musteris.Add(musteri);
        //        db.SaveChanges();
        //        return RedirectToAction("Index"); }  
        //    return View(musteri); }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //HttpPostedFileBase parametresiyle create view'ındaki input .. name=ehliyet kısmındaki name ile aynı olacak!!!
        public ActionResult Create(int tc, string ad_soyad, string adres, int telefon, System.Web.HttpPostedFileBase ehliyet)
        {
            if (ModelState.IsValid)
            {
                musteri musteri = new musteri();
                musteri.tc = tc;
                musteri.ad_soyad = ad_soyad;
                musteri.adres = adres;
                musteri.telefon = telefon;
                //dosyaYolu değişkeninde yüklenecek dosyanın bulunduğu ismini alıyoruz(ehliyet)
                string dosyaYolu = Path.GetFileName(ehliyet.FileName);
                //yuklemeYeri değişkeninde, Path.Combine metodu ile dosyanın yükleneceği yer bilgisini alıyoruz(Images klasörü)
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Images"), dosyaYolu);
                musteri.ehliyet = yuklemeYeri;
                ehliyet.SaveAs(yuklemeYeri);
                db.musteris.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");   
            }

            return View("Index");
        }


        // GET: Musteri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            musteri musteri = db.musteris.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteri/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tc,ad_soyad,adres,telefon,ehliyet")] musteri musteri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        // GET: Musteri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            musteri musteri = db.musteris.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Musteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            musteri musteri = db.musteris.Find(id);
            db.musteris.Remove(musteri);
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
