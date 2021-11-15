using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domain;
using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Reporting
{
    public class ReportableTable : BaseEntity
    {

        public ReportableTable()
        {

        }

        private ILazyLoader LazyLoader;
        public ReportableTable(ILazyLoader lazyLoader)
        {
            this.LazyLoader = lazyLoader;
        }

        [DisplayName("Table")]
        public string Name { get; set; }

        [DisplayName("Type Name")]
        [Required(ErrorMessage = "Required field")]
        public string TypeName { get; set; }

        private ICollection<ReportTemplate> _ReportTemplates;

        [PropFlag("FK_REF")]
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ReportTemplate> ReportTemplates 
        { 
            get => LazyLoader.Load(this, ref _ReportTemplates); 
            set => _ReportTemplates = value; 
        }

    }
}
