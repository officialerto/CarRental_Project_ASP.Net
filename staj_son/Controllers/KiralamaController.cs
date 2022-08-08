using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using staj_son.Models;

namespace staj_son.Controllers
{
    public class KiralamaController : Controller
    {
        car_rental_dbEntities db = new car_rental_dbEntities();
        // GET: Kiralama
        public ActionResult Index()
        {

            var result = (from r in db.kiralama
                          join c in db.arac_kayits on r.arac_id equals c.plaka
                          select new KiralamaViewModel
                          {

                              id=r.id,
                              arac_id=r.arac_id,
                              musteri_id=r.musteri_id,
                              ucret=r.ucret,
                              alis_tarihi=r.alis_tarihi,
                              iade_tarihi=r.iade_tarihi,
                              durum=c.durum

                          }).ToList();

            return View(result);
        }

        [HttpGet]
        //HTTPGET: SERVER TARAFINDAN BİLGİ GETİRİLİR 
        public ActionResult Getarac()
        {
            var arac = db.arac_kayits.ToList(); 

            return Json(arac, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Gettc(int tc)
        {
            var musteri = (from s in db.musteris where s.tc == tc select s.ad_soyad).ToList();

            return Json(musteri, JsonRequestBehavior.AllowGet);

        }
        //GİRİLEN BİLGİLERİN KAYDEDİLDİĞİ KISIM
        [HttpPost]
        public ActionResult Getdrm(String plaka)
        {
            var aracdrm = (from s in db.arac_kayits where s.plaka == plaka select s.durum).FirstOrDefault();    

            return Json(aracdrm, JsonRequestBehavior.AllowGet);

        }
        //SAVE BUTTON
        //HTTPPPOST: GENELDE İŞLEM YAPILIR
        [HttpPost]
        public ActionResult Save(kiralama kiralama)
        {
            if (ModelState.IsValid)
            {

                db.kiralama.Add(kiralama);

                var arac = db.arac_kayits.SingleOrDefault(e=>e.plaka == kiralama.arac_id);

                if (arac == null)
                    return HttpNotFound("Geçersiz Plaka");

                arac.durum = "Uygun Değil";
                db.Entry(arac).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(kiralama);

        }
    }
}