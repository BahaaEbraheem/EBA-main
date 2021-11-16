using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class EventTranslation : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public EventTranslation(ILazyLoader loader)
        {
            Loader = loader;
        }

        public EventTranslation()
        {

        }
        public string Name { get; set; }

        public string Description { get; set; }

        [PropFlag("FK")]
        [DisplayName("Event")]
        public int EventId { get; set; }


        private Event _Event;

        [PropFlag("FK_REF")]
        public  Event Event
        {
            get => Loader.Load(this, ref _Event);
            set => _Event = value;
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
