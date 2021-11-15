using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Settings
{
    public class AppSetting
    {
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }

    }    
}
