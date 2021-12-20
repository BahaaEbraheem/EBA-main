using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Commission : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Commission(ILazyLoader loader)
        {
            Loader = loader;
        }
        public Commission() => CommissionMembers = new List<CommissionMember>();
        /// <summary>
        /// اسم اللجنة بالعربي
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        /// <summary>
        /// اسم اللجنة بالأجنبي
        /// </summary>
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        /// <summary>
        /// وصف
        /// </summary>
        public string Description { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<CommissionMember> CommissionMembers { get; set; }

    }
}
