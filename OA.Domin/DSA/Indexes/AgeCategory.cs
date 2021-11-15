using System;
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
        public int? MinimumAge { get; set; }
        /// <summary>
        /// سنة التولد/الحد الأقصى
        /// </summary>
        public int? MaximumAge { get; set; }
        /// <summary>
        /// الدرجة
        /// </summary>
        public int? Degree { get; set; }
        /// <summary>
        /// حدود الانتقال بالدرجات
        /// </summary>
        public int? DegreesLimits { get; set; }
        
            


    }
}
