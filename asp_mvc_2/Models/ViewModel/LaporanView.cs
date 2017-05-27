using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.ViewModel
{
    public class LaporanView
    {
        [Key]

        public int id_laporan { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "ID Kamar")]

        public int? id_mobil { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "ID Pelanggan")]

        public int? id_pelanggan { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Keterangan")]

        public string keterangan { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Tgl Pinjam")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//untuk mengeluarkan tgl saja

        public DateTime? tgl_pinjam { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Tgl Kembali")]

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime? tgl_kembali { get; set; }

        [Required(ErrorMessage = "*")]

        [Display(Name = "Saldo")]

        public int? saldo { get; set; }
    }

    public class LaporanDataView

    {

        public IEnumerable<LaporanView> LaporanProfile { get; set; }

        public int? SelectedPelanggan { get; set; }

        public int? SelectedMobil { get; set; }

        public IEnumerable<PelangganView> PelangganProfile { get; set; }

        public int? SelectedKamar { get; set; }

        public IEnumerable<MobilView> MobilProfile { get; set; }

    }
}