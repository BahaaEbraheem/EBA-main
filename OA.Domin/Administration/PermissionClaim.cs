using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Administration
{
    public class PermissionClaim
    {
        [Key]
        public string Value { get; set; }
        
        public string Type { get; set; }      

        public string Name { get; set; }
    }
}
