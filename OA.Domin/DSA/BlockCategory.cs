using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class BlockCategory : BaseEntity
    {
        [DisplayName("Category")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Block> Blocks { get; set; }

    }
}
