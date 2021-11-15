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
    public class ImportantAchievement : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public ImportantAchievement(ILazyLoader loader)
        {
            Loader = loader;
        }

        public ImportantAchievement()
        {

        }
        /// <summary>
        ///اسم الإنجاز بالعربي
        /// </summary>
        public string Name_Ar { get; set; }

        /// <summary>
        /// نوع الإنجاز
        /// </summary>
        [DisplayName("Achievement Type")]

        public string AchievementType { get; set; }
        /// <summary>
        ///  معرف الشخص 
        /// </summary>
        [DisplayName("Person")]

        [PropFlag("FK")]
        public int? PersonId { get; set; }

        private Person _Person;

        [PropFlag("FK_REF")]
        public Person Person
        {
            get => Loader.Load(this, ref _Person);
            set => _Person = value;
        }

        /// <summary>
        /// الوصف
        /// </summary>
        public string Description { get; set; }





    }
}
