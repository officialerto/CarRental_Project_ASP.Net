using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace staj_son.Models
{
    public class KiralamaViewModel
    {

        public int id { get; set; }
        public string arac_id { get; set; }
        public Nullable<int> musteri_id { get; set; }
        public Nullable<decimal> ucret { get; set; }
        public Nullable<System.DateTime> alis_tarihi { get; set; }
        public Nullable<System.DateTime> iade_tarihi { get; set; }
        public string durum { get; set; }

    }
}