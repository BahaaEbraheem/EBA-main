using OA.Domin.WorkFlowBase.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Domin.WorkFlowBase.Execution
{
    public class WorkFlowExecution
    {
        private readonly IWorkFlowDefinition WorkFlowDefinition;
        public WorkFlowExecution(IWorkFlowDefinition workFlowDefinition)
        {
            WorkFlowDefinition = workFlowDefinition;
        }

        public bool Trigger(TriggerParam triggerParam)
        {
            
            var currState = triggerParam.Instance.State;
            var currTrigger = triggerParam.TriggerName;
            var transition = WorkFlowDefinition.Transtions.SingleOrDefault(t => t.InitState == currState && t.Trigger == currTrigger ||
                                                                                (t.InitStates != null && t.InitStates.Contains(currState) && t.Trigger == currTrigger));
            _ = transition ?? throw new Exception($"Work Flow Transition Not Found (Init State : ${triggerParam.Instance.State}, Trigger : ${triggerParam.TriggerName})");

            var transitionContext = new TransitionContext(triggerParam.Instance, transition, triggerParam.Variables);

            var canMakeTransition = transition.CanMakeTranstion?.Invoke(transitionContext);
            if (canMakeTransition == false)
                return false;

            transition.BeforeTransition?.DynamicInvoke(transitionContext);

            var state = WorkFlowDefinition.States.SingleOrDefault(s => s == transitionContext.Transtion.TargetState);
            triggerParam.Instance.State = state;

            transition.AfterTransition?.DynamicInvoke(transitionContext);

            return true;

        }

        

    }
}
