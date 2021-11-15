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

namespace OA.Domin.DSA
{
    public class CourseSubscriberRequest : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public CourseSubscriberRequest(ILazyLoader loader)
        {
            Loader = loader;
        }

        public CourseSubscriberRequest()
        {

        }
        /// <summary>
        /// معرف الدورة
        /// </summary>
        [DisplayName("Training Course")]
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
        /// معرف حالة الطلب
        /// </summary>
        [PropFlag("FK")]
    

        [DisplayName("Request State")]
        public int? RequestStateId { get; set; }
        private RequestState _RequestState;
        [PropFlag("FK_REF")]
        public RequestState RequestState
        {
            get => Loader.Load(this, ref _RequestState);
            set => _RequestState = value;
        }
        /// <summary>
        /// معرف الشخص
        /// </summary>
        [PropFlag("FK")]

        [DisplayName("Person")]
        public int? PersonId { get; set; }

        private Person _Person;

        [PropFlag("FK_REF")]
        public Person Person
        {
            get => Loader.Load(this, ref _Person);
            set => _Person = value;
        }
        /// <summary>
        /// تاريخ الطلب
        /// </summary>
        [DisplayName("Request Date")]

        public DateTime? RequestDate { get; set; }
        /// <summary>
        /// رقم الطلب
        /// </summary>
        [DisplayName("Request Number")]

        public int? RequestNumber { get; set; }
        /// <summary>
        /// إيصال الدفع
        /// </summary>
        public string PaymentReceipt { get; set; }
        [DisplayName("Accepted")]
        public bool IsAccepted { get; set; } = false;
        /// <summary>
        /// وصف 
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;
   
  

    }
}
