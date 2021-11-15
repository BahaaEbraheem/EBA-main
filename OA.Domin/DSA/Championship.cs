using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OA.Domin.DSA.Indexes
{
    public class Championship : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Championship(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Championship()
        {

        }
        /// <summary>
        ///اسم البطولة
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name_Ar { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }

        /// <summary>
        /// معرف الفئة العمرية
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Age Category")]
        public int? AgeCategoryId { get; set; }
        private AgeCategory _AgeCategory;
        [PropFlag("FK_REF")]
        public AgeCategory AgeCategory
        {
            get => Loader.Load(this, ref _AgeCategory);
            set => _AgeCategory = value;
        }
        /// <summary>
        /// معرف نوع البطولة
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Championship Type")]
        public int? ChampionshipTypeId { get; set; }
        private ChampionshipType _ChampionshipType;
        [PropFlag("FK_REF")]
        public ChampionshipType ChampionshipType
        {
            get => Loader.Load(this, ref _ChampionshipType);
            set => _ChampionshipType = value;
        }
        /// <summary>
        /// معرف تصنيف البطولة
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Championship Ranking")]
        public int? ChampionshipRankingId { get; set; }
        private ChampionshipRanking _ChampionshipRanking;
        [PropFlag("FK_REF")]
        public ChampionshipRanking ChampionshipRanking
        {
            get => Loader.Load(this, ref _ChampionshipRanking);
            set => _ChampionshipRanking = value;
        }
        /// <summary>
        /// معرف نوع القوس
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Arrow Type")]

        public int? ArrowTypeId { get; set; }
        private ArrowType _ArrowType;
        [PropFlag("FK_REF")]
        public ArrowType ArrowType
        {
            get => Loader.Load(this, ref _ArrowType);
            set => _ArrowType = value;
        }
        /// <summary>
        /// تاريخ البداية
        /// </summary>
        [DisplayName("Start Date")]

        public DateTime? StartDate { get; set; }
        /// <summary>
        /// تاريخ النهاية
        /// </summary>
        [DisplayName("End Date")]

        public DateTime? EndDate { get; set; }
        /// <summary>
        /// مسار الصورة الشخصية
        /// </summary>
        [DisplayName("Image Path")]

        public string ImagePath { get; set; }

        /// <summary>
        /// نبذة
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]

        public bool IsActive { get; set; } = true;

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ChampionshipRole> ChampionshipRole { get; set; }


    }
}
