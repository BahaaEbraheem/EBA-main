using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace OA.Domin.DSA.Indexes
{
    public class GameType : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public GameType(ILazyLoader loader)
        {
            Loader = loader;
        }

        public GameType()
        {

        }
        /// <summary>
        ///اسم نوع اللعبة
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]
        public string Name_En { get; set; }

        /// <summary>
        /// نبذة
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]

        public bool IsActive { get; set; } = true;
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ChampionshipType> ChampionshipType { get; set; }



    }
}
