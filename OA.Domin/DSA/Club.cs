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
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA
{
    public class Club : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Club(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Club()
        {

        }
        /// <summary>
        /// اسم النادي بالعربي
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name_Ar { get; set; }
        /// <summary>
        /// اسم النادي بالأجنبي
        /// </summary>
        [DisplayName("Name/En")]

        public string Name_En { get; set; }
        /// <summary>
        /// نوع النشاط
        /// </summary>
        [DisplayName("Active Type")]

        public string ActiveType { get; set; }
        /// <summary>
        /// الإمارة التي تقع بها مركز التدريب
        /// </summary>
        public Emirate Emirate { get; set; }
        /// <summary>
        /// رئيس النادي
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Club Boss")]
        public int? ClubBossId { get; set; }

        private Person _ClubBoss;

        [PropFlag("FK_REF")]
        [InverseProperty("ClubBossPerson")]
        public Person ClubBoss
        {
            get => Loader.Load(this, ref _ClubBoss);
            set => _ClubBoss = value;
        }

        /// <summary>
        ///مدير النادي
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Club Manager")]
        public int? ClubManagerId { get; set; }

        private Person _ClubManager;

        [PropFlag("FK_REF")]
        [InverseProperty("ClubManagerPerson")]

        public Person ClubManager
        {
            get => Loader.Load(this, ref _ClubManager);
            set => _ClubManager = value;
        }

        /// <summary>
        /// المدير المالي
        /// </summary>
        [DisplayName("Financial Manager")]
        [PropFlag("FK")]
        public int? FinancialManagerId { get; set; }

        private Person _FinancialManager;

        [PropFlag("FK_REF")]
        [InverseProperty("FinancialManagerPerson")]

        public Person FinancialManager
        {
            get => Loader.Load(this, ref _FinancialManager);
            set => _FinancialManager = value;
        }

        /// <summary>
        /// النوع(نادي- مركز تدريب
        /// </summary>
        public ClubType ClubType { get; set; }
        /// <summary>
        /// تاريخ الإشهار
        /// </summary>
        [DisplayName("Advertising Date")]

        public DateTime? AdvertisingDate { get; set; }
        /// <summary>
        /// الايميل
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// الفاكس
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        ///المدينة
        /// </summary>
        public string City_Ar { get; set; }
        /// <summary>
        ///المدينة
        /// </summary>
        public string City_En { get; set; }
        /// <summary>
        /// الموقع الالكتروني
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// محل الإقامة
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// مسار الصورة الشخصية
        /// </summary>
        [DisplayName("Image Path")]

        public string ImagePath { get; set; }
        /// <summary>
        /// رقم الهاتف
        /// </summary>
        [DisplayName("Phone Number")]

        public int? PhoneNumber { get; set; }

        /// <summary>
        /// فئة الرجال
        /// </summary>
        [DisplayName("Men Category")]

        public int? MenCategory { get; set; }

        /// <summary>
        /// فئة السيدات
        /// </summary>
        [DisplayName("Women Category")]

        public int? WomenCategory { get; set; }
        /// <summary>
        /// فئة الناشئين
        /// </summary>
        [DisplayName("YoungMen Category")]

        public int? YoungMenCategory { get; set; }
        /// <summary>
        /// فئة الناشئات
        /// </summary>
        [DisplayName("YoungWoMen Category")]

        public int? YoungWomenCategory { get; set; }
        /// <summary>
        /// عدد المدربين
        /// </summary>
        [DisplayName("Coaches Number")]

        public int? CoachesNumber { get; set; }
        /// <summary>
        /// عدد الإداريين
        /// </summary>
        [DisplayName("Administrators Number")]

        public int? AdministratorsNumber { get; set; }
        /// <summary>
        /// الوصف
        /// </summary>
        public string Description { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ClubPerson> ClubPerson { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Fcility> Fcility { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Match> FirstTeamMatch { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Match> SecondTeamMatch { get; set; }
    }
}
