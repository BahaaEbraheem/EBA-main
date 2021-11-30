using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA.Indexes
{
    public class Nationality : BaseEntity
    {

        /// <summary>
        /// الرمز
        /// </summary>
        public string Code { get; set; }
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        /// <summary>
        /// رمز الهاتف
        /// </summary>
        public string PhoneCode { get; set; }
        public string Description { get; set; }

    }
}
