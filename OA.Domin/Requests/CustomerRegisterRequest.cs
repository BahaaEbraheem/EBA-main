using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.Requests
{
    [NotMapped]
    public class CustomerRegisterRequest
    {

        public string Email { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }

        public List<UserVerificationAnswerCreateRequest> UserVerificationAnswers { get; set; }

    }
}
