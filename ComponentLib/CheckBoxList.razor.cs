using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    public partial class CheckBoxList<T> : ComponentBase
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string NameField { get; set; } = "Name";

        [Parameter]
        public string ValueField { get; set; } = "Id";

        [Parameter]
        public Dictionary<T, bool> Selected { get; set; } 

        public string FilterValue { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public void CheckBoxFilter(KeyboardEventArgs e)
        {
            
        }

        public void OnCheck(T item)
        {
            Selected[item] = !Selected[item];
        }

    }
}
