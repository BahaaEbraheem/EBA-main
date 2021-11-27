﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA.Indexes
{
    public class AgeCategory : BaseEntity
    {

        
      /// <summary>
      /// اسم الفئة العمرية
      /// </summary>
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        /// <summary>
        /// سنة التولد/الحد الأدنى
        /// </summary>
        public string MinimumAge { get; set; }
        /// <summary>
        /// سنة التولد/الحد الأقصى
        /// </summary>
        public string MaximumAge { get; set; }
        /// <summary>
        /// الدرجة
        /// </summary>
        public string Degree { get; set; }
        /// <summary>
        /// حدود الانتقال بالدرجات
        /// </summary>
        public string DegreesLimits { get; set; }
        
            


    }
}
