using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domain.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
