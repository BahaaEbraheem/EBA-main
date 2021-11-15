using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OA.Domin.DSA.Indexes
{
    public class ChampionshipRole : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public ChampionshipRole(ILazyLoader loader)
        {
            Loader = loader;
        }

        public ChampionshipRole()
        {

        }
        /// <summary>
        ///اسم دور البطولة
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name_Ar { get; set; }
        [DisplayName("Name/En")]

        public string Name_En { get; set; }

        /// <summary>
        /// معرف البطولة
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Championship")]

        public int ChampionshipId { get; set; }
        private Championship _Championship;
        [PropFlag("FK_REF")]
        public Championship Championship
        {
            get => Loader.Load(this, ref _Championship);
            set => _Championship = value;
        }

        /// <summary>
        /// من تاريخ
        /// </summary>
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }
        /// <summary>
        /// إلى تاريخ
        /// </summary>
        [DisplayName("To Date")]

        public DateTime? ToDate { get; set; }


        /// <summary>
        /// نبذة
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]
        public bool IActive { get; set; } = true;
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ChampionshipClubPlayer> ChampionshipClubPlayer { get; set; }
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Match> Match { get; set; }


    }
}
