using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Person : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Person(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Person()
        {

        }
        /// <summary>
        /// اسم الشخص بالعربي
        /// </summary>
        public string Name_Ar { get; set; }
        /// <summary>
        /// اسم الشخص بالأجنبي
        /// </summary>
        public string Name_En { get; set; }
        /// <summary>
        /// تاريخ ميلاده
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
      
        /// <summary>
        /// الجنسية 
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Nationality")]

        public int? NationalityId { get; set; }

        private Nationality _Nationality;

        [PropFlag("FK_REF")]
        public Nationality Nationality
        {
            get => Loader.Load(this, ref _Nationality);
            set => _Nationality = value;
        }
        /// <summary>
        /// الجنس
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// رقم جواز السفر
        /// </summary>
        [DisplayName("Passpor Number")]

        public string PassporNumber { get; set; }
        /// <summary>
        /// تاريخ انتهاء جواز السفر
        /// </summary>
        [DisplayName("Passpor EndDate")]

        public string PassporEndDate { get; set; }
        /// <summary>
        /// رقم الهوية
        /// </summary>
        [DisplayName("Identification Number")]
        public string IdentificationNumber { get; set; }
        /// <summary>
        /// جهة العمل
        /// </summary>
        public string Employer { get; set; }
        /// <summary>
        /// الفاكس
        /// </summary>
        public DateTime? Fax { get; set; }
        /// <summary>
        /// الايميل
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// المؤهل العلمي
        /// </summary>
        public string Qualification { get; set; }
        /// <summary>
        ///المدينة
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// محل الإقامة
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// مسار الصورة الشخصية
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// رقم الهاتف
        /// </summary>
        [DisplayName("Phone Number")]
        /// 
        public int? PhoneNumber { get; set; }
        /// <summary>
        /// نبذة
        /// </summary>
        public string Description { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<CommissionMembers> CommissionMembers { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Club> ClubBossPerson { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Club> ClubManagerPerson { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Club> FinancialManagerPerson { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<PersonType> PersonType { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ClubPerson> ClubPerson { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<TechnicalData> TechnicalData { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<AdministrationBoard> AdministrationBoard { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Player> Player { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Staff> Trainer { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ImportantAchievement> ImportantAchievement { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<PersonRequestState> PersonRequestState { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Match> FirstArbitratorMatch { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Match> SecondArbitratorMatch { get; set; }
       

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<CourseSubscriberRequest> CourseSubscriberRequest { get; set; }
    }
}
