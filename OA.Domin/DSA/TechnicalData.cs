using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OA.Domin.DSA.Indexes
{
    public class TechnicalData : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public TechnicalData(ILazyLoader loader)
        {
            Loader = loader;
        }
        public TechnicalData()
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
        ///سنوات الخبرة
        /// </summary>
        [DisplayName("YearsOf Practice")]

        public int? YearsOfPractice { get; set; }
        /// <summary>
        /// المباراة المحلية
        /// </summary>
        [DisplayName("Local Matches")]

        public int? LocalMatches { get; set; }
        /// <summary>
        /// المباريات الدولية
        /// </summary>
        [DisplayName("International Matches")]

        public int? InternationalMatches { get; set; }
        /// <summary>
        /// بدلة التدريب
        /// </summary>
        public string TrainingSuit { get; set; }
        /// <summary>
        /// القميص الرياضي
        /// </summary>
        public string SportShirt { get; set; }
        /// <summary>
        /// الحذاء الرياضي
        /// </summary>
        public string Sportshoe { get; set; }
        /// <summary>
        /// الطول
        /// </summary>
        public float? Height { get; set; }
        /// <summary>
        /// الوزن
        /// </summary>
        public float? Weight { get; set; }
        /// <summary>
        /// الأرقام القياسية
        /// </summary>
        [DisplayName("Standard Number")]

        public string StandardNumber { get; set; }
        /// <summary>
        /// النظر
        /// </summary>
        public string Look { get; set; }
        /// <summary>
        /// الوصف
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]

        public bool IsActive { get; set; } = true;


    }
}
