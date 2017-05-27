using asp_mvc_2.Models.EntityManager;
using asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_mvc_2.Controllers
{
    public class PelangganController : Controller
    {
        // GET: Pelanggan

        public ActionResult AddPelanggan()

        {

            return View();

        }

        [HttpPost]

        public ActionResult AddPelanggan(PelangganView kv)

        {

            if (ModelState.IsValid)

            {

                PelangganManager KM = new PelangganManager();

                KM.AddPelanggan(kv);

                return RedirectToAction("Welcome", "Home");

            }

            return View();

        }

        public ActionResult ManagePelangganPartial(string status = "")

        {

            //if (User.Identity.IsAuthenticated)

            //{

            string loginName = User.Identity.Name;

            PelangganManager KM = new PelangganManager();

            PelangganDataView KDV = new PelangganDataView();

            KDV.PelangganProfile = KM.GetPelangganData();

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

        public ActionResult UpdatePelangganData(int pelangganID, string noID, string

        nama, string alamat, string tlp1, string tlp2)

        {

            PelangganView KV = new PelangganView();

            KV.id_pelanggan = pelangganID;

            KV.no_id = noID;

            KV.nama = nama;

            KV.alamat = alamat;

            KV.no_tlp1 = tlp1;

            KV.no_tlp2 = tlp2;
            
            PelangganManager KM = new PelangganManager();

            KM.UpdatePelanggan(KV);

            return Json(new { success = true });

        }

        public ActionResult DeletePelanggan(int pelangganID)

        {

            PelangganManager KM = new PelangganManager();

            KM.DeletePelanggan(pelangganID);

            return Json(new { success = true });

        }

        public ActionResult Perubahan()

        {

            return View();

        }
    }
}