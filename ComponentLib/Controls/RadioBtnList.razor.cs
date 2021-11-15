using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib.Controls
{
    public partial class RadioBtnList : ComponentBase
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string ClassList { get; set; } = "";

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attrs { get; set; }

        [Parameter]
        public EventCallback<Dictionary<string, bool>> OnChange { get; set; }

        [Parameter]
        public Dictionary<string, bool> Buttons { get; set; } = new Dictionary<string, bool>();

        [Parameter]
        public Dictionary<string, string> Names { get; set; } = new Dictionary<string, string>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public async Task Changed(string key)
        {
            var value = !Buttons[key];

            var tempBtns = new Dictionary<string, bool>();
            foreach (var btn in Buttons)
                tempBtns.Add(btn.Key, btn.Value);

            foreach (var btn in tempBtns)
                Buttons[btn.Key] = (btn.Key != key) ? !value : value;

            await OnChange.InvokeAsync(Buttons);

        }

    }
}
