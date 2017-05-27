using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.ViewModel
{
    public class PelangganView
    {
        [Key]

        public int id_pelanggan { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "ID")]

        public string no_id { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Nama")]

        public string nama { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Alamat")]

        public string alamat { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "No Telp1")]

        public string no_tlp1 { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "No Telp2")]
        public string no_tlp2 { get; set; }

    }

    public class PelangganDataView

    {

        public IEnumerable<PelangganView> PelangganProfile { get; set; }

    }
}