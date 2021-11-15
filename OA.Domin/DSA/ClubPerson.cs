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
    public class ClubPerson : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public ClubPerson(ILazyLoader loader)
        {
            Loader = loader;
        }

        public ClubPerson()
        {

        }
        /// <summary>
        ///  النادي 
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Club")]
        public int? ClubId { get; set; }

        private Club _Club;

        [PropFlag("FK_REF")]
        public Club Club
        {
            get => Loader.Load(this, ref _Club);
            set => _Club = value;
        }
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
