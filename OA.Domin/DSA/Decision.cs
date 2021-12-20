using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Decision : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Decision(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Decision()
        {

        }
        /// <summary>
        /// رقم القرار
        /// </summary>
        [DisplayName("Decision Number")]

        public string DecisionNum { get; set; }
        /// <summary>
        /// تاريخ القرار
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// المحتوى
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// الفحوى
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// وصف
        /// </summary>
        public string Description { get; set; }


        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<CommissionMember> CommissionMembers { get; set; }
    }
}
