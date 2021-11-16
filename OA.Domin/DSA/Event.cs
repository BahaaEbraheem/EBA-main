using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Event : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Event(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Event()
        {

        }
        [DisplayName("Event")]
        public string Name { get; set; }

        [PropFlag("FK")]
        [DisplayName("Event Category")]
        public int EventCategoryId { get; set; }

      
        private EventCategory _EventCategory;

        [PropFlag("FK_REF")]
        public virtual EventCategory EventCategory
        {
            get => Loader.Load(this, ref _EventCategory);
            set => _EventCategory = value;
        }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public string ImagePath { get; set; }

        public string FilePath { get; set; }

        public int Order { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<EventTranslation> EventTranslations { get; set; }

        [PropFlag("IGNORE")]
        [NotMapped]
        public RequestFileData Image { get; set; }

        [PropFlag("IGNORE")]
        [NotMapped]
        public RequestFileData File { get; set; }


    }
}
