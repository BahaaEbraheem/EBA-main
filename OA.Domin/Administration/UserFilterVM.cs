using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.Administration
{
    [NotMapped]
    public class UserFilterVM
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string RoleId { get; set; }

        public int? BranchId { get; set; }

    }
}
