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
    public class Block : BaseEntity
    {

        public Block()
        {

        }

        private readonly ILazyLoader LazyLoader;
        public Block(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        [DisplayName("Block")]
        public string Name { get; set; }

        public string Description { get; set; }

        [PropFlag("FK")]
        [DisplayName("Category")]
        public int BlockCategoryId { get; set; }

        private BlockCategory _BlockCategory;

        [PropFlag("FK_REF")]
        public virtual BlockCategory BlockCategory 
        { 
            get => LazyLoader.Load(this, ref _BlockCategory);
            set => _BlockCategory = value; 
        }

        [DisplayName("URL")]
        public string BlockURL { get; set; }

        public string ImagePath { get; set; }

        public string FilePath { get; set; }

        public int Order { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [DisplayName("Visible")]
        public bool IsVisible { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<BlockTranslation> BlockTranslations { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData File { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }

    }
}
