using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaGrasso.Data.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please Neter your first name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter E-mail")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [Display(Name ="PAssowrd")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password")]
        [Display(Name = "Confirm")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
