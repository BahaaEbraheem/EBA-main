using OA.Services.Reporting.ExportVisitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Reporting
{
    public interface IExportVisitor
    {
        public byte[] VisitDataList<T>(ExportableDataList<T> data);

        public byte[] VisitTemplate(ExportableTemplate templateData);
    }
}
