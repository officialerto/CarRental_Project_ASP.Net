using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//SQL'DEN ALINAN DEĞİŞKENLERİN İSİMLERİNİ DÜZENLİYOR NAMESPACE

namespace staj_son.Models
{
    [MetadataType(typeof(musteriMetaData))]
    public partial class musteri
    {
        public class musteriMetaData
        {
            [DisplayName("TC Kimlik No")]
            public int tc { get; set; }

            [Required(ErrorMessage ="Lütfen Ad Soyad Giriniz!")]
            [StringLength(maximumLength:40,MinimumLength =2, ErrorMessage ="İsminiz Min 2, Max 40 Harf Olabilir!")]
            [DisplayName("Ad Soyad")]
            public string ad_soyad { get; set; }

            [Required(ErrorMessage = "Lütfen Adres Giriniz!")]
            [DisplayName("Adres")]
            public string adres { get; set; }

            [Required(ErrorMessage = "Lütfen Telefon Numarası Giriniz!")]
            [DisplayName("Telefon")]
            public Nullable<int> telefon { get; set; }

            [Required(ErrorMessage = "Lütfen Ehliyet Yükleyiniz!")]
            [DisplayName("Ehliyet")]
            public string ehliyet { get; set; }

        }
    }
}