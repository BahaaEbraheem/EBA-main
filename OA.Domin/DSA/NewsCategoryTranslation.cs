using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class NewsCategoryTranslation : BaseEntity
    {

        private readonly ILazyLoader Loader;
        public NewsCategoryTranslation(ILazyLoader loader)
        {
            Loader = loader;
        }

        public NewsCategoryTranslation()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }

        [PropFlag("FK")]
        [DisplayName("New Category")]
        public int NewsCategoryId { get; set; }

        private NewsCategory _NewsCategory;

        [PropFlag("FK_REF")]
        public virtual NewsCategory NewsCategory
        { 
            get => Loader.Load(this, ref _NewsCategory);
            set => _NewsCategory = value;
        }
        [PropFlag("FK")]
        [DisplayName("Language")]
        public int? LanguageId { get; set; }

        [PropFlag("FK_REF")]
        public virtual Language Language { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

    }
}
