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
    public class PersonType : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public PersonType(ILazyLoader loader)
        {
            Loader = loader;
        }

        public PersonType()
        {

        }
        [PropFlag("FK")]
        [DisplayName("Person Type")]
        [Required]
        public int? PTypeId { get; set; }

        private PType _PType;

        [PropFlag("FK_REF")]
        public PType PType
        {
            get => Loader.Load(this, ref _PType);
            set => _PType = value;
        }

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
        /// تاريخ البداية
        /// </summary>
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاريخ النهاية
        /// </summary>
        [DisplayName("End Date")]

        public DateTime EndDate { get; set; }
        /// <summary>
        /// وصف 
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<TrainingCourse> TrainingCourse { get; set; }
        public string PTypeName { get; set; }
    }
}
