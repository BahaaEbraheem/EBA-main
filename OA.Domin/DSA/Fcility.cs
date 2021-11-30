using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace OA.Domin.DSA.Indexes
{
    public class Fcility : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Fcility(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Fcility()
        {

        }
        /// <summary>
        ///اسم المنشأة بالعربي
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        /// <summary>
        /// اسم المنشأة بالأجنبي
        /// </summary>
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        /// <summary>
        ///  النادي 
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Club")]

        public int? ClubId { get; set; }

        private Club _Club;

        [PropFlag("FK_REF")]
        public Club Club
        {
            get => Loader.Load(this, ref _Club);
            set => _Club = value;
        }
        /// <summary>
        /// النوع
        /// </summary>
        public int? Type { get; set; }
        /// <summary>
        /// العدد
        /// </summary>
        public int? Number { get; set; }
        /// <summary>
        /// منشأة تخصصية
        /// </summary>
        [DisplayName("Is Specialty")]
        /// 
        public bool IsSpecialty { get; set; }
        /// <summary>
        /// الوصف
        /// </summary>
        public string Description { get; set; }





    }
}
