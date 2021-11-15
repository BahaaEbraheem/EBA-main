using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA
{
    public class MenueCategory : BaseEntity
    {
        [DisplayName("Category")]
        public string Name { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Menue> Menues { get; set; }

    }
}
