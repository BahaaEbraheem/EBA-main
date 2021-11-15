using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    public partial class MarkDown : ComponentBase
    {

        [Parameter]
        public string MarkUpStr { get; set; } = "";

        public string MarkDownStr { get; set; }

        protected override void OnParametersSet()
        {
            var markupString = new MarkupString(MarkUpStr);
            MarkDownStr = markupString.Value;
        }

    }
}
