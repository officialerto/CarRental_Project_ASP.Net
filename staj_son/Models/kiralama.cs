//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace staj_son.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class kiralama
    {
        public int id { get; set; }
        public string arac_id { get; set; }
        public Nullable<int> musteri_id { get; set; }
        public Nullable<decimal> ucret { get; set; }
        public Nullable<System.DateTime> alis_tarihi { get; set; }
        public Nullable<System.DateTime> iade_tarihi { get; set; }
    }
}
