using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    public partial class CheckMark : ComponentBase
    {

        [Parameter]
        public bool Checked { get; set; }

    }
}
