using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin.Attributes;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLib.Controls
{
    public class MInputSelectBase<T> : InputSelect<T>
    {

        [Inject]
        public IJSRuntime Jsrt { get; set; }

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Cls { get; set; } = "";

        [Parameter]
        public Dictionary<string, string> Items { get; set; } = new Dictionary<string, string>();

        [Parameter]
        public string Label { get; set; } = "";

        [Parameter]
        public Expression<Func<T>> For { get; set; }

        [Parameter]
        public Type EntityType { get; set; } = null;

        [Parameter]
        public string PropName { get; set; } = "";

        [Parameter]
        public EventCallback<string> ValueSelectedEvent { get; set; }


        DotNetObjectReference<MInputSelectBase<T>> ObjectReference;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            ObjectReference = DotNetObjectReference.Create(this);

            if (EntityType != null && PropName != "" && Label == "")
            {
                var propInfo = EntityType.GetProperty(PropName);
                Label = AttributeAccessor.GetDisplayNameAttr(propInfo);
            }

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var placeholder = Localizer["Select"] + " " + Localizer[Label];
            var selector = $"#{Id}";
            await Jsrt.InvokeVoidAsync("Select2", selector, placeholder);

            if (firstRender)
            {                
                //await Jsrt.InvokeVoidAsync("Select2", selector, placeholder);
                await Jsrt.InvokeVoidAsync("Select2OnChange", selector, ObjectReference, "OnChanged");
            }
        }

        [JSInvokable("OnChanged")]
        public async Task OnChanged(string value)
        {
            if (typeof(T) == typeof(string))
                CurrentValue = (T)(object)value;
            else if(typeof(T) == typeof(int?) || typeof(T) == typeof(int))
            {
                if (string.IsNullOrEmpty(value))
                    CurrentValue = (T)(object)null;
                else
                {
                    int.TryParse(value, out var intValue);
                    CurrentValue = (T)(object)intValue;
                }
            }

            if (ValueSelectedEvent.HasDelegate)
                await ValueSelectedEvent.InvokeAsync(value);

        }

        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (T)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = $"The selected value {value} is not a valid number";
                return false;
            }

            return base.TryParseValueFromString(value, out result, out validationErrorMessage);

        }
    }
}
