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

    public class Menue : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Menue(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Menue()
        {

        }
        [DisplayName("Menue")]
        public string Name { get; set; }

        [DisplayName("Level Order")]
        public int LevelOrder { get; set; }

        [DisplayName("Page URL")]
        public string PageUrl { get; set; }

        [PropFlag("FK")]
        [DisplayName("Parent Menue")]
        public int? ParentMenueId { get; set; }

        //[PropFlag("FK_REF")]
        //public virtual Menue ParentMenue { get; set; }
        private Menue _ParentMenue;

        [PropFlag("FK_REF")]
        [InverseProperty("Menues")]
        public  Menue ParentMenue
        {
            get => Loader.Load(this, ref _ParentMenue);
            set => _ParentMenue = value;
        }
        [PropFlag("FK")]
        [DisplayName("Menue Category")]
        public int? MenuCategoryId { get; set; }

        private MenueCategory _MenueCategory;

        [PropFlag("FK_REF")]
        public MenueCategory MenueCategory
        {
            get => Loader.Load(this, ref _MenueCategory);
            set => _MenueCategory = value;
        }
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
