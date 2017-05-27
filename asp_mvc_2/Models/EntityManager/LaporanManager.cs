using asp_mvc_2.Models.DB;
using asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.EntityManager
{
    public class LaporanManager
    {
        public void InsertLaporan(LaporanView lv)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                laporan lap = new laporan();

                lap.id_mobil = lv.id_mobil;

                lap.id_pelanggan = lv.id_pelanggan;

                lap.keterangan = lv.keterangan;

                lap.tgl_pinjam = lv.tgl_pinjam;

                lap.tgl_kembali = lv.tgl_kembali;

                TimeSpan d = (lv.tgl_kembali - lv.tgl_pinjam) ?? default(TimeSpan);

                int idMobil = lv.id_pelanggan ?? default(int);



                lap.saldo = int.Parse(d.Days.ToString()) * GetHargaSewa(idMobil);

                db.laporans.Add(lap);

                db.SaveChanges();

            }

        }

        public int GetHargaSewa(int idMobil)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                var km = db.mobils.Where(o => o.id_mobil.Equals(idMobil));

                if (km.Any())

                    return km.FirstOrDefault().harga_sewa ?? default(int);

                else

                    return 0;

            }

        }

        public List<LaporanView> GetLaporanData()

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                var laporan = db.laporans.Select(o => new LaporanView

                {

                    id_laporan = o.id_laporan,

                    id_mobil = o.id_mobil,

                    id_pelanggan = o.id_pelanggan,

                    keterangan = o.keterangan,

                    tgl_pinjam = o.tgl_pinjam,

                    tgl_kembali = o.tgl_kembali,

                    saldo = o.saldo

                }).ToList();

                return laporan;

            }

        }

        public LaporanDataView GetLaporanDataView()

        {

            LaporanDataView ldv = new LaporanDataView();

            PelangganManager pm = new PelangganManager();

            MobilManager km = new MobilManager();

            ldv.LaporanProfile = GetLaporanData();

            ldv.SelectedPelanggan = 1;

            ldv.PelangganProfile = pm.GetPelangganData();

            ldv.SelectedKamar = 1;

            ldv.MobilProfile = km.GetMobilData();



            return ldv;

        }
    }
}