using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA
{
    public class Album : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Album(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Album()
        {

        }
        /// <summary>
        /// اسم الألبوم عربي
        /// </summary>
        public string Name_Ar { get; set; }
        /// <summary>
        /// اسم الألبوم أجنبي
        /// </summary>
        public string Name_En { get; set; }
        /// <summary>
        ///  معرف الدورة التدريبية 
        /// </summary>
        [PropFlag("FK")]
        public int? TrainingCourseId { get; set; }

        private TrainingCourse _TrainingCourse;

        [PropFlag("FK_REF")]
        public TrainingCourse TrainingCourse
        {
            get => Loader.Load(this, ref _TrainingCourse);
            set => _TrainingCourse = value;
        }
        /// <summary>
        /// رابط الفيديو
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        /// نوع الألبوم
        /// </summary>
        public AlbumType AlbumType { get; set; }
        /// <summary>
        /// فئة الألبوم
        /// </summary>
        public AlbumCategory AlbumCategory { get; set; }
        /// <summary>
        /// وصف بالعربي
        /// </summary>
        public string Description_Ar { get; set; }

        /// <summary>
        /// تاريخ انشاء  
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// وصف بالأجنبي
        /// </summary>
        public string Description_En { get; set; }
      
        [PropFlag("FK")]
        [DisplayName("Language")]
        public int? LanguageId { get; set; }

        [PropFlag("FK_REF")]
        public virtual Language Language { get; set; }
        /// <summary>
        /// هل هو مدمج 
        /// </summary>
        public bool? Bulit_In { get; set; } 
        /// <summary>
        /// هل هو YouTube
        /// </summary>
        [DisplayName("Visible")]

        public bool IsVisible { get; set; } = true;
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<AlbumContent> AlbumContent { get; set; }
    }
}
