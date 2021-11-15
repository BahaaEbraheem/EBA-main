using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA.Indexes
{
    public class Course : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Course(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Course()
        {

        }
        /// <summary>
        ///اسم الدورة التدريبية بالعربي
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name_Ar { get; set; }
        /// <summary>
        /// اسم الدورة التدريبية بالأجنبي
        /// </summary>
        [DisplayName("Name/En")]

        public string Name_En { get; set; }
        /// <summary>
        /// نوع الدورة (محلي - دولي) 
        /// </summary>
        public CourseType CourseType { get; set; }
        /// <summary>
        ///  معرف الإداري أو الفني 
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Staff")]

        public int? StaffId { get; set; }

        private Staff _Staff;

        [PropFlag("FK_REF")]
        public Staff Staff
        {
            get => Loader.Load(this, ref _Staff);
            set => _Staff = value;
        }

        /// <summary>
        /// الوصف
        /// </summary>
        public string Description { get; set; }





    }
}
