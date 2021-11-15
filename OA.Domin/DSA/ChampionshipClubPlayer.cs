using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.DSA.Indexes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class ChampionshipClubPlayer : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public ChampionshipClubPlayer(ILazyLoader loader)
        {
            Loader = loader;
        }

        public ChampionshipClubPlayer()
        {

        }
        /// <summary>
        /// معرف اللاعب
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Player")]

        public int PlayerId { get; set; }
        private Player _Player;
        [PropFlag("FK_REF")]
        public Player Player
        {
            get => Loader.Load(this, ref _Player);
            set => _Player = value;
        }
        /// <summary>
        /// معرف دور البطولة
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Championship Role")]

        public int ChampionshipRoleId { get; set; }
        private ChampionshipRole _ChampionshipRole;
        [PropFlag("FK_REF")]
        public ChampionshipRole ChampionshipRole
        {
            get => Loader.Load(this, ref _ChampionshipRole);
            set => _ChampionshipRole = value;
        }
        /// <summary>
        /// معرف المجموعة
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Group")]

        public int GroupId { get; set; }
        private Group _Group;
        [PropFlag("FK_REF")]
        public Group Group
        {
            get => Loader.Load(this, ref _Group);
            set => _Group = value;
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


        public bool IsActive { get; set; } = true;


    }
}
