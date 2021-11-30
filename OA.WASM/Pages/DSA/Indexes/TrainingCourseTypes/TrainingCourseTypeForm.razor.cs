using Microsoft.AspNetCore.Components;
using OA.Domin.DSA.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Indexes.TrainingCourseTypes
{
    public partial class TrainingCourseTypeForm : ComponentBase
    {

        [Parameter]
        public bool IsEdit { get; set; }

        [Parameter]
        public TrainingCourseType TrainingCourseType { get; set; } = new TrainingCourseType();

        public string Active { get; set; } = "";

        protected override void OnInitialized()
        {
            Active = (IsEdit) ? "active" : "";

        }

    }
}
