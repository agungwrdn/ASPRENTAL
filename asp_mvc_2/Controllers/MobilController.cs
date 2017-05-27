using asp_mvc_2.Models.EntityManager;
using asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_mvc_2.Controllers
{
    public class MobilController : Controller
    {
        // GET: Mobil

        public ActionResult AddMobil()

        {

            return View();

        }

        [HttpPost]

        public ActionResult AddMobil(MobilView kv)

        {

            if (ModelState.IsValid)

            {

                MobilManager KM = new MobilManager();

                KM.AddMobil(kv);

                return RedirectToAction("Welcome", "Home");

            }

            return View();

        }

        public ActionResult ManageMobilPartial(string status = "")

        {

            //if (User.Identity.IsAuthenticated)

            //{

            string loginName = User.Identity.Name;

            MobilManager KM = new MobilManager();

            MobilDataView KDV = new MobilDataView();

            KDV.MobilProfile = KM.GetMobilData();

            string message = string.Empty;

            if (status.Equals("update"))

                message = "Update Successful";

            else if (status.Equals("delete"))

                message = "Delete Successful";

            ViewBag.Message = message;

            return PartialView(KDV);

            //}

            // return RedirectToAction("Index", "Home");

        }

        public ActionResult UpdateMobilData(int mobilID, string noPlat, string

        merk, string jenis, string warna, DateTime tahun, int harga)

        {

            MobilView KV = new MobilView();

            KV.id_mobil = mobilID;

            KV.no_plat = noPlat;

            KV.merk = merk;

            KV.jenis = jenis;

            KV.warna = warna;

            KV.tahun = tahun;
            KV.harga_sewa = harga;

            MobilManager KM = new MobilManager();

            KM.UpdateMobil(KV);

            return Json(new { success = true });

        }

        public ActionResult DeleteMobil(int mobilID)

        {

            MobilManager KM = new MobilManager();

            KM.DeleteMobil(mobilID);

            return Json(new { success = true });

        }

        public ActionResult Perubahan()

        {

            return View();

        }
    }
}