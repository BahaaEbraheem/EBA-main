using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using static OA.Domin.StaticIndexes;

namespace OA.Domin.DSA.Indexes
{
    public class Match : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public Match(ILazyLoader loader)
        {
            Loader = loader;
        }

        public Match()
        {

        }
        /// <summary>
        /// معرف دور البطولة
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Championship Role")]

        public int? ChampionshipRoleId { get; set; }
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

        public int? GroupId { get; set; }
        private Group _Group;
        [PropFlag("FK_REF")]
        public Group Group
        {
            get => Loader.Load(this, ref _Group);
            set => _Group = value;
        }
        /// <summary>
        /// معرف النادي
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("First Team")]

        public int? FirstTeamId { get; set; }
        private Club _FirstTeam;
        [PropFlag("FK_REF")]
        [InverseProperty("FirstTeamMatch")]
        public virtual Club FirstTeam
        {
            get => Loader.Load(this, ref _FirstTeam);
            set => _FirstTeam = value;
        }
        /// <summary>
        ///  معرف الصالة الرياضية
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Stadium")]

        public int? StadiumId { get; set; }
        private Stadium _Stadium;
        [PropFlag("FK_REF")]
        public Stadium Stadium
        {
            get => Loader.Load(this, ref _Stadium);
            set => _Stadium = value;
        }
        /// <summary>
        /// معرف النادي
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Second Team")]

        public int? SecondTeamId { get; set; }
        private Club _SecondTeam;
        [PropFlag("FK_REF")]
        [InverseProperty("SecondTeamMatch")]

        public virtual Club SecondTeam
        {
            get => Loader.Load(this, ref _SecondTeam);
            set => _SecondTeam = value;
        }
        /// <summary>
        /// معرف الشخص-الحكم
        /// </summary>
        [PropFlag("FK")]

        [DisplayName("First Arbitrator")]
        public int? FirstArbitratorId { get; set; }
        private Person _FirstArbitrator;
        [PropFlag("FK_REF")]
        [InverseProperty("FirstArbitratorMatch")]

        public Person FirstArbitrator
        {
            get => Loader.Load(this, ref _FirstArbitrator);
            set => _FirstArbitrator = value;
        }
        /// <summary>
        /// معرف الشخص-الحكم
        /// </summary>
        [PropFlag("FK")]
        [DisplayName("Second Arbitrator")]
        public int? SecondArbitratorId { get; set; }
        private Person _SecondArbitrator;
        [PropFlag("FK_REF")]
        [InverseProperty("SecondArbitratorMatch")]

        public Person SecondArbitrator
        {
            get => Loader.Load(this, ref _SecondArbitrator);
            set => _SecondArbitrator = value;
        }
        /// <summary>
        ///نتيجة الفريق الأول
        /// </summary>
        [DisplayName("FirstTeam Result")]

        public int? FirstTeamResult { get; set; }
        /// <summary>
        ///نتيجة الفريق الثاني 
        /// </summary>
        [DisplayName("SecondTeam Result")]

        public int? SecondTeamResult { get; set; }
        /// <summary>
        ///الفائز بالمباراة
        /// </summary>
        [DisplayName("Match Result")]
        public Result Result { get; set; }
        /// <summary>
        ///تاريخ المباراة
        /// </summary>
        [DisplayName("Match Date")]

        public DateTime? MatchDate { get; set; }
        /// <summary>
        ///من الوقت
        /// </summary>
        [DisplayName("From Time")]

        public TimeSpan? FromTime { get; set; }
        /// <summary>
        ///إلى الوقت
        /// </summary>
        [DisplayName("To Time")]

        public TimeSpan? ToTime { get; set; }

        /// <summary>
        /// نبذة
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]

        public bool IsActive { get; set; } = true;




    }
}
