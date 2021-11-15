using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.Reporting.TemplateReporting
{
    public class ReportTextTemplate : BaseEntity
    {

        public string Name { get; set; }


        public string Content { get; set; }

    }
}
