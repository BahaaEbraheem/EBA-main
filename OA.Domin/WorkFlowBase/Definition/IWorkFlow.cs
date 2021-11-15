using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.WorkFlowBase.Definition
{
    public interface IWorkFlow
    {

        string State { get; set; }

        string NextUserId { get; set; }

    }
}
