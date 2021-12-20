using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.ViewModels;
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
    public class AdministrationBoard : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public AdministrationBoard(ILazyLoader loader)
        {
            Loader = loader;
        }

        public AdministrationBoard()
        {
            Person = new Person();
        }


        /// <summary>
        /// معرف الشخص
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Person")]
        [Required]
        public int PersonId { get; set; }
        private Person _Person;
        [PropFlag("FK_REF")]
        public Person Person
        {
            get => Loader.Load(this, ref _Person);
            set => _Person = value;
        }


        /// <summary>
        /// تاريخ الدورة الانتخابية
        /// </summary>
        [DisplayName("Electoral Cycle")]
        public DateTime ElectoralCycle { get; set; }
    
        /// <summary>
        /// الوظيفة
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// المنصب
        /// </summary>
        public string Position { get; set; }
  
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<CommissionMember> CommissionMembers { get; set; }
    }
}
