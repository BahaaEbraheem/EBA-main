using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ComponentLib
{
    public partial class CustomValidationMessage<T> : ComponentBase, IDisposable
    {

        [Inject]
        public IStringLocalizer<CommonResources> Localizer { get; set; }

        private FieldIdentifier _FieldIdentifier;

        [CascadingParameter]
        private EditContext EditContext { get; set; }

        [Parameter]
        public Expression<Func<T>> For { get; set; }

        [Parameter]
        public string ClassList { get; set; } = "";

        protected IEnumerable<string> ValidationMessages => EditContext.GetValidationMessages(_FieldIdentifier);

        private void HandleValidationStateChanged(object o, ValidationStateChangedEventArgs args) => StateHasChanged();

        protected override void OnInitialized()
        {
            _FieldIdentifier = FieldIdentifier.Create(For);
            EditContext.OnValidationStateChanged += HandleValidationStateChanged;
        }

        public void Dispose()
        {
            EditContext.OnValidationStateChanged -= HandleValidationStateChanged;
        }
    }
}
