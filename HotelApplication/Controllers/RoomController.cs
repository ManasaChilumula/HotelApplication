using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.ViewModels;
using HotelApplication.Models;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace HotelApplication.Controllers
{
    public class RoomController : Controller
    {
        HotelDBEntities objHotelDBEntities = new HotelDBEntities();
        public ActionResult Index()
        {
            HotelViewModel objrooms = new HotelViewModel();
            objrooms.ListOfBookingStatus = (from obj in objHotelDBEntities.BookingStatus
                                            select new SelectListItem()
                                            {
                                                Text = obj.BookingStatus,
                                                Value = obj.BookingStatusId.ToString(),

                                            }).ToList();

            objrooms.ListOfRoomTypes = (from obj in objHotelDBEntities.RoomTypes
                                        select new SelectListItem()
                                        {
                                            Text = obj.RoomName,
                                            Value = obj.RoomTypeId.ToString(),
                                        }).ToList();

            return View(objrooms);


        }
        [HttpPost]
        public ActionResult SaveRoomDetails(HotelViewModel objHotelViewModel)
        {

            string UniqueName = Guid.NewGuid().ToString();
            string ActualName = UniqueName + Path.GetFileName(objHotelViewModel.Image.FileName);
            objHotelViewModel.Image.SaveAs(Server.MapPath("~/Images/" + ActualName));
            if (objHotelViewModel.RoomId==0) { 
            Room objRoom = new Room()
            {

                RoomNumber = objHotelViewModel.RoomNumber,
                RoomPrice = objHotelViewModel.RoomPrice,
                IsActive = true,
                BookingStatusId = objHotelViewModel.BookingStatusId,

                RoomTypeId = objHotelViewModel.RoomTypeId,
                RoomCapacity = objHotelViewModel.RoomCapacity,
                RoomDescription = objHotelViewModel.RoomDescription,
                RoomImage = ActualName,

            };

            objHotelDBEntities.Rooms.Add(objRoom);
        }
            else
            {
                Room objRoom = objHotelDBEntities.Rooms.Single(model => model.RoomId == objHotelViewModel.RoomId);
                objRoom.RoomNumber = objHotelViewModel.RoomNumber;
                objRoom.RoomPrice = objHotelViewModel.RoomPrice;
                objRoom.IsActive = true;
                objRoom.BookingStatusId = objHotelViewModel.BookingStatusId;
                objRoom.RoomTypeId = objHotelViewModel.RoomTypeId;
                objRoom.RoomCapacity = objHotelViewModel.RoomCapacity;
                objRoom.RoomDescription = objHotelViewModel.RoomDescription;
                objRoom.RoomImage = ActualName;
            }




            objHotelDBEntities.SaveChanges();

          

            return RedirectToAction("Index");

        }
       
        public PartialViewResult GetAllRoomDetails()
        {
            IEnumerable<RoomDetailsViewModel> ObjGetAllDetails = (from objRoom in objHotelDBEntities.Rooms
                                                                  join objBooking in objHotelDBEntities.BookingStatus on objRoom.BookingStatusId
                                                                  equals objBooking.BookingStatusId
                                                                  join objRoomType in objHotelDBEntities.RoomTypes on objRoom.RoomTypeId
                                                                  equals objRoomType.RoomTypeId where objRoom.IsActive==true

                                                                 
                                                                  select new RoomDetailsViewModel()
                                                                  {
                                                                      RoomNumber = objRoom.RoomNumber,
                                                                      RoomPrice = objRoom.RoomPrice,
                                                                      BookingStatus = objBooking.BookingStatus,
                                                                      RoomCapacity = objRoom.RoomCapacity,
                                                                      RoomDescription = objRoom.RoomDescription,
                                                                      RoomType = objRoomType.RoomName,
                                                                      RoomId=objRoom.RoomId,
                                                                      
                                                                      

                                                                  }).ToList();
            return PartialView("~/Views/Shared/_RoomDetailsPartial.cshtml", ObjGetAllDetails);
        }
        [HttpGet]
        public JsonResult EditRoomDetails(int roomId)
        {
            var ObjEditRoomDetails = objHotelDBEntities.Rooms.Single(model => model.RoomId == roomId);
            return Json(ObjEditRoomDetails, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteRoom(int roomId)
        {
            Room objRooms = objHotelDBEntities.Rooms.Single(model => model.RoomId == roomId);
            objRooms.IsActive = false;
            objHotelDBEntities.SaveChanges();
            return Json("Record Deleted", JsonRequestBehavior.AllowGet);
        }

        private class Reportdocument
        {
            public Reportdocument()
            {
            }
        }

        private class ReportDocument
        {
        }
    }
}