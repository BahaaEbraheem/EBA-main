using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.WorkFlowBase.Definition
{
    public interface IWorkFlowDefinition
    {
        string Type { get; }

        List<string> States { get; }
        
        List<string> Triggers { get; }

        List<Transtion> Transtions { get; }

    }
}
