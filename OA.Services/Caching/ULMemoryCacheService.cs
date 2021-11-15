using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.Caching
{
    public class ULMemoryCacheService
    {
        public MemoryCache Cache { get; set; }
        public ULMemoryCacheService()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {

            });
        }

    }
}
