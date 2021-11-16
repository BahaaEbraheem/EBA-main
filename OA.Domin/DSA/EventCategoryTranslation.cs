using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class EventCategoryTranslation : BaseEntity
    {

        private readonly ILazyLoader Loader;
        public EventCategoryTranslation(ILazyLoader loader)
        {
            Loader = loader;
        }

        public EventCategoryTranslation()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }

        [PropFlag("FK")]
        [DisplayName("Event Category")]
        public int EventCategoryId { get; set; }

        private EventCategory _EventCategory;

        [PropFlag("FK_REF")]
        public virtual EventCategory EventCategory 
        { 
            get => Loader.Load(this, ref _EventCategory);
            set => _EventCategory = value;
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
