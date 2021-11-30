using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA.Indexes
{
    public class Adjective : BaseEntity
    {


        /// <summary>
        /// اسم الصفة
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        /// <summary>
        /// الوصف
        /// </summary>
        public string Description { get; set; }

        
            


    }
}
