using Microsoft.AspNetCore.Components;
using OA.Domin.ComponentFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib.Controls
{
    public partial class Btn : ComponentBase
    {
        [Parameter]
        public string Text { get; set; } = "Submit";

        [Parameter]
        public string ClassList { get; set; } = "";

        [Parameter]
        public EventCallback ClickCallBack { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attrs { get; set; }

        public async Task BtnClick()
        {
            if(ClickCallBack.HasDelegate)
                await ClickCallBack.InvokeAsync(this);
        }
    }
}
