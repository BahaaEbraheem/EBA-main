using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Reporting
{
    public interface IExportableData
    {

        byte[] Accept(IExportVisitor visitor);

    }
}
