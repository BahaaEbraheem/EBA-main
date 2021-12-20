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

namespace OA.WASM.Pages.DSA.CommissionMembers
{
    public class CommissionMemberCreateBase : CreateBase<CommissionMember>
    {

        public Commission Commission { get; set; } = new Commission();

        public AdministrationBoard AdministrationBoard { get; set; } = new AdministrationBoard();
        public Dictionary<string, string> CommissionsItems { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> administrationboardsItems { get; set; } = new Dictionary<string, string>();

        //public Dictionary<string, string> PersonNationalityItems { get; set; } = new Dictionary<string, string>();
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            //PtypeItems = await GetIndexData<PType>();

            administrationboardsItems = await GetIndexData<AdministrationBoard>();
            CommissionsItems = await GetIndexData<Commission>();


        }
    }
}
