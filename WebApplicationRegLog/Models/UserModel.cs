using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationRegLog.Models
{
    public class UserModel
    {

        public string UserID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Compare("Password")]

        public string ConfirmPassword { get; set; }
    }
}