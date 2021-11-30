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
    public class PType : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public PType(ILazyLoader loader)
        {
            Loader = loader;
        }

        public PType()
        {

        }
        /// <summary>
        /// اسم نوع الشخص
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        public string Description { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<PersonType> PersonType { get; set; }

    }
}
