using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domin.Attributes;
using OA.Domin.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.DSA
{
    public class CommissionMember : BaseEntity
    {
        private readonly ILazyLoader Loader;
        public CommissionMember(ILazyLoader loader)
        {
            Loader = loader;
        }
        public CommissionMember()
        {
            //AdministrationBoard = new AdministrationBoard();
            //Commission = new Commission();
            //Decision = new Decision();
        }
        [PropFlag("FK")]
        [DisplayName("Administration Board")]

        public int? AdministrationBoardId { get; set; }

        private AdministrationBoard _AdministrationBoard;

        [PropFlag("FK_REF")]
        public AdministrationBoard AdministrationBoard
        {
            get => Loader.Load(this, ref _AdministrationBoard);
            set => _AdministrationBoard = value;
        }

        [PropFlag("FK")]
        [DisplayName("Commission")]
        public int? CommissionId { get; set; }

        private Commission _Commission;

        [PropFlag("FK_REF")]
        public Commission Commission
        {
            get => Loader.Load(this, ref _Commission);
            set => _Commission = value;
        }

        [PropFlag("FK")]
        [DisplayName("Decision")]
        public int? DecisionId { get; set; }

        private Decision _Decision;

        [PropFlag("FK_REF")]
        public Decision Decision
        {
            get => Loader.Load(this, ref _Decision);
            set => _Decision = value;
        }
        /// <summary>
        /// تاريخ البداية
        /// </summary>
        [DisplayName("Start Date")]

        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاريخ النهاية
        /// </summary>
        [DisplayName("End Date")]

        public DateTime EndDate { get; set; }
        /// <summary>
        /// وصف 
        /// </summary>
        public string Description { get; set; }
        [DisplayName("Active")]
        public bool IsActive { get; set; } = true;


    }
}
