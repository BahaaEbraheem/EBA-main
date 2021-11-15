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
    public class Staff : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Staff(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Staff()
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
        /// نبذة
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]

        public bool IsActive { get; set; } = true;
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<TrainingExperience> TrainingExperience { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Course> Cource { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Lecturer> Lecturer { get; set; }

    }
}
