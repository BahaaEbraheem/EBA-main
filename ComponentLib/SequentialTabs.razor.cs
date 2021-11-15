using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OA.Domin.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib
{
    public partial class SequentialTabs<TItem> : ComponentBase
    {

        [Inject]
        public IJSRuntime JSRT { get; set; }

        [Parameter]
        public string PanelNavId { get; set; } = "panelNav";

        [Parameter]
        public string PanelNavClassList { get; set; } = "";

        [Parameter]
        public string PanelClassList { get; set; } = "";

        [Parameter]
        public string PanelWrapperClassList { get; set; } = "";

        [Parameter]
        public string DataEnter { get; set; } = Animations.ScaleUp.GetEnumDiscription();

        [Parameter]
        public string DataExit { get; set; } = Animations.ScaleDown.GetEnumDiscription();

        [Parameter]
        public string DataSequential { get; set; } = "no";

        [Parameter]
        public Dictionary<string, TItem> TabsData { get; set; }

        [Parameter]
        public RenderFragment<TItem> TabTemplate { get; set; }

        [Parameter]
        public bool DynamicContect { get; set; }
        

        public enum Animations
        {
            [Description("slideleft fade")]
            SlideLeft,

            [Description("slideright fade")]
            SlideRight,

            [Description("scaleup fade")]
            ScaleUp,

            [Description("scaledown fade")]
            ScaleDown,

            [Description("slideup fade")]
            SlideUp,

            [Description("slidedown fade")]
            SlideDown

        };


        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (DynamicContect)
            {
                await JSRT.InvokeVoidAsync("InitTabs", PanelNavId);
            }
            else
            {
                if (firstRender)
                {
                    await JSRT.InvokeVoidAsync("InitTabs", PanelNavId);
                }
            }            
            
        }

        public async Task OnTabClick(string tabId)
        {
            await JSRT.InvokeVoidAsync("OnTabClick", tabId);
        }

    }
}
