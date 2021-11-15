using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.WorkFlowBase.Execution
{
    public class TriggerResult
    {

        private readonly TransitionContext TransitionContext;

        public bool IsAborted { get; set; }

        public string CurrentState 
        {
            get => TransitionContext.Instance.State;
        }

        public string TriggerName { get; set; }

        public TriggerResult(TransitionContext transitionContext)
        {
            TransitionContext = transitionContext;
        }


    }
}
