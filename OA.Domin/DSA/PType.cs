﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
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
        public string Name_Ar { get; set; }
        public string Name_En { get; set; }
        public string Description { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<PersonType> PersonType { get; set; }

    }
}
