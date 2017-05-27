using asp_mvc_2.Models.DB;
using asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_mvc_2.Models.EntityManager
{
    public class PelangganManager
    {
        public void AddPelanggan(PelangganView kv)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                pelanggan km = new pelanggan();

                km.no_id = kv.no_id;

                km.nama = kv.nama;

                km.alamat = kv.alamat;

                km.no_tlp1 = kv.no_tlp1;

                km.no_tlp2 = kv.no_tlp2;

                db.pelanggans.Add(km);

                db.SaveChanges();

            }

        }

        public void UpdatePelanggan(PelangganView kv)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                pelanggan km = db.pelanggans.Find(kv.id_pelanggan);

                km.no_id = kv.no_id;

                km.nama = kv.nama;

                km.alamat = kv.alamat;

                km.no_tlp1 = kv.no_tlp1;

                km.no_tlp2 = kv.no_tlp2;
                
                //db.kamars.Add(km);

                db.SaveChanges();

            }

        }

        public List<PelangganView> GetPelangganData()

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                var pelanggan = db.pelanggans.Select(o => new PelangganView

                {

                    id_pelanggan = o.id_pelanggan,

                    no_id = o.no_id,

                    nama = o.nama,

                    alamat = o.alamat,

                    no_tlp1 = o.no_tlp1,

                    no_tlp2 = o.no_tlp2,
                    

                }).ToList();

                return pelanggan;

            }

        }

        public void DeletePelanggan(int pelangganID)

        {

            using (DemoDBEntities1 db = new DemoDBEntities1())

            {

                using (var dbContextTransaction = db.Database.BeginTransaction())

                {

                    try

                    {

                        var Km = db.pelanggans.Where(o => o.id_pelanggan == pelangganID);

                        if (Km.Any())

                        {

                            db.pelanggans.Remove(Km.FirstOrDefault());

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