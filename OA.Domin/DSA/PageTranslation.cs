using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class PageTranslation : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public PageTranslation(ILazyLoader loader)
        {
            Loader = loader;
        }

        public PageTranslation()
        {

        }

        [DisplayName("Translation")]
        public string Name { get; set; }

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

        [DisplayName("Content")]
        public string HTMLContent { get; set; }

        [DisplayName("Link 1")]
        public string Link1 { get; set; }

        [DisplayName("Link 2")]
        public string Link2 { get; set; }

        public string FilePath { get; set; }

        [DisplayName("Page")]
        [PropFlag("FK")]
        public int PageId { get; set; }

        private Page _Page;

        [PropFlag("FK_REF")]
        public virtual Page Page { 
            get => Loader.Load(this, ref _Page);
            set => _Page = value;
        }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData File { get; set; }

    }
}
