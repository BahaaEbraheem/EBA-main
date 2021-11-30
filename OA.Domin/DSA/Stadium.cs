using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using static OA.Domin.StaticIndexes;
using System.ComponentModel;

namespace OA.Domin.DSA.Indexes
{
    public class Stadium : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Stadium(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Stadium()
        {

        }
        /// <summary>
        ///اسم الصالة الرياضية
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        /// <summary>
        /// عدد الجمهور
        /// </summary>
        public int? Crowd { get; set; }
        /// <summary>
        /// طول الصالة بالمتر
        /// </summary>
        public int? height_m { get; set; }
        /// <summary>
        /// عرض الصالة بالمتر
        /// </summary>
        public int? Width_m { get; set; }
        /// <summary>
        /// موقع الصالة بالعربي
        /// </summary>
        public string Position_Ar { get; set; }
        /// <summary>
        /// موقع الصالة بالاجنبي
        /// </summary>
        public string Position_En { get; set; }
        /// <summary>
        /// الإمارة التي تقع بها الصالة
        /// </summary>
        public Emirate Emirate { get; set; }
        /// <summary>
        /// حالة إضاءة الصالة
        /// </summary>
        public LightState lightState { get; set; }
        //public string LightState { get; set; }
        /// <summary>
        /// حالة مشغوليةالصالة
        /// </summary>
        //public string StadiumState { get; set; }
        public StadiumState StadiumState { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Match> Match { get; set; }



    }
}
