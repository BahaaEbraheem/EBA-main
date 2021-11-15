using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Player : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Player(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Player()
        {

        }
        /// <summary>
        /// معرف الشخص
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Person")]
        [Required]
        public int? PersonId { get; set; }
        private Person _Person;
        [PropFlag("FK_REF")]
        public Person Person
        {
            get => Loader.Load(this, ref _Person);
            set => _Person = value;
        }
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
      /// معرف الصفة
      /// </summary>
        [PropFlag("FK")]
        [DisplayName("Adjective")]

        public int? AdjectiveId { get; set; }
        private Adjective _Adjective;
        [PropFlag("FK_REF")]
        public Adjective Adjective
        {
            get => Loader.Load(this, ref _Adjective);
            set => _Adjective = value;
        }

        /// <summary>
        /// تاريخ ميلاده
        /// </summary>
        public DateTime? Coach { get; set; }

        /// <summary>
        /// الجنس
        /// </summary>
        public string WeaponType   { get; set; }
        /// <summary>
        /// رقم جواز السفر
        /// </summary>
        public string WeaponNumber { get; set; }
        /// <summary>
        /// رقم الهوية
        /// </summary>
        public string WeaponModel { get; set; }
        /// <summary>
        /// نبذة
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]

        public bool IsActive { get; set; } = true;
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ChampionshipClubPlayer> ChampionshipClubPlayer { get; set; }
    }
}
