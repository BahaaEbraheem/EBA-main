using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OA.Domin.Reporting.TemplateReporting
{
    [NotMapped]
    public class TemplateExportRequest
    {

        public string Title { get; set; }

        public string Body { get; set; }

        public IEnumerable<string> Data { get; set; }

        public string WaterMarkImagePath { get; set; }

        public string ExportAs { get; set; } = "Pdf";

    }
}
