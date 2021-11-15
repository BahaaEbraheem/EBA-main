using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.Requests
{
    [NotMapped]
    public class UserVerificationAnswerCreateRequest
    {
        public int VerificationQuestionId { get; set; }

        public string Answer { get; set; }
        
    }
}
