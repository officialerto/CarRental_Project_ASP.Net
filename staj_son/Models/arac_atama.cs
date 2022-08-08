using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//SQL'DEN ALINAN DEĞİŞKENLERİN İSİMLERİNİ DÜZENLİYOR NAMESPACE

namespace staj_son.Models
{
    [MetadataType(typeof(arac_kayitMetaData))]
    public partial class arac_kayit
    {
        public class arac_kayitMetaData
        {
            
            [DisplayName("Plaka")]  
            public string plaka { get; set; }
            [Required(ErrorMessage = "Lütfen Markasını Giriniz!")]
            [DisplayName("Marka")]
            public string marka { get; set; }
            [Required(ErrorMessage = "Lütfen Modelini Giriniz!")]
            [DisplayName("Model")]
            public string model { get; set; }
            [Required(ErrorMessage = "Lütfen Durumunu Giriniz!")]
            [DisplayName("Durum")]
            public string durum { get; set; }
            [Required(ErrorMessage = "Lütfen Yakıt Türü Giriniz!")]
            [DisplayName("Yakıt")]
            public string yakit { get; set; }
            [Required(ErrorMessage = "Lütfen Vites Giriniz!")]
            [DisplayName("Vites")]
            public string vites { get; set; }
            [Required(ErrorMessage = "Lütfen Ücret Giriniz!")]
            [DisplayName("Ücret")]
            public Nullable<decimal> ucret { get; set; }

        }
    }
}