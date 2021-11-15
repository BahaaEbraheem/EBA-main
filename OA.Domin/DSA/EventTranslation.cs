using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class EventTranslation : BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        [PropFlag("FK")]
        [DisplayName("Event")]
        public int EventId { get; set; }

        [PropFlag("FK_REF")]
        public virtual Event Event { get; set; }
        [PropFlag("FK")]
        [DisplayName("Language")]
        public int? LanguageId { get; set; }

        [PropFlag("FK_REF")]
        public virtual Language Language { get; set; }


        [DisplayName("Active")]
        public bool IsActive { get; set; }

    }
}
