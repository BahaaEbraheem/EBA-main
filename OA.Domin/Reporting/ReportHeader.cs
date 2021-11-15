using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domain;
using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Reporting
{
    public class ReportHeader : BaseEntity
    {

        public ReportHeader()
        {

        }

        private ILazyLoader LazyLoader;
        public ReportHeader(ILazyLoader lazyLoader)
        {
            this.LazyLoader = lazyLoader;
        }

        [Required(ErrorMessage = "Required field")]
        public string Header { get; set; }

        public int Order { get; set; }

        [PropFlag("FK")]
        public int ReportTemplateId { get; set; }

        private ReportTemplate _ReportTemplate;

        [PropFlag("FK_REF")]
        public virtual ReportTemplate ReportTemplate {
            get => LazyLoader.Load(this, ref _ReportTemplate);
            set => _ReportTemplate = value; 
        }

    }
}
