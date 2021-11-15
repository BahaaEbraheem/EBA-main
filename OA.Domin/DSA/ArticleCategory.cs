using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.DSA
{
    public class ArticleCategory : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public bool IsActive { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
