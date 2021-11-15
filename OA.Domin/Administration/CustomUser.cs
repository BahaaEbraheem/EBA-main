using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;

namespace OA.Domin.Administration
{
    public class CustomUser
    {
        public string Id { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        [DisplayName("Direct Manager User")]
        public string ManagerId { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Branch")]
        public int? BranchId { get; set; }

        public bool ConfirmedAccount { get; set; }

        public virtual IEnumerable<CustomRole> Roles { get; set; }
        public virtual IEnumerable<Claim> Claims { get; set; }
    }
}
