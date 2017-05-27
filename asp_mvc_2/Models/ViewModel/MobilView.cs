using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.ViewModel
{
    public class MobilView
    {
        [Key]

        public int id_mobil { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "No Plat")]

        public string no_plat { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Merk")]

        public string merk { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Jenis")]

        public string jenis { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Warna")]

        public string warna { get; set; }

        [Required(ErrorMessage = "*")]

        public DateTime? tahun { get; set; }


        [Display(Name = "Harga")]

        public int? harga_sewa { get; set; }

    }

    public class MobilDataView

    {

        public IEnumerable<MobilView> MobilProfile { get; set; }

    }
}