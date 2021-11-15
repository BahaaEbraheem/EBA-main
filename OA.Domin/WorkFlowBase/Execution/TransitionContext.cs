using OA.Domin.WorkFlowBase.Definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.WorkFlowBase.Execution
{
    public class TransitionContext
    {
        public IWorkFlow Instance { get; set; }

        public Transtion Transtion { get; set; }


        public Dictionary<string, IWorkFlowVariable> Variabels;

        public TransitionContext(IWorkFlow instance, Transtion transtion, Dictionary<string, IWorkFlowVariable> variables)
        {
            Instance = instance;
            Transtion = transtion;
            Variabels = variables;
        }

        public T GetVariable<T>(string key) where T : IWorkFlowVariable
        {
            return Variabels.ContainsKey(key) ? (T)Variabels[key] : default(T);
        }

    }
}
