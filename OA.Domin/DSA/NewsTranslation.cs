using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class NewsTranslation : BaseEntity
    {
        [DisplayName("Translation")]
        public string Name { get; set; }

        [PropFlag("FK")]
        [DisplayName("Language")]
        public int? LanguageId { get; set; }

        [PropFlag("FK_REF")]
        public virtual Language Language { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Content")]
        public string HTMLContent { get; set; }

        [PropFlag("FK")]
        [DisplayName("New")]
        public int NewsId { get; set; }

        [PropFlag("FK_REF")]
        public virtual News News { get; set; }

    }
}
