using ComponentLib;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.Domin.DSA.ViewModels;
using OA.Domin.RequestFeatures;
using OA.Domin.Resources;
using OA.WASM.Services;
using OA.WASM.Services.Administration;
//using OA.WASM.Services.Administrator_Board;
using OA.WASM.Services.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Commissions
{
    public class CommissionCreateBase : CreateBase<Commission>
    {
        public Commission Commission { get; set; } = new Commission();

    }
}
