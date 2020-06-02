using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelApplication.ViewModels
{
    public class RoomDetailsViewModel
   
    {
    [Key]
        public int RoomId { get; set; }


        [Display(Name ="Room Number")]
        [Required(ErrorMessage ="Enter Room Number")]
        [MaxLength(4)]
        [MinLength(3)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Room must be numeric")]
        public string RoomNumber { get; set; }


        [Display(Name = "Room Price ")]
        [Required(ErrorMessage = "Enter Room Price")]
         public decimal RoomPrice { get; set; }


        [Display(Name = "Booking Status")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Error: Must Choose a BookingStatus")]
        public String BookingStatus { get; set; }


        [Display(Name = "RoomType")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Error: Must Choose a RoomType")]
        public String RoomType { get; set; }


        [Display(Name = "Room Image ")]
        [Required(ErrorMessage = "Upload Room Image")]
        public String RoomImage { get; set; }


        [Display(Name = "Room Capacity  ")]
        [Required(ErrorMessage = "Enter Room Capacity")]
        [MaxLength(4)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Room Capacity must be numeric")]
        public int RoomCapacity { get; set; }

        [Display(Name = "Room Description  ")]
        [Required(ErrorMessage = "Enter Room Description")]
        public string RoomDescription { get; set; }
       

    }
}