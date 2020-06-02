using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HotelApplication.ViewModels
{
    public class CustomerRegisterViewModel
    {
        [Key]
        public int RegiserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Enter Gender")]
        public string Gender { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Enter Mobile naumber")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Display(Name = "Country")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Error: Must Choose a Country")]
        public string Country { get; set; }
        [Display(Name = "State")]
        [Required, Range(1, int.MaxValue, ErrorMessage = "Error: Must Choose a Country")]
        public string State { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "Enter City Name")]
        public string City { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter Address Name")]
        public string Address { get; set; }

        public List<SelectListItem> ListOfCountries { get; set; }
       
    }
}