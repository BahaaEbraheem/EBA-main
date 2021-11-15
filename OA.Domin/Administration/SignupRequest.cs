using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.Administration
{
    public class SignupRequest : BaseEntity
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public bool? Confirmed { get; set; }

        public string Reason { get; set; }

    }
}
