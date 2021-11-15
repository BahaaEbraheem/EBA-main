using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    public partial class VerticalTabs : ComponentBase
    {

        [Parameter]
        public RenderFragment TabList { get; set; }
        
        [Parameter]
        public RenderFragment TabContent { get; set; }

        [Parameter]
        public int ListSize { get; set; } = 5;

        public int ConSize { get; set; }

        protected override void OnParametersSet()
        {
            ConSize = 12 - ListSize;
        }

    }
}
