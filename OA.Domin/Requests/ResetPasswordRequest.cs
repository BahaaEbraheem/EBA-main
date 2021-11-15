using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Requests
{
    public class ResetPasswordRequest
    {
        public string Id { get; set; }

        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password Confirmation Missmatch")]
        public string PasswordConfirm { get; set; }

    }
}
