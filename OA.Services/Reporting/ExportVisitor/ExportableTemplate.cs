using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Reporting.ExportVisitor
{
    public class ExportableTemplate : IExportableData
    {

        public string Template { get; set; }

        public IEnumerable<string> data { get; set; }

        public byte[] Accept(IExportVisitor visitor)
        {
            return visitor.VisitTemplate(this);
        }
    }
}
