using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Indexes
{
    public class Nationality : BaseEntity
    {

        /// <summary>
        /// الرمز
        /// </summary>
        public int? Code { get; set; }
        public string Title_Ar { get; set; }
        public string Title_En { get; set; }
        /// <summary>
        /// رمز الهاتف
        /// </summary>
        public int? PhoneCode { get; set; }
        public string Description { get; set; }

    }
}
