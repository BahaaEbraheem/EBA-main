using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using OA.Domin.Attributes;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib.Controls
{
    public class MInputRangeBase : InputBase<int>
    {
        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Label { get; set; } = "";

        [Parameter]
        public int Min { get; set; } = 0;

        [Parameter]
        public int Max { get; set; } = 10;


        [Parameter]
        public Type EntityType { get; set; } = null;

        [Parameter]
        public string PropName { get; set; } = "";

        protected override void OnInitialized()
        {
            if (EntityType != null && PropName != "" && Label == "")
            {
                var propInfo = EntityType.GetProperty(PropName);
                Label = AttributeAccessor.GetDisplayNameAttr(propInfo);
            }
        }


        protected override bool TryParseValueFromString(string value, out int result, out string validationErrorMessage)
        {
            int.TryParse(value, out var intValue);

            result = intValue;
            validationErrorMessage = null;
            return true;
        }
    }
}
