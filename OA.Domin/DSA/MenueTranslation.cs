using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class MenueTranslation : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public MenueTranslation(ILazyLoader loader)
        {
            Loader = loader;
        }

        public MenueTranslation()
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
        [DisplayName("Menue")]
        public int MenueId { get; set; }

        private Menue _Menue;
        [PropFlag("FK_REF")]
        public Menue Menue
        {
            get => Loader.Load(this, ref _Menue);
            set => _Menue = value;
        }
    }
}
