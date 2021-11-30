using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA.Indexes
{
    public class TrainingCourseType : BaseEntity
    {


        /// <summary>
        /// اسم نوع الدورة
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        public string Description { get; set; }




    }
}
