using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using OA.Domin.Attributes;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ComponentLib.Controls
{
    public class MInputTextBase : InputBase<string>
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Label { get; set; } = "";

        [Parameter]
        public Expression<Func<string>> For { get; set; }

        [Parameter]
        public string Active { get; set; } = "";

        [Parameter]
        public string Type { get; set; } = "text";

        [Parameter]
        public bool MultiLine { get; set; } = false;

        [Parameter]
        public Type EntityType { get; set; } = null;

        [Parameter]
        public string PropName { get; set; } = "";

        protected override void OnInitialized()
        {
            if(EntityType != null && PropName != "" && Label == "")
            {
                var propInfo = EntityType.GetProperty(PropName);
                Label = AttributeAccessor.GetDisplayNameAttr(propInfo);
            }
        }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }

    }
}
