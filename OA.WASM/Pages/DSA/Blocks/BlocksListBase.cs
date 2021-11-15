using OA.Domin;
using OA.Domin.DSA;
using OA.WASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.WASM.Pages.DSA.Blocks
{
    public class BlocksListBase : ListBase<Block>
    {
        public async Task GetIndexDataEvent(string indexName)
        {
            var indexData = new List<IndexData>();
            if (indexName == nameof(BlockCategory))
            {
                indexData = await GetIndexData<BlockCategory>();
            }

            GridFilterRef.IndexDatas = indexData;
        }
    }
}
