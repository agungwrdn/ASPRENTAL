//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asp_mvc_2.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class mobil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mobil()
        {
            this.laporans = new HashSet<laporan>();
        }
    
        public int id_mobil { get; set; }
        public string no_plat { get; set; }
        public string merk { get; set; }
        public string jenis { get; set; }
        public string warna { get; set; }
        public Nullable<System.DateTime> tahun { get; set; }
        public Nullable<int> harga_sewa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<laporan> laporans { get; set; }
    }
}
