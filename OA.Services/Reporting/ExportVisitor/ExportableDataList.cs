using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Reporting
{
    public class ExportableDataList<T> : IExportableData
    {
        public Dictionary<string, List<object>> List { get; set; }

        public Dictionary<string, string> Fields { get; set; }

        public List<string> Headers { get; set; }

        public byte[] Accept(IExportVisitor visitor)
        {
            return visitor.VisitDataList(this);
        }

    }
}
