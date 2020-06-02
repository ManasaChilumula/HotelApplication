using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;

namespace HotelApplication.Controllers
{
    public class RegisterController : Controller
    {
        HotelDBEntities objHotelDBEntities = new HotelDBEntities();

        public ActionResult Index()
        {
            CustomerRegisterViewModel objRegisterViewModel = new CustomerRegisterViewModel();
            objRegisterViewModel.ListOfCountries = (from obj in objHotelDBEntities.Countries
                                                    select new SelectListItem()
                                                    {
                                                        Text = obj.CountryName,
                                                        Value = obj.CountryId.ToString(),
                                                    }).ToList();
            
            return View(objRegisterViewModel);
        }
        [HttpPost]
        public ActionResult SaveData(RegisterTable objRegister)
        {
            if (ModelState.IsValid)
            {
                using (HotelDBEntities objHotelDBEntities = new HotelDBEntities())
                {
                    objHotelDBEntities.RegisterTables.Add(objRegister);
                    objHotelDBEntities.SaveChanges();
                }
                ModelState.Clear();
               
            }
            return RedirectToAction("Index");
        }
        public PartialViewResult NavMenu()
        {
            return PartialView();
        }
        public ActionResult GetState(int? countryId)
        {
            var ListOfStates = objHotelDBEntities.States.Where(m => m.CountryId == countryId)
                                                       .Select(m => new SelectListItem
                                                       {
                                                           Text = m.StateName,
                                                           Value = m.StateId.ToString(),
                                                       }).ToList();
                                                        
                return Json(ListOfStates,JsonRequestBehavior.AllowGet);
        }

          
    }
}