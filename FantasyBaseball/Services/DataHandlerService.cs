using System;
using System.Collections.Generic;
using FantasyBaseball.DataHandling;
using FantasyBaseball.Models;
using Microsoft.Extensions.Caching.Memory;

namespace FantasyBaseball.Services
{
    public class DataHandler : IDataHandler
    {
        private Player Player;
        private IMemoryCache _cache;

        public DataHandler(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void InitializeData(string path)
        {
            Console.WriteLine("Gathering Data...");
            List<Player> cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(CacheKeys.Players, out cacheEntry))
            {
                // Key not in cache, so get data.
                 cacheEntry = BaseballStatsDataHandler.GatherPlayersData(path);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3600));

                // Save data in cache.
                _cache.Set(CacheKeys.Players, cacheEntry, cacheEntryOptions);
            }

            // Build and store the results of the data query
            Console.WriteLine("Data Processed!");

        }

        public string TestGetData()
        {
            // TODO go get real data
            List<Player> result;
            bool success = _cache.TryGetValue(CacheKeys.Players, out result);

            if (result.Count > 0 && success)
            {
                return result[0].ToString();

            }
            return new string("No Data");
        }
    }
}
