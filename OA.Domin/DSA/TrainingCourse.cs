using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA.Indexes
{
    public class TrainingCourse : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public TrainingCourse(ILazyLoader loader)
        {
            Loader = loader;
        }

        public TrainingCourse()
        {

        }
        /// <summary>
        ///اسم الدورة التدريبية بالعربي
        /// </summary>
        public string Name_Ar { get; set; }
        /// <summary>
        /// اسم الدورة التدريبية بالأجنبي
        /// </summary>
        public string Name_En { get; set; }
        /// <summary>
        /// تاريخ بدايةالدورةالتدريبية 
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// تاريخ نهايةالدورةالتدريبية  
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// تاريخ انتهاء التسجيل 
        /// </summary>
        public string RegistrationEndDate { get; set; }
        /// <summary>
        /// نوع الدورة التدريبية(في الموقع-مخفية) 
        /// </summary>
        public CoursePosition CoursePosition { get; set; } = CoursePosition.InSite;
        /// <summary>
        ///  معرف نوع الدورة 
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("TrainingCourse Type")]
        [Required]
        public int TrainingCourseTypeId { get; set; }

        private TrainingCourseType _TrainingCourseType;

        [PropFlag("FK_REF")]
        public TrainingCourseType TrainingCourseType
        {
            get => Loader.Load(this, ref _TrainingCourseType);
            set => _TrainingCourseType = value;
        }
        /// <summary>
        ///  معرف نوع الشخص 
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Person Type")]
        [Required]
        public int PersonTypeId { get; set; }

        private PersonType _PersonType;

        [PropFlag("FK_REF")]
        public PersonType PersonType
        {
            get => Loader.Load(this, ref _PersonType);
            set => _PersonType = value;
        }
        /// <summary>
        /// مسار الصورة الشخصية
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// الوصف بالعربي
        /// </summary>
        public string Description_Ar { get; set; }
        /// <summary>
        /// الوصف بالاجنبي
        /// </summary>
        public string Description_Er { get; set; }
        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<CourseSubscriberRequest> CourseSubscriberRequest { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Album> Album { get; set; }


    }
}
