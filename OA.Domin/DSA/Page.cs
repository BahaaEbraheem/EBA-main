using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Page : BaseEntity
    {
        [DisplayName("Page")]
        public string Name { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public string ImagePath { get; set; }

        public string Type { get; set; }

        public int Order { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<PageTranslation> PageTranslations { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }

    }
}
