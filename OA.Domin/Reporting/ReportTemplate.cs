using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Domain;
using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Domin.Reporting
{
    public class ReportTemplate : BaseEntity
    {
        public ReportTemplate()
        {

        }

        private ILazyLoader LazyLoader;
        public ReportTemplate(ILazyLoader lazyLoader)
        {
            this.LazyLoader = lazyLoader;
        }

        [Required(ErrorMessage = "Required field")]
        public string Title { get; set; }

        //Format ["Field1:Feild1 Display Name,Feild2:Feild1 Display Name ... "]
        public string FieldsOrder { get; set; }

        public bool Status { get; set; }

        [PropFlag("FK")]
        public int ReportableTableId { get; set; }

        [PropFlag("FK_REF")]
        public virtual ReportableTable ReportableTable { get; set; }

        private ICollection<ReportHeader> _ReportHeaders;

        [PropFlag("FK_REF")]
        [PropFlag("FK_REF_COLL")]
        public virtual ICollection<ReportHeader> ReportHeaders 
        { 
            get => LazyLoader.Load(this, ref _ReportHeaders); 
            set => _ReportHeaders = value; 
        }

    }
}
