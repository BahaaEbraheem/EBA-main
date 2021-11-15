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
    public class News : BaseEntity
    {
        [Required]
        public string Name_Ar { get; set; }
  
        public string Name_En { get; set; }
        [PropFlag("FK")]
        
        public int? NewsCategoryId { get; set; }

        [PropFlag("FK_REF")]
        public virtual NewsCategory NewsCategory { get; set; }

        [DisplayName("Added Date")]
        public DateTime? AddedDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        public string ImagePath { get; set; }
        public string Year { get; set; }

        public string FilePath { get; set; }

        public int Order { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<NewsTranslation> NewTranslations { get; set; }

        [PropFlag("IGNORE")]
        [NotMapped]
        public RequestFileData Image { get; set; }

        [PropFlag("IGNORE")]
        [NotMapped]
        public RequestFileData File { get; set; }


    }
}
