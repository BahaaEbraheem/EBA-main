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
        [DisplayName("Decision Num")]

        public int? DecisionNum { get; set; }
        /// <summary>
        /// تاريخ القرار
        /// </summary>
        public DateTime? Date { get; set; }
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


        [PropFlag("FK")]
        [DisplayName("Commission")]

        public int? CommissionId { get; set; }

        private Commission _Commission;

        [PropFlag("FK_REF")]
        public Commission Commission
        {
            get => Loader.Load(this, ref _Commission);
            set => _Commission = value;
        }

    }
}
