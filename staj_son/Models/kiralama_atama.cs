using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace staj_son.Models
{
    [MetadataType(typeof(kiralamaMetaData))]
    public partial class kiralama
    {
        public class kiralamaMetaData
        {
     
            [DisplayName("ID")]
            public int id { get; set; }
            [Required(ErrorMessage = "Lütfen Plaka Giriniz!")]
            [DisplayName("Araç ID")]
            public string arac_id { get; set; }
            [Required(ErrorMessage = "Lütfen Müşteri TC Giriniz!")]
            [DisplayName("Müşteri ID")]
            public Nullable<int> musteri_id { get; set; }
            [Required(ErrorMessage = "Lütfen Ücret Giriniz!")]
            [DisplayName("Ücret")]
            public Nullable<decimal> ucret { get; set; }
            [Required(ErrorMessage = "Lütfen Alış Tarihini Giriniz!")]
            [DisplayName("Alış Tarihi")]
            public Nullable<System.DateTime> alis_tarihi { get; set; }
            [Required(ErrorMessage = "Lütfen İade Tarihini Giriniz!")]
            [DisplayName("İade Tarihi")]
            public Nullable<System.DateTime> iade_tarihi { get; set; }

        }
    }
}