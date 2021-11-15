using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class Attachment : BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Extention { get; set; }

        public string Path { get; set; }

        public string URL { get; set; }

        public string Type { get; set; }

        public int Order { get; set; }

        public int ReferenceId { get; set; }

        public string Reference { get; set; }

        [NotMapped]
        [PropFlag("IGNORE")]
        public virtual RequestFileData File { get; set; }

    }
}
