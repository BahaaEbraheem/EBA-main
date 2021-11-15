using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Menue : BaseEntity
    {
        [DisplayName("Menue")]
        public string Name { get; set; }

        [DisplayName("Level Order")]
        public int LevelOrder { get; set; }

        [DisplayName("Page URL")]
        public string PageUrl { get; set; }

        [PropFlag("FK")]
        [DisplayName("Parent Menue")]
        public int? MenueId { get; set; }

        [PropFlag("FK_REF")]
        public virtual Menue ParentMenue { get; set; }

        [PropFlag("FK")]
        [DisplayName("Category")]
        public int? MenuCategoryId { get; set; }

        [PropFlag("FK_REF")]
        public virtual MenueCategory MenuCategory { get; set; }

        public string Type { get; set; }

        public string FilePath { get; set; }

        public string ImagePath { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Menue> Menues { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<MenueTranslation> MenueTranslations { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData File { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }

    }
}
