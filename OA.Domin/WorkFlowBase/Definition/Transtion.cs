using OA.Domin.WorkFlowBase.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.WorkFlowBase.Definition
{
    public class Transtion
    {
        public string InitState { get; set; }

        public List<string> InitStates { get; set; }

        public string Trigger { get; set; }

        public string TargetState { get; set; }

        public Func<TransitionContext, bool> CanMakeTranstion { get; set; }

        public Action<TransitionContext> BeforeTransition { get; set; }

        public Action<TransitionContext> AfterTransition { get; set; }

    }
}
