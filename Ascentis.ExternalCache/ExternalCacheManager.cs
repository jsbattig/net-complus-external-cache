﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.InteropServices;

namespace Ascentis.Infrastructure
{
    [Guid("1f12e287-8b0d-446b-80dd-7c02fe4d339e")]
    public class ExternalCacheManager : System.EnterpriseServices.ServicedComponent, IExternalCacheManager
    {
        public void ClearAllCaches()
        {
            MemoryCache.Default.Trim(100);
            var localCaches = ExternalCache.Caches.Select(item => item.Value).ToList();
            ExternalCache.Caches.Clear();
            foreach (var cache in localCaches)
            {
                cache.Trim(100);
                cache.Dispose();
            }
        }
    }
}