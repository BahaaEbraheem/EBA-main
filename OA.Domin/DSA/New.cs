using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class New : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public New(ILazyLoader loader)
        {
            Loader = loader;
        }
        public New()
        {

        }
        [DisplayName("New")]
        public string Name { get; set; }

        [PropFlag("FK")]
        [DisplayName("New Category")]
        public int? NewCategoryId { get; set; }
        private NewCategory _NewCategory;
        [PropFlag("FK_REF")]
        public NewCategory NewCategory
        {
            get => Loader.Load(this, ref _NewCategory);
            set => _NewCategory = value;
        }
  

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public string ImagePath { get; set; }
        public int Year { get; set; }

        public string FilePath { get; set; }

        public int Order { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<NewTranslation> NewTranslations { get; set; }

        [PropFlag("IGNORE")]
        [NotMapped]
        public RequestFileData Image { get; set; }

        [PropFlag("IGNORE")]
        [NotMapped]
        public RequestFileData File { get; set; }


    }
}
