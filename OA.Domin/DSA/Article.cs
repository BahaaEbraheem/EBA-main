using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Article : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Article(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Article()
        {

        }

        public string Name { get; set; }

        public int Order { get; set; }

        public DateTime Date { get; set; }

        public string FilePath { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }

        public string Content { get; set; }

        [PropFlag("FK")]
        public int ArticleCategoryId { get; set; }

        private ArticleCategory _ArticleCategory;

        [PropFlag("FK_REF")]
        public ArticleCategory ArticleCategory 
        { 
            get => Loader.Load(this, ref _ArticleCategory);
            set => _ArticleCategory = value; 
        }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ArticleTranslation> ArticleTranslations { get; set; }


        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData File { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData Image { get; set; }

    }
}
