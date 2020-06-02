using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelApplication.Models;
using HotelApplication.ViewModels;


namespace HotelApplication.Controllers
{
    public class BookingController : Controller
    {
        HotelDBEntities objHotelDBEntities = new HotelDBEntities();
        // GET: Booking

        public ActionResult Index()
        {
            BookingViewModel objBookingViewModel = new BookingViewModel();
            objBookingViewModel.ListOfRooms = (from objRoom in objHotelDBEntities.Rooms
                                               select new SelectListItem
                                               {
                                                   Text = objRoom.RoomNumber,
                                                   Value = objRoom.RoomId.ToString()
                                               }).ToList();
            objBookingViewModel.BookingFrom = DateTime.Now;
            objBookingViewModel.BookingTo = DateTime.Now.AddDays(1);


            return View(objBookingViewModel);
        }
        [HttpPost]
        public ActionResult SaveBookingDetails(BookingViewModel objBookingViewModel)
        {
            if (ModelState.IsValid)
            {
                int NoOfdays = Convert.ToInt32((objBookingViewModel.BookingTo - objBookingViewModel.BookingFrom).TotalDays);
                Room objRoom = objHotelDBEntities.Rooms.Single(model => model.RoomId == objBookingViewModel.AssignRoomId);
                decimal RoomPrice = objRoom.RoomPrice;
                decimal TotalPrice = RoomPrice * NoOfdays;
                RoomBooking objRoomBooking = new RoomBooking()
                {
                    CustomerName = objBookingViewModel.CustomerName,
                    CustomerAddress = objBookingViewModel.CustomerAddress,
                    BookingFrom = objBookingViewModel.BookingFrom,
                    BookingTo = objBookingViewModel.BookingTo,
                    AssignRoomId = objBookingViewModel.AssignRoomId,
                    NoOfMembers = objBookingViewModel.NoOfMembers,
                    TotalAmount = TotalPrice
                };
         
            objHotelDBEntities.RoomBookings.Add(objRoomBooking);
            }
            objHotelDBEntities.SaveChanges();

            return RedirectToAction("Index");

        }
       public PartialViewResult GetBookings()
        {
            BookingViewModel objBookingViewModel = new BookingViewModel();

            IEnumerable<BookingViewModel> ObjGetAllDetails = (from objbooking in objHotelDBEntities.RoomBookings

                                                              select new BookingViewModel()
                                                              {
                                                                  CustomerName = objbooking.CustomerName,
                                                                  CustomerAddress = objbooking.CustomerAddress,
                                                                  AssignRoomId = objbooking.AssignRoomId,
                                                                  BookingFrom = objbooking.BookingFrom,
                                                                  BookingTo = objbooking.BookingTo,
                                                                  NoOfMembers = objbooking.NoOfMembers,
                                                                  TotalAmount=objbooking.TotalAmount,
                                                                  
                                                              }).ToList();
            return PartialView("~/Views/Shared/_RoomDetailsPartial.cshtml", ObjGetAllDetails);
        }
    }
}