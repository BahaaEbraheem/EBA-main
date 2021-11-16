using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class NewTranslation : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public NewTranslation(ILazyLoader loader)
        {
            Loader = loader;
        }
        public NewTranslation()
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

        [PropFlag("FK")]
        [DisplayName("New")]
        public int? NewId { get; set; }
        private New _New;
        [PropFlag("FK_REF")]
        public New New
        {
            get => Loader.Load(this, ref _New);
            set => _New = value;
        }
    }
}
