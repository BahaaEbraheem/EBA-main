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
    public class NewCategory : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public NewCategory(ILazyLoader loader)
        {
            Loader = loader;
        }

        public NewCategory()
        {

        }
        public string Name { get; set; }
        public string Descreption { get; set; }
        public string ImagePath { get; set; }
        public int Order { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<New> News { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<NewCategoryTranslation> NewCategoryTranslations { get; set; }

        [PropFlag("IGNORE")]
        [NotMapped]
        public RequestFileData Image { get; set; }


    }
}
