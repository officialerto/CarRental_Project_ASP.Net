//entity framework kullanırken alttakini mutlaka yazarız "using proje ismi.Models"
using staj_son.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace staj_son.Controllers
{
    public class AraciadeController : Controller
    {
        car_rental_dbEntities db = new car_rental_dbEntities();

        // GET: Araciade
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(arac_iade aracia)
        {
            if (ModelState.IsValid)
            {

                db.arac_iades.Add(aracia);
                //SingleOrDefault: İçindeki koşul sağlanırsa, o sonuç döner aksi durumda boş.
                var arac = db.arac_kayits.SingleOrDefault(e=>e.plaka == aracia.plaka);

                if (arac == null)
                    return HttpNotFound("Plaka Bulunamadı");
                arac.durum = "Mevcut";
                db.Entry(arac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(aracia);
        }




        [HttpPost]
        public ActionResult Gettc(String plaka)
        {
            var aracn = (from s in db.kiralama
                         where s.arac_id == plaka
                         select new
                         {
                             AlisTarihi=s.alis_tarihi,
                             IadeTarihi=s.iade_tarihi,
                             Musteriid=s.musteri_id,
                             Plaka=s.arac_id,
                             Ucret=s.ucret,
                             Gecikme=SqlFunctions.DateDiff("day",s.iade_tarihi,DateTime.Now)

                         }).ToArray();

            return Json(aracn, JsonRequestBehavior.AllowGet);
        }


    }
}