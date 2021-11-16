using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class NewCategoryTranslation : BaseEntity
    {

        private readonly ILazyLoader Loader;
        public NewCategoryTranslation(ILazyLoader loader)
        {
            Loader = loader;
        }

        public NewCategoryTranslation()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }

        [PropFlag("FK")]
        [DisplayName("New Category")]
        public int NewCategoryId { get; set; }

        private NewCategory _NewCategory;

        [PropFlag("FK_REF")]
        public virtual NewCategory NewCategory
        { 
            get => Loader.Load(this, ref _NewCategory);
            set => _NewCategory = value;
        }
        [PropFlag("FK")]
        [DisplayName("Language")]
        public int? LanguageId { get; set; }
        private Language _Language;
        [PropFlag("FK_REF")]
        public Language Language
        {
            get => Loader.Load(this, ref _Language);
            set => _Language = value;
        }
        [DisplayName("Active")]
        public bool IsActive { get; set; }

    }
}
