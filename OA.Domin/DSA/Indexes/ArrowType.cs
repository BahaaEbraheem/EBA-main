using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA.Indexes
{
    public class ArrowType : BaseEntity
    {

        /// <summary>
        /// اسم نوع السهم
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        public string Description { get; set; }





    }
}
