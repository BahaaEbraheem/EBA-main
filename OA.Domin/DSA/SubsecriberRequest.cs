//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using OA.Domin.Attributes;
//using OA.Domin.RequestFeatures;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;

//namespace OA.Domin.DSA.Indexes
//{
//    public class SubsecriberRequest : BaseEntity
//    {
//        private readonly ILazyLoader Loader;
//        public SubsecriberRequest(ILazyLoader loader)
//        {
//            Loader = loader;
//        }

//        public SubsecriberRequest()
//        {

//        }
//        /// <summary>
//        /// معرف الشخص
//        /// </summary>
//        [PropFlag("FK")]
//        [DisplayName("Person")]
//        [Required]
//        public int PersonId { get; set; }
//        private Person _Person;
//        [PropFlag("FK_REF")]
//        public Person Person
//        {
//            get => Loader.Load(this, ref _Person);
//            set => _Person = value;
//        }
//        /// <summary>
//        /// معرف حالة الطلب
//        /// </summary>
//        [PropFlag("FK")]

//        [DisplayName("Request State")]
//        [Required]

//        public int RequestStateId { get; set; }
//        private RequestState _RequestState;
//        [PropFlag("FK_REF")]
//        public RequestState RequestState
//        {
//            get => Loader.Load(this, ref _RequestState);
//            set => _RequestState = value;
//        }
//        /// <summary>
//        /// إيصال الدفع
//        /// </summary>
//        public string PaymentReceipt { get; set; }
//        /// <summary>
//        /// تاريخ الطلب
//        /// </summary>
//        public DateTime? RequestDate { get; set; }
//        /// <summary>
//        /// رقم الطلب
//        /// </summary>
//        public int? RequestNumber { get; set; }
//        /// <summary>
//        /// وصف 
//        /// </summary>
//        public string Description { get; set; }
//        [DisplayName("Accepted")]

//        public bool IsAccepted { get; set; } = false;
//        [DisplayName("Active")]

//        public bool IsActive { get; set; } = true;




//    }
//}
