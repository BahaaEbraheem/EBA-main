using OA.Domin.WorkFlowBase.Definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.WorkFlowBase.Execution
{
    public class TriggerParam
    {

        public string TriggerName { get; set; }

        public IWorkFlow Instance { get; set; }

        public Dictionary<string, IWorkFlowVariable> Variables {get; set;}

        public TriggerParam(string triggerName, IWorkFlow instance)
        {
            TriggerName = triggerName;
            Instance = instance;
            Variables = new Dictionary<string, IWorkFlowVariable>();
        }

    }
}
