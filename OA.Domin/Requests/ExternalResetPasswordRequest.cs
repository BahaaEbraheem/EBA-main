using OA.Domin.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.Requests
{
    [NotMapped]
    public class ExternalResetPasswordRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public List<UserVerificationAnswerCreateRequest> UserVerificationAnswers { get; set; }

    }
}
