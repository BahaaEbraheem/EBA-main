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
    public class CommissionMembersListBase : ListBase<CommissionMember>
    {

        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();

            if (indexName == "MenuCategory")
                indexData = await GetIndexData<AdministrationBoard>();
            if (indexName == nameof(Menue))
                indexData = await GetIndexData<Commission>();

            GridFilterRef.IndexDatas = indexData;
        }
 
    }
}
