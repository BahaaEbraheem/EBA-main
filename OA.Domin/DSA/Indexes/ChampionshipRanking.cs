using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OA.Domin.DSA.Indexes
{
    public class ChampionshipRanking : BaseEntity
    {


        /// <summary>
        /// اسم تصنيف البطولات
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }
        public string Description { get; set; }
 
        
            


    }
}
