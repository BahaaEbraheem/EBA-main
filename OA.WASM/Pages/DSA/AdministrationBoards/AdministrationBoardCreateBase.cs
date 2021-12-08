using Microsoft.AspNetCore.Components;
using OA.Domin;
using OA.Domin.DSA;
using OA.Domin.DSA.Indexes;
using OA.Domin.DSA.ViewModels;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.AdministrationBoards
{
    public class AdministrationBoardCreateBase : CreateBase<AdministrationBoard>
    {

        public Dictionary<string, string> PtypeItems { get; set; } = new Dictionary<string, string>();
       
        public Dictionary<string, string> PersonNationalityItems { get; set; } = new Dictionary<string, string>();
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            PtypeItems = await GetIndexData<PType>();

            PersonNationalityItems = await GetIndexData<Nationality>();

        }


    }
}
