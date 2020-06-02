using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelApplication.ViewModels
{
    public class HotelViewModel
    {
       [Key]
        public int RoomId { get; set; }


        [Display(Name = "Room Number")]
        [Required(ErrorMessage = "Enter Room Number")]
       
        public string RoomNumber { get; set; }

        [Display(Name = "Room Price ")]
        [Required(ErrorMessage = "Enter Room Price")]
      
        public decimal RoomPrice { get; set; }

        [Display(Name = "Booking Status")]
        [Required(ErrorMessage = "Must Choose a BookingStatus")]
        public int BookingStatusId { get; set; }

        [Display(Name = "Room Type")]
        [Required(ErrorMessage = "Must Choose a Room Type")]
        public int RoomTypeId { get; set; }

        [Display(Name = "Room Image")]
        public string RoomImage { get; set; }
        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Room Capacity  ")]
        [Required(ErrorMessage = "Enter Room Capacity")]
        
       
        public int RoomCapacity { get; set; }

        [Display(Name = "Room Description  ")]
        [Required(ErrorMessage = "Enter Room Description")]
        public string RoomDescription { get; set; }
        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List<SelectListItem> ListOfRoomTypes { get; set; }
    }
}