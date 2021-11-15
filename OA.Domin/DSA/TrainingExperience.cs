using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OA.Domin.DSA.Indexes
{
    public class TrainingExperience : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public TrainingExperience(ILazyLoader loader)
        {
            Loader = loader;
        }

        public TrainingExperience()
        {

        }
        /// <summary>
        ///اسم الخبرة التدريبية بالعربي
        /// </summary>
        public string Name_Ar { get; set; }
        /// <summary>
        /// اسم الخبرة التدريبية بالأجنبي
        /// </summary>
        public string Name_En { get; set; }
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
