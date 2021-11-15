using Microsoft.AspNetCore.Components;
using OA.Domin.ComponentFeatures;
using OA.Domin.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    public partial class Grid<T> : ComponentBase
    {

        [CascadingParameter]
        public Theme Theme { get; set; }

        [Parameter]
        public RenderFragment GridHeader { get; set; }

        [Parameter]
        public RenderFragment<T> GridRow { get; set; }

        [Parameter]
        public int PageNumber { get; set; }

        [Parameter]
        public IEnumerable<T> Items { get; set; }

    }
}
