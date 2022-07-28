using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Notification.Models
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        //[EmailAddress(ErrorMessage ="Email is not Valid")]
        public string Email { get; set; }

        [Required]
        //[RegularExpression("^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$ %^&*-]).{8,}$")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password Not Matched..!")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string address { get; set; }
    }
}
