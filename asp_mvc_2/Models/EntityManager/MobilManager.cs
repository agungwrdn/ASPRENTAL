using asp_mvc_2.Models.DB;
using asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.EntityManager
{
    public class MobilManager
    {
        public void AddMobil(MobilView kv)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                mobil km = new mobil();

                km.no_plat = kv.no_plat;

                km.merk = kv.merk;

                km.jenis = kv.jenis;

                km.warna = kv.warna;

                km.tahun = kv.tahun;

                km.harga_sewa = kv.harga_sewa;

                db.mobils.Add(km);

                db.SaveChanges();

            }

        }

        public void UpdateMobil(MobilView kv)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                mobil km = db.mobils.Find(kv.id_mobil);

                km.no_plat = kv.no_plat;

                km.merk = kv.merk;

                km.jenis = kv.jenis;

                km.warna = kv.warna;

                km.tahun = kv.tahun;

                km.harga_sewa = kv.harga_sewa;

                //db.kamars.Add(km);

                db.SaveChanges();

            }

        }

        public List<MobilView> GetMobilData()

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                var mobil = db.mobils.Select(o => new MobilView

                {

                    id_mobil = o.id_mobil,

                    no_plat = o.no_plat,

                    merk = o.merk,

                    harga_sewa = o.harga_sewa,

                    warna = o.warna,

                    jenis = o.jenis,

                    tahun = o.tahun



                }).ToList();

                return mobil;

            }

        }

        public void DeleteMobil(int mobilID)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                using (var dbContextTransaction = db.Database.BeginTransaction())

                {

                    try

                    {

                        var Km = db.mobils.Where(o => o.id_mobil == mobilID);

                        if (Km.Any())

                        {

                            db.mobils.Remove(Km.FirstOrDefault());

                            db.SaveChanges();

                        }

                        dbContextTransaction.Commit();

                    }

                    catch

                    {

                        dbContextTransaction.Rollback();

                    }

                }

            }

        }
    }
}