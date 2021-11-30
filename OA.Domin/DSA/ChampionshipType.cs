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
    public class ChampionshipType : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public ChampionshipType(ILazyLoader loader)
        {
            Loader = loader;
        }

        public ChampionshipType()
        {

        }
        /// <summary>
        ///اسم نوع البطولة
        /// </summary>
        [DisplayName("Name/Ar")]
        public string Name { get; set; }
        [DisplayName("Name/En")]

        public string Name_En { get; set; }

        /// <summary>
        /// معرف البطولة
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Game Type")]
        public int GameTypeId { get; set; }
        private GameType _GameType;
        [PropFlag("FK_REF")]
        public GameType GameType
        {
            get => Loader.Load(this, ref _GameType);
            set => _GameType = value;
        }



        /// <summary>
        /// نبذة
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<Championship> Championship { get; set; }



    }
}
