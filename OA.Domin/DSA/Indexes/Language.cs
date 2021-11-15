using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using OA.Domin.DSA.Indexes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
namespace OA.Domin.DSA.Indexes
{
    public class Language : BaseEntity
    {
    
        /// <summary>
        ///  اسم اللغة بالعربي
        /// </summary>
        public string Name_Ar { get; set; }
        /// <summary>
        /// اسم اللغة بالأجنبي
        /// </summary>
        public string Name_En { get; set; }
        /// <summary>
        /// ترميز اللغة
        /// </summary>
        public string Slug { get; set; }


        [DisplayName("Active")]
        public bool? IsActive { get; set; }
        /// <summary>
        /// وصف 
        /// </summary>
        public string Description { get; set; }


    }
}
