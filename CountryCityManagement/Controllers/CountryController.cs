using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CountryCityManagement.Models;

namespace CountryCityManagement.Controllers
{
    public class CountryController : Controller
    {
        CountryDbGateway aCountryDbGateway = new CountryDbGateway();
        
        public ActionResult SaveCountry()
        {
            ViewBag.Countries = aCountryDbGateway.GetAll().OrderBy(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCountry(Country aCountry, HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var imagePath = Path.Combine(Server.MapPath("/Images"), fileName);
            file.SaveAs(imagePath);
            aCountry.ImageLocation = "/Images/" + fileName;
            aCountryDbGateway.SaveCountry(aCountry);
            ViewBag.Countries = aCountryDbGateway.GetAll().OrderBy(x => x.Name).ToList();
            return View();
        }

        public JsonResult CheckName(string name)
        {
            if (aCountryDbGateway.GetAll().FirstOrDefault(x => x.Name == name) == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Show(int? id)
        {
            ViewBag.Country = aCountryDbGateway.GetAll().FirstOrDefault(x => x.CountryId == id);
            ViewBag.Countries = aCountryDbGateway.GetAll().OrderBy(x => x.Name).ToList();
            return View("SaveCountry");
        }

    }
}