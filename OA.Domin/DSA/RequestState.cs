using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Domin.DSA.Indexes
{
    public class RequestState : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public RequestState(ILazyLoader loader)
        {
            Loader = loader;
        }

        public RequestState()
        {

        }
        /// <summary>
        ///اسم حالة الطلب
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// الوصف
        /// </summary>
        public string Description { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<PersonRequestState> PersonRequestState { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<CourseSubscriberRequest> CourseSubscriberRequest { get; set; }
        //[PropFlag("FK_REF_COLL")]
        //public virtual ICollection<SubsecriberRequest> SubsecriberRequest { get; set; }

    }
}
