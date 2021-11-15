using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.Administration
{
    public class VerificationQuestion : BaseEntity
    {
        public string Question { get; set; }

        public virtual ICollection<UserVerificationAnswer> UserVerificationAnswers { get; set; }

    }
}
