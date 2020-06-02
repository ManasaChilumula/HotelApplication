using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelApplication.ViewModels
{
    public class BookingViewModel
    {
        [Key]
        public int BookingId { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer Name  is required")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Address")]
        [Required(ErrorMessage = "CustomerAddress  is required")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Booking From")]
        [Required(ErrorMessage = "Booking From is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingFrom { get; set; }

        [Display(Name = "Booking To")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "BookingTo is required")]
        public DateTime BookingTo { get; set; }
        [Display(Name = "Assign RoomId")]
        [Required(ErrorMessage = "Please Select Room Id")]
        public int AssignRoomId { get; set; }

        [Display(Name = "No Of Members")]
        [Required(ErrorMessage = "Enter Number of members")]
        public int NoOfMembers { get; set; }
        public decimal TotalAmount { get; set; }

        public IEnumerable<SelectListItem> ListOfRooms { get; set; }
    }
}