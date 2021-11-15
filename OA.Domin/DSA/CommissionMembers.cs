using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class CommissionMembers : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public CommissionMembers(ILazyLoader loader)
        {
            Loader = loader;
        }

        public CommissionMembers()
        {

        }
        [PropFlag("FK")]
        [DisplayName("Administration Board")]

        public int? PersonId { get; set; }

        private Person _Person;

        [PropFlag("FK_REF")]
        public Person Person
        {
            get => Loader.Load(this, ref _Person);
            set => _Person = value;
        }

        [PropFlag("FK")]
        [DisplayName("Commission")]
        public int? CommissionId { get; set; }

        private Commission _Commission;

        [PropFlag("FK_REF")]
        public Commission Commission
        {
            get => Loader.Load(this, ref _Commission);
            set => _Commission = value;
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
        /// وصف 
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;


    }
}
