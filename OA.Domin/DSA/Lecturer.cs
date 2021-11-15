using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA.Indexes
{
    public class Lecturer : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Lecturer(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Lecturer()
        {

        }

        /// <summary>
        /// نوع المحاضر(محلي - دولي) 
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
